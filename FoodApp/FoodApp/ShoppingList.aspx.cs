﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp
{
    public partial class ShoppingList : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userID;

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            userID = Convert.ToInt32(Session["userid"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int portion = 0;
            if (Session["portion"].ToString() != "" && Session["portion"].ToString() != null)
            {
                portion = Convert.ToInt32(Session["portion"].ToString());
            }
            lbRecipe.Items.Clear();
            lbRecipePortion.Items.Clear();
            lbFoodItemID.Items.Clear();
            if (lbRecipe.Items.Count == 0)
            {
                ArrayList chosenRecipe = (ArrayList)Session["chosenRecipe"];
                for (int i = 0; i < chosenRecipe.Count; i++)
                {
                    lbRecipe.Items.Add(((ListItem)chosenRecipe[i]));
                }
                //get portion
                if (lbRecipePortion.Items.Count == 0)
                {
                    for (int l = 0; l < lbRecipe.Items.Count; l++)
                    {
                        string recipeid = lbRecipe.Items[l].Value;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            int basePortion = Convert.ToInt32(reader["Portion"].ToString());
                            double resultPortion = Convert.ToDouble(portion) / Convert.ToDouble(basePortion);
                            lbRecipePortion.Items.Add(resultPortion.ToString("F2"));
                            lbRecipePortion.Items[lbRecipePortion.Items.Count - 1].Value = reader["RecipeID"].ToString();
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
                    //get food item
                    if (lbFoodItemID.Items.Count == 0)
                    {
                        for (int j = 0; j < lbRecipePortion.Items.Count; j++)
                        {
                            string recipeid = lbRecipePortion.Items[j].Value;
                            OleDbCommand command = new OleDbCommand("SELECT * FROM RecipeFoodItem WHERE RecipeID = " + recipeid.ToString(), myConnection);
                            command.CommandType = CommandType.Text;
                            OleDbDataReader reader = command.ExecuteReader();
                            bool notEoF = reader.Read();
                            while (notEoF)
                            {
                                if (lbFoodItemID.Items.Count != 0)
                                {
                                    bool checkExistingFoodItem = false;
                                    for (int m = 0; m < lbFoodItemID.Items.Count; m++)
                                    {
                                        if (reader["FoodItemID"].ToString() == lbFoodItemID.Items[m].Text)
                                        {
                                            checkExistingFoodItem = true;
                                            lbFoodItemID.Items[m].Value = (Convert.ToDouble(lbFoodItemID.Items[m].Value) + Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                        }
                                    }
                                    if (checkExistingFoodItem == false)
                                    {
                                        lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                        lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                    }
                                }
                                else
                                {
                                    lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                    lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                }
                                notEoF = reader.Read();
                            }
                            reader.Close();
                        }
                        //check amount from storage
                        for (int n = 0; n < lbFoodItemID.Items.Count; n++)
                        {
                            string foodItemID = lbFoodItemID.Items[n].Text;
                            OleDbCommand command = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString() + " AND FoodItemID = " + foodItemID.ToString(), myConnection);
                            command.CommandType = CommandType.Text;
                            OleDbDataReader reader = command.ExecuteReader();
                            bool notEoF = reader.Read();
                            while (notEoF)
                            {
                                if (lbFoodItemID.Items[n].Text == reader["FoodItemID"].ToString())
                                {
                                    lbFoodItemID.Items[n].Value = (Convert.ToDouble(lbFoodItemID.Items[n].Value) - Convert.ToDouble(reader["Amount"].ToString())).ToString();
                                }
                                notEoF = reader.Read();
                            }
                            reader.Close();
                            if (Convert.ToDouble(lbFoodItemID.Items[n].Value) <= 0)
                            {
                                lbFoodItemID.Items.RemoveAt(n);
                                n -= 1;
                            }
                        }
                        if (tbShoppingList.Rows.Count == 0)
                        {
                            TableHeaderRow tbHeaderRow = new TableHeaderRow();
                            tbShoppingList.Rows.Add(tbHeaderRow);
                            TableHeaderCell tbHeaderCellName = new TableHeaderCell();
                            TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
                            tbHeaderCellName.Text = "Name";
                            tbHeaderCellAmount.Text = "Amount";
                            tbHeaderRow.Cells.Add(tbHeaderCellName);
                            tbHeaderRow.Cells.Add(tbHeaderCellAmount);
                            for (int k = 0; k < lbFoodItemID.Items.Count; k++)
                            {
                                string foodid = lbFoodItemID.Items[k].Text;
                                OleDbCommand command = new OleDbCommand("SELECT * FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
                                command.CommandType = CommandType.Text;
                                OleDbDataReader reader = command.ExecuteReader();
                                bool notEoF = reader.Read();
                                while (notEoF)
                                {
                                    TableRow tbRow = new TableHeaderRow();
                                    tbShoppingList.Rows.Add(tbRow);
                                    TableCell tbCellName = new TableHeaderCell();
                                    TableCell tbCellAmount = new TableHeaderCell();
                                    tbCellName.Text = reader["Name"].ToString();
                                    tbCellAmount.Text = lbFoodItemID.Items[k].Value + " " + reader["UnitType"].ToString();
                                    tbRow.Cells.Add(tbCellName);
                                    tbRow.Cells.Add(tbCellAmount);
                                    notEoF = reader.Read();
                                }
                                reader.Close();
                            }
                        }//End if tbShoppingList.Rows.Count == 0
                    }//End if lbFoodItemID.Items.Count == 0
                }//End if lbRecipePortion.Items.Count == 0
            }//End if lbRecipe.Items.Count == 0
        }//End page load

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
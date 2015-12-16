using System;
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
        private double portion;

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            userID = Convert.ToInt32(Session["userid"].ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["portion"].ToString() != "" && Session["portion"].ToString() != null)
            {
                portion = Convert.ToInt32(Session["portion"].ToString());
            }
            lbFoodItemID.Items.Clear();
            tbShoppingList.Rows.Clear();
            ListItemCollection chosenRecipe = (ListItemCollection)Session["chosenRecipe"];
            if (lbFoodItemID.Items.Count == 0 && tbShoppingList.Rows.Count == 0)
            {
                TableHeaderRow tbHeaderRow = new TableHeaderRow();
                tbShoppingList.Rows.Add(tbHeaderRow);
                TableHeaderCell tbHeaderCellName = new TableHeaderCell();
                TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
                tbHeaderCellName.Text = "Name";
                tbHeaderCellAmount.Text = "Amount";
                tbHeaderRow.Cells.Add(tbHeaderCellName);
                tbHeaderRow.Cells.Add(tbHeaderCellAmount);
                for (int j = 0; j < chosenRecipe.Count; j++)
                {
                    string recipeid = chosenRecipe[j].Value;
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Recipe AS r INNER JOIN RecipeFoodItem AS rf ON r.RecipeID = rf.RecipeID WHERE rf.RecipeID = " + recipeid.ToString(), myConnection);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    bool notEoF = reader.Read();
                    while (notEoF)
                    {
                        double basePortion = Convert.ToDouble(reader["Portion"].ToString());
                        double resultPortion = portion / basePortion;
                        if (lbFoodItemID.Items.Count != 0)
                        {
                            bool checkExistingFoodItem = false;
                            for (int m = 0; m < lbFoodItemID.Items.Count; m++)
                            {
                                if (reader["FoodItemID"].ToString() == lbFoodItemID.Items[m].Text)
                                {
                                    checkExistingFoodItem = true;
                                    lbFoodItemID.Items[m].Value = (Convert.ToDouble(lbFoodItemID.Items[m].Value) + Convert.ToDouble(reader["Amount"].ToString()) * resultPortion).ToString();
                                }
                            }
                            if (checkExistingFoodItem == false)
                            {
                                lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * resultPortion).ToString();
                            }
                        }
                        else
                        {
                            lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                            lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * resultPortion).ToString();
                        }
                        notEoF = reader.Read();
                    }
                    reader.Close();
                }
                //check amount from storage
                for (int n = 0; n < lbFoodItemID.Items.Count; n++)
                {
                    string unitType = "";
                    string foodItemID = lbFoodItemID.Items[n].Text;
                    if (lbFoodItemID.Items[n].Text.All(char.IsDigit) && lbFoodItemID.Items[n].Text.Any())
                    {
                        OleDbCommand command = new OleDbCommand("SELECT * FROM UserFoodItem AS uf INNER JOIN FoodItem AS f ON uf.FoodItemID = f.FoodItemID  WHERE uf.UserDataID = " + userID.ToString() + " AND uf.FoodItemID = " + foodItemID.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            bool notEoF = reader.Read();
                            while (notEoF)
                            {
                                lbFoodItemID.Items[n].Text = reader["Name"].ToString();
                                lbFoodItemID.Items[n].Value = (Convert.ToDouble(lbFoodItemID.Items[n].Value) - Convert.ToDouble(reader["Amount"].ToString())).ToString();
                                unitType = reader["UnitType"].ToString();
                                notEoF = reader.Read();
                            }
                            reader.Close();
                            if (Convert.ToDouble(lbFoodItemID.Items[n].Value) <= 0)
                            {
                                lbFoodItemID.Items.RemoveAt(n);
                                n -= 1;
                            }
                            else
                            {
                                TableRow tbRow = new TableHeaderRow();
                                tbShoppingList.Rows.Add(tbRow);
                                TableCell tbCellName = new TableHeaderCell();
                                TableCell tbCellAmount = new TableHeaderCell();
                                tbCellName.Text = lbFoodItemID.Items[n].Text;
                                tbCellAmount.Text = lbFoodItemID.Items[n].Value + " " + unitType;
                                tbRow.Cells.Add(tbCellName);
                                tbRow.Cells.Add(tbCellAmount);
                            }
                        }
                        else
                        {
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM FoodItem WHERE FoodItemID = " + foodItemID.ToString(), myConnection);
                            cmd.CommandType = CommandType.Text;
                            OleDbDataReader readerAgain = cmd.ExecuteReader();
                            bool notEoF = readerAgain.Read();
                            while (notEoF)
                            {
                                lbFoodItemID.Items[n].Text = readerAgain["Name"].ToString();
                                lbFoodItemID.Items[n].Value = lbFoodItemID.Items[n].Value;
                                unitType = readerAgain["UnitType"].ToString();
                                notEoF = readerAgain.Read();
                            }
                            readerAgain.Close();
                            TableRow tbRow = new TableHeaderRow();
                            tbShoppingList.Rows.Add(tbRow);
                            TableCell tbCellName = new TableHeaderCell();
                            TableCell tbCellAmount = new TableHeaderCell();
                            tbCellName.Text = lbFoodItemID.Items[n].Text;
                            tbCellAmount.Text = lbFoodItemID.Items[n].Value + " " + unitType;
                            tbRow.Cells.Add(tbCellName);
                            tbRow.Cells.Add(tbCellAmount);
                        }
                    }
                }//End if tbShoppingList.Rows.Count == 0
            }//End if lbFoodItemID.Items.Count == 0
        }//End page load

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddShoppingList_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddShoppingList.aspx");
        }
    }
}
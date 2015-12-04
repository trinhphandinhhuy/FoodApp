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
    public partial class PlanMeal : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userid;
        private List<int> recipeid = new List<int>();
        private ArrayList listbox1 = new ArrayList();
        private ArrayList listbox2 = new ArrayList();

        protected void Page_Init(object sender, EventArgs e)
        {
            checkUserAuthentication();
            userid = Convert.ToInt32(Session["userid"].ToString());
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            if (ddlRecipe.Items.Count == 0)
            {
                OleDbCommand command1 = new OleDbCommand("SELECT * FROM UserRecipe", myConnection);
                command1.CommandType = CommandType.Text;
                OleDbDataReader reader1 = command1.ExecuteReader();
                bool notEoF1 = reader1.Read();
                while (notEoF1)
                {
                    if (userid == Convert.ToInt32(reader1["UserDataID"].ToString()))
                    {
                        recipeid.Add(Convert.ToInt32(reader1["RecipeID"].ToString()));
                    }
                    notEoF1 = reader1.Read();
                }
                reader1.Close();
                OleDbCommand command2 = new OleDbCommand("SELECT * FROM Recipe", myConnection);
                command2.CommandType = CommandType.Text;
                OleDbDataReader reader2 = command2.ExecuteReader();
                bool notEoF2 = reader2.Read();
                while (notEoF2)
                {
                    foreach (int r in recipeid)
                    {
                        if (r == Convert.ToInt32(reader2["RecipeID"].ToString()))
                        {
                            ddlRecipe.Items.Add(reader2["Name"].ToString());
                            ddlRecipe.Items[ddlRecipe.Items.Count - 1].Value = reader2["RecipeID"].ToString();
                            notEoF2 = reader2.Read();
                        }
                    }
                    notEoF2 = reader2.Read();
                }
                reader2.Close();
            }
            int maxPortion = 10;
            if (ddlPortion.Items.Count == 0)
            {
                for (int i = 1; i <= maxPortion; i++)
                {
                    ddlPortion.Items.Add(i.ToString());
                    ddlPortion.Items[ddlPortion.Items.Count - 1].Value = i.ToString();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void checkUserAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddRecipeToPlannedMeal_Click(object sender, EventArgs e)
        {
            if (ddlRecipe.SelectedIndex >= 0)
            {
                for (int i = 0; i < ddlRecipe.Items.Count; i++)
                {
                    if (ddlRecipe.Items[i].Selected)
                    {
                        if (!listbox1.Contains(ddlRecipe.Items[i]))
                        {
                            listbox1.Add(ddlRecipe.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < listbox1.Count; i++)
                {
                    if (!lbChosenRecipe.Items.Contains(((ListItem)listbox1[i])))
                    {
                        lbChosenRecipe.Items.Add(((ListItem)listbox1[i]));
                    }
                    ddlRecipe.Items.Remove(((ListItem)listbox1[i]));
                }
                lbChosenRecipe.SelectedIndex = -1;
            }
        }

        protected void btnRemoveChosenRecipe_Click(object sender, EventArgs e)
        {
            if (lbChosenRecipe.SelectedIndex >= 0)
            {
                for (int i = 0; i < lbChosenRecipe.Items.Count; i++)
                {
                    if (lbChosenRecipe.Items[i].Selected)
                    {
                        if (!listbox2.Contains(lbChosenRecipe.Items[i]))
                        {
                            listbox2.Add(lbChosenRecipe.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < listbox2.Count; i++)
                {
                    if (!ddlRecipe.Items.Contains(((ListItem)listbox2[i])))
                    {
                        ddlRecipe.Items.Add(((ListItem)listbox2[i]));
                    }
                    lbChosenRecipe.Items.Remove(((ListItem)listbox2[i]));
                }
                ddlRecipe.SelectedIndex = -1;
            }
        }

        protected void btnConfirmPlannedMeal_Click(object sender, EventArgs e)
        {
            ArrayList chosenRecipe = new ArrayList();
            if (lbChosenRecipe.Items.Count > 0)
            {
                for (int i = 0; i < lbChosenRecipe.Items.Count; i++)
                {
                    chosenRecipe.Add(lbChosenRecipe.Items[i]);
                }
            }
            Session["chosenRecipe"] = chosenRecipe;
            Session["portion"] = ddlPortion.SelectedValue;
            Response.Redirect("ShoppingList.aspx");
        }
    }
}
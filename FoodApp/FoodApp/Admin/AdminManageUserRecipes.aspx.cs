﻿using System;
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
    public partial class AdminManageUserRecipes : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand;
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int recipeid;
        protected void Page_Init(object sender, EventArgs e)
        {
            checkAdminAuthentication();
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDB();
            }

            
        }

        private void checkAdminAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "") { Response.Redirect("Login.aspx"); }
            if (Session["userlevel"] != null && Session["userlevel"].ToString() != "Admin") { Response.Redirect("Login.aspx"); }
        }

        private void getDB()
        {
            RecipeTable.DataSource = null;
            RecipeTable.DataBind();
            //Define the command objects (SQL commands)
            mySelectCommand.CommandText = "SELECT RecipeID, Name FROM Recipe WHERE UserDataID <> 7";
            //Fetching rows into the Data Set
            myAdapter.Fill(myDataSet);
            //Show the users in the Data Grid
            RecipeTable.DataSource = myDataSet;
            RecipeTable.DataBind();
        }

        protected void RecipeTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            recipeid = Convert.ToInt32(RecipeTable.Rows[e.RowIndex].Cells[1].Text);
            myDeleteCommand = new OleDbCommand("DELETE FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
            myDeleteCommand.CommandType = CommandType.Text;
            myDeleteCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void RecipeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[1].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + item + "?')){ return false; };";
                    }
                }
            }
        }

        protected void btnAddRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecipe.aspx");
        }

        protected void btnManageOwnRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageOwnRecipe.aspx");
        }

        protected void btnManageUserRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageUserRecipes.aspx");
        }

        protected void btnExploreRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExploringRecipes.aspx");
        }

        protected void Recipe_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void User_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
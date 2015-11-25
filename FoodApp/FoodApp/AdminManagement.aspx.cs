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
    public partial class AdminAccount : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int userid;
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

            if (Session["userlevel"].ToString() != "Admin")
            {
               AdminFunction.Visible = false;
               Ingredients.Visible = false;
            }
        }
        private void checkAdminAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "") { Response.Redirect("Login.aspx"); }
            if (Session["userlevel"] != null && Session["userlevel"].ToString() != "Admin") { Response.Redirect("Login.aspx"); }
        }
        private void getDB()
        {
            UserDataTable.DataSource = null;
            UserDataTable.DataBind();
            //Define the command objects (SQL commands)
            mySelectCommand.CommandText = "SELECT UserDataID, Username, Email FROM UserData Where UserRoleID = 2";
            //Fetching rows into the Data Set
            myAdapter.Fill(myDataSet, "UserData");
            //Show the users in the Data Grid
            UserDataTable.DataSource = myDataSet;
            UserDataTable.DataMember = "UserData";
            UserDataTable.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string hashedPassword = PasswordHash.PasswordHash.CreateHash(txtPassword.Text);
            myInsertCommand.Connection = myConnection;
            myInsertCommand.CommandType = CommandType.Text;
            myInsertCommand.CommandText = "INSERT INTO UserData(UserRoleID, Username, Email, UserPassword) values(2, @Username,@Email,@Password)";
            //adding parameters with value
            myInsertCommand.Parameters.AddWithValue("@Username", txtUsername.Text.ToString());
            myInsertCommand.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
            myInsertCommand.Parameters.AddWithValue("@Password", hashedPassword);

            myInsertCommand.ExecuteNonQuery();  //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void UserDataTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            userid = Convert.ToInt32(UserDataTable.Rows[e.RowIndex].Cells[1].Text);
            string commandString = "DELETE FROM UserData WHERE UserDataID = " + userid.ToString();
            OleDbCommand cmd2 = new OleDbCommand(commandString, myConnection);
            cmd2.CommandType = CommandType.Text;
            cmd2.ExecuteNonQuery();  //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void User_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }
        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddUser.aspx");
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDeleteUser.aspx");
        }

        protected void btnEditUsernameAndEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeUsernameAndEmail.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void Recipes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
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
    public partial class AdminAddEditDeleteFoodItem : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand = new OleDbCommand();
        private OleDbCommand myUpdateCommand = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int foodid;
        protected void Page_Init(object sender, EventArgs e)
        {
            checkAdminAuthentication();
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            if (ddlFoodType.Items.Count == 0)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM FoodType", myConnection);
                command.CommandType = CommandType.Text;
                OleDbDataReader reader = command.ExecuteReader();
                bool notEoF = reader.Read();
                while (notEoF)
                {
                    ddlFoodType.Items.Add(reader["Name"].ToString());
                    ddlFoodType.Items[ddlFoodType.Items.Count - 1].Value = reader["FoodTypeID"].ToString();
                    notEoF = reader.Read();
                }
                reader.Close();
            }
            if (ddlUnitType.Items.Count == 0)
            {
                ddlUnitType.Items.Add("kg");
                ddlUnitType.Items[ddlUnitType.Items.Count - 1].Value = "kg";
                ddlUnitType.Items.Add("l");
                ddlUnitType.Items[ddlUnitType.Items.Count - 1].Value = "l";
            }
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
            FoodTable.DataSource = null;
            FoodTable.DataBind();
            //Define the command objects (SQL commands)
            mySelectCommand.CommandText = "SELECT * FROM FoodItem";
            //Fetching rows into the Data Set
            myAdapter.Fill(myDataSet);
            //Show the users in the Data Grid
            FoodTable.DataSource = myDataSet;
            FoodTable.DataBind();
        }

        protected void btnAddFoodItem_Click(object sender, EventArgs e)
        {
            myInsertCommand.Connection = myConnection;
            myInsertCommand.CommandType = CommandType.Text;
            myInsertCommand.CommandText = "INSERT INTO FoodItem(Name, FoodTypeID, UnitType) values(@Name,@FoodTypeID,@UnitType)";
            //adding parameters with value
            myInsertCommand.Parameters.AddWithValue("@Name", txtFoodName.Text.ToString());
            myInsertCommand.Parameters.AddWithValue("@FoodTypeID", ddlFoodType.SelectedValue.ToString());
            myInsertCommand.Parameters.AddWithValue("@UnitType", ddlUnitType.SelectedValue.ToString());

            myInsertCommand.ExecuteNonQuery();  //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void FoodTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foodid = Convert.ToInt32(FoodTable.Rows[e.RowIndex].Cells[2].Text);
            myDeleteCommand = new OleDbCommand("DELETE FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
            myDeleteCommand.CommandType = CommandType.Text;
            myDeleteCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void FoodTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            FoodTable.EditIndex = e.NewEditIndex;
            getDB();
        }

        protected void FoodTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void FoodTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            FoodTable.EditIndex = -1;
            getDB();
        }

        
    }
}
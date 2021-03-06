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
    public partial class AddNewIngredient : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        protected void Page_Init(object sender, EventArgs e)
        {
            //checkAdminAuthentication();
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
            string[] unitType = { "g", "ml" };
            if (ddlUnitType.Items.Count == 0)
            {
                foreach (string u in unitType)
                {
                    ddlUnitType.Items.Add(u);
                    ddlUnitType.Items[ddlUnitType.Items.Count - 1].Value = u;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlevel"].ToString() != "Admin")
            {
                Response.Redirect("Dashboard.aspx");
            }
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
        }
    }
}
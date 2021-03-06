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
    public partial class PlannedMealHistory : System.Web.UI.Page
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
            //getDB();
            if (!Page.IsPostBack)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM PlannedMeal WHERE UserDataID = " + userID + " ORDER BY CreatedDate DESC", myConnection);
                command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                da.Fill(dt);
                PlannedMeal.DataSource = dt;
                PlannedMeal.DataBind();

            }
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void getDB()
        {

            OleDbCommand command = new OleDbCommand("SELECT * FROM PlannedMeal WHERE UserDataID = " + userID + " AND CreatedDate = #" + datefilterPlanMeal.SelectedDate.ToShortDateString() + "# ORDER BY CreatedDate DESC", myConnection);
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            PlannedMeal.DataSource = dt;
            PlannedMeal.DataBind();
            //myConnection.Close();
        }

        protected void datefilterPlanMeal_SelectionChanged(object sender, EventArgs e)
        {
            getDB();

        }

        protected void datefilterPlanMeal_DayRender(object sender, DayRenderEventArgs e)
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM PlannedMeal WHERE UserDataID = " + userID + " ORDER BY CreatedDate DESC", myConnection);

            OleDbDataReader dr = command.ExecuteReader();
            // Read DataReader till it reaches the end
            while (dr.Read() == true)
            {
                // Assign the Calendar control dates
                // already contained in the database
                //datefilterPlanMeal.SelectedDates.Add((DateTime)dr["CreatedDate"]);
                if (e.Day.Date == (DateTime)dr["CreatedDate"])
                {
                    e.Cell.BackColor = System.Drawing.Color.Silver;
                }
            }
            if (e.Day.IsSelected)
            {
                e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#4db6ac");
                e.Cell.ForeColor = System.Drawing.Color.White;
            }

            // Close DataReader
            dr.Close();
        }
    }
}
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
    public partial class PlannedMealHistory : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userID;

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            userID = Convert.ToInt32(Session["userid"].ToString());
        }

        private void getDB()
        {
            OleDbCommand command = new OleDbCommand("SELECT * FROM PlannedMeal WHERE UserDataID = " + userID, myConnection);
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            PlannedMeal.DataSource = dt;
            PlannedMeal.DataBind();
            myConnection.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getDB();
        }

        
    }
}
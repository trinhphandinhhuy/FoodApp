using System;
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
    public partial class AdminDeleteUser : System.Web.UI.Page
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
       
    }
}
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
    public partial class AdminAddUser : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
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
           
        }

        private void checkAdminAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "") { Response.Redirect("Login.aspx"); }
            if (Session["userlevel"] != null && Session["userlevel"].ToString() != "Admin") { Response.Redirect("Login.aspx"); }
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
        }
       
    }
}
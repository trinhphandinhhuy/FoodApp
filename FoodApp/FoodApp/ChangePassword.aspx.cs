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
    public partial class ChangePassword : System.Web.UI.Page
    {
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private OleDbConnection myConnection;
        private string passwordHash;
        private int userid;
        protected void Page_Init(object sender, EventArgs e)
        {
            checkUserAuthentication();
            string usernameSession = Session["username"].ToString();
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM UserData", myConnection);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            bool existingUsername = false;
            while (notEoF)
            {
                if (usernameSession == reader["Username"].ToString())
                {
                    passwordHash = reader["UserPassword"].ToString();
                    userid = Convert.ToInt32(reader["UserDataID"].ToString());
                    existingUsername = true;
                }
                notEoF = reader.Read();
            }
            reader.Close();
            if (existingUsername == false)
            {
                Response.Redirect("Login.aspx");
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
        protected void CheckOldPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (PasswordHash.PasswordHash.ValidatePassword(txtOldPassword.Text, passwordHash)) { args.IsValid = true; }
            else { args.IsValid = false; }
        }
        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                string newPassword = PasswordHash.PasswordHash.CreateHash(txtNewPassword.Text);
                string commandString = "UPDATE UserData SET UserPassword = '" + newPassword + "' WHERE UserDataID = " + userid.ToString();
                OleDbCommand cmd2 = new OleDbCommand(commandString, myConnection);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();  //executing query
                myConnection.Close(); //closing connection
            }
        }
       
    }
}
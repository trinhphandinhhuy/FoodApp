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
    public partial class Login : System.Web.UI.Page
    {
        private string user_name;
        private string password;
        private int user_id;
        private string user_role;
        OleDbConnection myConnection = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        }
        protected void userAuthentication_ServerValidate(object source, ServerValidateEventArgs args)
        {
            cmd.Connection = myConnection;
            cmd.CommandText = "SELECT * FROM UserData AS ud INNER JOIN UserRole AS ur ON ud.UserRoleID = ur.UserRoleID";
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            bool existingUsername = false;
            bool correctPassword = false;
            while (notEoF)
            {
                if (txtUsername.Text == reader["Username"].ToString())
                {
                    user_name = txtUsername.Text;
                    existingUsername = true;
                    password = txtPassword.Text;
                    if (PasswordHash.PasswordHash.ValidatePassword(password, reader["UserPassword"].ToString()))
                    {
                        user_id = Convert.ToInt32(reader["UserDataID"].ToString());
                        user_role = reader["Name"].ToString();
                        correctPassword = true;
                    }
                }
                notEoF = reader.Read();
            }
            reader.Close();
            if (existingUsername && correctPassword)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                myConnection.Close();
                Session["username"] = user_name;
                Session["userlevel"] = user_role;
                Session["userid"] = user_id;
                Response.Redirect("ExploringRecipes.aspx");
            }
        }
    }
}
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
    public partial class UserAccount : System.Web.UI.Page
    {
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private OleDbConnection myConnection;
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
                    txtUsername.Text = reader["Username"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
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
            if (Session["userlevel"].ToString() == "Admin")
            {
                AdminFunction.Visible = true;
            }
            else
            {
                AdminFunction.Visible = false;
            }
        }
        private void checkUserAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnChangeUsernameAndEmailAddress_Click(object sender, EventArgs e)
        {
            string commandString = "UPDATE UserData SET Username = '" + txtUsername.Text + "', Email = '" + txtEmail.Text + "' WHERE UserDataID = " + userid.ToString();
            OleDbCommand cmd2 = new OleDbCommand(commandString, myConnection);
            cmd2.CommandType = CommandType.Text;
            Session["username"] = txtUsername.Text;
            cmd2.ExecuteNonQuery();  //executing query
            myConnection.Close(); //closing connection
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
    }
}
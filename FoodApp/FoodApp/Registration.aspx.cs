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
    public partial class Registration : System.Web.UI.Page
    {
        OleDbConnection myConnection = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    string hashedPassword = PasswordHash.PasswordHash.CreateHash(txtPassword.Text.ToString());
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO UserData(UserRoleID, Username, Email, UserPassword) values(2, @Username,@Email,@Password)";

                    //adding parameters with value
                    cmd.Parameters.AddWithValue("@Username", txtUserName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.ToString());
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.ExecuteNonQuery();  //executing query
                    myConnection.Close(); //closing connection
                    //lblMsg.Text = "Registered Successfully..";
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
            }
            else
            {
                //lblMsg.Text = "Register fail!";
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //refreshing/reloading page to clear all the controls
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
    }
}
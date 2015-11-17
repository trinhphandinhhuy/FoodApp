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
    public partial class AddRecipe : System.Web.UI.Page
    {
        OleDbConnection myConnection = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr;

            connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Recipe(Name, Portion, CookingTime, Discription) values( @Name, @Portion, @CookingTime, @Discription)";

                    //adding parameters with value
                    //cmd.Parameters.AddWithValue("@UserDataID", txtUserName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Name", txtRecipeName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Portion", txtPortion.Text.ToString());
                    cmd.Parameters.AddWithValue("@CookingTime", txtCookingTime.Text.ToString());
                    cmd.Parameters.AddWithValue("@Discription", txtDescription.Text.ToString());
                    


                    cmd.ExecuteNonQuery();  //executing query
                    myConnection.Close(); //closing connection
                    //lblMsg.Text = "Registered Successfully..";
                    Response.Redirect("Dashboard.aspx");
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

       
    }
}
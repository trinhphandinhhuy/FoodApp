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
        OleDbCommand cmd2 = new OleDbCommand();
        private string user_data_ID;
        private object label1;

        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr;

            connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            Label11.Text = Session["username"].ToString();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Recipe(UserDataID, Name, Portion, CookingTime, Description,MealTypeID) values(@UserDataID, @Name, @Portion, @CookingTime, @Description,4)";
                    cmd2.Connection = myConnection;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT UserDataID FROM UserData WHERE Username ='" + Session["username"].ToString()+"'" ;
                    OleDbDataReader reader = cmd2.ExecuteReader();
                    bool notEoF = reader.Read();
                    while (notEoF)
                    {
                        user_data_ID = reader["UserDataID"].ToString();
                        notEoF = reader.Read();
                    }
                    reader.Close();
                    //adding parameters with value

                    cmd.Parameters.AddWithValue("@UserDataID", Convert.ToInt32(user_data_ID));
                    cmd.Parameters.AddWithValue("@Name", txtRecipeName.Text.ToString());
                    cmd.Parameters.AddWithValue("@Portion", Convert.ToInt32(txtPortion.Text));
                    cmd.Parameters.AddWithValue("@CookingTime", Convert.ToInt32(txtCookingTime.Text));
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text.ToString());
                    


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
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
    public partial class AdminManageOwnRecipe : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand;
        private OleDbCommand myDeleteCommand2;

        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int recipeid, userid;
        protected void Page_Init(object sender, EventArgs e)
        {
            checkUserAuthentication();
            userid = Convert.ToInt32(Session["userid"].ToString());
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;           
        }

        private void checkUserAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDB();
            }
        }
        private void getDB()
        {
            AdminRecipeTable.DataSource = null;
            AdminRecipeTable.DataBind();
            //Define the command objects (SQL commands)

            //Placebo: no admin recipe added
            List<int> listOfRecipe = new List<int>();
            OleDbCommand command = new OleDbCommand("SELECT * FROM UserRecipe WHERE UserDataID = " + userid.ToString() + ";", myConnection);
            command.CommandType = CommandType.Text;
            OleDbDataReader reader = command.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                listOfRecipe.Add(Convert.ToInt32(reader["RecipeID"]));
                notEoF = reader.Read();
            }
            reader.Close();
            if (listOfRecipe.Count > 0)
            {
                string selectCommandText = "SELECT * FROM Recipe WHERE";
                for (int i = 0; i < listOfRecipe.Count; i++)
                {
                    if (i == 0)
                    {
                        selectCommandText += " RecipeID = " + listOfRecipe[i].ToString();
                    }
                    else if (i > 0)
                    {
                        selectCommandText += " OR RecipeID = " + listOfRecipe[i].ToString();
                    }
                }
                mySelectCommand.CommandText = selectCommandText;
                //Fetching rows into the Data Set
                myAdapter.Fill(myDataSet);
                //Show the users in the Data Grid
                AdminRecipeTable.DataSource = myDataSet;
                AdminRecipeTable.DataBind();
            }
        }
        protected void AdminRecipeTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool owner = false;
            recipeid = Convert.ToInt32(AdminRecipeTable.Rows[e.RowIndex].Cells[1].Text);
            OleDbCommand command = new OleDbCommand("SELECT * FROM UserRecipe WHERE UserDataID = " + userid.ToString() + " AND RecipeID = " + recipeid.ToString() + ";", myConnection);
            command.CommandType = CommandType.Text;
            OleDbDataReader reader = command.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                owner = Convert.ToBoolean(reader["Owner"].ToString());
                notEoF = reader.Read();
            }
            reader.Close();
            if (owner)
            {
                myDeleteCommand = new OleDbCommand("DELETE FROM UserRecipe WHERE RecipeID = " + recipeid.ToString() + ";", myConnection);
                myDeleteCommand.CommandType = CommandType.Text;
                myDeleteCommand.ExecuteNonQuery(); //executing query
                myDeleteCommand2 = new OleDbCommand("DELETE FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
                myDeleteCommand2.CommandType = CommandType.Text;
                myDeleteCommand2.ExecuteNonQuery(); //executing query
            }
            else
            {
                myDeleteCommand = new OleDbCommand("DELETE FROM UserRecipe WHERE UserDataID = " + userid.ToString() + " AND RecipeID = " + recipeid.ToString() + ";", myConnection);
                myDeleteCommand.CommandType = CommandType.Text;
                myDeleteCommand.ExecuteNonQuery(); //executing query
            }
            getDB();
            myConnection.Close(); //closing connection
            
        }

        protected void AdminRecipeTable_OnSelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("EditRecipe.aspx?RecipeID=" + AdminRecipeTable.Rows[e.NewSelectedIndex].Cells[1].Text);
        }
        protected void AdminRecipeTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
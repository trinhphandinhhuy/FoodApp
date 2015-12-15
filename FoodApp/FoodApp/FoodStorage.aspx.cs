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
    public partial class FoodStorage : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand;
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int foodid;
        private int userID;
        private OleDbDataReader myReader;

        protected void Page_Init(object sender, EventArgs e)
        {
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            userID = Convert.ToInt32(Session["userid"].ToString());
            checkAuthentication();
            //ListAll();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            mySelectCommand.CommandType = CommandType.Text;
            mySelectCommand.CommandText = "SELECT Name, FoodTypeID FROM FoodType ORDER BY Name DESC";
            myReader = mySelectCommand.ExecuteReader();
            bool notEoF;
            //read first row from database
            notEoF = myReader.Read();
            //read row by row until the last row
            if (ddlCategory.Items.Count == 0)
            {
                ddlCategory.Items.Add("All Categories");
                while (notEoF)
                {
                    ddlCategory.Items.Add(myReader["Name"].ToString());
                    ddlCategory.Items[ddlCategory.Items.Count - 1].Value = myReader["FoodTypeID"].ToString();
                    notEoF = myReader.Read();
                }
            }
            else { }

            myReader.Close();
            if(!Page.IsPostBack)
            {
                getDB();
            }
            
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
        private void getDB()
        {
            FoodTable.DataSource = null;
            FoodTable.DataBind();
            //Define the command objects (SQL commands)
            if (ddlCategory.SelectedItem.Text == "All Categories")
            {
                mySelectCommand.CommandText = "SELECT FoodItem.Name , UserFoodItem.Amount, FoodItem.UnitType FROM FoodItem INNER JOIN UserFoodItem ON FoodItem.FoodItemID = UserFoodItem.FoodItemID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%' AND UserFoodItem.UserDataID = " + userID + " ORDER BY FoodItem.Name ASC;";
            }
            else
            {
                mySelectCommand.CommandText = "SELECT FoodItem.Name , UserFoodItem.Amount, FoodItem.UnitType FROM FoodItem INNER JOIN UserFoodItem ON FoodItem.FoodItemID = UserFoodItem.FoodItemID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%' AND UserFoodItem.UserDataID = " + userID + " AND FoodItem.FoodTypeID = " + ddlCategory.SelectedItem.Value + " ORDER BY FoodItem.Name ASC;";
            }
            //Fetching rows into the Data Set

            myAdapter.Fill(myDataSet, "UserFoodItem");
            //Show the users in the Data Grid
            FoodTable.DataSource = myDataSet;
            FoodTable.DataMember = "UserFoodItem";
            FoodTable.DataBind();
        }

        private void ListAll()
        {
            FoodTable.DataSource = null;
            FoodTable.DataBind();

            mySelectCommand.CommandText = "SELECT FoodItem.Name , UserFoodItem.Amount, FoodItem.UnitType FROM FoodItem INNER JOIN UserFoodItem ON FoodItem.FoodItemID = UserFoodItem.FoodItemID WHERE UserFoodItem.UserDataID = " + userID + ";";

            //Fetching rows into the Data Set

            myAdapter.Fill(myDataSet, "UserFoodItem");
            //Show the users in the Data Grid
            FoodTable.DataSource = myDataSet;
            FoodTable.DataMember = "UserFoodItem";
            FoodTable.DataBind();
        }

        protected void FoodTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            foodid = Convert.ToInt32(FoodTable.Rows[e.RowIndex].Cells[1].Text);
            myDeleteCommand = new OleDbCommand("DELETE FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
            myDeleteCommand.CommandType = CommandType.Text;
            myDeleteCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        protected void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            getDB();
        }
    }
}
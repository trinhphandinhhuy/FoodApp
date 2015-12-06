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
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand;
        
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int recipeid;
        protected void Page_Init(object sender, EventArgs e)
        {
            checkUserAuthentication();
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
            //mySelectCommand.CommandText = "SELECT Recipe.RecipeID, Recipe.Name, Recipe.MealTypeID, Recipe.Portion, Recipe.CookingTime, Recipe.Description FROM Recipe INNER JOIN UserData ON Recipe.UserDataID = UserData.UserDataID WHERE UserData.Username = 'huytrinh';";
            mySelectCommand.CommandText = "SELECT Recipe.RecipeID, Recipe.Name, Recipe.MealTypeID, Recipe.Portion, Recipe.CookingTime, Recipe.Description FROM (Recipe INNER JOIN UserData ON Recipe.UserDataID = UserData.UserDataID) INNER JOIN MealType ON Recipe.MealTypeID = MealType.MealTypeID WHERE UserData.Username = '" + Session["username"].ToString() + "';";
            
            //Fetching rows into the Data Set
            myAdapter.Fill(myDataSet);
            //Show the users in the Data Grid
            AdminRecipeTable.DataSource = myDataSet;
            AdminRecipeTable.DataBind();
        }

        

        protected void AdminRecipeTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            recipeid = Convert.ToInt32(AdminRecipeTable.Rows[e.RowIndex].Cells[1].Text);
            myDeleteCommand = new OleDbCommand("DELETE FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
            myDeleteCommand.CommandType = CommandType.Text;
            myDeleteCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            getDB();
        }

        

        protected void btnAddRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecipe.aspx");
        }

        protected void btnManageOwnRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageOwnRecipe.aspx");
        }

        protected void btnManageUserRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin/AdminManageUserRecipes.aspx");
        }

        protected void btnExploreRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExploringRecipes.aspx");
        }

        protected void Recipe_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void User_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
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
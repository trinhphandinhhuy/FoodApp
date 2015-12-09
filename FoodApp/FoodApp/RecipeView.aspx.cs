using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace FoodApp
{
    public partial class RecipeView : System.Web.UI.Page

    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbCommand cmd2 = new OleDbCommand();
      
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
    

        protected void Page_Load(object sender, EventArgs e)
        {
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        
            cmd2.Connection = myConnection;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "SELECT UserData.Username, Recipe.Name, Recipe.Portion, Recipe.CookingTime, Recipe.Description, MealType.Name, Recipe.ImageURL,Recipe.RecipeID FROM MealType INNER JOIN (Recipe INNER JOIN UserData ON Recipe.UserDataID = UserData.UserDataID) ON MealType.MealTypeID = Recipe.MealTypeID WHERE(((Recipe.Name) = '" + Session["RecipeAdded"].ToString() + "'))";
            OleDbDataReader reader = cmd2.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                recipeAuthor.Text = reader["Username"].ToString();                
                RecipeName.Text = reader[1].ToString();
                portions.Text = reader["Portion"].ToString();
                cookingtime.Text = reader["CookingTime"].ToString();
                descriptions.Text = reader["Description"].ToString();
                MealType.Text = reader[5].ToString();
               
                RecipeImage.ImageUrl = reader["ImageURL"].ToString();
                Session["RecipeID"] = reader["RecipeID"].ToString();
                notEoF = reader.Read();
            }
            reader.Close();
            myConnection.Close();  
        }
    }
}
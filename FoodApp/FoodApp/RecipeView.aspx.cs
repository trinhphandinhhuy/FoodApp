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
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            int recipeID = 0;
            if (Request.QueryString["RecipeID"] != null && Request.QueryString["RecipeID"] != "")
            {
                recipeID = Convert.ToInt32(Request.QueryString["RecipeID"]);
            }
            else
            {
                Response.Redirect("ExploringRecipe.aspx");
            }
            myConnection.ConnectionString = connstr;
            myConnection.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM UserData AS u INNER JOIN Recipe AS r ON r.UserDataID = u.UserDataID WHERE r.RecipeID = " + recipeID, myConnection);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                recipeAuthor.Text = reader["Username"].ToString();                
                RecipeName.Text = reader["Name"].ToString();
                portions.Text = reader["Portion"].ToString();
                cookingtime.Text = reader["CookingTime"].ToString();
                descriptions.Text = reader["Description"].ToString();
                OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM MealType WHERE MealTypeID = " + reader["MealTypeID"].ToString(), myConnection);
                cmd2.CommandType = CommandType.Text;
                OleDbDataReader reader2 = cmd2.ExecuteReader();
                bool notEoF2 = reader2.Read();
                while (notEoF2)
                {
                    MealType.Text = reader2["Name"].ToString();
                    notEoF2 = reader2.Read();
                }
                reader2.Close();
                RecipeImage.ImageUrl = reader["ImageURL"].ToString();
                notEoF = reader.Read();
            }
            reader.Close();
            TableHeaderRow tbHeaderRow = new TableHeaderRow();
            tbFoodItem.Rows.Add(tbHeaderRow);
            TableHeaderCell tbHeaderCellName = new TableHeaderCell();
            TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
            tbHeaderCellName.Text = "Name";
            tbHeaderCellAmount.Text = "Amount";
            tbHeaderRow.Cells.Add(tbHeaderCellName);
            tbHeaderRow.Cells.Add(tbHeaderCellAmount);
            OleDbCommand cmd3 = new OleDbCommand("SELECT * FROM RecipeFoodItem INNER JOIN FoodItem ON RecipeFoodItem.FoodItemID = FoodItem.FoodItemID WHERE RecipeFoodItem.RecipeID = " + recipeID.ToString(), myConnection);
            cmd3.CommandType = CommandType.Text;
            OleDbDataReader reader3 = cmd3.ExecuteReader();
            bool notEoF3 = reader3.Read();
            while (notEoF3)
            {
                TableRow tbRow = new TableRow();
                tbFoodItem.Rows.Add(tbRow);
                TableCell tbCellName = new TableCell();
                TableCell tbCellAmount = new TableCell();
                tbCellName.Text = reader3["Name"].ToString();
                tbCellAmount.Text = reader3["Amount"].ToString() + " " + reader3["UnitType"].ToString();
                tbRow.Cells.Add(tbCellName);
                tbRow.Cells.Add(tbCellAmount);
                notEoF3 = reader3.Read();
            }
            reader3.Close();
            myConnection.Close();  
        }
    }
}
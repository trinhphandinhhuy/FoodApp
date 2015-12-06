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
using System.IO;
using System.Web.UI.HtmlControls;



namespace FoodApp
{
    public partial class AddRecipe : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbCommand cmd2 = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private string user_data_ID;
        private string tmpRecipeID;
        private string filename;

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            MealTypeData.ConnectionString = connstr;
            FoodStuffDS.ConnectionString = connstr;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckRecipeID();
            if (!Page.IsPostBack)
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
            IngredientRecipeDB.DataSource = null;
            IngredientRecipeDB.DataBind();
            //Define the command objects (SQL commands)
            mySelectCommand.CommandText = "SELECT FoodItem.Name,RecipeFoodItem.Amount, FoodItem.UnitType FROM FoodItem INNER JOIN RecipeFoodItem ON FoodItem.FoodItemID = RecipeFoodItem.FoodItemID Where RecipeID = " + tmpRecipeID;
            //Fetching rows into the Data Set
            myAdapter.Fill(myDataSet, "IngredientRecipeDB");
            //Show the users in the Data Grid
            IngredientRecipeDB.DataSource = myDataSet;
            IngredientRecipeDB.DataMember = "IngredientRecipeDB";
            IngredientRecipeDB.DataBind();
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                try
                {
                    //Upload image into server
                    if (fileUpload.HasFile)
                    {
                       string fileName = Server.MapPath("~/img/recipeImg/") + Path.GetFileName(fileUpload.PostedFile.FileName);
                        filename = "~/img/recipeImg/" + Path.GetFileName(fileUpload.PostedFile.FileName);
                        fileUpload.SaveAs(fileName);
                    }
                    
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "INSERT INTO Recipe(UserDataID, Name, Portion, CookingTime, Description,MealTypeID,ImageURL) values(@UserDataID, @Name, @Portion, @CookingTime, @Description,@MealTypeID,@ImageURL)";
                    cmd2.Connection = myConnection;
                    cmd2.CommandType = CommandType.Text;
                    cmd2.CommandText = "SELECT UserDataID FROM UserData WHERE Username ='" + Session["username"].ToString() + "'";
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
                    cmd.Parameters.AddWithValue("@MealTypeID", Convert.ToInt32(DlRecipeType.SelectedValue));
                    cmd.Parameters.AddWithValue("@ImageURL", filename);
                    cmd.ExecuteNonQuery();  //executing query
                    myConnection.Close(); //closing connection
                    //lblMsg.Text = "Registered Successfully..";
                    Session["RecipeAdded"] = txtRecipeName.Text;
                    Response.Redirect("RecipeView.aspx");
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
        protected void AddIngButton_Click(object sender, EventArgs e)
        {
            Response.Cookies["Ingredients"]["FoodItemID"] = DlIngredients.SelectedValue;
            Response.Cookies["Ingredients"]["Amount"] = txtAmount.Text;
            try
            {
                //add ingredients
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO RecipeFoodItem(RecipeID, FoodItemID, Amount) values(@RecipeID, @FoodItemID, @Amount)";

                cmd.Parameters.AddWithValue("@RecipeID", Convert.ToInt32(tmpRecipeID));
                cmd.Parameters.AddWithValue("@FoodItemID", Convert.ToInt32(DlIngredients.SelectedValue));
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(txtAmount.Text));
                cmd.ExecuteNonQuery();  //executing query
                getDB();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
        }
        protected void CheckRecipeID()
        {
            cmd.Connection = myConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MAX(RecipeID) as ID FROM Recipe";
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                if (reader["ID"].ToString() != "")
                {
                    tmpRecipeID = Convert.ToString(Convert.ToInt32(reader["ID"]) + 1);
                }
                else
                {
                    tmpRecipeID = "1";
                }
                notEoF = reader.Read();
            }
            reader.Close();
        }
    }
}


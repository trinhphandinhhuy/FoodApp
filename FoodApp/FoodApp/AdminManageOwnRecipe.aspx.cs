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
        private OleDbCommand myUpdateCommand;
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

            if (Session["userlevel"].ToString() != "Admin") btnManageUserRecipes.Visible = false;
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
            mySelectCommand.CommandText = "SELECT Recipe.RecipeID, Recipe.Name, Recipe.MealTypeID, Recipe.Portion, Recipe.CookingTime, Recipe.Description FROM Recipe INNER JOIN UserData ON Recipe.UserDataID = UserData.UserDataID WHERE UserData.Username = '" + Session["username"].ToString() + "';";
            
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

        protected void AdminRecipeTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            AdminRecipeTable.EditIndex = e.NewEditIndex;
            getDB();
        }

        protected void AdminRecipeTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            AdminRecipeTable.EditIndex = -1;
            getDB();
        }

        protected void AdminRecipeTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = AdminRecipeTable.Rows[e.RowIndex];
            TextBox EditRecipeName = (TextBox)row.FindControl("EditRecipeName");
            DropDownList EditMealType = (DropDownList)row.FindControl("EditMealType");
            DropDownList EditPortion = (DropDownList)row.FindControl("EditPortion");
            DropDownList EditCookingTime = (DropDownList)row.FindControl("EditCookingTime");
            TextBox EditDescription = (TextBox)row.FindControl("EditDescription");
            
            recipeid = Convert.ToInt32(AdminRecipeTable.Rows[e.RowIndex].Cells[1].Text);
            myUpdateCommand = new OleDbCommand("Update Recipe SET Name='" + EditRecipeName.Text + "', MealTypeID= '" + EditMealType.SelectedValue 
                + "', Portion='" + EditPortion.SelectedValue + "', CookingTime='" + EditCookingTime.SelectedValue + "', Description='" + EditDescription.Text + "'  WHERE RecipeID = " + recipeid.ToString(), myConnection);
            myUpdateCommand.CommandType = CommandType.Text;
            myUpdateCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            AdminRecipeTable.EditIndex = -1;
            getDB();
        }

        protected void AdminRecipeTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    //check if is in edit mode
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DropDownList EditMealType = (DropDownList)e.Row.FindControl("EditMealType");
                        OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT * FROM Recipe", myConnection);
                        cmd.CommandType = CommandType.Text;
                        OleDbDataReader reader = cmd.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            EditMealType.Items.Add(reader["MealTypeID"].ToString());
                            EditMealType.Items[EditMealType.Items.Count - 1].Value = reader["MealTypeID"].ToString();
                            notEoF = reader.Read();
                        }
                        reader.Close();

                        DropDownList EditPortion = (DropDownList)e.Row.FindControl("EditPortion");
                        if (EditPortion.Items.Count == 0)
                        {
                            for (int i = 0; i < 10; i++ )
                            {
                                EditPortion.Items.Add(i.ToString());
                                EditPortion.Items[EditPortion.Items.Count - 1].Value = i.ToString();
                            }   
                        }

                        DropDownList EditCookingTime = (DropDownList)e.Row.FindControl("EditCookingTime");
                        if (EditPortion.Items.Count == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                EditCookingTime.Items.Add((i * 15 + 15).ToString());
                                EditCookingTime.Items[EditPortion.Items.Count - 1].Value = (i * 15 + 15).ToString();
                            }
                        }

                    }
                }
            }
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
            Response.Redirect("AdminManageUserRecipes.aspx");
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
            Response.Redirect("UserIngredient.aspx");
        }

    }
}
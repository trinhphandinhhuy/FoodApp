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
    public partial class EditRecipe : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myUpdateCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbCommand cmd2 = new OleDbCommand();
        private OleDbCommand cmd3 = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private OleDbDataReader myReader = null;
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private string user_data_ID;
        private string RecipeID;

        
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
            RecipeID = Request.QueryString["RecipeID"];
            if (!Page.IsPostBack)
            {
                getRecipe();
                getIngredients();               
            }

        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        private void getRecipe()
        {
            mySelectCommand.CommandText = "SELECT * FROM Recipe WHERE RecipeID= " + RecipeID;
            myReader = mySelectCommand.ExecuteReader();
            while (myReader.Read())
            {
                txtRecipeName.Text = myReader["Name"].ToString();
                txtCookingTime.Text = myReader["CookingTime"].ToString();
                txtPortion.Text = myReader["Portion"].ToString();
                txtDescription.Text = myReader["Description"].ToString();
            }
            myReader.Close();   
        }

        private void getIngredients()
        {
            //what is this for?
            //IngredientRecipeDB.DataSource = null;
            //IngredientRecipeDB.DataBind();

            //Define the command objects (SQL commands)
            mySelectCommand.CommandText = "SELECT FoodItem.Name,RecipeFoodItem.Amount, FoodItem.UnitType FROM FoodItem INNER JOIN RecipeFoodItem ON FoodItem.FoodItemID = RecipeFoodItem.FoodItemID Where RecipeID = " + RecipeID;
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
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE Recipe SET Name = @Name, Portion = @Portion, CookingTime = @CookingTime, Description = @Description, MealTypeID = @MealTypeID WHERE RecipeID = " + RecipeID;
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
                    cmd.ExecuteNonQuery();  //executing query
                    getRecipe();
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
        protected void AddIngButton_Click(object sender, EventArgs e)
        {
            try
            {
                //add ingredients
                cmd.Connection = myConnection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE RecipeFoodItem SET FoodItemID = @FoodItemID, Amount = @Amount WHERE RecipeID = " + RecipeID;

                cmd.Parameters.AddWithValue("@FoodItemID", Convert.ToInt32(DlIngredients.SelectedValue));
                cmd.Parameters.AddWithValue("@Amount", Convert.ToDouble(txtAmount.Text));
                cmd.ExecuteNonQuery();  //executing query
                getIngredients();
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message.ToString();
            }
        }

        protected void IngredientRecipeDB_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string selectedIngredient = IngredientRecipeDB.Rows[e.RowIndex].Cells[1].Text;
            myDeleteCommand.CommandText = "DELETE FROM RecipeFoodItem INNER JOIN FoodItem ON FoodItem.FoodItemID = RecipeFoodItem.FoodItemID WHERE RecipeID" + RecipeID + "AND FoodItem.Name = " + selectedIngredient;
            myDeleteCommand.ExecuteNonQuery();
            myConnection.Close();
            getIngredients();
        }



        protected void IngredientRecipeDB_RowEditing(object sender, GridViewEditEventArgs e)
        {
            IngredientRecipeDB.EditIndex = e.NewEditIndex;
            getIngredients();
        }

        protected void IngredientRecipeDB_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = IngredientRecipeDB.Rows[e.RowIndex];
            DropDownList ddlUpdateIngName = (DropDownList)row.FindControl("ddlUpdateIngName");
            TextBox txtUpdateIngAmount = (TextBox)row.FindControl("txtUpdateIngAmount");
            string selectedIngredient = IngredientRecipeDB.Rows[e.RowIndex].Cells[1].Text;
            myUpdateCommand.CommandText = "Update RecipeFoodItem INNER JOIN INNER JOIN FoodItem ON FoodItem.FoodItemID = RecipeFoodItem.FoodItemID"
            + "SET FoodItemID= (SELECT FoodItemID FROM FoodItem WHERE Name = '" + ddlUpdateIngName.SelectedValue 
            + "'), Amount='" + Convert.ToInt32(txtUpdateIngAmount.ToString()) + "'  WHERE RecipeID = " + RecipeID + " AND FoodItemID = (SELECT FoodItemID FROM FoodItem WHERE Name = '" + selectedIngredient + "');";
            myUpdateCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            IngredientRecipeDB.EditIndex = -1;
            getIngredients();
        }

        protected void IngredientRecipeDB_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            IngredientRecipeDB.EditIndex = -1;
            getIngredients();
        }

        protected void IngredientRecipeDB_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    //check if is in edit mode
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DropDownList ddlUpdateIngName = (DropDownList)e.Row.FindControl("ddlUpdateIngName");
                        cmd3.Connection = myConnection;
                        cmd3.CommandText = "SELECT Name FROM FoodItem";
                        myReader = cmd3.ExecuteReader();
                        while (myReader.Read())
                        {
                            ddlUpdateIngName.Items.Add(myReader["Name"].ToString());
                            ddlUpdateIngName.Items[ddlUpdateIngName.Items.Count - 1].Value = myReader["Name"].ToString();
                        }
                        myReader.Close();
                       
                    }
                }
            }
        }

        protected void MealType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


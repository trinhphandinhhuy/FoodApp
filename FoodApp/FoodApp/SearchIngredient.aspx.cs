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
    public partial class SearchIngredient : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand myInsertCommand = new OleDbCommand();
        private OleDbCommand myDeleteCommand;
        private OleDbCommand myUpdateCommand;
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"Database\DatabaseforApp.mdb;";
        private int foodid;
        private OleDbDataReader myReader;

        protected void Page_Init(object sender, EventArgs e)
        {
            //checkAuthentication();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;

            //mySelectCommand.Connection = myConnection;
            mySelectCommand.CommandType = CommandType.Text;
            mySelectCommand.CommandText = "SELECT Name FROM FoodType";
            myReader = mySelectCommand.ExecuteReader();
            bool notEoF;
            //read first row from database
            notEoF = myReader.Read();
            //read row by row until the last row
            if(ddlCategory.Items.Count == 0)
            {
                ddlCategory.Items.Add("All Categories");
                while (notEoF)
                {
                    ddlCategory.Items.Add(myReader["Name"].ToString());
                    notEoF = myReader.Read();
                }
            } else { }
            
            myReader.Close();

        }

        private void getDB()
        {

            FoodTable.DataSource = null;
            FoodTable.DataBind();
            //Define the command objects (SQL commands)
            if(ddlCategory.SelectedItem.Text == "All Categories")
            {
                mySelectCommand.CommandText = "SELECT FoodItem.* FROM FoodItem INNER JOIN FoodType ON FoodItem.FoodTypeID = FoodType.FoodTypeID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%';";
            } else
            {
                mySelectCommand.CommandText = "SELECT FoodItem.* FROM FoodItem INNER JOIN FoodType ON FoodItem.FoodTypeID = FoodType.FoodTypeID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%' AND FoodType.Name = '" + ddlCategory.SelectedItem.Text + "';";
            }
            //Fetching rows into the Data Set

            myAdapter.Fill(myDataSet);
            //Show the users in the Data Grid
            FoodTable.DataSource = myDataSet;
            FoodTable.DataBind();
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
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

        protected void FoodTable_RowEditing(object sender, GridViewEditEventArgs e)
        {
            FoodTable.EditIndex = e.NewEditIndex;
            getDB();
        }

        protected void FoodTable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = FoodTable.Rows[e.RowIndex];
            TextBox txtUpdateFoodName = (TextBox)row.FindControl("txtUpdateFoodName");
            DropDownList ddlUpdateUnitType = (DropDownList)row.FindControl("ddlUpdateUnitType");
            DropDownList ddlUpdateFoodType = (DropDownList)row.FindControl("ddlUpdateFoodType");
            foodid = Convert.ToInt32(FoodTable.Rows[e.RowIndex].Cells[1].Text);
            myUpdateCommand = new OleDbCommand("Update FoodItem SET Name='" + txtUpdateFoodName.Text + "', UnitType='" + ddlUpdateUnitType.SelectedValue + "', FoodTypeID = '" + ddlUpdateFoodType.SelectedValue + "'  WHERE FoodItemID = " + foodid.ToString(), myConnection);
            myUpdateCommand.CommandType = CommandType.Text;
            myUpdateCommand.ExecuteNonQuery(); //executing query
            myConnection.Close(); //closing connection
            FoodTable.EditIndex = -1;
            getDB();
        }

        protected void FoodTable_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            FoodTable.EditIndex = -1;
            getDB();
        }

        protected void FoodTable_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.DataItem != null)
                {
                    //check if is in edit mode
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DropDownList ddlUpdateFoodType = (DropDownList)e.Row.FindControl("ddlUpdateFoodType");
                        OleDbCommand cmd = new OleDbCommand("SELECT * FROM FoodType", myConnection);
                        cmd.CommandType = CommandType.Text;
                        OleDbDataReader reader = cmd.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            ddlUpdateFoodType.Items.Add(reader["Name"].ToString());
                            ddlUpdateFoodType.Items[ddlUpdateFoodType.Items.Count - 1].Value = reader["FoodTypeID"].ToString();
                            notEoF = reader.Read();
                        }
                        reader.Close();
                        DropDownList ddlUpdateUnitType = (DropDownList)e.Row.FindControl("ddlUpdateUnitType");
                        if (ddlUpdateUnitType.Items.Count == 0)
                        {
                            ddlUpdateUnitType.Items.Add("kg");
                            ddlUpdateUnitType.Items[ddlUpdateUnitType.Items.Count - 1].Value = "kg";
                            ddlUpdateUnitType.Items.Add("l");
                            ddlUpdateUnitType.Items[ddlUpdateUnitType.Items.Count - 1].Value = "l";
                        }
                    }
                }
            }
        }

        protected void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            getDB();

        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewIngredient.aspx");
        }

        protected void btnListAllIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAllIngredient.aspx");
        }

        protected void btnSearchIngredient1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchIngredient.aspx");
        }

        protected void Recipes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
            
        }

        protected void MyList_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }
    }
}
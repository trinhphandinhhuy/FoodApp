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
    public partial class ListAllIngredient : System.Web.UI.Page
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
        protected void Page_Init(object sender, EventArgs e)
        {
            //  checkAdminAuthentication();
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getDB();
            }

            if (Session["userlevel"].ToString() != "Admin")
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
        private void checkAdminAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "") { Response.Redirect("Login.aspx"); }
            if (Session["userlevel"] != null && Session["userlevel"].ToString() != "Admin") { Response.Redirect("Login.aspx"); }
        }
        private void getDB()
        {
            
            FoodTable.DataSource = null;
            FoodTable.DataBind();
            //Define the command objects (SQL commands)
            
            mySelectCommand.CommandText = "SELECT * FROM FoodItem";
            //Fetching rows into the Data Set
            
            myAdapter.Fill(myDataSet);
            //Show the users in the Data Grid
            FoodTable.DataSource = myDataSet;
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
                        string[] unitType = { "g", "ml" };
                        if (ddlUpdateUnitType.Items.Count == 0)
                        {
                            foreach (string u in unitType)
                            {
                                ddlUpdateUnitType.Items.Add(u);
                                ddlUpdateUnitType.Items[ddlUpdateUnitType.Items.Count - 1].Value = u;
                            }
                        }
                    }
                }
            }
        }

      
    }
}
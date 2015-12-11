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
        private OleDbCommand cmd, cmd2, cmd3, cmd4;
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int user_data_ID;
        private string filename = "";

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            user_data_ID = Convert.ToInt32(Session["userid"].ToString());
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            MealTypeData.ConnectionString = connstr;
            FoodStuffDS.ConnectionString = connstr;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void AddIngButton_Click(object sender, EventArgs e)
        {
            double num;
            string amount = txtAmount.Text;
            bool isNum = Double.TryParse(amount, out num);
            if (amount != "")
            {
                if (isNum)
                {
                    lbChosenFoodItemID.Items.Add(DlIngredients.SelectedValue);
                    lbChosenFoodItemID.Items[lbChosenFoodItemID.Items.Count - 1].Value = txtAmount.Text;
                    tbChosenFoodItem.Rows.Clear();
                    TableHeaderRow tbHeaderRow = new TableHeaderRow();
                    tbChosenFoodItem.Rows.Add(tbHeaderRow);
                    TableHeaderCell tbHeaderCellName = new TableHeaderCell();
                    TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
                    tbHeaderCellName.Text = "Name";
                    tbHeaderCellAmount.Text = "Amount";
                    tbHeaderRow.Cells.Add(tbHeaderCellName);
                    tbHeaderRow.Cells.Add(tbHeaderCellAmount);
                    for (int k = 0; k < lbChosenFoodItemID.Items.Count; k++)
                    {
                        string foodid = lbChosenFoodItemID.Items[k].Text;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            TableRow tbRow = new TableRow();
                            tbChosenFoodItem.Rows.Add(tbRow);
                            TableCell tbCellName = new TableCell();
                            TableCell tbCellAmount = new TableCell();
                            tbCellName.Text = reader["Name"].ToString();
                            tbCellAmount.Text = lbChosenFoodItemID.Items[k].Value + " " + reader["UnitType"].ToString();
                            tbRow.Cells.Add(tbCellName);
                            tbRow.Cells.Add(tbCellAmount);
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
                }
                else
                {
                    lblAmount.Text = "Amount is Invalid";
                }
            }
            else
            {
                lblAmount.Text = "Amount Required";
            }
            
        } 
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                if (fileUpload.HasFile)
                {
                    string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                    filename = "/img/recipeImg/" + Path.GetFileName(fileUpload.PostedFile.FileName);
                    fileUpload.PostedFile.SaveAs(Server.MapPath("~/img/recipeImg/") + fileName);
                }
                cmd = new OleDbCommand("INSERT INTO Recipe(UserDataID, Name, Portion, CookingTime, Description,MealTypeID,ImageURL) values(@UserDataID, @Name, @Portion, @CookingTime, @Description,@MealTypeID,@ImageURL)", myConnection);
                cmd2 = new OleDbCommand("Select @@Identity", myConnection);
                cmd.CommandType = CommandType.Text;
                cmd2.CommandType = CommandType.Text;
                //adding parameters with value
                cmd.Parameters.AddWithValue("@UserDataID", user_data_ID);
                cmd.Parameters.AddWithValue("@Name", txtRecipeName.Text.ToString());
                cmd.Parameters.AddWithValue("@Portion", Convert.ToInt32(txtPortion.Text));
                cmd.Parameters.AddWithValue("@CookingTime", Convert.ToInt32(txtCookingTime.Text));
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.ToString());
                cmd.Parameters.AddWithValue("@MealTypeID", Convert.ToInt32(DlRecipeType.SelectedValue));
                cmd.Parameters.AddWithValue("@ImageURL", filename);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery(); //executing query
                int newRecipeID = Convert.ToInt32(cmd2.ExecuteScalar());
                if (lbChosenFoodItemID.Items.Count > 0)
                {
                    foreach (ListItem fID in lbChosenFoodItemID.Items)
                    {
                    cmd3 = new OleDbCommand("INSERT INTO RecipeFoodItem(RecipeID, FoodItemID, Amount) values(@RecipeID, @FoodItemID, @Amount)", myConnection);
                    cmd3.CommandType = CommandType.Text;
                    //adding parameters with value
                    cmd3.Parameters.AddWithValue("@RecipeID", newRecipeID.ToString());
                    cmd3.Parameters.AddWithValue("@FoodItemID", fID.Text.ToString());
                    cmd3.Parameters.AddWithValue("@Amount", fID.Value.ToString());
                    cmd3.ExecuteNonQuery();  //executing query
                    }
                }
                cmd4 = new OleDbCommand("INSERT INTO UserRecipe(RecipeID, UserDataID, Owner) values(@RecipeID, @UserDataID, @Owner)", myConnection);
                cmd4.CommandType = CommandType.Text;
                //adding parameters with value
                cmd4.Parameters.AddWithValue("@RecipeID", newRecipeID.ToString());
                cmd4.Parameters.AddWithValue("@UserDataID", user_data_ID.ToString());
                cmd4.Parameters.AddWithValue("@Owner", -1);
                cmd4.ExecuteNonQuery();  //executing query
                myConnection.Close();
                Response.Redirect("AdminManageOwnRecipe.aspx");
            }
            else
            {
                //lblMsg.Text = "Register fail!";
            }
        }
    }
}


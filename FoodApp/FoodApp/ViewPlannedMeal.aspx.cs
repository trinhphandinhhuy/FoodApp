using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace FoodApp
{
    public partial class ViewPlannedMeal : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userID;
        private int plannedMealID;
        private int portion;

        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            checkAuthentication();
            lbRecipePortion.Items.Clear();
            lbFoodItemID.Items.Clear();
            userID = Convert.ToInt32(Session["userid"].ToString());
            if (Request.QueryString["PlannedMealID"] != null && Request.QueryString["PlannedMealID"] != "") { plannedMealID = Convert.ToInt32(Request.QueryString["PlannedMealID"]); }
            else { Response.Redirect("PlannedMealHistory.aspx"); }
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PlannedMeal WHERE PlannedMealID = " + plannedMealID, myConnection);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                lblCreatedDate.Text = reader["CreatedDate"].ToString();
                portion = Convert.ToInt32(reader["Portion"].ToString());
                notEoF = reader.Read();
            }
            reader.Close();
            if (ddlPortion.Items.Count == 0)
            {
                for (int i = 1; i <= 10; i++)
                {
                    ddlPortion.Items.Add(i.ToString());
                    ddlPortion.Items[ddlPortion.Items.Count - 1].Value = i.ToString();
                }
            }
            lblPortion.Text = portion.ToString();
            TableHeaderRow tbHeaderRow = new TableHeaderRow();
            tbRecipe.Rows.Add(tbHeaderRow);
            TableHeaderCell tbHeaderCellName = new TableHeaderCell();
            tbHeaderCellName.Text = "Name";
            tbHeaderRow.Cells.Add(tbHeaderCellName);
            OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM PlannedMealRecipe AS pr INNER JOIN Recipe AS r ON pr.RecipeID = r.RecipeID WHERE pr.PlannedMealID = " + plannedMealID, myConnection);
            cmd2.CommandType = CommandType.Text;
            OleDbDataReader reader2 = cmd2.ExecuteReader();
            bool notEoF2 = reader2.Read();
            while (notEoF2)
            {
                ddlChosenRecipe.Items.Add(reader2["Name"].ToString());
                ddlChosenRecipe.Items[ddlChosenRecipe.Items.Count - 1].Value = reader2["pr.RecipeID"].ToString();
                TableRow tbRow = new TableRow();
                tbRecipe.Rows.Add(tbRow);
                TableCell tbCellName = new TableCell();
                tbCellName.Text = reader2["Name"].ToString();
                tbRow.Cells.Add(tbCellName);
                notEoF2 = reader2.Read();
            }
            reader2.Close();
            string selectString = "SELECT * FROM Recipe AS r INNER JOIN UserRecipe AS ur ON r.RecipeID = ur.RecipeID WHERE ur.UserDataID = " + userID.ToString();
            for (int i = 0; i < ddlChosenRecipe.Items.Count; i++)
            {
                selectString += " AND ur.RecipeID <> " + ddlChosenRecipe.Items[i].Value;
            }
            selectString += " ORDER BY r.Name DESC";
            OleDbCommand cmd3 = new OleDbCommand(selectString, myConnection);
            cmd3.CommandType = CommandType.Text;
            OleDbDataReader reader3 = cmd3.ExecuteReader();
            bool notEoF3 = reader3.Read();
            while (notEoF3)
            {
                ddlRecipe.Items.Add(reader3["Name"].ToString());
                ddlRecipe.Items[ddlRecipe.Items.Count - 1].Value = reader3["ur.RecipeID"].ToString();
                notEoF3 = reader3.Read();
            }
            reader3.Close();
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddNewRecipe_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("INSERT INTO PlannedMealRecipe(PlannedMealID, RecipeID) VALUES(@PlannedMealID, @RecipeID)", myConnection);
            cmd.CommandType = CommandType.Text;
            //adding parameters with value
            cmd.Parameters.AddWithValue("@PlannedMealID", plannedMealID.ToString());
            cmd.Parameters.AddWithValue("@RecipeID", ddlRecipe.SelectedValue.ToString());
            cmd.ExecuteNonQuery(); //executing query
            myConnection.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnRemoveRecipe_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("DELETE FROM PlannedMealRecipe WHERE PlannedMealID = " + plannedMealID.ToString() + " AND RecipeID = " + ddlChosenRecipe.SelectedValue.ToString(), myConnection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery(); //executing query
            myConnection.Close();
            Response.Redirect(Request.RawUrl);
        }

        protected void btnCheckStorage_Click(object sender, EventArgs e)
        {
            bool missingFoodItem = false;
            ArrayList chosenRecipe = new ArrayList();
            if (ddlChosenRecipe.Items.Count > 0)
            {
                for (int i = 0; i < ddlChosenRecipe.Items.Count; i++)
                {
                    chosenRecipe.Add(ddlChosenRecipe.Items[i]);
                }
            }
            //get portion
            lbRecipePortion.Items.Clear();
            if (lbRecipePortion.Items.Count == 0)
            {
                for (int l = 0; l < ddlChosenRecipe.Items.Count; l++)
                {
                    string recipeid = ddlChosenRecipe.Items[l].Value;
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    bool notEoF = reader.Read();
                    while (notEoF)
                    {
                        double basePortion = Convert.ToDouble(reader["Portion"].ToString());
                        double resultPortion = Convert.ToDouble(portion) / basePortion;
                        lbRecipePortion.Items.Add(resultPortion.ToString("F2"));
                        lbRecipePortion.Items[lbRecipePortion.Items.Count - 1].Value = reader["RecipeID"].ToString();
                        notEoF = reader.Read();
                    }
                    reader.Close();
                }
                //get food item
                lbFoodItemID.Items.Clear();
                if (lbFoodItemID.Items.Count == 0)
                {
                    for (int j = 0; j < lbRecipePortion.Items.Count; j++)
                    {
                        string recipeid = lbRecipePortion.Items[j].Value;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM RecipeFoodItem WHERE RecipeID = " + recipeid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            if (lbFoodItemID.Items.Count != 0)
                            {
                                bool checkExistingFoodItem = false;
                                for (int m = 0; m < lbFoodItemID.Items.Count; m++)
                                {
                                    if (reader["FoodItemID"].ToString() == lbFoodItemID.Items[m].Text)
                                    {
                                        checkExistingFoodItem = true;
                                        lbFoodItemID.Items[m].Value = (Convert.ToDouble(lbFoodItemID.Items[m].Value) + Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                    }
                                }
                                if (checkExistingFoodItem == false)
                                {
                                    lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                    lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                }
                            }
                            else
                            {
                                lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                            }
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
                    //check amount from storage
                    OleDbCommand command2 = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString(), myConnection);
                    command2.CommandType = CommandType.Text;
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    bool notEoF2 = reader2.Read();
                    while (notEoF2)
                    {
                        for (int n = 0; n < lbFoodItemID.Items.Count; n++)
                        {
                            if (lbFoodItemID.Items[n].Text == reader2["FoodItemID"].ToString())
                            {
                                if (Convert.ToDouble(lbFoodItemID.Items[n].Value) > Convert.ToDouble(reader2["Amount"].ToString()))
                                {
                                    missingFoodItem = true;
                                }
                            }
                        }
                        notEoF2 = reader2.Read();
                    }
                    reader2.Close();
                }
            }
            if (missingFoodItem)
            {
                lblCheckStorage.Text = "";
                myConnection.Close(); //closing connection
                Session["chosenRecipe"] = chosenRecipe;
                Session["portion"] = portion;
                Response.Redirect("ShoppingList.aspx");
            }
            else
            {
                lblCheckStorage.Text = "User have enough food item to cook the meal";
            }
        }

        protected void btnCook_Click(object sender, EventArgs e)
        {
            bool missingFoodItem = false;
            ArrayList chosenRecipe = new ArrayList();
            if (ddlChosenRecipe.Items.Count > 0)
            {
                for (int i = 0; i < ddlChosenRecipe.Items.Count; i++)
                {
                    chosenRecipe.Add(ddlChosenRecipe.Items[i]);
                }
            }
            //get portion
            if (lbRecipePortion.Items.Count == 0)
            {
                for (int l = 0; l < ddlChosenRecipe.Items.Count; l++)
                {
                    string recipeid = ddlChosenRecipe.Items[l].Value;
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    bool notEoF = reader.Read();
                    while (notEoF)
                    {
                        double basePortion = Convert.ToDouble(reader["Portion"].ToString());
                        double resultPortion = Convert.ToDouble(portion) / basePortion;
                        lbRecipePortion.Items.Add(resultPortion.ToString("F2"));
                        lbRecipePortion.Items[lbRecipePortion.Items.Count - 1].Value = reader["RecipeID"].ToString();
                        notEoF = reader.Read();
                    }
                    reader.Close();
                }
                //get food item
                if (lbFoodItemID.Items.Count == 0)
                {
                    for (int j = 0; j < lbRecipePortion.Items.Count; j++)
                    {
                        string recipeid = lbRecipePortion.Items[j].Value;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM RecipeFoodItem WHERE RecipeID = " + recipeid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            if (lbFoodItemID.Items.Count != 0)
                            {
                                bool checkExistingFoodItem = false;
                                for (int m = 0; m < lbFoodItemID.Items.Count; m++)
                                {
                                    if (reader["FoodItemID"].ToString() == lbFoodItemID.Items[m].Text)
                                    {
                                        checkExistingFoodItem = true;
                                        lbFoodItemID.Items[m].Value = (Convert.ToDouble(lbFoodItemID.Items[m].Value) + Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                    }
                                }
                                if (checkExistingFoodItem == false)
                                {
                                    lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                    lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                }
                            }
                            else
                            {
                                lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                            }
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
                    //check amount from storage
                    OleDbCommand command2 = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString(), myConnection);
                    command2.CommandType = CommandType.Text;
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    bool notEoF2 = reader2.Read();
                    while (notEoF2)
                    {
                        for (int n = 0; n < lbFoodItemID.Items.Count; n++)
                        {
                            if (lbFoodItemID.Items[n].Text == reader2["FoodItemID"].ToString())
                            {
                                if (Convert.ToDouble(lbFoodItemID.Items[n].Value) > Convert.ToDouble(reader2["Amount"].ToString()))
                                {
                                    missingFoodItem = true;
                                }
                            }
                        }
                        notEoF2 = reader2.Read();
                    }
                    reader2.Close();
                }
            }
            if (missingFoodItem)
            {
                lblCheckStorage.Text = "";
                myConnection.Close(); //closing connection
                Session["chosenRecipe"] = chosenRecipe;
                Session["portion"] = portion;
                Response.Redirect("ShoppingList.aspx");
            }
            else
            {
                lblCheckStorage.Text = "";
                for (int n = 0; n < lbFoodItemID.Items.Count; n++)
                {
                    string foodItemID = lbFoodItemID.Items[n].Text;
                    OleDbCommand command = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString() + " AND FoodItemID = " + foodItemID.ToString(), myConnection);
                    command.CommandType = CommandType.Text;
                    OleDbDataReader reader = command.ExecuteReader();
                    bool notEoF = reader.Read();
                    while (notEoF)
                    {
                        if (lbFoodItemID.Items[n].Text == reader["FoodItemID"].ToString())
                        {
                            double amount = Convert.ToDouble(reader["Amount"].ToString()) - Convert.ToDouble(lbFoodItemID.Items[n].Value);
                            OleDbCommand cmd7 = new OleDbCommand("UPDATE UserFoodItem SET Amount = " + amount.ToString() + " WHERE UserDataID = " + userID + " AND FoodItemID = " + lbFoodItemID.Items[n].Text, myConnection);
                            cmd7.CommandType = CommandType.Text;
                            //adding parameters with value
                            cmd7.ExecuteNonQuery();  //executing query
                        }
                        notEoF = reader.Read();
                    }
                    reader.Close();
                }
                lblDone.Text = "Done";
            }
        }

        protected void btnChangePortion_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand("UPDATE PlannedMeal SET Portion = " + ddlPortion.SelectedItem.Value.ToString() + " WHERE PlannedMealID = " + plannedMealID.ToString(), myConnection);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery(); //executing query
            myConnection.Close();
            Response.Redirect(Request.RawUrl);
        }
    }
}
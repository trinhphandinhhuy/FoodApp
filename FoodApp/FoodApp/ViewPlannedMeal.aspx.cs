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
        private bool alreadyCook;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkAuthentication();
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
                lblCreatedDate.Text = reader["CreatedDate"].ToString().Split(' ')[0];
                portion = Convert.ToInt32(reader["Portion"].ToString());
                alreadyCook = Convert.ToBoolean(reader["AlreadyCook"].ToString());
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
            ddlChosenRecipe.Items.Clear();
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
            if (checkFoodStorage())
            {
                lblCheck.Text = "You do not have enough food on the storage";
                btnCheckStorage.Visible = true;
                btnCook.Visible = false;
            }
            else
            {
                lblCheck.Text = "You have enough food on the storage";
                btnCheckStorage.Visible = false;
                btnCook.Visible = true;
            }
            if (checkDate(lblCreatedDate.Text))
            {
                btnAddNewRecipe.Visible = false;
                btnRemoveRecipe.Visible = false;
                btnChangePortion.Visible = false;
                btnCheckStorage.Visible = false;
                btnCook.Visible = false;
                ddlChosenRecipe.Visible = false;
                ddlPortion.Visible = false;
                ddlRecipe.Visible = false;
            }
            if (alreadyCook)
            {
                lblCheck.Text = "You have already cooked this meal";
                btnAddNewRecipe.Visible = false;
                btnRemoveRecipe.Visible = false;
                btnChangePortion.Visible = false;
                btnCheckStorage.Visible = false;
                btnCook.Visible = false;
                ddlChosenRecipe.Visible = false;
                ddlPortion.Visible = false;
                ddlRecipe.Visible = false;
            }
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        private bool checkFoodStorage()
        {
            bool missingFoodItem = false;
            bool nonExisting = false;
            //get portion
            if (lbRecipePortion.Items.Count == 0)
            {
                foreach (ListItem cr in ddlChosenRecipe.Items)
                {
                    string recipeid = cr.Value;
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
                    foreach (ListItem rP in lbRecipePortion.Items)
                    {
                        string recipeid = rP.Value;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM RecipeFoodItem WHERE RecipeID = " + recipeid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            if (lbFoodItemID.Items.Count != 0)
                            {
                                bool checkExistingFoodItem = false;
                                foreach (ListItem fID in lbFoodItemID.Items)
                                {
                                    if (reader["FoodItemID"].ToString() == fID.Text)
                                    {
                                        checkExistingFoodItem = true;
                                        fID.Value = (Convert.ToDouble(fID.Value) + Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(rP.Text)).ToString();
                                    }
                                }
                                if (checkExistingFoodItem == false)
                                {
                                    lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                    lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(rP.Text)).ToString();
                                }
                            }
                            else
                            {
                                lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(rP.Text)).ToString();
                            }
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
                    //check amount from storage
                    foreach (ListItem fID in lbFoodItemID.Items)
                    {
                        OleDbCommand command2 = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString() + " AND FoodItemID = " + fID.Text, myConnection);
                        command2.CommandType = CommandType.Text;
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        bool notEoF2 = reader2.Read();
                        if (reader2.HasRows)
                        {
                            while (notEoF2)
                            {
                                if (Convert.ToDouble(fID.Value) > Convert.ToDouble(reader2["Amount"].ToString()))
                                {
                                    missingFoodItem = true;
                                }
                                notEoF2 = reader2.Read();
                            }
                            reader2.Close();
                        }
                        else
                        {
                            nonExisting = true;
                        }
                    }
                }
            }
            if (missingFoodItem || nonExisting)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool checkDate(string past)
        {
            DateTime now = DateTime.Now.Date;
            DateTime check = Convert.ToDateTime(past).Date;
            if (now > check) { return true; }
            else { return false; }
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
            ListItemCollection chosenRecipe = new ListItemCollection();
            if (ddlChosenRecipe.Items.Count > 0)
            {
                foreach (ListItem cR in ddlChosenRecipe.Items)
                {
                    chosenRecipe.Add(cR);
                }
            }
            myConnection.Close(); //closing connection
            Session["chosenRecipe"] = chosenRecipe;
            Session["portion"] = portion;
            Response.Redirect("ShoppingList.aspx");
        }

        protected void btnCook_Click(object sender, EventArgs e)
        {
            foreach (ListItem fID in lbFoodItemID.Items)
            {
                OleDbCommand command = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + userID.ToString() + " AND FoodItemID = " + fID.Text, myConnection);
                command.CommandType = CommandType.Text;
                OleDbDataReader reader = command.ExecuteReader();
                bool notEoF = reader.Read();
                while (notEoF)
                {
                    if (fID.Text == reader["FoodItemID"].ToString())
                    {
                        double amount = Convert.ToDouble(reader["Amount"].ToString()) - Convert.ToDouble(fID.Value);
                        OleDbCommand cmd = new OleDbCommand("UPDATE UserFoodItem SET Amount = " + amount.ToString() + " WHERE UserDataID = " + userID + " AND FoodItemID = " + fID.Text, myConnection);
                        cmd.CommandType = CommandType.Text;
                        //adding parameters with value
                        cmd.ExecuteNonQuery();  //executing query
                    }
                    notEoF = reader.Read();
                }
                reader.Close();
            }
            OleDbCommand updateCommand = new OleDbCommand("UPDATE PlannedMeal SET AlreadyCook = -1 WHERE UserDataID = " + userID + " AND PlannedMealID = " + plannedMealID.ToString(), myConnection);
            updateCommand.CommandType = CommandType.Text;
            updateCommand.ExecuteNonQuery();  //executing query
            myConnection.Close();
            Response.Redirect(Request.RawUrl);
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
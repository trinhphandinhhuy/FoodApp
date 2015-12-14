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
    public partial class AddShoppingList : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7;
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int user_data_ID;

        protected void Page_Load(object sender, EventArgs e)
        {
            checkAuthentication();
            txtDate.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            user_data_ID = Convert.ToInt32(Session["userid"].ToString());
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            if (ddlFoodItem.Items.Count == 0)
            {
                cmd6 = new OleDbCommand("SELECT * FROM FoodItem ORDER BY Name ASC", myConnection);
                cmd6.CommandType = CommandType.Text;
                OleDbDataReader reader = cmd6.ExecuteReader();
                bool notEoF = reader.Read();
                while (notEoF)
                {
                    ddlFoodItem.Items.Add(reader["Name"].ToString());
                    ddlFoodItem.Items[ddlFoodItem.Items.Count - 1].Value = reader["FoodItemID"].ToString();
                    notEoF = reader.Read();
                }
                reader.Close();
            }
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddFoodItemToShoppingList_Click(object sender, EventArgs e)
        {
            double num;
            string amount = txtAmount.Text;
            bool isNum = Double.TryParse(amount, out num);
            if (amount != "")
            {
                if (isNum)
                {
                    lbFoodItemID.Items.Add(ddlFoodItem.SelectedValue);
                    lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = txtAmount.Text;
                    tbFoodItem.Rows.Clear();
                    TableHeaderRow tbHeaderRow = new TableHeaderRow();
                    tbFoodItem.Rows.Add(tbHeaderRow);
                    TableHeaderCell tbHeaderCellName = new TableHeaderCell();
                    TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
                    tbHeaderCellName.Text = "Name";
                    tbHeaderCellAmount.Text = "Amount";
                    tbHeaderRow.Cells.Add(tbHeaderCellName);
                    tbHeaderRow.Cells.Add(tbHeaderCellAmount);
                    for (int k = 0; k < lbFoodItemID.Items.Count; k++)
                    {
                        string foodid = lbFoodItemID.Items[k].Text;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            TableRow tbRow = new TableRow();
                            tbFoodItem.Rows.Add(tbRow);
                            TableCell tbCellName = new TableCell();
                            TableCell tbCellAmount = new TableCell();
                            tbCellName.Text = reader["Name"].ToString();
                            tbCellAmount.Text = lbFoodItemID.Items[k].Value + " " + reader["UnitType"].ToString();
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

        protected void btnConfirmShoppingList_Click(object sender, EventArgs e)
        {
            if(lbFoodItemID.Items.Count != 0)
            {
                if (txtDate.Text != "")
                {
                    cmd = new OleDbCommand("INSERT INTO ShoppingList(UserDataID, CreatedDate) values(@UserDataID, @CreatedDate)", myConnection);
                    cmd2 = new OleDbCommand("Select @@Identity", myConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd2.CommandType = CommandType.Text;
                    //adding parameters with value
                    cmd.Parameters.AddWithValue("@UserDataID", user_data_ID);
                    cmd.Parameters.AddWithValue("@CreatedDate", txtDate.Text.ToString());
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery(); //executing query
                    int newShoppingListID = Convert.ToInt32(cmd2.ExecuteScalar());
                    if (lbFoodItemID.Items.Count > 0)
                    {
                        foreach (ListItem fID in lbFoodItemID.Items)
                        {
                            cmd3 = new OleDbCommand("INSERT INTO ShoppingListFoodItem(ShoppingListID, FoodItemID, Amount) values(@ShoppingListID, @FoodItemID, @Amount)", myConnection);
                            cmd3.CommandType = CommandType.Text;
                            //adding parameters with value
                            cmd3.Parameters.AddWithValue("@RecipeID", newShoppingListID.ToString());
                            cmd3.Parameters.AddWithValue("@FoodItemID", fID.Text.ToString());
                            cmd3.Parameters.AddWithValue("@Amount", fID.Value.ToString());
                            cmd3.ExecuteNonQuery();  //executing query
                            cmd5 = new OleDbCommand("SELECT * FROM UserFoodItem WHERE UserDataID = " + user_data_ID, myConnection);
                            cmd5.CommandType = CommandType.Text;
                            OleDbDataReader reader = cmd5.ExecuteReader();
                            bool notEoF = reader.Read();
                            while (notEoF)
                            {
                                bool existingFoodItem = false;
                                foreach (ListItem f in lbFoodItemID.Items)
                                {
                                    if (Convert.ToInt32(f.Text) == Convert.ToInt32(reader["FoodItemID"].ToString()))
                                    {
                                        existingFoodItem = true;
                                    }
                                }
                                if (existingFoodItem)
                                {
                                    double amount = Convert.ToDouble(fID.Value) + Convert.ToDouble(reader["Amount"].ToString());
                                    cmd7 = new OleDbCommand("UPDATE UserFoodItem SET Amount = " + amount.ToString() + " WHERE UserDataID = " + user_data_ID + " AND FoodItemID = " + fID.Text, myConnection);
                                    cmd7.CommandType = CommandType.Text;
                                    //adding parameters with value
                                    cmd7.ExecuteNonQuery();  //executing query
                                }
                                else
                                {
                                    cmd4 = new OleDbCommand("INSERT INTO UserFoodItem(UserDataID, FoodItemID, Amount) values(@UserDataID, @FoodItemID, @Amount)", myConnection);
                                    cmd4.CommandType = CommandType.Text;
                                    cmd4.Parameters.AddWithValue("@UserDataID", user_data_ID.ToString());
                                    cmd4.Parameters.AddWithValue("@FoodItemID", fID.Text);
                                    cmd4.Parameters.AddWithValue("@Amount", fID.Value);
                                    cmd4.ExecuteNonQuery();  //executing query
                                }
                                notEoF = reader.Read();
                            }
                            reader.Close();
                        }
                    }
                    myConnection.Close();
                    Response.Redirect("ShoppingListHistory.aspx");
                }
                else
                {
                    lblCheck.Text = "Please select a date";
                }
            }
            else
            {
                lblCheck.Text = "Please add a food item";
            }
        }
    }
}
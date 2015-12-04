using System;
using System.Collections;
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
    public partial class ShoppingList : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int portion = 0;
            if (Session["portion"].ToString() != "" && Session["portion"].ToString() != null)
            {
                portion = Convert.ToInt32(Session["portion"].ToString());
                lblPortion.Text = Session["portion"].ToString();
            }
            if (lbRecipe.Items.Count == 0)
            {
                ArrayList chosenRecipe = (ArrayList)Session["chosenRecipe"];
                for (int i = 0; i < chosenRecipe.Count; i++)
                {
                    lbRecipe.Items.Add(((ListItem)chosenRecipe[i]));
                }
                if (lbRecipePortion.Items.Count == 0)
                {
                    for (int l = 0; l < lbRecipe.Items.Count; l++)
                    {
                        string recipeid = lbRecipe.Items[l].Value;
                        OleDbCommand command = new OleDbCommand("SELECT * FROM Recipe WHERE RecipeID = " + recipeid.ToString(), myConnection);
                        command.CommandType = CommandType.Text;
                        OleDbDataReader reader = command.ExecuteReader();
                        bool notEoF = reader.Read();
                        while (notEoF)
                        {
                            
                            int basePortion = Convert.ToInt32(reader["Portion"].ToString());
                            double resultPortion = portion / basePortion;
                            
                            lbRecipePortion.Items.Add(resultPortion.ToString());
                            lbRecipePortion.Items[lbRecipePortion.Items.Count - 1].Value = reader["RecipeID"].ToString();
                            notEoF = reader.Read();
                        }
                        reader.Close();
                    }
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
                                lbFoodItemID.Items.Add(reader["FoodItemID"].ToString());
                                lbFoodItemID.Items[lbFoodItemID.Items.Count - 1].Value = (Convert.ToDouble(reader["Amount"].ToString()) * Convert.ToDouble(lbRecipePortion.Items[j].Text)).ToString();
                                notEoF = reader.Read();
                            }
                            reader.Close();
                        }
                        if (lbFoodItem.Items.Count == 0)
                        {
                            for (int k = 0; k < lbFoodItemID.Items.Count; k++)
                            {
                                string foodid = lbFoodItemID.Items[k].Text;
                                OleDbCommand command = new OleDbCommand("SELECT * FROM FoodItem WHERE FoodItemID = " + foodid.ToString(), myConnection);
                                command.CommandType = CommandType.Text;
                                OleDbDataReader reader = command.ExecuteReader();
                                bool notEoF = reader.Read();
                                while (notEoF)
                                {
                                    lbFoodItem.Items.Add(reader["Name"].ToString());
                                    lbFoodItem.Items[lbFoodItem.Items.Count - 1].Value = lbFoodItemID.Items[k].Value + " " + reader["UnitType"].ToString();
                                    notEoF = reader.Read();
                                }
                                reader.Close();
                            }
                        }
                    }
                }
            }
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            lblCheck.Text = lbFoodItem.SelectedValue;
        }
    }
}
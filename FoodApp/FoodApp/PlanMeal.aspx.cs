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
    public partial class PlanMeal : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        private string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userid;
        private ArrayList listbox1 = new ArrayList();
        private ArrayList listbox2 = new ArrayList();

        protected void Page_Init(object sender, EventArgs e)
        {
            checkUserAuthentication();
            txtDate.Attributes["min"] = DateTime.Now.ToString("yyyy-MM-dd");
            userid = Convert.ToInt32(Session["userid"].ToString());
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            if (ddlRecipe.Items.Count == 0)
            {
                OleDbCommand command1 = new OleDbCommand("SELECT * FROM UserRecipe AS ur INNER JOIN Recipe AS r ON r.RecipeID = ur.RecipeID WHERE ur.UserDataID = " + userid.ToString() + " ORDER BY r.Name ASC", myConnection);
                command1.CommandType = CommandType.Text;
                OleDbDataReader reader1 = command1.ExecuteReader();
                bool notEoF1 = reader1.Read();
                while (notEoF1)
                {
                    ddlRecipe.Items.Add(reader1["Name"].ToString());
                    ddlRecipe.Items[ddlRecipe.Items.Count - 1].Value = reader1["r.RecipeID"].ToString();
                    notEoF1 = reader1.Read();
                }
                reader1.Close();
            }
            int maxPortion = 10;
            if (ddlPortion.Items.Count == 0)
            {
                for (int i = 1; i <= maxPortion; i++)
                {
                    ddlPortion.Items.Add(i.ToString());
                    ddlPortion.Items[ddlPortion.Items.Count - 1].Value = i.ToString();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void checkUserAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAddRecipeToPlannedMeal_Click(object sender, EventArgs e)
        {
            if (ddlRecipe.SelectedIndex >= 0)
            {
                for (int i = 0; i < ddlRecipe.Items.Count; i++)
                {
                    if (ddlRecipe.Items[i].Selected)
                    {
                        if (!listbox1.Contains(ddlRecipe.Items[i]))
                        {
                            listbox1.Add(ddlRecipe.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < listbox1.Count; i++)
                {
                    if (!lbChosenRecipe.Items.Contains(((ListItem)listbox1[i])))
                    {
                        lbChosenRecipe.Items.Add(((ListItem)listbox1[i]));
                    }
                    ddlRecipe.Items.Remove(((ListItem)listbox1[i]));
                }
                lbChosenRecipe.SelectedIndex = -1;
            }
        }

        protected void btnRemoveChosenRecipe_Click(object sender, EventArgs e)
        {
            if (lbChosenRecipe.SelectedIndex >= 0)
            {
                for (int i = 0; i < lbChosenRecipe.Items.Count; i++)
                {
                    if (lbChosenRecipe.Items[i].Selected)
                    {
                        if (!listbox2.Contains(lbChosenRecipe.Items[i]))
                        {
                            listbox2.Add(lbChosenRecipe.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < listbox2.Count; i++)
                {
                    if (!ddlRecipe.Items.Contains(((ListItem)listbox2[i])))
                    {
                        ddlRecipe.Items.Add(((ListItem)listbox2[i]));
                    }
                    lbChosenRecipe.Items.Remove(((ListItem)listbox2[i]));
                }
                ddlRecipe.SelectedIndex = -1;
            }
        }

        protected void btnConfirmPlannedMeal_Click(object sender, EventArgs e)
        {
            if (lbChosenRecipe.Items.Count != 0)
            {
                if (txtDate.Text != "")
                {
                    int portion = Convert.ToInt32(ddlPortion.SelectedValue);
                    ListItemCollection chosenRecipe = new ListItemCollection();
                    OleDbCommand command = new OleDbCommand("INSERT INTO PlannedMeal(UserDataID, Portion, CreatedDate) VALUES(@UserDataID, @Portion, @CreatedDate)", myConnection);
                    OleDbCommand command2 = new OleDbCommand("Select @@Identity", myConnection);
                    command.CommandType = CommandType.Text;
                    command2.CommandType = CommandType.Text;
                    //adding parameters with value
                    command.Parameters.AddWithValue("@UserDataID", userid.ToString());
                    command.Parameters.AddWithValue("@Portion", portion.ToString());
                    command.Parameters.AddWithValue("@CreatedDate", txtDate.Text.ToString());
                    command.ExecuteNonQuery(); //executing query
                    command2.ExecuteNonQuery(); //executing query
                    int plannedMealID = Convert.ToInt32(command2.ExecuteScalar());
                    if (lbChosenRecipe.Items.Count > 0)
                    {
                        foreach (ListItem cr in lbChosenRecipe.Items)
                        {
                            chosenRecipe.Add(cr);
                            int recipeID = Convert.ToInt32(cr.Value);
                            OleDbCommand insertCommand = new OleDbCommand("INSERT INTO PlannedMealRecipe(PlannedMealID, RecipeID) VALUES(@PlannedMealID, @RecipeID)", myConnection);
                            insertCommand.CommandType = CommandType.Text;
                            //adding parameters with value
                            insertCommand.Parameters.AddWithValue("@PlannedMealID", plannedMealID.ToString());
                            insertCommand.Parameters.AddWithValue("@RecipeID", recipeID.ToString());
                            insertCommand.ExecuteNonQuery();  //executing query
                        }
                    }
                    myConnection.Close(); //closing connection
                    Session["chosenRecipe"] = chosenRecipe;
                    Session["portion"] = portion;
                    Response.Redirect("ShoppingList.aspx");
                }
                else
                {
                    lblCheckChosenRecipe.Text = "Please choose a date";
                }
            }
            else
            {
                lblCheckChosenRecipe.Text = "Please choose an recipe";
            }
        }
    }
}
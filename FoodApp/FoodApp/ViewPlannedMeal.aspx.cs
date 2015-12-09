using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            int plannedMealID = 0;
            if (Request.QueryString["PlannedMealID"] != null && Request.QueryString["PlannedMealID"] != "")
            {
                plannedMealID = Convert.ToInt32(Request.QueryString["PlannedMealID"]);
            }
            else
            {
                Response.Redirect("PlannedMealHistory.aspx");
            }
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM PlannedMeal WHERE PlannedMealID = " + plannedMealID, myConnection);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                lblPlannedMealID.Text = reader["PlannedMealID"].ToString();
                lblCreatedDate.Text = reader["CreatedDate"].ToString();
                lblPortion.Text = reader["Portion"].ToString();
                notEoF = reader.Read();
            }
            reader.Close();
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
                TableRow tbRow = new TableRow();
                tbRecipe.Rows.Add(tbRow);
                TableCell tbCellName = new TableCell();
                tbCellName.Text = reader2["Name"].ToString();
                tbRow.Cells.Add(tbCellName);
                notEoF2 = reader2.Read();
            }
            reader2.Close();
        }
    }
}
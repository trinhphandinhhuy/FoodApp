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
    public partial class ViewSPList : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";

        protected void Page_Load(object sender, EventArgs e)
        {
            int shoppingListID = 0;
            if (Request.QueryString["ShoppingListID"] != null && Request.QueryString["ShoppingListID"] != "")
            {
                shoppingListID = Convert.ToInt32(Request.QueryString["ShoppingListID"]);
            }
            else
            {
                Response.Redirect("ShoppingListHistory.aspx");
            }
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM ShoppingList WHERE ShoppingListID = " + shoppingListID, myConnection);
            cmd.CommandType = CommandType.Text;
            OleDbDataReader reader = cmd.ExecuteReader();
            bool notEoF = reader.Read();
            while (notEoF)
            {
                lblCreatedDate.Text = reader["CreatedDate"].ToString().Split(' ')[0].ToString();
                notEoF = reader.Read();
            }
            reader.Close();
            TableHeaderRow tbHeaderRow = new TableHeaderRow();
            tbFoodItem.Rows.Add(tbHeaderRow);
            TableHeaderCell tbHeaderCellName = new TableHeaderCell();
            TableHeaderCell tbHeaderCellAmount = new TableHeaderCell();
            tbHeaderCellName.Text = "Name";
            tbHeaderCellAmount.Text = "Amount";
            tbHeaderRow.Cells.Add(tbHeaderCellName);
            tbHeaderRow.Cells.Add(tbHeaderCellAmount);
            OleDbCommand cmd2 = new OleDbCommand("SELECT * FROM FoodItem AS f INNER JOIN ShoppingListFoodItem AS sf ON f.FoodItemID = sf.FoodItemID WHERE sf.ShoppingListID = " + shoppingListID, myConnection);
            cmd2.CommandType = CommandType.Text;
            OleDbDataReader reader2 = cmd2.ExecuteReader();
            bool notEoF2 = reader2.Read();
            while (notEoF2)
            {
                TableRow tbRow = new TableRow();
                tbFoodItem.Rows.Add(tbRow);
                TableCell tbCellName = new TableCell();
                TableCell tbCellAmount = new TableCell();
                tbCellName.Text = reader2["Name"].ToString();
                tbCellAmount.Text = reader2["Amount"].ToString() + " " + reader2["UnitType"].ToString();
                tbRow.Cells.Add(tbCellName);
                tbRow.Cells.Add(tbCellAmount);
                notEoF2 = reader2.Read();
            }
            reader2.Close();
        }
    }
}
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
        OleDbConnection myConnection = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        OleDbCommand cmd2 = new OleDbCommand();
        OleDbDataReader myReader;

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            String connstr;

            connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
            myConnection.ConnectionString = connstr;
            myConnection.Open();

            cmd.Connection = myConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Name FROM FoodType";
            myReader = cmd.ExecuteReader();
            bool notEoF;
            //read first row from database
            notEoF = myReader.Read();
            //read row by row until the last row
            if(ddlCategory.Items.Count == 0)
            {
                while (notEoF)
                {
                    ddlCategory.Items.Add(myReader["Name"].ToString());
                    notEoF = myReader.Read();
                }
            } else { }
            
            myReader.Close();

        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            int countRow = 0;
            cmd.Connection = myConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM FoodItem INNER JOIN FoodType ON FoodItem.FoodTypeID = FoodType.FoodTypeID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%' AND FoodType.Name = '" + ddlCategory.SelectedItem.Text + "';";
            countRow = (int)cmd.ExecuteScalar();
            if(countRow > 0)
            {
                cmd.CommandText = "SELECT FoodItem.Name FROM FoodItem INNER JOIN FoodType ON FoodItem.FoodTypeID = FoodType.FoodTypeID WHERE FoodItem.Name LIKE '%" + txtBoxSearchName.Text + "%' AND FoodType.Name = '" + ddlCategory.SelectedItem.Text + "';";
                myReader = cmd.ExecuteReader();
                myReader.Read();
                for (int i = 0; i < countRow; i++)
                {
                    TableRow tRow = new TableRow();
                    tblSearchIngredient.Rows.Add(tRow);
                    TableCell tCell = new TableCell();
                    tCell.Text = myReader["Name"].ToString();
                    tRow.Cells.Add(tCell);
                    myReader.Read();
                }
            } else
            {
                TableRow tRow = new TableRow();
                tblSearchIngredient.Rows.Add(tRow);
                TableCell tCell = new TableCell();
                tCell.Text = "No results found";
                tRow.Cells.Add(tCell);
            }
           // ddlCategory.Items.Clear();
        }
    }
}
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
    public partial class ShoppingListHistory : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        string connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private int userID;

        protected void Page_Init(object sender, EventArgs e)
        {
            checkAuthentication();
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            userID = Convert.ToInt32(Session["userid"].ToString());
        }

        private void checkAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            AjaxControlToolkit.Accordion Accordion1 = new AjaxControlToolkit.Accordion();
            Accordion1.ID = "acc1";
            
            AjaxControlToolkit.AccordionPane pane1 = new AjaxControlToolkit.AccordionPane();
            pane1.ID = "pane1";
            pane1.HeaderContainer.Controls.Add(new LiteralControl("Pane 1"));
            pane1.ContentContainer.Controls.Add(new LiteralControl("This is Accordion Pane No 1"));
            AjaxControlToolkit.AccordionPane pane2 = new AjaxControlToolkit.AccordionPane();
            pane2.ID = "pane2";
            pane2.HeaderContainer.Controls.Add(new LiteralControl("Pane 2"));
            pane2.ContentContainer.Controls.Add(new LiteralControl("This is Accordion Pane No 2"));
    
            Accordion1.Panes.Add(pane1);
            this.Controls.Add(Accordion1);
            */
            
            OleDbCommand command = new OleDbCommand("SELECT * FROM ShoppingList WHERE UserDataID = " + userID, myConnection);
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(command);
            da.Fill(dt);
            ShoppingList.DataSource = dt;
            ShoppingList.DataBind();

            myConnection.Close();
        }
    }
}
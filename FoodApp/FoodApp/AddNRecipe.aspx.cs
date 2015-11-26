using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;

namespace FoodApp
{
    public partial class AddNRecipe : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand mySelectCommand = new OleDbCommand();
        private OleDbCommand cmd = new OleDbCommand();
        private OleDbCommand cmd2 = new OleDbCommand();
        private OleDbDataAdapter myAdapter = new OleDbDataAdapter();
        private DataSet myDataSet = new DataSet();
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0;" +
             @"Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
        private string user_data_ID;
        private string tmpRecipeID;

        protected void Page_Init(object sender, EventArgs e)
        {
            
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            mySelectCommand.Connection = myConnection;
            myAdapter.SelectCommand = mySelectCommand;
            MealTypeData.ConnectionString = connstr;
            FoodStuffDS.ConnectionString = connstr;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }

        }
        protected void Upload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/img/") + filename);
                /*Uploaded file path*/
                string filePath = "~/img/" + filename;
                /*******************************************/
                /*Code to save the file path into data base*/
                /*******************************************/
                lblmessage.Text = "File uploaded successfully.";
                Image1.ImageUrl = filePath;
            }
            else
            {
                lblmessage.Text = "Please select file.";
            }
        }

        protected void MealTypeData_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}
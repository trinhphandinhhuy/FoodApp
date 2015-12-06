using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Import namespace OleDb for databases (outside class)
using System.Data.OleDb;
//System.Data for command object
using System.Data;

namespace FoodApp
{
    public partial class ExploringRecipes : System.Web.UI.Page
    {
        private OleDbConnection myConnection = new OleDbConnection();
        private OleDbCommand cmd = new OleDbCommand();
        String connstr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + System.AppDomain.CurrentDomain.BaseDirectory + @"\Database\DatabaseforApp.mdb;";
       

        protected void Page_Load(object sender, EventArgs e)

        {
            myConnection.ConnectionString = connstr;
            myConnection.Open();
            cmd.Connection = myConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Recipe.Name, Recipe.ImageURL, UserData.Username FROM UserData INNER JOIN Recipe ON UserData.UserDataID = Recipe.UserDataID; ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd); 
            da.Fill(dt);
            RecipeList.DataSource = dt;
            RecipeList.DataBind();

            myConnection.Close();
        }
    }
}
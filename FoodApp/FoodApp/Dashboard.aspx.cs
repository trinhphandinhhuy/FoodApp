using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp
{
    public partial class SuccessLogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Convert.ToString(Session["userlevel"])) ==  "1")
            {
                Label1.Text = "Admin";


            }
            else
            {
                Label1.Text = Convert.ToString(Session["username"]);
            }
        }
    }
}
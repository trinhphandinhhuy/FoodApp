using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp.MasterPage
{
    public partial class MPIngreManagement : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user_level = Session["userlevel"].ToString();
            if (user_level == "admin")
            {
                AdminMenu.Visible = true;
            }
            else
            {
                AdminMenu.Visible = false;
            }
        }
    }
}
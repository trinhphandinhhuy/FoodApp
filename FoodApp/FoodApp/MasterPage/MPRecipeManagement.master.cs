using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp.MasterPage
{
    public partial class MPRecipeManagement : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlevel"].ToString() == "Admin")
            {
                AdminManageRe.Visible = true;
                
            }
            else
            {
                AdminManageRe.Visible = false;              
            }

        }
    }
}
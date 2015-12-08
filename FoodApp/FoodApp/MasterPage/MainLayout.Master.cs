using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp.MasterPage
{
    public partial class MainLayout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //check show of button
            if (Session["userlevel"].ToString() == "Admin")
            {
               
                AdminIngredientTab.Visible = true;
                AdminManageRe.Visible = true;
                ShopingListTab.Visible = false;
                UserIngredientTab.Visible = false;
                AdminManagementTab.Visible = true;
                IngreAdminTab.Visible = true;
                IngreUsertab.Visible = false;
                ShoppinglistUserTab.Visible = false;
                UsermanaAdminTab.Visible = true;
            }
            else
            {
                
                AdminIngredientTab.Visible = false;
                AdminManageRe.Visible = false;
                ShopingListTab.Visible = true;
                UserIngredientTab.Visible = true;
                AdminManagementTab.Visible = false;
                IngreAdminTab.Visible = false;
                IngreUsertab.Visible = true;
                ShoppinglistUserTab.Visible = true;
                UsermanaAdminTab.Visible = false;
            }

            //print username
            if ((Convert.ToString(Session["userlevel"])) == "1")
            {
                UserNameAc.Text = "Admin";
            }
            else
            {
                UserNameAc.Text = Convert.ToString(Session["username"]);
            }
        
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
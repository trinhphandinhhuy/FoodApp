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
            checkUserAuthentication();
            if ((Convert.ToString(Session["userlevel"])) ==  "1")
            {
                Label1.Text = "Admin";
            }
            else
            {
                Label1.Text = Convert.ToString(Session["username"]);
            }

        }
        private void checkUserAuthentication()
        {
            if (Session["username"] == null || Session["username"].ToString() == "" || Session["userlevel"] == null || Session["userlevel"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void User_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }

        protected void Recipes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }
    }
}
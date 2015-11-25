using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp
{
    public partial class ManageIngredient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlevel"].ToString() != "Admin")
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnListAllIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAllIngredient.aspx");
        }

        protected void btnSearchIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchIngredient.aspx");
        }

        protected void btnAddIngredient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewIngredient.aspx");
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
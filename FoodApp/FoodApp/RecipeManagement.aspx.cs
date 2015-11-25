using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp
{
    public partial class RecipeManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlevel"].ToString() == "Admin")
            {
                btnManageUserRecipes.Visible = true;
            }
            else
            {
                btnManageUserRecipes.Visible = false;
                Ingredients.Visible = false;
            }
            
        }

        protected void Recipes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void MyList_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }

        protected void btnManageOwnRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageOwnRecipe.aspx");
        }

        protected void btnManageUserRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageUserRecipes.aspx");
        }

        protected void btnAddRecipe_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddRecipe.aspx");
        }

        protected void btnExploreRecipes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExploringRecipes.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
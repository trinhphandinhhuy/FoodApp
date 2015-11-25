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

        protected void Recipes_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("RecipeManagement.aspx");
        }
    }
}
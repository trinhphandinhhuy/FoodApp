using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodApp
{
    public partial class UserManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userlevel"].ToString() == "Admin")
            {
                AdminFunction.Visible = true;
            }
            else
            {
                AdminFunction.Visible = false;
            }
        }

        protected void Ingredients_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ManageIngredient.aspx");
        }

        protected void User_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("UserManagement.aspx");
        }

        protected void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminAddUser.aspx");
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDeleteUser.aspx");
        }

        protected void btnEditUsernameAndEmail_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeUsernameAndEmail.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }
    }
}
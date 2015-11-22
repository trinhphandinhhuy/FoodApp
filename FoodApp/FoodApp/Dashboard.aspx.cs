﻿using System;
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
            /* ContentPlaceHolder content = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
             Button newButton = new System.Web.UI.WebControls.Button();
             newButton.ID = "btnAddNewIng";
             newButton.Text = "Add new Ingredient";
             newButton.Visible = true;
             newButton.CssClass = "btn btn-info";          
             content.Controls.Add(newButton);*/

          
        }
    }
}
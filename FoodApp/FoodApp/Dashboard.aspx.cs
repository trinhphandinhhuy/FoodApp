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
    }
}
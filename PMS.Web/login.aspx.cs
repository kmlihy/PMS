﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class login : System.Web.UI.Page
    {
        public string code;
        protected string account;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = Request.Form["userName"].ToString();
            //code = Session["code"].ToString().ToLower();
        }
    }
}
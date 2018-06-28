using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected string getName = "";
        protected int getCurrentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Response.Write("第一次");
            }
            else
            {
                Response.Write("不是第一次");
            }
        }
    }
}
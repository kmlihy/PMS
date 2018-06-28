using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Title titleId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleBll titleBll = new TitleBll();
            string tId = Request.QueryString["titleId"];
            titleId = titleBll.GetTitle(int.Parse(tId));
        }
    }
}
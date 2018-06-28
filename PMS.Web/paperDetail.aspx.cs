using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class paperDetail : System.Web.UI.Page
    {
        protected Title titleId = null;
        protected string titleid;
        protected void Page_Load(object sender, EventArgs e)
        {
            titleid = Request["titleId"].ToString();
            TitleBll nb = new TitleBll();
            titleId = nb.GetTitle(4);
            //titleId = nb.GetTitle(int.Parse(titleid));

        }
    }
}
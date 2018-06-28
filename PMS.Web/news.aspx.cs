using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class news : System.Web.UI.Page
    {
        protected News newsId = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string newid = Request["newid"].ToString();
            //System.Diagnostics.Debug.WriteLine(newid);
            NewsBll nb = new NewsBll();
            newsId = nb.GetNews(int.Parse(newid));
        }
    }
}
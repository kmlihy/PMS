using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class main : System.Web.UI.Page
    {
        protected int State;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                State = int.Parse(Session["state"].ToString());
            }
            catch {
            }
        }
    }
}
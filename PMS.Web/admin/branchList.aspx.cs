using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class branchList : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            CollegeBll collbll = new CollegeBll();
            ds = collbll.Select();
        }
    }
}
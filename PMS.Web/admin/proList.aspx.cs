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
    public partial class proList : System.Web.UI.Page
    {
       protected DataSet ds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProfessionBll probll = new ProfessionBll();
            ds = probll.Select();
            TableBuilder tb = new TableBuilder();
            
        }
    }
}
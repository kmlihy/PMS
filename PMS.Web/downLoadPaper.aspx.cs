using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.Model;
using PMS.BLL;
using System.Data;

namespace PMS.Web
{
    public partial class downLoadPaper : System.Web.UI.Page
    {
        protected string userName = null;
        protected Student user = null;
        protected string userType = null;
        protected DataSet ds;
        protected string stuAccount = null;
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
    }
}
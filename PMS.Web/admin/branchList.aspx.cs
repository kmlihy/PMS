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
        CollegeBll collbll = new CollegeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata("", 1);
        }
        public void getdata(string strWhere,int IntPageNum)
        {
            TableBuilder tb = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "college",
                IntColType = 1,
                IntOrder = 0,
                StrColumnlist = "college",
                IntPageSize = 5,
                IntPageNum = IntPageNum,
                StrWhere = strWhere
            };
            ds = collbll.Select();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web.admin
{
    public partial class batchList : System.Web.UI.Page
    {
        protected DataSet plands = null;
        int intPageCount;
        PlanBll planBll = new PlanBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getpage("", 1);
        }
        public void getpage(string strWhere,int pageNum)
        {
            TableBuilder tBuilder = new TableBuilder("V_Plan", "planId", 0, 0, "*", 1, pageNum, strWhere);
            plands = planBll.SelectBypage(tBuilder, out intPageCount);
        }
    }
}
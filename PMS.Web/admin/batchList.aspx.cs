using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;

namespace PMS.Web.admin
{
    public partial class batchList : System.Web.UI.Page
    {
        protected DataSet plands = null;
        protected DataSet prods = null;
        protected DataSet colds = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //批次数据填充
            PlanBll planBll = new PlanBll();
            plands = planBll.Select();
            //专业数据填充
            ProfessionBll proBll = new ProfessionBll();
            prods = proBll.Select();
            //院系数据填充
            CollegeBll colBll = new CollegeBll();
            colds = colBll.Select();
        }
    }
}
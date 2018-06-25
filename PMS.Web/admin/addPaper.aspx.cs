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
    public partial class addPaper : System.Web.UI.Page
    {
        ProfessionBll teabll = new ProfessionBll();
        protected DataSet ds = null;
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }
        public void getdata()
        {
            //绑定筛选条件中的专业数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_Profession",
                StrColumn = "proId",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "proName",
                IntPageSize = 5,
                IntPageNum = 1,
                StrWhere = ""
            };
            //ds = teabll.SelectBypage(tbd, out count);
            
        }
    }
}
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
    public partial class adminList : System.Web.UI.Page
    {
        TeacherBll teabll = new TeacherBll();
        protected DataSet ds = null,dsColl = null;
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata("", 1);
        }
        public void getdata(string strWhere, int IntPageNum)
        {
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrColumn = "teaType",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "teaAccount,teaName,collegeName,sex,phone,Email",
                IntPageSize = 3,
                IntPageNum = IntPageNum,
                StrWhere = "teaType=0 and "+strWhere
            };
            ds = teabll.SelectBypage(tbd, out count);
            //绑定筛选条件中的分院数据
            TableBuilder tbdColl = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "collegeId",
                IntColType = 1,
                IntOrder = 0,
                StrColumnlist = "collegeName",
                IntPageSize = 5,
                IntPageNum = 1,
                StrWhere = ""
            };
            dsColl = teabll.SelectBypage(tbdColl, out count);
        }
    }
}
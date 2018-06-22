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
        protected DataSet ds = null, dsColl = null;
        TeacherBll teabll = new TeacherBll();
        CollegeBll collbll = new CollegeBll();
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata("", 1);
        }
        public void getdata(string strWhere, int IntPageNum)
        {
            string strTeaType = "";
            if (strWhere == "")
            {
                strTeaType = "teaType=0";
            }
            else
            {
                strTeaType = "teaType=0 and ";
            }
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrColumn = "teaType",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "teaAccount,teaName,sex,collegeName,phone,Email",
                IntPageSize = 5,
                IntPageNum = IntPageNum,
                StrWhere = strTeaType + strWhere
            };
            ds = teabll.SelectBypage(tbd, out count);
            // 绑定筛选条件中的学院信息
            dsColl = collbll.Select();
        }
    }
}
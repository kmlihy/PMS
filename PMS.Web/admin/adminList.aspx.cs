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
        //获取数据
        protected DataSet ds = null, dsColl = null;
        TeacherBll teabll = new TeacherBll();
        CollegeBll collbll = new CollegeBll();
        int count = 1;
        protected string where = "";
        protected int pageNum = 1;
        protected int pageSize = 5;
        //分页
        protected string getName = "";
        protected int getCurrentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            GetData("", pageNum, pageSize);
            //分页
            string name = Request["name"];
            string currentPage = Request["currentPage"];
            string op = Request["op"];
            if (op == "1")
            {
                getCurrentPage = int.Parse(currentPage) - 1;
                System.Diagnostics.Debug.WriteLine("op1当前页为：" + getCurrentPage);
            }
            else if (op == "2")
            {
                getCurrentPage = int.Parse(currentPage) + 1;
                System.Diagnostics.Debug.WriteLine("op2当前页为：" + getCurrentPage);
            }
            else
            {
                //getCurrentPage = int.Parse(currentPage);
            }
        }
        //获取数据
        public void GetData(string strWhere, int pageNum,int pageSize)
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
                IntPageSize = pageSize,
                IntPageNum = pageNum,
                StrWhere = strTeaType + strWhere
            };
            ds = teabll.SelectBypage(tbd, out count);
            // 绑定筛选条件中的学院信息
            dsColl = collbll.Select();
        }
    }
}
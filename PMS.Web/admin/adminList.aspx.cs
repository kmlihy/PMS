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
        protected DataSet ds = null;
        protected int count;
        protected int pageSize = 1;
        //分页
        protected int getCurrentPage = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            getdata("", 1);
            //分页
            changepage();
            //根据分页条件获取数据
            getdata("", getCurrentPage);
        }
        //获取数据
        public void getdata(string strWhere, int pageNum)
        {
            //判断身份是否是管理员
            string strTeaType = "";
            if (strWhere == "")
            {
                strTeaType = "teaType=2";
            }
            else
            {
                strTeaType = "teaType=2 and ";
            }
            //获取数据
            TeacherBll teabll = new TeacherBll();
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrColumn = "teaAccount",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "teaAccount,teaName,sex,collegeName,phone,Email",
                IntPageSize = pageSize,
                IntPageNum = pageNum,
                StrWhere = strTeaType + strWhere
            };
            ds = teabll.SelectBypage(tbd, out count);
            count = count % pageSize == 0 ? count / pageSize : count / pageSize + 1;
        }
        //分页
        public void changepage()
        {
            try
            {
                string currentPage = Request.QueryString["currentPage"];
                getCurrentPage = int.Parse(currentPage);
            }
            catch { }
            if (getCurrentPage <= 1)
            {
                getCurrentPage = 1;
            }
            else if (getCurrentPage >= count)
            {
                getCurrentPage = count;
            }
            ViewState["page"] = getCurrentPage;
        }
    }
}
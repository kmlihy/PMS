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
        protected int count;
        protected int pageSize = 1;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected String search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            Search();
            getdata(Search());
        }
        //获取数据
        public void getdata(string strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            //判断身份是否是管理员
            string strTeaType = "";
            if (strWhere == null || strWhere == "")
            {
                strTeaType = "teaType=2";
            }
            else
            {
                strTeaType = "teaType=2 and ";
            }
            //获取数据
            TeacherBll teabll = new TeacherBll();
            CollegeBll coll = new CollegeBll();
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrColumn = "teaAccount",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "teaAccount,teaName,sex,collegeName,phone,Email",
                IntPageSize = pageSize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = strTeaType + strWhere
            };
            getCurrentPage = int.Parse(currentPage);
            ds = teabll.SelectBypage(tbd, out count);
            //获取学院所有信息
            dsColl = coll.Select();
        }
        //分页
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format(" teaAccount={0} or teaName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
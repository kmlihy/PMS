using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class myStuOpeningReportList : CommonPage
    {
        protected DataSet ds = null;
        protected Teacher teacher = null;
        protected string teaName = null, teaAccount = null, teaNnum = null, secSearch, search;
        protected int count, pagesize = 20;
        protected int getCurrentPage = 1;
        TeacherBll teaBll = new TeacherBll();
        TitleBll titleBll = new TitleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            PathBll pathBll = new PathBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            string op = Context.Request.Form["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                Search();
                getData(Search());
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        public void getData(string strWhere)
        {
            string currentPage = Context.Request.QueryString["currentPage"];
            Teacher tea = (Teacher)Session["loginuser"];
            teaAccount = tea.TeaAccount;
            //teacher = (Teacher)Session["loginuser"]; 
            string countPage = Request.QueryString["currentPage"];
            string where1 = "teaAccount = " + teaAccount;
            string where2 = "teaAccount = " + teaAccount + " and " + strWhere;
            TableBuilder tableBuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null || strWhere == "" ? where1 : where2,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = 1,
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
                StrColumnlist = "*"
            };
            //getCurrentPage = int.Parse(countPage);
            ds = titleBll.SelectBypage(tableBuilder, out count);
        }

        /// <summary>
        ///输入框搜索
        /// <summary>
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                    secSearch = "";
                }
                else if (search == null)
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    secSearch = search;
                    search = String.Format("realName {0} or stuAccount {0} or title {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
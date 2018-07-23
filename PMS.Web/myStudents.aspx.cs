using PMS.BLL;
using PMS.Model;
using System;
using System.Data;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class myStudents : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //专业
        protected DataSet prods = null;
        //批次
        protected DataSet plans = null;
        //学院
        protected DataSet bads = null;
        protected ProfessionBll probll = new ProfessionBll();
        TitleRecordBll titrecordbll = new TitleRecordBll();
        protected CollegeBll colbll = new CollegeBll();
        protected PlanBll plbll = new PlanBll();
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        protected String search = "";
        protected String searchdrop = "";
        protected string showstr = null;
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected string secSearch = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.Form["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                Search();
                getPage(Search());
            }
            //批次下拉菜单
            if (type == "plandrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                if (dropstrWhereplan == "0")
                {
                    getPage("");
                }
                string strWhere = string.Format(" planId = {0}", dropstrWhereplan);
                getPage(strWhere);
            }
            //专业下拉菜单
            if (type == "prodrop")
            {
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0}", dropstrWherepro);
                getPage(strWhere);
            }
            //所有下拉菜单
            if (type == "alldrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
                getPage(strWhere);
            }

            bads = colbll.Select();
            prods = probll.Select();
            plans = plbll.Select();

        }

        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropsearch"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                }
                else
                {
                    searchdrop = String.Format(" proId={0}", "'" + searchdrop + "'");

                }
            }
            catch
            {

            }
            return searchdrop;
        }

        //获取表格数据
        public void getPage(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }

            TitleRecordBll titlerd = new TitleRecordBll();
            Teacher tea = (Teacher)Session["loginuser"];
            string teaAccount = tea.TeaAccount;
            string where1 = "teaAccount = " + teaAccount;
            string where2 = "teaAccount = " + teaAccount + " and " + strWhere;
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null || strWhere == "" ? where1 : where2,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titlerd.SelectBypage(tabuilder, out count);
        }

        //输入框搜索
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
                    search = String.Format("titleRecordId {0} or realName {0} or phone {0} or proName {0} or title {0} or planName {0} or sex {0}", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
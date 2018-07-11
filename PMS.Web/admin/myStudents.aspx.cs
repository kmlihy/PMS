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
        protected int pagesize = 2;
        protected String search = "";
        protected String searchdrop = "";
        protected string showstr = null;
        protected string showinput = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.Form["op"];
            string type = Request.QueryString["type"];
            if (type == "btn")
            {
                Search();
                getPage(Search());
            }
            else if (type == "drop")
            {
                Searchdrop();
                getPage(Searchdrop());
            }
            else
            {
                Search();
                getPage(Search());
            }

            bads = colbll.Select();
            prods = probll.Select();
            plans = plbll.Select();
            //下拉搜索后条件保存
            if (searchdrop == null)
            {
                showstr = "-请选择专业-";
            }
            else if (searchdrop != null && searchdrop.Length > 0)
            {
                string sec = searchdrop.ToString();
                string[] secArray = sec.Split('=');
                if (secArray.Length > 0)
                {
                    string str = secArray[1].ToString();
                    showstr = str.Substring(1, str.Length - 2);
                }
            }
            //查询按钮点击后查询条件保存
            if (search == null)
            {
                showinput = "请输入查询条件";
            }
            else if (search != null && search.Length > 1)
            {
                string sec = search.ToString();
                string[] secArray = sec.Split('%');
                string str = secArray[1].ToString();
                showinput = str;

            }
            else { }
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
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null ? "" : strWhere,
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
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format(" realName {0} or proName {0} or title {0} or planName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
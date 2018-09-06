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
    public partial class myStudentRespondent : System.Web.UI.Page
    {
        public DataSet dsPro, dsPlan, ds;
        public string teaAccount, dropstrWhereplan, dropstrWherepro, searchdrop, search, currentPage, secSearch;
        public int getCurrentPage = 1, pagesize = 5, count, collegeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            ProfessionBll probll = new ProfessionBll();
            PlanBll planBll = new PlanBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            collegeId = teacher.college.ColID;
            dsPro = probll.SelectByCollegeId(collegeId);
            dsPlan = planBll.GetplanByCollegeId(collegeId);
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

            CrossGuideBll crossBll = new CrossGuideBll();
            Teacher tea = (Teacher)Session["loginuser"];
            teaAccount = tea.TeaAccount;
            string where1 = "leader = " + teaAccount + " or member = " + teaAccount + " or recorder = " + teaAccount;
            string where2 = "leader = " + teaAccount + " or member = " + teaAccount + " or recorder = " + teaAccount + " and " + strWhere;
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_DefenceRecord",
                StrWhere = strWhere == null || strWhere == "" ? where1 : where2,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "stuAccount",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = crossBll.SelectBypage(tabuilder, out count);
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
                    search = String.Format("realName {0} or phone {0} or proName {0} or title {0} or planName {0} or sex {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
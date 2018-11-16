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
    public partial class checkReportTeacher : CommonPage
    {
        public DataSet ds;
        public string teaAccount, searchdrop, search, currentPage, secSearch;
        public int getCurrentPage = 1, pagesize = 5, count, collegeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            PathBll pathBll = new PathBll();
            Path path = new Path();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            collegeId = teacher.college.ColID;
            string op = Context.Request.Form["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                Search();
                getPage(Search());
            }
            string agree = Request["agree"];
            if(agree != null) {
                string stuAccount = Request["stuAccount"];
                DataSet ds = trbll.GetByAccount(stuAccount);
                int i = ds.Tables[0].Rows.Count - 1;
                TitleRecord titleRecord = new TitleRecord();
                titleRecord.TitleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                if (agree == "yes")
                {
                    path.state = 3;
                }
                else if (agree == "no")
                {
                    path.state = 1;
                }
                path.type = 1;
                path.titleRecord = titleRecord;
                pathBll.updateState(path);
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

            CrossBll crossBll = new CrossBll();
            Teacher tea = (Teacher)Session["loginuser"];
            teaAccount = tea.TeaAccount;
            string where1 = "type = 1 and teaAccount = " + teaAccount;
            string where2 = "type = 1 and teaAccount = " + teaAccount + " and " + strWhere;
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Path",
                StrWhere = strWhere == null || strWhere == "" ? where1 : where2,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
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
                    search = String.Format("stuAccount {0} or realName {0} or title {0} or title {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
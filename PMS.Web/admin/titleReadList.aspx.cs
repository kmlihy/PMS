using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class titleReadList : System.Web.UI.Page
    {
        protected DataSet ds = null, dsPro = null, dsPlan = null, dsColl = null;//储存标题表、专业、批次、分院信息
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected string showstr = null;
        protected string showinput = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 3;
        protected String search = "";

        TeacherBll teabll = new TeacherBll();
        ProfessionBll probll = new ProfessionBll();
        PlanBll plabll = new PlanBll();

        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
                dsColl = colbll.Select();
                dsPro = probll.Select();
                dsPlan = plabll.Select();
            }

        }
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TitleBll titbll = new TitleBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Title",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
        }

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
                    search = String.Format("titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
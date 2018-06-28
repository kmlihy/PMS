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
    public partial class batchList : System.Web.UI.Page
    {
        protected DataSet plands = null;//批次
        protected DataSet colds = null;//院系
        protected int count;
        protected int getCurrentPage = 1;
        protected int pagesize = 1;
        protected String search = "";
        PlanBll planBll = new PlanBll();
        CollegeBll colBll = new CollegeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            colds = colBll.Select();
            Search();
            getdata(Search());
        }
        public void getdata(string strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            BLL.TeacherBll sdao = new TeacherBll();
            TeacherBll pro = new TeacherBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Plan",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "planId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            plands = pro.SelectBypage(tabuilder, out count);
        }

        public string Search()
        {
            try {
                search = Request.QueryString["search"];
                if(search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format("planName={0} or collegeName={0}", "'" + search + "'");
                }
            }
            catch { }
            return search;
        }
    }
}
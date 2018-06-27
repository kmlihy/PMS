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
    public partial class branchList : System.Web.UI.Page
    {
        //获取数据
        CollegeBll collbll = new CollegeBll();
        protected DataSet ds = null;
        protected int count;
        protected int pageSize = 1;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected String search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "collegeId",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "*",
                IntPageSize = pageSize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = strWhere == null ? "" : strWhere
            };
            getCurrentPage = int.Parse(currentPage);
            ds = collbll.SelectBypage(tbd,out count);
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
                    search = String.Format(" collegeName={0}", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
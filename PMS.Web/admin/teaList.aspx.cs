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
    public partial class teaList : System.Web.UI.Page
    {
        protected DataSet ds=null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize=1;
        protected String search = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Search();
            getdata(Search(), 1);
            changepage();
            getdata(Search(), getCurrentPage);    
        }

        public void getdata(String strWhere, int IntPageNum)
        {
            BLL.TeacherBll sdao = new TeacherBll();
            TeacherBll pro = new TeacherBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrWhere = strWhere==null ? "": strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = IntPageNum,
                IntPageSize = pagesize,
                StrColumn = "teaAccount",
                StrColumnlist = "*"
            };
            ds = pro.SelectBypage(tabuilder, out count);
        }

        public void changepage() {
            try
            {
                string currentPage = Request.QueryString["currentPage"];
                getCurrentPage = int.Parse(currentPage);
            }
            catch { }
            if (getCurrentPage < 1)
            {
                getCurrentPage = 1;
            }
            else if (getCurrentPage > (count == 0 ? 1 : count))
            {
                getCurrentPage = count == 0  ?  1 : count;
            }
            ViewState["page"] = getCurrentPage;
        }

        public string Search() {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else
                {
                    search = String.Format(" teaAccount={0} or teaName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }   
            }
            catch {
            }
            return search;
        }
    }
}
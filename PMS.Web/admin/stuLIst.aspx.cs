using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;
using System.Data;

namespace PMS.Web.admin
{
    public partial class stuLIst : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected DataSet prods = null;
        protected int intPageCount;
        protected int pagesize = 1;
        protected int getCurrentPage = 1;
        StudentBll stuBll = new StudentBll();
        ProfessionBll proBll = new ProfessionBll();
        public void Page_Load(object sender, EventArgs e)
        {
            prods = proBll.Select();
            getpage("", 1);
            changePage();
            getpage("", getCurrentPage);
        }
        public void getpage(string strWhere, int pageNum)
        {
            TableBuilder tBuilder = new TableBuilder("V_Student", "stuAccount", 0, 0, "*", pagesize, pageNum,strWhere);
            ds = stuBll.SelectBypage(tBuilder, out intPageCount);
        }
        public void changePage()
        {
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
            else if (getCurrentPage > intPageCount)
            {
                getCurrentPage = intPageCount;
            }
            ViewState["page"] = getCurrentPage;
        }
    }
}
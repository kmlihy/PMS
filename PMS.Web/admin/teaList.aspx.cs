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

        protected void Page_Load(object sender, EventArgs e)
        {

            getdata("", 1);
            changepage();
            getdata("", getCurrentPage);    
        }

        public void getdata(String strWhere, int IntPageNum)
        {
            BLL.TeacherBll sdao = new TeacherBll();
            TeacherBll pro = new TeacherBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrWhere = strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = IntPageNum,
                IntPageSize = pagesize,
                StrColumn = "teaAccount",
                StrColumnlist = "*"
            };
            ds = pro.SelectBypage(tabuilder, out count);
            count = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
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
            else if (getCurrentPage > count)
            {
                getCurrentPage = count;
            }
            ViewState["page"] = getCurrentPage;

        }
    }
}
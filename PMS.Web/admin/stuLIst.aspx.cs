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
        protected DataSet studs = null;
        public int intPageCount;
        StudentBll stuBll = new StudentBll();
        public void Page_Load(object sender, EventArgs e)
        {
            getpage("", 1);
        }
        public void getpage(string strWhere, int pageNum)
        {
            TableBuilder tBuilder = new TableBuilder("V_Student", "stuAccount", 0, 0, "*", 2, pageNum,strWhere);
            studs = stuBll.SelectBypage(tBuilder, out intPageCount);
        }
    }
}
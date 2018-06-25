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

        protected void Page_Load(object sender, EventArgs e)
        {
            getdata("", 1);
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
                IntPageSize = 2,
                StrColumn = "teaAccount",
                StrColumnlist = "*"
            };
            int count;
            ds = pro.SelectBypage(tabuilder, out count);
        }
    }
}
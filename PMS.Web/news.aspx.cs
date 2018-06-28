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
    public partial class news : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        string strteaType = "";
        protected string newid;
        protected string newsType;
        protected string teaAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string newid = Request["newid"].ToString();
            //System.Diagnostics.Debug.WriteLine(newid);
            getdata("", 1);
            getdata(strteaType, getCurrentPage);
        }
        public void getdata(String strWhere, int IntPageNum)
        {
            NewsBll nb = new NewsBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "T_News",
                StrWhere = strteaType,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = IntPageNum,
                IntPageSize = pagesize,
                StrColumn = "newsId",
                StrColumnlist = "*"
            };
            ds = nb.SelectBypage(tabuilder, out count);
            count = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
        }
    }
}
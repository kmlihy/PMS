using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    public partial class allNews : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 1;
        string strteaType = "";
        private string strWhere = "";
        protected string newid;
        protected string newsType;

        protected void Page_Load(object sender, EventArgs e)
        {
            strWhere = "";
            newid = Request.QueryString["newid"];
                if (newid == "0")
                {
                    strteaType = "teaType=0";
                    newsType = "学校公告";
                }
                else if (newid == "1")
                {
                    strteaType = "teaType=1";
                    newsType = "学生公告";
            }
                else if (newid == "2")
                {
                    strteaType = "teaType=2";
                    newsType = "学院公告";
            }
            getdata("", 1);
            changepage();
            getdata(strteaType, getCurrentPage);
        }
        public void getdata(String strWhere, int IntPageNum)
        {
            NewsBll nb = new NewsBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_News",
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

        public void changepage()
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
            else if (getCurrentPage > count)
            {
                getCurrentPage = count;
            }
            ViewState["page"] = getCurrentPage;
        }
    }
}
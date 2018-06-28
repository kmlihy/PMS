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
        protected string roleId;
        protected string newsType;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            strWhere = "";
            roleId = Request.QueryString["roleId"];
                if (roleId == "0")
                {
                    strteaType = "teaType=0";
                    newsType = "学校公告";
                }
                else if (roleId == "1")
                {
                    strteaType = "teaType=1";
                    newsType = "学生公告";
            }
                else if (roleId == "2")
                {
                    strteaType = "teaType=2";
                    newsType = "学院公告";
            }
            getdata(strteaType);
        }
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            NewsBll nb = new NewsBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_News",
                StrWhere = strteaType,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "newsId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = nb.SelectBypage(tabuilder, out count);
        }
    }
}
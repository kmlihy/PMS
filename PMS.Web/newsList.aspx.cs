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
    public partial class newsList : System.Web.UI.Page
    {
        protected DataSet dsSadmin = null;
        protected DataSet dsAdmin = null;
        protected DataSet dsTea = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsBll bll = new NewsBll();

            //查询超级管理员管理员的公告信息
            TableBuilder tableBuilder = new TableBuilder();
            tableBuilder.StrTable = "V_News";
            tableBuilder.StrColumn = "newsId";
            tableBuilder.IntColType = 0;
            tableBuilder.IntOrder = 0;
            tableBuilder.StrColumnlist = "*";
            tableBuilder.IntPageSize = 5;
            tableBuilder.IntPageNum = 1;
            tableBuilder.StrWhere = "teaType = 0";
            dsSadmin = bll.SelectBypage(tableBuilder, out int intPageCount);

            //查询管理员的公告信息
            TableBuilder tableBuilder1 = new TableBuilder();
            tableBuilder1.StrTable = "V_News";
            tableBuilder1.StrColumn = "createTime";
            tableBuilder1.IntColType = 2;
            tableBuilder1.IntOrder = 1;
            tableBuilder1.StrColumnlist = "*";
            tableBuilder1.IntPageSize = 5;
            tableBuilder1.IntPageNum = 1;
            tableBuilder1.StrWhere = "teaType = 2";
            dsAdmin = bll.SelectBypage(tableBuilder1, out int intPageCount1);

            //查询教师的公告信息
            TableBuilder tableBuilder2 = new TableBuilder();
            tableBuilder2.StrTable = "V_News";
            tableBuilder2.StrColumn = "createTime";
            tableBuilder2.IntColType = 2;
            tableBuilder2.IntOrder = 1;
            tableBuilder2.StrColumnlist = "*";
            tableBuilder2.IntPageSize = 5;
            tableBuilder2.IntPageNum = 1;
            tableBuilder2.StrWhere = "teaType = 1";
            dsTea = bll.SelectBypage(tableBuilder2, out int intPageCount2);
        }
    }
}
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
    public partial class stuHistoryPaper : CommonPage
    {
        public DataSet dsPath;
        public string stuAccount;
        public int getCurrentPage = 1, pagesize = 5, count;
        PathBll pathBll = new PathBll();
        CrossBll crossBll = new CrossBll();
        TitleRecordBll titleRecordBll = new TitleRecordBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            Teacher tea = (Teacher)Session["loginuser"];
            string teaAccount = tea.TeaAccount;
            stuAccount = Request.QueryString["stuAccount"];
            TitleRecord titleRecord = titleRecordBll.getRtIdByTea(stuAccount,teaAccount);
            int titleRecordId = titleRecord.TitleRecordId;

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "T_Path",
                StrWhere = "titleRecordId=" + titleRecordId,
                IntColType = 0,
                IntOrder = 1,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "pathId",
                StrColumnlist = "pathTitle,dateTime,path"
            };
            getCurrentPage = int.Parse(currentPage);
            dsPath = crossBll.SelectBypage(tabuilder, out count);

        }
    }
}
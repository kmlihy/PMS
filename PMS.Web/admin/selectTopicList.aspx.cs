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
    using Result = Enums.OpResult;
    public partial class selectTopicList : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //专业
        protected DataSet prods = null;
        protected ProfessionBll probll = new ProfessionBll();

        TitleRecordBll titrecordbll = new TitleRecordBll();
        //学院
        protected DataSet bads = null;
        protected CollegeBll colbll = new CollegeBll();
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 2;
        protected String search = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            string op = Context.Request.Form["op"];
            if (op == "del")
            {
                IsdeleteCollege();
                delPro();


            }
            if (!IsPostBack)
            {
                Search();
                getPage(Search());
                bads = colbll.Select();
                prods = probll.Select();
            }
        }
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string recordid = Context.Request["Recordid"].ToString();
            Result row = Result.记录不存在;
            if (titrecordbll.IsDelete("T_Student", "proId", recordid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (titrecordbll.IsDelete("T_Title", "proId", recordid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除
        public void delPro()
        {
            int recordid = int.Parse(Context.Request["Recordid"].ToString());
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
                Result result = titrecordbll.delete(recordid);

                if (result == Result.删除成功)
                {
                    Response.Write("删除成功");
                    Response.End();
                }
                else
                {
                    Response.Write("删除失败");
                    Response.End();
                }
            }
            else
            {
                Response.Write("在其他表中有关联不能删除");
                Response.End();
            }
        }
        //获取数据
        public void getPage(String strWhere)
        {

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }


            TitleRecordBll titlerd = new TitleRecordBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titlerd.SelectBypage(tabuilder, out count);
        }
        //搜索
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format(" teaName {0} or realName {0} or planName {0} or proName {0} or collegeName {0}", "like '%" + search + "%'");
                    
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
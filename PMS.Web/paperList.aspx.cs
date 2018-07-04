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
    public partial class paperList : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //题目
        protected TitleBll titbll = new TitleBll();
        //当前页数
        protected int getCurrentPage = 1;
        //总页
        protected int count;
        //每页的行数
        protected int pagesize = 8;
        //查询条件
        public String search = "";

        PublicProcedureBll pbll = new PublicProcedureBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.QueryString["op"];
            string titleid = Context.Request.QueryString["titleId"];
            if (!Page.IsPostBack)
            {
                getPage(search);
            }
            if(op == "selectTitle")
            {
                TitleRecord titleRecord = new TitleRecord();
                //TODO 后期从session里获取学生对象
                //Student student =  (Student)Session["user"];               
                Student student = new Student();
                student.StuAccount = "2121008";
                titleRecord.student = student;
                Title title = new Title();
                title.TitleId = int.Parse(titleid);
                titleRecord.title = title;

                int row = pbll.AddTitlerecord(titleRecord);
                if(row > 0)
                {
                    Response.Write("选题成功");
                    Response.End();
                }
                else
                {
                    Response.Write("选题失败");
                    Response.End();
                }
            }
        }

        //列表
        public void getPage(String strWhere)
        {

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Title",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
        }
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
                    search = String.Format(" proName={0} or collegeName={0} ", "'" + search + "'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
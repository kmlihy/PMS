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
    using Result = Enums.OpResult;
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
        protected int pagesize = 5;
        string stuId = "2121003";

        PublicProcedureBll pbll = new PublicProcedureBll();
        StudentBll stuBll = new StudentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.QueryString["op"];
            string titleid = Context.Request.QueryString["titleId"];
            if (!Page.IsPostBack)
            {
                getPage("");
            }
          
            if (op == "selectTitle")
            {
                StusecltTitle();
                //TitleRecord titleRecord = new TitleRecord();
                ////TODO 后期从session里获取学生对象
                ////Student student =  (Student)Session["user"];               
                //Student student = new Student();
                //student.StuAccount = "2121001";
                //titleRecord.student = student;
                //Title title = new Title();
                //title.TitleId = int.Parse(titleid);
                //titleRecord.title = title;

                //int row = pbll.AddTitlerecord(titleRecord);
                //if(row > 0)
                //{
                //    Response.Write("选题成功");
                //    Response.End();
                //}
                //else
                //{
                //    Response.Write("选题失败");
                //    Response.End();
                //}
            }
        }
        //判断是否已选题
        public Result isExist()
        {
            //如果存在关联即表示已选，反之则未选
            //string stuId = Context.Request["stuId"].ToString();
            Result row = Result.记录不存在;
            if (stuBll.IsDelete("T_TitleRecord", "stuAccount", stuId) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        public void StusecltTitle()
        {
            //string stuId = Context.Request["stuId"].ToString();
            Result row = isExist();
            if (row == Result.记录不存在)
            {
                string titleid = Context.Request.QueryString["titleId"];
                TitleRecord titleRecord = new TitleRecord();
                //TODO 后期从session里获取学生对象
                //Student student =  (Student)Session["user"];               
                Student student = new Student();
                student.StuAccount = stuId;
                titleRecord.student = student;
                Title title = new Title();
                title.TitleId = int.Parse(titleid);
                titleRecord.title = title;

                int rows = pbll.AddTitlerecord(titleRecord);
                if (rows > 0)
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
            else
            {
                Response.Write("已选题");
                Response.End();
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
                IntOrder = 1,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
        }
    }
}
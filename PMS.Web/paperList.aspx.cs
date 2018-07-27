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

        string stuId = "";

        PublicProcedureBll pbll = new PublicProcedureBll();
        StudentBll stuBll = new StudentBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取登录学生学号
            Student stu = (Student)Session["loginuser"];
            stuId = stu.StuAccount;
            //获取op titiId
            string op = Context.Request.QueryString["op"];
            string titleid = Context.Request.QueryString["titleId"];
            //获取学生专业id 
            string proId = stu.profession.ProId.ToString();

            if (!Page.IsPostBack)
            {
                if (proId != null)
                {
                    proId = "proId=" + proId;
                    getPage(proId);
                }
            }

            if (op == "selectTitle")
            {
                StusecltTitle();
            }
        }

        /// <summary>
        /// //判断是否已选题
        /// </summary>
        /// <returns>返回是否已选题</returns>
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
        /// <summary>
        /// 执行选题操作
        /// </summary>
        public void StusecltTitle()
        {
            //string stuId = Context.Request["stuId"].ToString();
            int titleid = int.Parse(Context.Request.QueryString["titleId"]);
            Title dstitle = new Title();
            TitleBll titleSelect = new TitleBll();
            dstitle = titleSelect.GetTitle(titleid);

            int limited = int.Parse(dstitle.Limit.ToString());
            int selected = int.Parse(dstitle.Selected.ToString());
            if (selected < limited)
            {
                Result row = isExist();
                if (row == Result.记录不存在)
                {

                    TitleRecord titleRecord = new TitleRecord();
                    Student student = new Student();
                    student.StuAccount = stuId;
                    titleRecord.student = student;
                    Title title = new Title();
                    title.TitleId = titleid;
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
            else
            {
                Response.Write("已达上限");
                Response.End();
            }
        }

        //列表
        /// <summary>
        /// 表格数据加载
        /// </summary>
        /// <param name="strWhere">查询条件</param>
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
                StrWhere = strWhere == null ? "state = 1" : "state = 1 and "+strWhere,
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
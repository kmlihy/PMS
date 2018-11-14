using PMS.BLL;
using PMS.DBHelper;
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
    public partial class paperList : CommonPage
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
        PublicProcedureBll pbll = new PublicProcedureBll();
        StudentBll stuBll = new StudentBll();
        Student stu = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll titleRecordBll = new TitleRecordBll();
            TitleBll titleBll = new TitleBll();
            //获取登录学生学号
            stu = (Student)Session["loginuser"];
            string stuAccount = stu.StuAccount.ToString();
            ds = titleRecordBll.Select();
            if (ds!=null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (stuAccount == ds.Tables[0].Rows[i]["stuAccount"].ToString())
                        {
                            string tId = ds.Tables[0].Rows[i]["titleId"].ToString();
                            Title title = titleBll.GetTitle(int.Parse(tId));
                            string showTitle = title.title.ToString();
                            if (showTitle != "")
                            {
                                Response.Write("<a href='../PaperDtailStu.aspx'>你已选过题目，请点击跳转到题目详情界面  </a>");
                                Response.End();
                            }
                        }
                    }
                }
            }
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
            if (stuBll.IsDelete("T_TitleRecord", "stuAccount", stu.StuAccount) == Result.关联引用)
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
            Plan plan = new Plan();
            TitleBll titleSelect = new TitleBll();
            PlanBll planBll = new PlanBll();
            dstitle = titleSelect.GetTitle(titleid);

            int limited = int.Parse(dstitle.Limit.ToString());
            int selected = int.Parse(dstitle.Selected.ToString());

            //获取截止时间
            int pid = dstitle.plan.PlanId;
            plan = planBll.Select(pid);
            string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime nowTime = Convert.ToDateTime(now);
            string end = plan.EndTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endTime = Convert.ToDateTime(end);
            try
            {
                if (nowTime <= endTime)
                {
                    if (selected < limited)
                    {
                        Result row = isExist();
                        if (row == Result.记录不存在)
                        {
                            TitleRecord titleRecord = new TitleRecord();
                            titleRecord.student = stu;
                            Title title = new Title();
                            title.TitleId = titleid;
                            titleRecord.title = title;

                            int rows = pbll.AddTitlerecord(titleRecord);
                            if (rows > 0)
                            {
                                LogHelper.Info(this.GetType(), stu.StuAccount + " - " + stu.RealName + " - 学生选题 - " + dstitle.TitleId + dstitle.title);
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
                else
                {
                    Response.Write("选题时间已截止");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
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
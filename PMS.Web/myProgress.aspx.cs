using PMS.BLL;
using PMS.Model;
using System;
using System.Data;

namespace PMS.Web
{
    public partial class myGrogress : System.Web.UI.Page
    {
        protected string title;//题目
        protected int titleId;//题目ID
        protected string stuNO = null;//学生学号
        protected DateTime startTime;//选题开始时间
        protected DateTime endTime;//选题结束时间
        protected DateTime selectTime;//学生的选题时间
        protected string planId;//批次ID
        protected string titleRecordId = null;//选题记录ID
        protected DateTime opTime;//提交开题报告时间
        protected Student student;
        protected OpenReport opReport;
        protected string state;//登录类型
        protected DataSet ds;
        protected DataSet titleDs;
        TitleRecordBll Record = new TitleRecordBll();
        PlanBll planBll = new PlanBll();
        OpenReportBll opBll = new OpenReportBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            state = Session["state"].ToString();
            if(state == "3")
            {
                student = (Student)Session["loginuser"];
                stuNO = student.StuAccount;
                if (Record.selectBystuId(stuNO)==true)
                {
                    ds = Record.GetByAccount(stuNO);
                    title = ds.Tables[0].Rows[0]["title"].ToString();//获取标题
                    planId = ds.Tables[0].Rows[0]["planId"].ToString();//获取批次ID
                    Plan plan = planBll.Select(int.Parse(planId));//获取批次信息
                    startTime = plan.StartTime;//批次开始时间
                    endTime = plan.EndTime;//批次结束时间
                    string dsTime = ds.Tables[0].Rows[0]["createTime"].ToString();
                    selectTime = Convert.ToDateTime(dsTime);//学生选定题目时间
                    titleRecordId = ds.Tables[0].Rows[0]["titleRecordId"].ToString();
                    opReport = opBll.Select(int.Parse(titleRecordId));
                    opTime = opReport.reportTime;
                }
                else
                {
                    Response.Write("你还没有选题，请先进行选题");
                }
            }
            else
            {
                Response.Write("管理员和教师没有进度条");
            }
        }

    }
}
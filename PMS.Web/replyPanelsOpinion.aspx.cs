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
    public partial class replyPanelsOpinion : CommonPage
    {
        protected DataSet ds;
        protected string stuAccount, stuPro, title;
        protected int planId;
        TitleRecordBll titlebll = new TitleRecordBll();
        Score scoreModel = new Score();
        protected void Page_Load(object sender, EventArgs e)
        {

            stuAccount = Request.QueryString["stuAccount"];
            if (stuAccount != null)
            {
                Session["stuAccount"] = stuAccount;
            }
            else
            {
                stuAccount = Session["stuAccount"].ToString();
            }
            ds = titlebll.GetByAccount(stuAccount);
            planId = Convert.ToInt32(ds.Tables[0].Rows[0]["planId"]);
            string op = Request["op"];
            if (op == "submit")
            {
                insert();
            }
        }
        public void insert()
        {
            string txtAreReportContent = Request["ReportContent"];
            string txtAreReportTime = Request["ReportTime"];
            string txtAreDefence = Request["Defence"];
            string txtAreInnovate = Request["Innovate"];
            double txtAreDefenceScore = double.Parse(Request["DefenceScore"]);
            string txtAreEvaluate = Request["txtAreEvaluate"];
            Plan plan = new Plan();
            try
            {
                StudentBll studentBll = new StudentBll();
                Student stu = studentBll.GetModel(stuAccount);
                plan.PlanId = planId;
                scoreModel.student = stu;
                scoreModel.plan = plan;
                scoreModel.reportContent = txtAreReportContent;
                scoreModel.reportTime = txtAreReportTime;
                scoreModel.defence = txtAreDefence;
                scoreModel.defenInnovate = txtAreInnovate;
                scoreModel.defenceScore = txtAreDefenceScore;
                scoreModel.defenEvaluate = txtAreEvaluate;
                ScoreBll scorebll = new ScoreBll();
                Result row = scorebll.updatereplyPanelsOpinion(scoreModel);
                if (row == Result.添加成功)
                {
                    Teacher teacher = (Teacher)Session["loginuser"];
                    LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 教师添加 - " + stu.StuAccount + " - " + stu.RealName + " - 学生的答辩成绩及评定");
                    Response.Write("提交成功");
                    Response.End();
                }
                else
                {
                    Response.Write("提交失败");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
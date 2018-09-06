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
    public partial class replyPanelsOpinion : System.Web.UI.Page
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

            Student stu = new Student();
            Plan plan = new Plan();

            stu.StuAccount = stuAccount;
            plan.PlanId = planId;

            scoreModel.student = stu;
            scoreModel.plan = plan;
            scoreModel.reportContent = txtAreReportContent;
            scoreModel.reportTime = txtAreReportTime;
            scoreModel.defence = txtAreDefence;
            scoreModel.innovate = txtAreInnovate;
            scoreModel.defenceScore = txtAreDefenceScore;
            ScoreBll scorebll = new ScoreBll();
            Result row = scorebll.updatereplyPanelsOpinion(scoreModel);
            if (row == Result.添加成功)
            {
                Response.Write("提交成功");
                Response.End();
            }
            else
            {
                Response.Write("提交失败");
                Response.End();
            }
        }
    }
}
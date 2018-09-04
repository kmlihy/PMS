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
    public partial class InstructorsComments : System.Web.UI.Page
    {
        public DataSet getData;
        GuideRecordBll guideRecordBll = new GuideRecordBll();
        Score scoreModel = new Score();
        ScoreBll sbll = new ScoreBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request["op"];
            string stuAccount = Request.QueryString["stuAccount"];
            int titleRecordId = Convert.ToInt32(Request.QueryString["titleRecordId"]);
            getData = guideRecordBll.Select(titleRecordId);

            int planId = 0;
            for (int i = 0; i < getData.Tables[0].Rows.Count; i++)
            {
                string account = Request.QueryString["stuAccount"];
                if (stuAccount == account)
                {
                    planId = Convert.ToInt32(getData.Tables[0].Rows[i]["planId"].ToString());
                    break;
                }
            }

            double score = Convert.ToDouble(Request["score"]);
            string remarks = "指导成绩";
            string investigation = Request["investigation"];
            string practice = Request["practice"];
            string solveProblem = Request["solveProblem"];
            string workAttitude = Request["workAttitude"];
            string quality = Request["quality"];
            string evaluate = Request["evaluate"];
            string innovate = Request["innovate"];
            Student student = new Student();
            Plan plan = new Plan();

            if (op=="submit")
            {
                student.StuAccount = stuAccount;
                plan.PlanId = planId;
                scoreModel.student = student;
                scoreModel.plan = plan;
                scoreModel.score = score;
                scoreModel.remarks = remarks;
                scoreModel.investigation = investigation;
                scoreModel.practice = practice;
                scoreModel.solveProblem = solveProblem;
                scoreModel.workAttitude = workAttitude;
                scoreModel.quality = quality;
                scoreModel.innovate = innovate;
                scoreModel.evaluate = evaluate;

                Result row = sbll.insertInstructorsComments(scoreModel);
                if (row == Result.添加成功)
                {
                    Response.Write("添加成功");
                    Response.End();
                }
                else
                {
                    Response.Write("添加成功");
                    Response.End();
                }
            }
        }
    }
}
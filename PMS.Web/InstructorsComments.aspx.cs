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
            string stuAccount = Request.QueryString["stuAccount"];
            int titleRecordId = Convert.ToInt32(Request.QueryString["titleRecordId"]);
            getData = guideRecordBll.Select(titleRecordId);
            if (stuAccount == null || stuAccount == "")
            {
                insert();
            }
            else
            {
                int planId = 0;
                for (int i = 0; i < getData.Tables[0].Rows.Count; i++)
                {
                    string account = getData.Tables[0].Rows[i]["stuAccount"].ToString();
                    if (stuAccount == account)
                    {
                        Session["stuAccount"] = stuAccount;
                        planId = Convert.ToInt32(getData.Tables[0].Rows[i]["planId"].ToString());
                        Session["planId"] = planId;
                        break;
                    }
                }
            }
        }

        public void insert()
        {
            string op = Request["op"];
            if (op == "submit")
            {
                double guideScore = Convert.ToDouble(Request["score"]);
                string investigation = Request["investigation"];
                string practice = Request["practice"];
                string solveProblem = Request["solveProblem"];
                string workAttitude = Request["workAttitude"];
                string quality = Request["quality"];
                string evaluate = Request["evaluate"];
                string innovate = Request["innovate"];
                Student student = new Student();
                Plan plan = new Plan();

                student.StuAccount = Session["stuAccount"].ToString();
                plan.PlanId = Convert.ToInt32(Session["planId"]);
                scoreModel.student = student;
                scoreModel.plan = plan;
                scoreModel.guideScore = guideScore;
                scoreModel.investigation = investigation;
                scoreModel.practice = practice;
                scoreModel.solveProblem = solveProblem;
                scoreModel.workAttitude = workAttitude;
                scoreModel.paperDesign = quality;
                scoreModel.innovate = innovate;
                scoreModel.evaluate = evaluate;

                Result row = sbll.insertInstructorsComments(scoreModel);
                if (row == Result.添加成功)
                {
                    Response.Write("提交成功");
                    Response.End();
                }
                else
                {
                    Response.Write("提交成功");
                    Response.End();
                }
            }
        }
    }
}
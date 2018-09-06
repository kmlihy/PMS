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
        TitleRecordBll titlebll = new TitleRecordBll();
        Score scoreModel = new Score();
        ScoreBll sbll = new ScoreBll();
        string stuAccount;
        int planId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            }
            int titleRecordId = Convert.ToInt32(Request.QueryString["titleRecordId"]);
            getData = titlebll.GetByAccount(stuAccount);
            planId = Convert.ToInt32(getData.Tables[0].Rows[0]["planId"]);
            string op = Request["op"];
            if (op == "submit")
            {
                insert();
            }
        }

        public void insert()
        {
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
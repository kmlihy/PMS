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
    public partial class crossGuide : System.Web.UI.Page
    {
        public string stuName, proName, title;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            CrossGuideBll crossGuideBll = new CrossGuideBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            DataSet ds = crossGuideBll.GetByAccount(teaAccount);
            int planId=0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string stuAccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                string account = Request.QueryString["stuAccount"];
                if (account==null||account=="")
                {
                    string op = Request["op"];
                    if (op == "add")
                    {
                        insert();
                    }
                }
                else
                {
                    if (stuAccount == account)
                    {
                        Session["stuAccount"] = stuAccount;
                        stuName = ds.Tables[0].Rows[i]["realName"].ToString();
                        proName = ds.Tables[0].Rows[i]["proName"].ToString();
                        title = ds.Tables[0].Rows[i]["title"].ToString();
                        planId = Convert.ToInt32(ds.Tables[0].Rows[i]["planId"].ToString());
                        Session["planId"] = planId;
                        break;
                    }
                }
            } 
        }
        public void insert()
        {
            double score = Convert.ToDouble(Request["score"]);
            string material = Request["material"];
            string paperDesign = Request["quality"];
            string workload = Request["workload"];
            string innovate = Request["innovate"];
            string evaluate = Request["evaluate"];
            StudentBll stuBll = new StudentBll();
            Student student = stuBll.GetModel(Session["stuAccount"].ToString());
            ScoreBll sbll = new ScoreBll();
            Score scoreModel = new Score();
            scoreModel.material = material;
            scoreModel.paperDesign = paperDesign;
            scoreModel.workload = workload;
            scoreModel.innovate = innovate;
            scoreModel.evaluate = evaluate;
            scoreModel.crossScore = score;
            scoreModel.student = student;
            Plan plan = new Plan();
            plan.PlanId = Convert.ToInt32(Session["planId"]);
            scoreModel.plan = plan;
            Result row = sbll.updateCrossGuide(scoreModel);
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
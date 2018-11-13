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
    public partial class crossGuide : System.Web.UI.Page
    {
        public string stuName, proName, title;
        Teacher teacher = new Teacher();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            CrossBll crossBll = new CrossBll();
            teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            DataSet ds = crossBll.SelectByTea(teaAccount);
            if (ds != null)
            {
                int planId = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string stuAccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                    string account = Request.QueryString["stuAccount"];
                    if (account == null || account == "")
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
            try
            {
                scoreModel.material = material;
                scoreModel.paperDesign = paperDesign;
                scoreModel.workload = workload;
                scoreModel.crossInnovate = innovate;
                scoreModel.crossEvaluate = evaluate;
                scoreModel.crossScore = score;
                scoreModel.student = student;
                Plan plan = new Plan();
                plan.PlanId = Convert.ToInt32(Session["planId"]);
                scoreModel.plan = plan;
                Result row = sbll.updateCrossGuide(scoreModel);
                if (row == Result.添加成功)
                {
                    LogHelper.Info(this.GetType(), teacher.TeaAccount + teacher.TeaName + "-对-" + student.StuAccount + student.RealName + "学生的交叉指导意见");
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
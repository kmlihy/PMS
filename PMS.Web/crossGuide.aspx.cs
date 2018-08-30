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
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            DataSet ds = trbll.GetByAccount(teaAccount);
            int planId=0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string stuAccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                if (stuAccount == "15612200017")
                {
                    stuName = ds.Tables[0].Rows[i]["stuName"].ToString();
                    proName = ds.Tables[0].Rows[i]["proName"].ToString();
                    title = ds.Tables[0].Rows[i]["title"].ToString();
                    planId = Convert.ToInt32(ds.Tables[0].Rows[i]["planId"].ToString());
                    break;
                }
            }
            string op = Request["op"];
            if (op == "add")
            {
                double score = Convert.ToDouble(Request["score"]);
                string assess = Request["assess"];
                string evaluate = Request["evaluate"];
                StudentBll stuBll = new StudentBll();
                Student student = stuBll.GetModel("15612200017");
                ScoreBll sbll = new ScoreBll();
                Score scoreModel = new Score();
                scoreModel.assess = assess;
                scoreModel.evaluate = evaluate;
                scoreModel.remarks = "交叉评阅";
                scoreModel.score = score;
                scoreModel.student = student;
                scoreModel.plan.PlanId = planId;
                Result row = sbll.Insert(scoreModel);
                if(row == Result.添加成功)
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
}
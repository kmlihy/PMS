using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class crossGuide : System.Web.UI.Page
    {
        public string stuName, profession, title;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            TitleRecord tr = trbll.GetByAccount(teaAccount);
            stuName = tr.student.RealName;
            profession = tr.profession.ProName;
            title = tr.title.title;
            string op = Request["op"];
            if (op == "add")
            {
                double score = Convert.ToDouble(Request["score"]);
                string assess = Request["assess"];
                string evaluate = Request["evaluate"];
                ScoreBll sbll = new ScoreBll();
                Score scoreModel = new Score();
                scoreModel.assess = assess;
                scoreModel.evaluate = evaluate;
                scoreModel.remarks = "交叉评阅";
                scoreModel.score = score;
                scoreModel.student = tr.student;
                scoreModel.plan = tr.plan;
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
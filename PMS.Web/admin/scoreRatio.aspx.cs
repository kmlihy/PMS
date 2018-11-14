using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class scoreRatio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request["op"];
            if(op == "submit")
            {
                string guide = Request["guide"];
                string cross = Request["cross"];
                string defence = Request["defence"];
                string excellent = Request["excellent"];
                ScoreBll scoreBll = new ScoreBll();
                Score score = new Score();
                try
                {
                    score.guideRatio = Convert.ToDouble(guide) * 0.01;
                    score.crossRatio = Convert.ToDouble(cross) * 0.01;
                    score.defenceRatio = Convert.ToDouble(defence) * 0.01;
                    score.excellent = Convert.ToInt32(excellent);
                    Result row = scoreBll.insertRatio(score);
                    if (row == Result.添加成功)
                    {
                        Teacher teacher = (Teacher)Session["user"];
                        LogHelper.Info(this.GetType(), teacher.TeaAccount + " - "+ teacher.TeaName + " - 添加成绩占比信息");
                        Response.Write("添加成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("添加失败");
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
}
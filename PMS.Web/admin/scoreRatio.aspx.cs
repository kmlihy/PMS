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
    public partial class scoreRatio : CommonPage
    {
        ScoreBll scoreBll = new ScoreBll();
        public double sguide, scross, sdedence, sexcellent;
        protected void Page_Load(object sender, EventArgs e)
        {
            Score scoreRatio = scoreBll.getRatio();
            sguide = scoreRatio.guideRatio;
            scross = scoreRatio.crossRatio;
            sdedence = scoreRatio.defenceRatio;
            sexcellent = scoreRatio.excellent;

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
                    score.guideRatio = Convert.ToDouble(guide);
                    score.crossRatio = Convert.ToDouble(cross);
                    score.defenceRatio = Convert.ToDouble(defence);
                    score.excellent = Convert.ToInt32(excellent);
                    Result row = scoreBll.updateRatio(score);
                    if (row == Result.更新成功)
                    {
                        Teacher teacher = (Teacher)Session["user"];
                        LogHelper.Info(this.GetType(), teacher.TeaAccount + " - "+ teacher.TeaName + " - 更新成绩占比信息");
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
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
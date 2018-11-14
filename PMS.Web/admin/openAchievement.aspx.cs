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
    public partial class openAchievement : System.Web.UI.Page
    {
        public int status;
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request["op"];
            ScoreBll scoreBll = new ScoreBll();
            TeacherBll teacherBll = new TeacherBll();
            PlanBll planBll = new PlanBll();
            Teacher teacher = new Teacher();
            College college = new College();
            Score score = new Score();
            Teacher tea = (Teacher)Session["user"];
            int collegeId = tea.college.ColID;
            string startTime = DateTime.Now.ToString("yyyy-MM");
            Plan plan = planBll.getPlanId(collegeId, startTime + "%");
            int planId = plan.PlanId;
            try
            {
                if (op == "open")
                {
                    int state = 1;
                    teacher.state = 0;
                    college.ColID = collegeId;
                    teacher.college = college;
                    Result result = scoreBll.openScore(state, planId);
                    Result row = teacherBll.updateState(teacher);
                    if (result == Result.更新成功 && row == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 开放查看成绩");
                        Response.Write("成绩已开放");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("成绩开放失败，可能当前批次没有可开放成绩");
                        Response.End();
                    }
                }
                else if (op == "close")
                {
                    int state = 0;
                    Result result = scoreBll.openScore(state, planId);
                    if (result == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 关闭查看成绩");
                        Response.Write("成绩已关闭查询");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("关闭查询失败，可能当前批次没有可开放成绩");
                        Response.End();
                    }
                }
                else
                {
                    int openState = 1;
                    Result result = scoreBll.selectSate(openState, planId);
                    //按钮开关
                    if (result == Result.记录存在)
                    {
                        status = 1;//开
                    }
                    else
                    {
                        status = 0;//关
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
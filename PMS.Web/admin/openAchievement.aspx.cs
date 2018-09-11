﻿using PMS.BLL;
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
            Teacher teacher = new Teacher();
            Score score = new Score();
            if (op=="open")
            {
                score.openState = 1;
                teacher.state = 0;
                Result result = scoreBll.openScore(score);
                Result row = teacherBll.updateState(teacher);
                if (result==Result.更新成功 && row==Result.更新成功)
                {
                    Response.Write("成绩已开放");
                    Response.End();
                }
                else
                {
                    Response.Write("成绩开放失败");
                    Response.End();
                }
            }
            else if(op=="close")
            {
                score.openState = 0;
                Result result = scoreBll.openScore(score);
                if (result == Result.更新成功)
                {
                    Response.Write("成绩已关闭查询");
                    Response.End();
                }
                else
                {
                    Response.Write("关闭查询失败");
                    Response.End();
                }
            }
            else
            {
                int openState = 0;
                Result result = scoreBll.selectSate(openState);
                //按钮开关
                if (result == Result.记录存在)
                {
                    status = 0;//关
                }
                else
                {
                    status = 1;//开
                }
            }
        }
    }
}
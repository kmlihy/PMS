using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class addPaper : System.Web.UI.Page
    {
        ProfessionBll probll = new ProfessionBll();//调用专业对象
        Profession pro = new Profession();
        protected DataSet ds = null,pbds = null;
        int count = 1;
        PlanBll pbll = new PlanBll();//调用批次对象
        Plan plan = new Plan();
        protected string college;//获取学院
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];

            //selectPro();
            //调用下拉菜单数据
            TeacherBll teabll = new TeacherBll();
            //TODO 获取当前登录的教师账号
            //Teacher tea = (Teacher)Session["loginuser"];
            TableBuilder tb = new TableBuilder();
            ds = probll.Select();//调用专业方法
            pbds = pbll.Select();//调用批次方法

            if (op == "add")
            {
                string paperTitle = Request["paperTitle"].ToString();
                string profession = Request["profession"].ToString();
                string plans = Request["plan"].ToString();
                string numMax = Request["numMax"].ToString();
                string paperContent = Request["paperContent"].ToString();
                TitleBll titlebll = new TitleBll();
                Title title = new Title();
                title.title = paperTitle;
                title.TitleContent = paperContent;
                title.CreateTime = DateTime.Now;
                //TODO 专业批次选定人数为固定值，需重新改动
                title.Selected = 0;
                title.Limit = int.Parse(numMax);
                //TODO 固定发布教师账号
                Teacher tea = new Teacher();
                tea.TeaAccount = "admin";
                title.teacher = tea;
                title.plan = new Plan { PlanId = 1 };
                title.profession = new Profession { ProId = 1 };
                
                Result result = titlebll.Insert(title);
                if (result == Result.添加成功)
                {
                    Response.Write("添加成功");
                    Response.End();
                }
                else
                {
                    Response.Write("添加失败");
                    Response.End();
                }
            }
        }
    }
}
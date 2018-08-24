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
    public partial class addPaper : CommonPage
    {
        ProfessionBll probll = new ProfessionBll();//调用专业对象
        Profession pro = new Profession();
        protected DataSet prods = null,plands = null;
        int count = 1;
        PlanBll pbll = new PlanBll();//调用批次对象
        Plan plan = new Plan();
        protected string college;//获取学院
        protected string article;
        protected Title titleEdit;
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            article = Request.QueryString["article"];
            //调用下拉菜单数据
            TeacherBll teabll = new TeacherBll();
            //TODO 获取当前登录的教师账号
            Teacher tea = (Teacher)Session["loginuser"];
            //加载登录教师所在分院的专业
            TableBuilder tabuilderPro = new TableBuilder();
            tabuilderPro.StrTable = "T_Profession";
            tabuilderPro.StrWhere = "collegeId = '" + tea.college.ColID + "'";
            tabuilderPro.IntColType = 0;
            tabuilderPro.IntOrder = 0;
            tabuilderPro.IntPageNum = 1;
            tabuilderPro.IntPageSize = 100;
            tabuilderPro.StrColumn = "proId";
            tabuilderPro.StrColumnlist = "*";
            prods = probll.SelectBypage(tabuilderPro, out count);
            //加载登录教师所在分院的批次
            TableBuilder tabuilderPlan = new TableBuilder();
            tabuilderPlan.StrTable = "T_Plan";
            tabuilderPlan.StrWhere = "collegeId = '" + tea.college.ColID + "'";
            tabuilderPlan.IntColType = 0;
            tabuilderPlan.IntOrder = 0;
            tabuilderPlan.IntPageNum = 1;
            tabuilderPlan.IntPageSize = 100;
            tabuilderPlan.StrColumn = "planId";
            tabuilderPlan.StrColumnlist = "*";
            plands = pbll.SelectBypage(tabuilderPlan, out count);

            if (article == "edit")
            {
                string titleId = Request.QueryString["titleId"];
                Session["titleId"] = titleId;
                TitleBll titBll = new TitleBll();
                titleEdit = titBll.GetTitle(Convert.ToInt32(titleId));
                //string ti = title.Limit.ToString();
            }
            else {
                TitleBll titlebll = new TitleBll();
                Title title = new Title();

                if (op == "new")
                {
                    string paperTitle = Request["paperTitle"].ToString();
                    string profession = Request["profession"].ToString();
                    string plans = Request["plan"].ToString();
                    string numMax = Request["numMax"].ToString();
                    string paperContent = Request["paperContent"].ToString();
                    title.title = paperTitle;
                    title.TitleContent = HttpUtility.UrlDecode(paperContent);
                    title.CreateTime = DateTime.Now;
                    //TODO 专业批次选定人数为固定值，需重新改动
                    title.Selected = 0;
                    title.Limit = int.Parse(numMax);
                    title.teacher = (Teacher)Session["loginuser"];
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
                else if(op == "edit")
                {
                    string paperTitle = Request["paperTitle"].ToString();
                    string profession = Request["profession"].ToString();
                    string plans = Request["plan"].ToString();
                    string numMax = Request["numMax"].ToString();
                    string paperContent = Request["paperContent"].ToString();
                    title.TitleId = Convert.ToInt32(Session["titleId"].ToString());
                    title.title = paperTitle;
                    title.TitleContent = HttpUtility.UrlDecode(paperContent);
                    title.CreateTime = DateTime.Now;
                    //TODO 专业批次选定人数为固定值，需重新改动
                    title.Selected = 0;
                    title.Limit = int.Parse(numMax);
                    title.teacher = (Teacher)Session["loginuser"];
                    title.plan = new Plan { PlanId = 1 };
                    title.profession = new Profession { ProId = 1 };
                    Result result = titlebll.Update(title);
                    if (result == Result.更新成功)
                    {
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
            }
        }
    }
}
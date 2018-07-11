using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PMS.BLL.Enums;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class titleList : System.Web.UI.Page
    {
        protected DataSet ds = null;//储存标题表
        protected DataSet prods = null;//储存专业信息
        protected DataSet plads = null;//储存批次信息
        protected DataSet colds = null;//储存分院信息

        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 3;
        protected String search = "";
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected string showstr = null;
        protected string showinput = null;
        

        TeacherBll teabll = new TeacherBll();//教师对象
        ProfessionBll probll = new ProfessionBll();//专业
        PlanBll plabll = new PlanBll();//批次业务逻辑
        TitleBll titbll = new TitleBll();//标题业务逻辑

        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            //编辑
            if (op == "edit")
            {
                editTitle();
                Search();
                getdata(Search());
            }
            //删除
            if (op == "del")
            {
                deleteTitle();
                Search();
                getdata(Search());
            }
            //选择文本
            if (type == "textSelect")
            {                
                getdata(Search());
            }
            //批次下拉菜单
            if(type == "plandrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                if(dropstrWhereplan == "0")
                {
                    getdata("");
                }
                string strWhere = string.Format(" planId = {0}", dropstrWhereplan);
                getdata(strWhere);
            }
            //专业下拉菜单
            if(type == "prodrop")
            {
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0}", dropstrWherepro);
                getdata(strWhere);
            }
            //所有下拉菜单
            if(type == "alldrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
                getdata(strWhere);
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TitleBll titbll = new TitleBll();
            TableBuilder tabuilder = new TableBuilder();
            tabuilder.StrTable = "V_Title";
            tabuilder.StrWhere = (strWhere == null ? "" : strWhere);
            tabuilder.IntColType = 0;
            tabuilder.IntOrder = 0;
            tabuilder.IntPageNum = int.Parse(currentPage);
            tabuilder.IntPageSize = pagesize;
            tabuilder.StrColumn = "titleId";
            tabuilder.StrColumnlist = "*";
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
            
            colds = colbll.Select();
            prods = probll.Select();
            plads = plabll.Select();
        }

        /// <summary>
        /// 查询筛选方法
        /// </summary>
        /// <returns>返回查询参数</returns>
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format("titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }

        /// <summary>
        /// 编辑题目
        /// </summary>
        public void editTitle()
        {
            int titleId = int.Parse(Context.Request["saveTitleId"].ToString());
            string title = Context.Request["saveTitle"].ToString();
            string plans = Context.Request["savePlan"].ToString();
            string prof = Context.Request["saveProf"].ToString();
            string teaName = Context.Request["saveTeaName"].ToString();
            int limit = int.Parse(Context.Request["saveLimit"].ToString());
            DateTime createTime = Convert.ToDateTime(Context.Request["saveCreateTime"].ToString());
            string content = Context.Request["saveContent"].ToString();
            int selected = int.Parse(Context.Request["saveSelected"].ToString());
            
            Plan pla = new Plan();
            pla.PlanName = plans;

            Profession pro = new Profession();
            pro.ProName = prof;

            Teacher tea = new Teacher();
            tea.TeaAccount = teaName;

            TitleBll tbll = new TitleBll();
            Title getTitle = tbll.GetTitle(titleId);
            try
            {
                getTitle.TitleId = titleId;
                getTitle.title = title;
                getTitle.plan = pla;
                getTitle.profession = pro;
                getTitle.teacher = tea;
                getTitle.Limit = limit;
                getTitle.CreateTime = createTime;
                getTitle.TitleContent = content;
                getTitle.Selected = selected;

                Result result = tbll.Update(getTitle);
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
            catch (Exception ex) { Response.Write(ex.Message); }
        }

        /// <summary>
        /// 判断是否能删除
        /// </summary>
        /// <returns>返回删除结果</returns>
        public Result isDeleteTitle()
        {
            string titleId = Context.Request["deleteTitleId"].ToString();
            Result delResult = Result.记录不存在;
            if (titbll.IsDelete("T_TitleRecord", "titleId", titleId) == Result.关联引用)
            {
                delResult = Result.关联引用;
            }
            return delResult;
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        public void deleteTitle()
        {
            int titleId = int.Parse(Context.Request["deleteTitleId"].ToString());
            Result row = isDeleteTitle();
            if (row == Result.记录不存在)
            {
                Result result = titbll.Delete(titleId);
                if (result == Result.删除成功)
                {
                    Response.Write("删除成功");
                    Response.End();
                }
                else
                {
                    Response.Write("删除失败");
                    Response.End();
                }
            }
            else
            {
                Response.Write("在其他表中有关联不能删除");
                Response.End();
            }
        }
    }
}
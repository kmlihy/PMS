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
    public partial class myReplyStudent : CommonPage
    {
        protected DataSet ds = null;//储存标题表
        protected DataSet prods = null;//储存专业信息
        protected DataSet plads = null;//储存批次信息
        protected DataSet colds = null;//储存分院信息

        protected int getCurrentPage = 1,count,pagesize = 5,state;
        protected String search = "";
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected string showstr = null;
        protected string showinput = null;
        protected string secSearch = "";
        protected string defenGroupId = null;
        TeacherBll teabll = new TeacherBll();//教师对象
        ProfessionBll probll = new ProfessionBll();//专业
        PlanBll plabll = new PlanBll();//批次业务逻辑
        TitleBll titbll = new TitleBll();//标题业务逻辑
        Teacher tea = new Teacher();
        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (state == 1)
            {
                tea = (Teacher)Session["loginuser"];
            }
            else if (state == 2)
            {
                tea = (Teacher)Session["user"];
            }
            state = Convert.ToInt32(Session["state"]);
            string op = Context.Request["op"];
            string type = Request.QueryString["type"];
            //获取defenRecordId
            defenGroupId = Request.QueryString["defenGroupId"].ToString();
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
                if (defenGroupId != null)
                {
                    Session["defenGroupId"] = defenGroupId;
                }
                else
                {
                    defenGroupId = Session["defenGroupId"].ToString();
                }
            }
            //选择文本
            if (type == "textSelect")
            {
                getdata(Search());
            }
            //批次下拉菜单
            if (type == "plandrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                if (dropstrWhereplan == "0")
                {
                    getdata("");
                }
                string strWhere = string.Format(" planId = {0}", dropstrWhereplan);
                getdata(strWhere);
            }
            //专业下拉菜单
            if (type == "prodrop")
            {
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0}", dropstrWherepro);
                getdata(strWhere);
            }
            //所有下拉菜单
            if (type == "alldrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
                getdata(strWhere);
            }
            string alert = Request.QueryString["state"];
            if (alert == "1")
            {
                Response.Write("<script>alert('批次已激活，不可编辑')</script>");
            }
            if(op == "delete")
            {
                int defenRecordId = Convert.ToInt32(Request["defenRecordId"]);
                DefenceBll defenceBll = new DefenceBll();
                try
                {
                    Result row = defenceBll.DelRecord(defenRecordId);
                    if (row == Result.删除成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 删除" + defenRecordId + "答辩记录");
                        Response.Write("删除成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("删除失败");
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
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
            string account = "defenGroupId = "+ defenGroupId;

            string Account = account + " and ";
            TableBuilder tabuilder = new TableBuilder();
            tabuilder.StrTable = "V_DefenceRecord";
            tabuilder.StrWhere = (strWhere == null || strWhere == "" ? account : Account + strWhere);
            tabuilder.IntColType = 0;
            tabuilder.IntOrder = 0;
            tabuilder.IntPageNum = int.Parse(currentPage);
            tabuilder.IntPageSize = pagesize;
            tabuilder.StrColumn = "defenRecordId";
            tabuilder.StrColumnlist = "*";
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
            //加载所有分院
            colds = colbll.Select();
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
            plads = plabll.SelectBypage(tabuilderPlan, out count);
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
                    secSearch = "";
                }
                else if (search == null)
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    secSearch = search;
                    search = String.Format("stuAccount {0} or proName {0} or planName {0} or realName {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
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

        protected int getCurrentPage = 1,count,pagesize = 20,state;
        protected String search = "";
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected String dropstrWherecoll = "";
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
            state = Convert.ToInt32(Session["state"]);
            if (state == 1)
            {
                tea = (Teacher)Session["loginuser"];
            }
            else if (state == 2 || state == 0)
            {
                tea = (Teacher)Session["user"];
            }
            string op = Context.Request["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                //获取defenRecordId
                defenGroupId = Request["defenGroupId"];
                if (defenGroupId != null)
                {
                    Session["defenGroupId"] = defenGroupId;
                }
                else
                {
                    defenGroupId = Session["defenGroupId"].ToString();
                }
                colds = colbll.Select();
                Search();
                getdata(Search());
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
            string type = Request.QueryString["type"];
            //选择文本
            if (type == "textSelect")
            {
                strWhere = Search();
            }
            //批次下拉菜单
            if (type == "plandrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                if (dropstrWhereplan == "0")
                {
                    strWhere = "";
                }
                strWhere = string.Format(" planId = {0}", dropstrWhereplan);
            }
            //专业下拉菜单
            if (type == "prodrop")
            {
                dropstrWherepro = Request["dropstrWherepro"];
                strWhere = string.Format(" proId = {0}", dropstrWherepro);
            }
            //学院下拉菜单
            if (type == "colldrop")
            {
                dropstrWherecoll = Request["dropstrWherecoll"];
                strWhere = string.Format(" collegeId = {0}", dropstrWherecoll);
                //加载超管所选分院的所有专业
                TableBuilder tabuilderPro = new TableBuilder();
                tabuilderPro.StrTable = "T_Profession";
                tabuilderPro.StrWhere = "collegeId = '" + dropstrWherecoll + "'";
                tabuilderPro.IntColType = 0;
                tabuilderPro.IntOrder = 0;
                tabuilderPro.IntPageNum = 1;
                tabuilderPro.IntPageSize = 100;
                tabuilderPro.StrColumn = "proId";
                tabuilderPro.StrColumnlist = "*";
                prods = probll.SelectBypage(tabuilderPro, out count);
                //加载超管所选分院的所有批次
                TableBuilder tabuilderPlan = new TableBuilder();
                tabuilderPlan.StrTable = "T_Plan";
                tabuilderPlan.StrWhere = "collegeId = '" + dropstrWherecoll + "'";
                tabuilderPlan.IntColType = 0;
                tabuilderPlan.IntOrder = 0;
                tabuilderPlan.IntPageNum = 1;
                tabuilderPlan.IntPageSize = 100;
                tabuilderPlan.StrColumn = "planId";
                tabuilderPlan.StrColumnlist = "*";
                plads = plabll.SelectBypage(tabuilderPlan, out count);
            }
            //所有下拉菜单
            if (type == "alldrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
            }
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
            if (state == 2 || state == 1)
            {
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
            else if(state == 0)
            {
                dropstrWherecoll = Request["dropstrWherecoll"];
                dropstrWherepro= Request["dropstrWherepro"];
                dropstrWhereplan = Request["dropstrWhereplan"];
                //加载超管所选分院的所有专业
                TableBuilder tabuilderPro = new TableBuilder();
                tabuilderPro.StrTable = "T_Profession";
                tabuilderPro.StrWhere = "collegeId = '" + dropstrWherecoll + "'";
                tabuilderPro.IntColType = 0;
                tabuilderPro.IntOrder = 0;
                tabuilderPro.IntPageNum = 1;
                tabuilderPro.IntPageSize = 100;
                tabuilderPro.StrColumn = "proId";
                tabuilderPro.StrColumnlist = "*";
                prods = probll.SelectBypage(tabuilderPro, out count);
                //加载超管所选分院的所有批次
                TableBuilder tabuilderPlan = new TableBuilder();
                tabuilderPlan.StrTable = "T_Plan";
                tabuilderPlan.StrWhere = "collegeId = '" + dropstrWherecoll + "'";
                tabuilderPlan.IntColType = 0;
                tabuilderPlan.IntOrder = 0;
                tabuilderPlan.IntPageNum = 1;
                tabuilderPlan.IntPageSize = 100;
                tabuilderPlan.StrColumn = "planId";
                tabuilderPlan.StrColumnlist = "*";
                plads = plabll.SelectBypage(tabuilderPlan, out count);
            }
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
                    if (state == 0)
                    {
                        search = String.Format("stuAccount {0} or proName {0} or planName {0} or collegeName {0} or realName {0} ", "like '%" + search + "%'");
                    }
                    else
                    {
                        search = String.Format("stuAccount {0} or proName {0} or planName {0} or realName {0} ", "like '%" + search + "%'");
                    }
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
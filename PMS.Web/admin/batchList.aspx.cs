using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;
using System.Globalization;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class batchList : System.Web.UI.Page
    {
        protected DataSet plands = null;//批次
        protected DataSet ds;
        protected DataSet colds = null;//院系

        protected int count;
        protected int getCurrentPage = 1;
        protected int pagesize = 5;

        protected String search = "";
        protected String secSearch = "";
        protected String searchdrop = "";
        protected string showstr = "";
        protected string showinput = null;
        protected Teacher loginUser;
        protected string collegeName;
        protected int state;

        PlanBll planBll = new PlanBll();
        CollegeBll colBll = new CollegeBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string editorOp = Context.Request["editorOp"];
            string delOp = Context.Request["delOp"];
            string type = Request.QueryString["type"];
            loginUser = (Teacher)Session["user"];
            state = Convert.ToInt32(Session["state"].ToString());
            collegeName = loginUser.college.ColName.ToString();
            if (!Page.IsPostBack)
            {
                getdata("");
                colds = colBll.Select();
            }
            if (op == "add")//添加
            {
                savePlan();
            }
            if (editorOp == "editor")//编辑
            {
                EditorPlan();
            }
            if (delOp == "del")//删除
            {
                deletePlan();
            }
            if (type == "btn")
            {
                getdata(Search());
            }
            if(type == "drop")
            {
                getdata(Searchdrop());
            }
        }
        /// <summary>
        /// 编辑批次
        /// </summary>
        public void EditorPlan()
        {
            string planName = Context.Request["editorPlanName"].ToString();
            DateTime startTime = Convert.ToDateTime(Context.Request["editorStartTime"].ToString()),
                   endTime = Convert.ToDateTime(Context.Request["editorEndTime"].ToString());
            int state = int.Parse(Context.Request["editorState"].ToString()),
                planId = int.Parse(Context.Request["editorPlanId"].ToString()),
                collegeId = int.Parse(Context.Request["planCollegeId"].ToString());
            College coll = new College()
            {
                ColID = collegeId
            };
            Plan plan = new Plan()
            {
                PlanId = planId,
                PlanName = planName,
                StartTime = startTime,
                EndTime = endTime,
                State = state,
                college = coll
            };
            try
            {
                PlanBll pBll = new PlanBll();
                Result EditorResult = pBll.Update(plan);
                //字符串转日期
                string start = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd HH:mm");
                DateTime startdt = Convert.ToDateTime(start);
                string end = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd HH:mm");
                DateTime enddt = Convert.ToDateTime(end);

                if (startdt < enddt)
                {
                    if (EditorResult == Result.更新成功)
                    {
                        Response.Write("更新成功");
                        //Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        //Response.End();
                    }
                }
                else
                {
                    Response.Write("开始时间必须小于结束时间");
                }
            }
            catch(Exception ex) { Response.Write(ex.Message); }
            finally
            {
                Response.End();
            }
        }
        /// <summary>
        /// 添加批次
        /// </summary>
        public void savePlan()
        {
            //获取参数
            string planName = Context.Request["planName"].ToString(),
                   startTime = Context.Request["startTime"].ToString(),
                   endTime = Context.Request["endTime"].ToString(),
                   college = Context.Request["college"].ToString(),
                   planstate = Context.Request["state"].ToString();
            //int state = int.Parse(Context.Request["state"].ToString());
            //collegeId = int.Parse(Context.Request["college"].ToString());
            if (planName != ""&&startTime != ""&&endTime !=""&&state.ToString()!=""&&college!="") {
                int collegeId = int.Parse(college),
                    state = int.Parse(planstate);
                //字符串转日期
                string start = Convert.ToDateTime(startTime).ToString("yyyy-MM-dd HH:mm");
                DateTime startdt = Convert.ToDateTime(start);
                string end = Convert.ToDateTime(endTime).ToString("yyyy-MM-dd HH:mm");
                DateTime enddt = Convert.ToDateTime(end);

                //实例化参数
                College coll = new College()
                {
                    ColID = collegeId
                };
                //判断当开始时间在结束时间之后时，不能执行添加
                if (startdt < enddt) {
                    Plan plan = new Plan()
                    {
                        PlanName = planName,
                        StartTime = startdt,
                        EndTime = enddt,
                        State = state,
                        college = coll
                    };
                    PlanBll pBll = new PlanBll();
                    Result result = pBll.Insert(plan);
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
                else
                {
                    Response.Write("开始时间必须小于结束时间");
                    Response.End();
                }
            }
            else
            {
                Response.Write("以上内容不能出现未填项");
                Response.End();
            }
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="strWhere"></param>
        public void getdata(String strWhere)
        {
            loginUser = (Teacher)Session["user"];
            collegeName = loginUser.college.ColName.ToString();
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            BLL.StudentBll sdao = new StudentBll();
            StudentBll pro = new StudentBll();
            string account = "collegeName = '" + collegeName + "'";
            string Account = "collegeName = '" + collegeName + "' and ";
            int state = int.Parse(Session["state"].ToString());
            if (state == 2)
            {
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Plan",
                    StrWhere = strWhere == null || strWhere == "" ? account : Account + strWhere,
                    IntColType = 0,
                    IntOrder = 0,
                    IntPageNum = int.Parse(currentPage),
                    IntPageSize = pagesize,
                    StrColumn = "planId",
                    StrColumnlist = "*"
                };
                getCurrentPage = int.Parse(currentPage);
                plands = pro.SelectBypage(tabuilder, out count);
            }
            else
            {
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Plan",
                    StrWhere = strWhere == null || strWhere == "" ? "" : strWhere,
                    IntColType = 0,
                    IntOrder = 0,
                    IntPageNum = int.Parse(currentPage),
                    IntPageSize = pagesize,
                    StrColumn = "planId",
                    StrColumnlist = "*"
                };
                getCurrentPage = int.Parse(currentPage);
                plands = pro.SelectBypage(tabuilder, out count);
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public string Search()
        {
            try {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                    secSearch = "";
                }
                else if (search == null || search == "")
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    secSearch = search;
                    search = String.Format("planName {0} or collegeName {0}", "like " + "'%" + search + "%'");
                }
            }
            catch { }
            return search;
        }
        /// <summary>
        /// 下拉查询
        /// </summary>
        /// <returns></returns>
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropstrWhere"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                    //下拉框保留查询条件
                    showstr = "0";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                    //下拉框保留查询条件
                    showstr = "0";
                }
                else
                {
                    //下拉框保留查询条件
                    showstr = searchdrop;
                    searchdrop = String.Format("collegeId={0} ", "'" + searchdrop + "'");
                }
            }
            catch
            {
            }
            return searchdrop;
        }
        /// <summary>
        /// 判断是否能删除批次
        /// </summary>
        /// <returns></returns>
        public Result isDeletePlan()
        {
            string planId = Context.Request["deletePlanId"].ToString();
            Result delResult = Result.记录不存在;
            if (planBll.IsDelete("T_Title", "planId", planId) == Result.关联引用)
            {
                delResult = Result.关联引用;
            }
            return delResult;
        }
        /// <summary>
        /// 删除批次
        /// </summary>
        public void deletePlan()
        {
            int planId = int.Parse(Context.Request["deletePlanId"].ToString());
            Result row = isDeletePlan();
            if (row == Result.记录不存在)
            {
                Result result = planBll.Delete(planId);
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
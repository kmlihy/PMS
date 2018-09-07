using PMS.BLL;
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
    public partial class distributionReplyTeam : System.Web.UI.Page
    {
        public DataSet getPlan,getLeader,getMember,getRecord,getColl,dsPlan,ds;
        public int state;
        public string op, leader, member, record,_planId,coll,planid;
        public int getCurrentPage = 1, pagesize = 1, count;
        protected string search = "",showmsg = "", searchPlan = "", searchCollege = "";
        protected string userType = "", showColl = "", showPlan = "";
        PlanBll planBll = new PlanBll();
        DefenceBll defenceBll = new DefenceBll();
        TeacherBll teacherBll = new TeacherBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            Teacher teacher = (Teacher)Session["user"];
            int collegeId = teacher.college.ColID;
            state = Convert.ToInt32(Session["state"]);
            if (state==0)
            {
                //超管
                coll = Request.QueryString["collegeId"];
                planid = Request.QueryString["planId"];
                Coll();
                getdata(Search());
            }
            else if(state==2)
            {
                //分管
                planid = Request.QueryString["planId"];
                dsPlan = planBll.getPlanByCid(collegeId);
                leader = Request.QueryString["leader"];
                member = Request.QueryString["member"];
                record = Request.QueryString["record"];
                _planId = Request.QueryString["planId"];
                getPlan = planBll.getPlanByCid(collegeId);
                op = Request.QueryString["op"];
                string submit = Request["submit"];
                if (submit == "submit")
                {
                    insert();
                }
                if (op==""||op==null)
                {
                    getLeader = teacherBll.getLeaderByColl(collegeId, "", "");
                    getMember = teacherBll.getMemberByColl(collegeId, "", "");
                    getRecord = teacherBll.getRecordByColl(collegeId, "", "");
                }
                else
                {
                    if (op == "change1")
                    {
                        getLeader = teacherBll.getLeaderByColl(collegeId, member, record);
                        getMember = teacherBll.getMemberByColl(collegeId, leader, record);
                        getRecord = teacherBll.getRecordByColl(collegeId, leader, member);
                    }
                    else if (op == "change2")
                    {
                        getLeader = teacherBll.getLeaderByColl(collegeId, member, record);
                        getMember = teacherBll.getMemberByColl(collegeId, leader, record);
                        getRecord = teacherBll.getRecordByColl(collegeId, leader, member);
                    }
                    else if (op == "change3")
                    {
                        getLeader = teacherBll.getLeaderByColl(collegeId, member, record);
                        getMember = teacherBll.getMemberByColl(collegeId, leader, record);
                        getRecord = teacherBll.getRecordByColl(collegeId, leader, member); ;
                    }
                }
                getdata(Search());
            }
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            string PlanId = Request.QueryString["planId"];
            string CollId = Request.QueryString["collegeId"];
            if(PlanId == "0" && CollId == "0")
            {
                getdata(Search());
            }
            else if(CollId != "0" && PlanId == "0")
            {
                getdata(SearchCollege());
            }
            else if (PlanId != "0" && CollId == "0")
            {
                getdata(SearchPlan());
            }
            else if(PlanId != "0" && CollId != "0")
            {
                getdata(SearchCollAndPlan());
            }
        }
        /// <summary>
        /// 添加答辩小组
        /// </summary>
        private void insert()
        {
            string leaderId = Request["leaderId"];
            string memberId = Request["memberId"];
            string recordId = Request["recordId"];
            string planId = Request["planId"];
            Teacher teaLeader = teacherBll.GetModel(leaderId);
            Teacher teaMember = teacherBll.GetModel(memberId);
            Teacher tearecord = teacherBll.GetModel(recordId);
            string leaderName = teaLeader.TeaName;
            string memberName = teaMember.TeaName;
            string recordName = tearecord.TeaName;

            DefenceGroup defenceGroup = new DefenceGroup();
            defenceGroup.leader = leaderId;
            defenceGroup.member = memberId;
            defenceGroup.recorder = recordId;
            defenceGroup.leaderName = leaderName;
            defenceGroup.memberName = memberName;
            defenceGroup.recordName = recordName;
            Plan plan = new Plan();
            plan.PlanId = Convert.ToInt32(planId);
            defenceGroup.plan = plan;
            //添加过的教师不显示
            Result result, row1, row2, row3;
            teaLeader.state = 1;
            row1 = teacherBll.Updata(teaLeader);
            teaMember.state = 1;
            row2 = teacherBll.Updata(teaMember);
            tearecord.state = 1;
            row3 = teacherBll.Updata(tearecord);
            if (row1 == Result.更新失败 || row2 == Result.更新失败 || row3 == Result.更新失败)
            {
                teaLeader.state = 0;
                row1 = teacherBll.Updata(teaLeader);
                teaMember.state = 0;
                row2 = teacherBll.Updata(teaMember);
                tearecord.state = 0;
                row3 = teacherBll.Updata(tearecord);
                result = Result.添加失败;
            }
            else {
                result = defenceBll.InsertGroup(defenceGroup);
            }
            if (result == Result.添加成功)
            {
                Response.Write("分配成功");
                Response.End();
            }
            else
            {
                Response.Write("分配失败");
                Response.End();
            }
        }

        /// <summary>
        /// 获取学院下拉框数据
        /// </summary>
        private void Coll()
        {
            CollegeBll collegeBll = new CollegeBll();
            getColl = collegeBll.Select();
            dsPlan = planBll.getPlanByCid(Convert.ToInt32(coll));
        }

        /// <summary>
        /// 批次下拉框查询
        /// </summary>
        /// <returns></returns>
        public string SearchPlan()
        {
            try
            {
                searchPlan = Request.QueryString["planId"];
                if (searchPlan.Length == 0)
                {
                    searchPlan = "";
                }
                else if (searchPlan == null)
                {
                    searchPlan = "";
                }
                else if (searchPlan == "0")
                {
                    searchPlan = "";
                }
                else
                {
                    //下拉框保留查询条件
                    showPlan = searchPlan;
                    searchPlan = String.Format("planId={0} ", "'" + searchPlan + "'");
                }
            }
            catch
            {
            }
            return searchPlan;
        }

        /// <summary>
        /// 学院下拉查询
        /// </summary>
        /// <returns></returns>
        public string SearchCollege()
        {

            try
            {
                searchCollege = Request.QueryString["collegeId"];
                if (searchCollege.Length == 0)
                {
                    searchCollege = "";
                }
                else if (searchCollege == null)
                {
                    searchCollege = "";
                }
                else if (searchCollege == "0")
                {
                    searchCollege = "";
                }
                else
                {
                    //分院下拉搜索后条件保存
                    showColl = searchCollege;
                    searchCollege = String.Format(" collegeId={0}", searchCollege);
                }
            }
            catch
            {

            }
            return searchCollege;
        }

        public string SearchCollAndPlan()
        {
            try
            {
                searchPlan = Request.QueryString["planId"];
                searchCollege = Request.QueryString["collegeId"];
                //分院下拉搜索后条件保存
                showColl = searchCollege;
                showPlan = searchPlan;
                search = String.Format(" collegeId={0} and planId={1}", searchCollege, searchPlan);
            }
            catch
            {

            }
            return search;
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        /// <returns></returns>
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
                    showmsg = search;
                    search = String.Format("planName {0} or leaderName {0} or memberName {0} or collegeName {0} or recordName {0}", "like " + "'%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            string userType = Session["state"].ToString();
            string userCollege = "";
            //usertype=2 为分院管理员登录
            TeacherBll teaBll = new TeacherBll();
            if (userType == "2")
            {
                Teacher tea = (Teacher)Session["user"];
                int userCollegeId = tea.college.ColID;
                if (strWhere == null || strWhere == "")
                {
                    userCollege = "collegeId=" + userCollegeId + "";
                }
                else
                {
                    userCollege = "collegeId=" + userCollegeId + "and" + "(" + strWhere + ")";
                }
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Defence",
                    StrWhere = userCollege,
                    IntColType = 0,
                    IntOrder = 0,
                    IntPageNum = int.Parse(currentPage),
                    IntPageSize = pagesize,
                    StrColumn = "defenGroupId",
                    StrColumnlist = "*"
                };
                getCurrentPage = int.Parse(currentPage);
                ds = teaBll.SelectBypage(tabuilder, out count);

            }
            else
            {
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Defence",
                    StrWhere = strWhere == null || strWhere == "" ? "" : strWhere,
                    IntColType = 0,
                    IntOrder = 0,
                    IntPageNum = int.Parse(currentPage),
                    IntPageSize = pagesize,
                    StrColumn = "defenGroupId",
                    StrColumnlist = "*"
                };
                getCurrentPage = int.Parse(currentPage);
                ds = teaBll.SelectBypage(tabuilder, out count);
            }
        }
    }
}

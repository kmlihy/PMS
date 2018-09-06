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
        public DataSet getPlan,getLeader,getMember,getRecord,getColl,dsPlan;
        public int state;
        public string op, leader, member, record,_planId,coll,planid;
        public int getCurrentPage = 1, pagesize = 5, count;
        protected string search = "", searchdrop = "", searchCollege = "", searchProAndCollege = "", showmsg = "";
        protected string showstr = null, showcollegedrop = "", userType = "";
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
                state = 0;
                coll = Request.QueryString["collegeId"];
                planid = Request.QueryString["planId"];
                Coll();
            }
            else if(state==2)
            {
                //分管
                state = 2;
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
            }
        }

        private void insert()
        {
            string leaderId = Request["leaderId"];
            string memberId = Request["memberId"];
            string recordId = Request["recordId"];
            string planId = Request["planId"];
            Teacher teaLeader = teacherBll.GetModel(leaderId);
            Teacher teaMember = teacherBll.GetModel(memberId);
            Teacher tearecord = teacherBll.GetModel(planId);
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
            Result result = defenceBll.InsertGroup(defenceGroup);
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

        private void Coll()
        {
            CollegeBll collegeBll = new CollegeBll();
            getColl = collegeBll.Select();
            dsPlan = planBll.getPlanByCid(Convert.ToInt32(coll));
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
                    search = String.Format("stuAccount {0} or sex {0} or realName {0} or collegeName {0} or phone {0} or Email {0} or proName {0} ", "like " + "'%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
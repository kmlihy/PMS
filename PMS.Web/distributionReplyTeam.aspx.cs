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
        public DataSet getPlan,getLeader,getMember,getRecord;
        public int state;
        public string op, leader, member, record,_planId;
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
            }
            else if(state==2)
            {
                //分管
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

        public void insert()
        {
            string leaderId = Request["leaderId"];
            string memberId = Request["memberId"];
            string recordId = Request["recordId"];
            string planId = Request["planId"];
            DefenceGroup defenceGroup = new DefenceGroup();
            defenceGroup.leader = leaderId;
            defenceGroup.member = memberId;
            defenceGroup.recorder = recordId;
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
    }
}
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
    public partial class oralDefenseStudent : System.Web.UI.Page
    {

        TitleRecordBll titleRecordBll = new TitleRecordBll();
        DefenceBll defenceBll = new DefenceBll();
        TeacherBll teacherBll = new TeacherBll();

        public string RTId;
        public string leaderName, memberName, recorderName;
        public string leaderTel, memberTel, recorderTel;
        public string leaderMail, memberMail,recorderMail;

        protected void Page_Load(object sender, EventArgs e)
        {
            getPage();
        }
        public void getPage()
        {
            Student stu = (Student)Session["loginuser"];
            string account = stu.StuAccount;
            TitleRecord titleRecord = titleRecordBll.getRtId(account);
            RTId = titleRecord.TitleRecordId.ToString();
            //暂未选题
            if (RTId=="0" || RTId == ""|| RTId == null)
            {
                RTId = "";
            }
            //暂未指定答辩小组
            else if (!defenceBll.isGroup(RTId))
            {
                RTId = "noGroup";
            }
            else
            {

                DefenceGroup getDgId = defenceBll.getDgId(RTId);
                string dgId = getDgId.defenGroupId.ToString();
                DefenceGroup defenceGroup = defenceBll.getTeaId(dgId);

                ///分别取到小组成员账号
                string leader = defenceGroup.leader;
                string member = defenceGroup.member;
                string recorder = defenceGroup.recorder;

                Teacher leaderId = teacherBll.GetModel(leader);
                Teacher memberId = teacherBll.GetModel(member);
                Teacher recorderId = teacherBll.GetModel(recorder);

                //取到姓名
                leaderName = leaderId.TeaName;
                memberName = memberId.TeaName;
                recorderName = recorderId.TeaName;
                //取到电话
                leaderTel = leaderId.Phone;
                memberTel = memberId.Phone;
                recorderTel = recorderId.Phone;
                //取到邮箱
                leaderMail = leaderId.Email;
                memberMail = memberId.Email;
                recorderMail = recorderId.Email;
            }
        }
    }
}
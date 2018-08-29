using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class mediiumQuality : CommonPage
    {
        public string stuAccount, stuName, profession, college, title, teaName;
        public int state;
        public MedtermQuality mq = new MedtermQuality();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            TitleRecord tr = new TitleRecord();
            MedtermQualityBll mqbll = new MedtermQualityBll();
            MedtermQuality medterm = new MedtermQuality();
            state =Convert.ToInt32(Session["state"].ToString());
            if (state == 1)
            {
                Teacher teacher = (Teacher)Session["loginuser"];
                string teaAccount = teacher.TeaAccount;
                tr = trbll.GetByAccount(teaAccount);
                stuAccount = tr.student.StuAccount;
                stuName = tr.student.RealName;
                profession = tr.profession.ProName;
                college = teacher.college.ColName;
                title = tr.title.title;
                teaName = teacher.TeaName;
            }
            else if(state == 3)
            {
                Student student = (Student)Session["loginuser"];
                stuAccount = student.StuAccount;
                stuName = student.RealName;
                profession = student.profession.ProName;
                college = student.college.ColName;
                tr = trbll.GetByAccount(stuAccount);
                title = tr.title.title;
                teaName = tr.teacher.TeaName;
            }
            string op = Request["op"];
            if(op == "student")
            {
                string plan = Request["student"];
                medterm.planFinishSituation = plan;
                medterm.dateTime = DateTime.Now;
                medterm.titleRecord = tr;
                Result row = mqbll.stuInsert(medterm);
                if(row == Result.添加成功)
                {
                    Response.Write("提交成功");
                    Response.End();
                }
                else
                {
                    Response.Write("提交失败");
                    Response.End();
                }
            }
            else if(op == "teacher")
            {
                string opinion = Request["teacher"];
                medterm.teacherOpinion = opinion;
                medterm.dateTime = DateTime.Now;
                medterm.titleRecord = tr;
                Result row = mqbll.teaInsert(medterm);
                if (row == Result.添加成功)
                {
                    Response.Write("提交成功");
                    Response.End();
                }
                else
                {
                    Response.Write("提交失败");
                    Response.End();
                }
            }
            mq = mqbll.Select(tr.TitleRecordId);
        }
    }
}
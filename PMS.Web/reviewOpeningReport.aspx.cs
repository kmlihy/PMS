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
    public partial class reviewOpeningReport : CommonPage
    {
        public string stuAccount, stuName, profession, title, teaName;
        public OpenReport or;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            TitleRecord tr = trbll.GetByAccount(teaAccount);
            stuAccount = tr.student.StuAccount;
            stuName = tr.student.RealName;
            profession = tr.profession.ProName;
            title = tr.title.title;
            teaName = teacher.TeaName;
            OpenReportBll orbll = new OpenReportBll();
            or = orbll.Select(tr.TitleRecordId);
            string op = Request["op"];
            if(op == "review")
            {
                string teacherOpinion = Request["teacherOpinion"];
                Result row = orbll.teaInsert(tr.TitleRecordId, teacherOpinion);
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
        }
    }
}
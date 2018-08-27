using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMS.Web
{
    public partial class openingReport : CommonPage
    {
        public string stuAccount, stuName, profession, title, teaName;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            Student student = (Student)Session["loginuser"];
            stuAccount = student.StuAccount;
            stuName = student.RealName;
            profession = student.profession.ProName;
            TitleRecord tr = trbll.GetByAccount(stuAccount);
            title = tr.title.title;
            teaName = tr.teacher.TeaName;
            if(Request["op"] !=null || Request["op"] != "")
            {
                string meaning = Request["meaning"];
                string trend = Request["trend"];
                string content = Request["content"];
                string plan = Request["plan"];
                string method = Request["method"];
                string outline = Request["outline"];
                string reference = Request["reference"];
            }
        }
    }
}
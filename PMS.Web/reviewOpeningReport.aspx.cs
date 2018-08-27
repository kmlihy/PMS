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
    public partial class reviewOpeningReport : CommonPage
    {
        public string stuAccount, stuName, profession, title, teaName;
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

        }
    }
}
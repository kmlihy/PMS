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
    public partial class thesisSubmit : System.Web.UI.Page
    {
        public int state, openState;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll titleRecordBll = new TitleRecordBll();
            PathBll pathBll = new PathBll();
            TitleRecord titleRecord = titleRecordBll.getRtId(stuAccount);
            int titleRecordId = titleRecord.TitleRecordId;
            OpenReport openReport = titleRecordBll.getState(titleRecordId);
            Path path = pathBll.getState(titleRecordId,0);
            openState = openReport.state;
            state = path.state;
        }
    }
}
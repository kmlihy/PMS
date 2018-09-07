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
    public partial class checkReport : System.Web.UI.Page
    {
        PathBll pathBll = new PathBll();
        public int state;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll titleRecordBll = new TitleRecordBll();
            TitleRecord titleRecord = titleRecordBll.getRtId(stuAccount);
            int rtId = titleRecord.TitleRecordId;
            if (rtId==0)
            {
                state = 3;
            }
            else
            {
                Result result = pathBll.selectByTitleRecordId(rtId.ToString());
                if (result == Result.记录存在)
                {
                    state = 1;
                }
                else
                {
                    state = 0;
                }
            }
        }
    }
}
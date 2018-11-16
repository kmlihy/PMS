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
    public partial class checkReport : CommonPage
    {
        PathBll pathBll = new PathBll();
        public int state,pstate;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll titleRecordBll = new TitleRecordBll();
            TitleRecord titleRecord = titleRecordBll.getRtId(stuAccount);
            int rtId = titleRecord.TitleRecordId;
            Path path = pathBll.getState(rtId,1);
            pstate = path.state;
            if (rtId==0)
            {
                //未选题
                state = 3;
            }
            else
            {
                Result result = pathBll.selectByTitleRecordId(rtId.ToString());
                if (result == Result.记录存在)
                {
                    //显示页面
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
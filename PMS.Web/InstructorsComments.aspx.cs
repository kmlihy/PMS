using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class InstructorsComments : System.Web.UI.Page
    {
        public DataSet getData;
        GuideRecordBll guideRecordBll = new GuideRecordBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string stuAccount = Request.QueryString["stuAccount"];
            int titleRecordId = Convert.ToInt32(Request.QueryString["titleRecordId"]);
            getData = guideRecordBll.Select(titleRecordId, stuAccount);
        }
    }
}
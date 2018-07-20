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
    public partial class stuCenter : System.Web.UI.Page
    {

        protected Student student = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO 改成从session里获取值
            student = (Student)Session["loginuser"];
            StudentBll sbll = new StudentBll();
            student = sbll.GetModel(student.StuAccount);
        }
    }
}
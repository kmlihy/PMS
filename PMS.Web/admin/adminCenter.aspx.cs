using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class adminCenter : System.Web.UI.Page
    {
        protected Model.Teacher teacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            teacher = (Teacher)Session["user"];
            getTeacher(teacher.TeaAccount);
        }

        public void getTeacher(string Account) {
            BLL.TeacherBll tbll = new BLL.TeacherBll();
            teacher=tbll.GetModel(Account);
        }
    }
}
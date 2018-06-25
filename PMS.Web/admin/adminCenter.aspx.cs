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
            //TODO 改成从session里获取值
            //teacher = (Teacher)Session["user"];
            getTeacher("teacher");
        }

        public void getTeacher(string Account) {
            BLL.TeacherBll tbll = new BLL.TeacherBll();
            teacher=tbll.GetModel(Account);
        }
    }
}
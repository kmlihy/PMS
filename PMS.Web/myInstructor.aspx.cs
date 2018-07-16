using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class myInstructor : System.Web.UI.Page
    {
        protected Model.Teacher teacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取指导教师的账号进行查询
            getTeacher("100009");
        }
        public void getTeacher(string Account)
        {
            BLL.TeacherBll tbll = new BLL.TeacherBll();
            teacher = tbll.GetModel(Account);
        }
    }
}
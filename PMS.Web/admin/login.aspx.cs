using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;

namespace PMS.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                string teaAccount = Request.Form["userName"].ToString();
                string pwd = Request.Form["pwd"].ToString();
                TeacherBll bll = new TeacherBll();
                Model.Teacher teacher = bll.Login(teaAccount, pwd);
                Session["user"] = teacher;
                Response.Write("<script>alert(" + teacher + ");</script>");
            }
            catch {

            }
           
        }
    }
}
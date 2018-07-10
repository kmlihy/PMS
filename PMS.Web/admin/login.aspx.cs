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
        protected string teaAccount;
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                teaAccount = Request.Form["userName"].ToString();
                string pwd = Request.Form["pwd"].ToString();
                TeacherBll bll = new TeacherBll();
                Model.Teacher teacher = bll.Login(teaAccount, pwd);
                if (teacher!=null)
                {
                    if(teacher.TeaType == 0)
                    {
                        Session["user"] = teacher;
                        Session["state"] = 0;
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                        Session["user"] = teacher;
                        Session["state"] = 2;
                        Response.Redirect("main.aspx");
                    }                   
                }               
               
            }
            catch {

            }
           
        }
    }
}
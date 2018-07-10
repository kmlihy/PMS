using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using System.Web.Security;

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
                string roles = "administrator";
                Model.Teacher teacher = bll.Login(teaAccount, pwd);
                if (teacher!=null)
                {
                    if(teacher.TeaType == 0)
                    {
                        Session["user"] = teacher;
                        Session["state"] = 0;
                        FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                        string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                        HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                        Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                        Session["user"] = teacher;
                        Session["state"] = 2;                       
                        FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                        string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                        HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                        Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                        Response.Redirect("main.aspx");
                    }                   
                }               
               
            }
            catch {

            }
           
        }
    }
}
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected string userName;
        protected string pwd;
        protected string captcha;
        protected string usertype;

        protected void Page_Load(object sender, EventArgs e)
        {
         try {
                userName = Request.Form["userName"].Trim();
                pwd = Request.Form["pwd"].Trim();
                captcha = Request.Form["captcha"].ToLower();
                usertype = Request.Form["user"].Trim();
                string Verification = vildata();
                string roles = "";
            if (Verification.Length == 0)
            {
                int loginstate = 0;
                switch (usertype) {
                    case "teacher":
                        BLL.TeacherBll tdao = new BLL.TeacherBll();
                        Model.Teacher tea = tdao.Login(userName, Security.SHA256Hash(pwd));
                        if (tea == null)
                        {
                            loginstate = 0;
                        }
                        else {
                            loginstate = 1;
                            Session["loginuser"] = tea;
                            Session["state"] = 1;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            roles = "teacher";
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            }
                        break;
                    case "student":
                        BLL.StudentBll sdao = new BLL.StudentBll();
                        Model.Student stu = sdao.Login(userName, Security.SHA256Hash(pwd));
                        if (stu == null)
                        {
                            loginstate = 0;
                        }
                        else
                        {
                            loginstate = 1;
                            Session["loginuser"] = stu;
                            Session["state"] = 3;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            roles = "student";
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, userName, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            }
                        break;
                }
                    if (loginstate == 0)
                    {
                        Response.Write("<script>alert('登录角色错误');</script>");
                    }
                    else if (loginstate == 1)
                    {
                        Response.Redirect("admin/main.aspx");
                    }
                    else {
                        Response.Write("<script>alert('登录失败');</script>");
                    }
                 }
                else
                {
                    Response.Write("<script>alert('" + Verification + "');</script>");
                }
             }
            catch
            {

            }
    }
  

        /// <summary>
        /// 验证前台页面的数据
        /// </summary>
        /// <returns></returns>
        public string vildata() {
            string alertmsg = "";
            if (userName == null) {
                alertmsg = "用户名不能为空";
            }
            else if (pwd==null) {
                alertmsg = "密码不能为空";
            }
            else if (captcha == null)
            {
                alertmsg = "验证码不能为空";
            }
            else if (usertype == null)
            {
                alertmsg = "用户类型不能为空"; 
            }
            else if (captcha != null)
            {
                if (captcha == Session["code"].ToString().ToLower())
                {
                }
                else {
                    alertmsg = "验证码不正确";
                }
            }
            return alertmsg;
        }
    }
}
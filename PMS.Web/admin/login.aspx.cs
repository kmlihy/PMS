using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using System.Web.Security;
using PMS.Model;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using PMS.DBHelper;

namespace PMS.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected string teaAccount;

        //单点登录判断
        private void isLogined(string id)
        {
            Hashtable hOnline = (Hashtable)Application["Online"];
            if (hOnline != null)
            {
                int i = 0;
                while (i < hOnline.Count)
                {
                    IDictionaryEnumerator idE = hOnline.GetEnumerator();
                    string strKey = "";
                    while (idE.MoveNext())
                    {
                        if (idE.Value != null && idE.Value.ToString().Equals(id))
                        {
                            //already login              
                            strKey = idE.Key.ToString();
                            hOnline[strKey] = "XXXXXX";
                            break;
                        }
                    }
                    i = i + 1;
                }
            }
            else
            {
                hOnline = new Hashtable();
            }
            hOnline[Session.SessionID] = id;
            Application.Lock();
            Application["Online"] = hOnline;
            Application.UnLock();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request["op"];
            string pwd = "";
            if (op == "login")
            {
                try
                {
                    teaAccount = Request["userName"].Trim();
                    pwd = Request["pwd"].Trim();
                    TeacherBll bll = new TeacherBll();
                    string roles = "administrator";
                    RSACryptoService rsa = new RSACryptoService();
                    Teacher teacher = bll.Login(teaAccount, rsa.Decrypt(pwd));
                    if (teacher != null)
                    {
                        if (teacher.TeaType == 0)
                        {
                            Session["user"] = teacher;
                            Session["state"] = 0;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            //Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            isLogined(teaAccount);
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 登录");
                            Response.Write("登录成功");
                            Response.End();
                        }
                        else if (teacher.TeaType == 2)
                        {
                            Session["user"] = teacher;
                            Session["state"] = 2;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            //Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            isLogined(teaAccount);
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 登录");
                            Response.Write("登录成功");
                            Response.End();
                        }
                        else
                        {
                            LogHelper.Error(this.GetType(), "用户名或密码错误");
                            Response.Write("用户名或密码错误");
                            Response.End();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }
        }
    }
}
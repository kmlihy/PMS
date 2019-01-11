using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected string account;
        protected string pwd;
        protected string captcha;
        protected string usertype;

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
            try
            {
                string op = Request["op"];
                if (op == "login")
                {
                    account = Request["userName"].Trim();
                    pwd = Request["pwd"].Trim();
                    captcha = Request["captcha"].ToLower();
                    usertype = Request["type"].Trim();
                    string Verification = vildata();
                    string roles = "";
                    if (Verification.Length == 0)
                    {
                        int loginstate = 0;
                        RSACryptoService rsa = new RSACryptoService();
                        switch (usertype)
                        {
                            case "teacher":
                                TeacherBll teaBll = new TeacherBll();
                                if (teaBll.GetModel(account).TeaType == 1)
                                {
                                    Teacher tea = teaBll.Login(account, rsa.Decrypt(pwd));
                                    if (tea == null)
                                    {
                                        loginstate = 0;
                                    }
                                    else
                                    {
                                        loginstate = 1;
                                        Session["loginuser"] = tea;
                                        Session["state"] = 1;
                                        Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                                        roles = "teacher";
                                        FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, account, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                                        string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                                        //Session["HashTicket"] = HashTicket;
                                        HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                                        Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                                        isLogined(account);
                                    }
                                }
                                else
                                {
                                    Response.Write("管理员");
                                    Response.End();
                                }
                                break;
                            case "student":
                                StudentBll sdao = new BLL.StudentBll();
                                Student stu = sdao.Login(account, rsa.Decrypt(pwd));

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
                                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, account, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                                    string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                                    //Session["HashTicket"] = HashTicket;
                                    HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                                    Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                                    isLogined(account);
                                }
                                break;
                        }
                        if (loginstate == 0)
                        {
                            Response.Write("用户名或密码错误");
                            Response.End();
                        }
                        else if (loginstate == 1)
                        {
                            if (Convert.ToInt32(Session["state"]) == 1)
                            {
                                Teacher tea = (Teacher)Session["loginuser"];
                                LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 登录");
                            }
                            else if (Convert.ToInt32(Session["state"]) == 3)
                            {
                                Student stu = (Student)Session["loginuser"];
                                LogHelper.Info(this.GetType(), stu.StuAccount + " - " + stu.RealName + " - 登录");
                            }
                            Response.Write("登录成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("登录失败");
                            Response.End();
                        }
                    }
                    else
                    {
                        LogHelper.Error(this.GetType(), account + " - " + Verification);
                        Response.Write(Verification);
                        Response.End();
                    }
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
        public string vildata()
        {
            string alertmsg = "";
            if (account == null)
            {
                alertmsg = "用户名不能为空";
            }
            else if (pwd == null)
            {
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
                else
                {
                    alertmsg = "验证码不正确";
                }
            }
            return alertmsg;
        }
    }
}
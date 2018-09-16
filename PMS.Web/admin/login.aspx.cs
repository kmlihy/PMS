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

namespace PMS.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected string teaAccount;
        protected string strPublicKeyExponent = "";
        protected string strPublicKeyModulus = "";

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
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //if (string.Compare(Request.RequestType, "get", true) == 0)
            //{
            //    //将私钥存Session中
            //    Session["private_key"] = rsa.ToXmlString(true);
            //}
            //else
            //{
                try
                {
                string op = Request["op"];
                string pwd="";
                if (op == "login")
                {
                    teaAccount = Request["userName"].Trim();
                    pwd = Request["pwd"].Trim();
                }

                    //rsa.FromXmlString((string)Session["private_key"]);
                    //byte[] result = rsa.Decrypt(Security.HexStringToBytes(pwd), false);
                    //System.Text.ASCIIEncoding enc = new ASCIIEncoding();
                    //string strPwdMD5 = enc.GetString(result);

                    TeacherBll bll = new TeacherBll();
                    string roles = "administrator";
                    Teacher teacher = bll.Login(teaAccount, Security.SHA256Hash(pwd));

                    if (teacher != null)
                    {
                        if (teacher.TeaType == 0)
                        {
                            Session["user"] = teacher;
                            Session["state"] = 0;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            isLogined(teaAccount);
                            Response.Redirect("main.aspx");
                        }
                        else if (teacher.TeaType == 2)
                        {
                            Session["user"] = teacher;
                            Session["state"] = 2;
                            Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                            FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1, teaAccount, DateTime.Now, DateTime.Now.AddMinutes(30), true, roles); //建立身份验证票对象 
                            string HashTicket = FormsAuthentication.Encrypt(Ticket); //加密序列化验证票为字符串 
                            Session["HashTicket"] = HashTicket;
                            HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket); //生成Cookie 
                            Context.Response.Cookies.Add(UserCookie); //票据写入Cookie 
                            isLogined(teaAccount);
                            Response.Redirect("main.aspx");
                        }
                        else
                        {
                            Response.Write("用户名或密码错误");
                            Response.End();
                        }
                    }

                }
                catch
                {

                }
            //}
            //RSAParameters parameter = rsa.ExportParameters(true);
            //strPublicKeyExponent = Security.BytesToHexString(parameter.Exponent);
            //strPublicKeyModulus = Security.BytesToHexString(parameter.Modulus);
        }
    }
}
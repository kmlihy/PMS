using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class main : System.Web.UI.Page
    {
        protected int State;
        protected string url;
        TitleRecordBll titleRecordBll = new TitleRecordBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                State = int.Parse(Session["state"].ToString());
                if(State == 0)
                {
                    Response.Write("<script>$('#myCenter').hide();</script>");
                }
                else if(State == 1)
                {
                    url = "teaCenter.aspx";
                }
                else if (State == 2)
                {
                    url = "adminCenter.aspx";
                }
                else if (State == 3)
                {
                    url = "../stuCenter.aspx";
                    Student student = (Student)Session["loginuser"];
                    string account = student.StuAccount;
                }
                //Response.Write(count);
                string op = Request.QueryString["op"].ToString();
                //退出登录实现
                if (op.Equals("logout"))
                {
                    //删除身份凭证
                    FormsAuthentication.SignOut();
                    //设置Cookie的值为空
                    Response.Cookies[FormsAuthentication.FormsCookieName].Value = null;
                    //设置Cookie的过期时间为上个月今天
                    Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddMonths(-1);                   
                }
            }
            catch {
            }
        }
    }
}
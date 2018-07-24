using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class RetrievePwd : System.Web.UI.Page
    {
        Result result;
        protected string account;
        protected string email;
        protected string code;
        protected string pwd;
        /// <summary>
        /// 6位数字验证码
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomCode()
        {
            int length = 6;
            var result = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10));
            }
            Session["result"] = result;
            return result.ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            StudentBll stuBll = new StudentBll();
            try
            {
                string op = Context.Request["op"].ToString();
                //string send = Context.Request["send"].ToString();
                if (op == "send")
                {
                    GenerateRandomCode();
                    Response.Write("验证码已发送至邮箱");
                    //Response.Write(Session["result"]);
                    Response.End();
                }
                account = Context.Request["account"].ToString();
                email = Context.Request["email"].ToString();
                code = Context.Request["code"].ToString();
                pwd = Context.Request["pwd"].ToString();
                if (op=="change")
                {
                    if (!stuBll.selectBystuId(account))
                    {
                        Response.Write("账号不存在");
                        Response.End();
                    }
                    else if(!stuBll.selectByEmail(email))
                    {
                        Response.Write("邮箱不存在");
                        Response.End();
                    }
                    else if(code != Session["result"].ToString())
                    {
                        Response.Write("验证码错误");
                        Response.End();
                    }
                    else if (stuBll.selectBystuId(account) && stuBll.selectByEmail(email) && code == Session["result"].ToString())
                    {
                        Response.Write("修改成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("修改失败");
                        Response.End();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
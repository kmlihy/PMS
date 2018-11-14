using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
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
        protected string user;
        StudentBll stuBll = new StudentBll();
        TeacherBll teacherBll = new TeacherBll();
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
            try
            {
                string op = Context.Request["op"].ToString();
                if (op == "send")
                {
                    account = Context.Request["account"].ToString();
                    user = Context.Request["user"].ToString();
                    email = Context.Request["email"].ToString();
                    switch (user)
                    {
                        case "student": isStudent(); break;
                        case "teacher": isTeacher(); break;
                    }
                    if (email == null || email == "")
                    {
                        Response.Write("邮箱未填写");
                        Response.End();
                    }
                    else
                    {
                        GenerateRandomCode();
                        sendMail(email);
                        Response.Write("验证码已发送至邮箱");
                        Response.End();
                    }
                }
                if (op == "change")
                {
                    account = Context.Request["account"].ToString();
                    email = Context.Request["email"].ToString();
                    code = Context.Request["code"].ToString();
                    pwd = Context.Request["pwd"].ToString();
                    user = Context.Request["user"].ToString();

                    switch (user)
                    {
                        case "student": student(); break;
                        case "teacher": teacher(); break;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        private void isStudent()
        {
            Student stu = stuBll.GetModel(account);
            if (!stuBll.selectBystuId(account))
            {
                Response.Write("账号不存在，请检查用户类型");
                Response.End();
            }
            else if (email != stu.Email)
            {
                Response.Write("邮箱错误");
                Response.End();
            }
        }
        private void isTeacher()
        {
            Teacher tea = teacherBll.GetModel(account);
            if (!teacherBll.selectByteaId(account))
            {
                Response.Write("账号不存在，请检查用户类型");
                Response.End();
            }
            else if (email != tea.Email)
            {
                Response.Write("邮箱错误");
                Response.End();
            }
        }
        private void student()
        {
            try
            {
                Student stu = stuBll.GetModel(account);
                if (code != Session["result"].ToString() || Session["result"].ToString() == "")
                {
                    Response.Write("验证码错误");
                    Response.End();
                }
                else if (stuBll.selectBystuId(account) && email == stu.Email && code == Session["result"].ToString())
                {
                    result = stuBll.UpdataPwd(account, pwd);
                    if (result == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), stu.StuAccount + " - " + stu.RealName + " - 重置密码");
                        Response.Write("修改成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("修改失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("修改失败");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        private void teacher()
        {
            try
            {
                Teacher tea = teacherBll.GetModel(account);
                if (code != Session["result"].ToString() || Session["result"].ToString() == "")
                {
                    Response.Write("验证码错误");
                    Response.End();
                }
                else if (teacherBll.selectByteaId(account) && email == tea.Email && code == Session["result"].ToString())
                {
                    result = teacherBll.UpdataPwd(account, pwd);
                    if (result == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 重置密码");
                        Response.Write("修改成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("修改失败");
                        Response.End();
                    }
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        /// <summary>
        /// 发送验证码到邮箱
        /// </summary>
        /// <param name="name"></param>
        /// <param name="mail"></param>
        private void sendMail(string mail)
        {
            try
            {
                string addresser = "user@idaobin.com";
                string emailPwd = "daobin@123";
                string title = "云南工商学院毕业选题系统";
                string content = "您的验证码为：" + Session["result"];
                MailMessage message = new MailMessage(addresser, mail);
                message.Subject = title;
                message.Body = content;
                message.Priority = MailPriority.High;
                SmtpClient client = new SmtpClient("smtp.mxhichina.com", 25);
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(addresser, emailPwd);
                client.Send(message);
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
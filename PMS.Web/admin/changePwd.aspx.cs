using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.DBHelper;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class changePwd : CommonPage
    {
        protected string account;
        protected Student stu;//获取学生实体
        protected Teacher admin;//获取登录管理员实体
        protected Teacher teacher;//获取登录教师实体
        protected string adminPwd;//管理员密码
        protected string teacherPwd;//教师密码
        protected string teacherID;//教师工号
        protected string stuPwd;//学生密码
        protected string stuID;//学号
        Security sec = new Security();
        TeacherBll teaBll = new TeacherBll();
        StudentBll stuBll = new StudentBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            int state = Convert.ToInt32(Session["state"].ToString());
            if (state == 1)
            {
                Teacher tea = (Teacher)Session["loginuser"];
                account = tea.TeaAccount;
            }
            else if (state == 2 || state == 0)
            {
                Teacher tea = (Teacher)Session["user"];
                account = tea.TeaAccount;
            }
            else if (state == 3)
            {
                Student stu = (Student)Session["loginuser"];
                account = stu.StuAccount;
            }
            string op = Request["type"];
            if(op == "change")
            {
                Change();
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        public void Change()
        {
            
            RSACryptoService rsa = new RSACryptoService();
            string oldpwd = rsa.Decrypt(Request["old"]);
            string newpwd = Request["newP"];
            int state = Convert.ToInt32(Session["state"].ToString());
            string Old = oldpwd;
            string NewPwd = newpwd;
            try
            {
                if (state == 0 || state == 2)
                {
                    admin = (Teacher)Session["user"];
                    teacherPwd = admin.TeaPwd;
                    teacherID = admin.TeaAccount;
                    if (Old == teacherPwd)
                    {
                        Result result = teaBll.UpdataPwd(teacherID, NewPwd);
                        if (result == Result.更新成功)
                        {
                            LogHelper.Info(this.GetType(), admin.TeaAccount + admin.TeaName + "-修改密码");
                            Response.Write("更新成功");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
                else if (state == 1)
                {
                    teacher = (Teacher)Session["loginuser"];
                    teacherPwd = teacher.TeaPwd;
                    teacherID = teacher.TeaAccount;
                    if (Old == teacherPwd)
                    {
                        Result result = teaBll.UpdataPwd(teacherID, NewPwd);
                        if (result == Result.更新成功)
                        {
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + teacher.TeaName + "-修改密码");
                            Response.Write("更新成功");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
                else
                {
                    stu = (Student)Session["loginuser"];
                    stuPwd = stu.StuPwd;
                    stuID = stu.StuAccount;
                    if (Old == stuPwd)
                    {
                        Result result = stuBll.UpdataPwd(stuID, NewPwd);
                        if (result == Result.更新成功)
                        {
                            LogHelper.Info(this.GetType(), stu.StuAccount + stu.RealName + "-修改密码");
                            Response.Write("更新成功");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("更新失败");
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
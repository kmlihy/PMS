using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class changePwd : System.Web.UI.Page
    {
        protected string account;
        protected string OLDPWD;//hash加密后的旧密码
        protected string NEWPWD;//hash加密后的新密码
        protected string state;//获取登录者
        protected Student stu;//获取学生实体
        protected Teacher admin;//获取登录管理员实体
        protected Teacher teacher;//获取登录教师实体
        protected string adminPwd;//管理员密码
        protected string teacherPwd;//教师密码
        protected string stuPwd;//学生密码
        Security sec = new Security();
        TeacherBll teaBll = new TeacherBll();
        StudentBll stuBll = new StudentBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            int state = Convert.ToInt32(Session["state"].ToString());
            string op = Context.Request["op"];
            if(state == 1)
            {
                Teacher tea = (Teacher)Session["loginuser"];
                account = tea.TeaAccount;
            }
            else if(state == 3)
            {
                Student stu = (Student)Session["loginuser"];
                account = stu.StuAccount;
            }
            if(op == "password")
            {
                changePassWord();
            }
        }
        public void changePassWord()
        {
            state = Session["state"].ToString();
            string oldPwd = Context.Request["oldPwd"],
                newPwd = Context.Request["newPwd"];
            OLDPWD = Security.SHA256Hash(oldPwd);
            if(state == "0" || state == "2")
            {
                admin = (Teacher)Session["user"];
                adminPwd = admin.TeaPwd;
                if(OLDPWD == adminPwd)
                {
                    NEWPWD = newPwd;
                    Teacher updatePwd = new Teacher()
                    {
                        TeaPwd = NEWPWD
                    };
                    Result update = teaBll.Updata(updatePwd);
                    if(update == Result.更新成功)
                    {
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
            }
            else if(state == "1")
            {
                teacher = (Teacher)Session["loginuser"];
                teacherPwd = teacher.TeaPwd;
                if(OLDPWD == teacherPwd)
                {
                    NEWPWD = newPwd;
                    Teacher updatePwd = new Teacher()
                    {
                        TeaPwd = NEWPWD
                    };
                    Result update = teaBll.Updata(updatePwd);
                    if (update == Result.更新成功)
                    {
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
            }

            else
            {
                stu = (Student)Session["loginuser"];
                stuPwd = stu.StuPwd;
                if(OLDPWD == stuPwd)
                {
                    NEWPWD = newPwd;
                    Student updateStu = new Student();
                    updateStu.StuPwd = NEWPWD;
                    Result update = stuBll.Updata(updateStu);
                    if (update == Result.更新成功)
                    {
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
            }
        }
    }
}
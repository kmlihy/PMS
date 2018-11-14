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
    public partial class adminCenter : CommonPage
    {
        protected Teacher teacher = null;
        protected Enums.OpResult enums;
        protected void Page_Load(object sender, EventArgs e)
        {
           teacher = (Teacher)Session["user"];
           string op = Request.QueryString["op"];
           if (op=="update")
            {
                string phone = Context.Request["phone"].ToString();
                string Email = Context.Request["Email"].ToString();
                Teacher newTea = new Teacher();
                College college = new College();
                try
                {
                    newTea.TeaAccount = teacher.TeaAccount;
                    newTea.TeaName = teacher.TeaName;
                    newTea.TeaPwd = teacher.TeaPwd;
                    newTea.Sex = teacher.Sex;
                    college.ColID = teacher.college.ColID;
                    college.ColName = teacher.college.ColName;
                    newTea.college = college;
                    newTea.TeaType = teacher.TeaType;
                    newTea.Phone = phone;
                    newTea.Email = Email;
                    updata(newTea);
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }         
        }

        public void updata(Teacher teacher)
        {
            TeacherBll bll = new TeacherBll();
            Enums.OpResult enums = bll.Updata(teacher);
            if (enums.Equals(Enums.OpResult.更新成功))
            {
                LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 管理员修改个人信息");
                Response.Write("修改成功");
                Session["user"] = teacher;
                Response.End();
            }
            else
            {
                Response.Write("修改失败");
                Response.End();
            }
        }

    }
}
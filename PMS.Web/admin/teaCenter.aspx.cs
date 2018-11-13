using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class teaCenter : CommonPage
    {
        protected Teacher teacher = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO 改成从session里获取值
            teacher = (Teacher)Session["loginuser"];
            TeacherBll tbll = new TeacherBll();
            teacher = tbll.GetModel(teacher.TeaAccount);
            string op = Request.QueryString["op"];
            if (op == "update")
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
                    newTea.college = teacher.college;
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
                LogHelper.Info(this.GetType(), teacher.TeaAccount + teacher.TeaName + "-修改个人信息");
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
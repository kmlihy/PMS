using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web.admin
{
    public partial class adminCenter : System.Web.UI.Page
    {
        protected Teacher teacher = null;
        protected Teacher teacher1 = null;
        protected Enums.OpResult enums;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                teacher = (Teacher)Session["user"];
            }
            else
            {
                try
                {
                    teacher = (Teacher)Session["user"];
                    string phone = Context.Request["phone"].ToString();
                    string Email = Context.Request["email"].ToString();
                    teacher.Phone = phone;
                    teacher.Email = Email;
                }
                catch (Exception)
                {

                }
                abc(teacher);
            }

        }

        public void abc(Teacher teacher)
        {
            TeacherBll bll = new TeacherBll();
            Enums.OpResult enums = bll.Updata(teacher);
            if (enums.Equals(Enums.OpResult.更新成功))
            {
                Response.Write("<script>alert('修改成功')</script>");
            }
            else
            {
                Response.Write("<script>alert(" + enums + ")</script>");
            }
        }

        //public void getTeacher(string Account)
        //{
         //   BLL.TeacherBll tbll = new BLL.TeacherBll();
          //  teacher = tbll.GetModel(Account);
       // }

    }
}
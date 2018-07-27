using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class stuCenter : System.Web.UI.Page
    {

        protected Student student = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO 改成从session里获取值
            student = (Student)Session["loginuser"];
            StudentBll sbll = new StudentBll();
            string op = Request.QueryString["op"];
            student = sbll.GetModel(student.StuAccount);
            if (op == "update")
            {
                string phone = Context.Request["phone"].ToString();
                string Email = Context.Request["Email"].ToString();
                Student newStu = new Student();
                College college = new College();
                Profession pro = new Profession();
                newStu.StuAccount = student.StuAccount;
                newStu.RealName = student.RealName;
                newStu.StuPwd = student.StuPwd;
                newStu.Sex = student.Sex;
                newStu.college = student.college;
                newStu.profession = student.profession;
                newStu.Phone = phone;
                newStu.Email = Email;
                updata(newStu);
            }
        }
        public void updata(Student student)
        {
            StudentBll bll = new StudentBll();
            Enums.OpResult enums = bll.Updata(student);
            if (enums.Equals(Enums.OpResult.更新成功))
            {
                Response.Write("修改成功");
                Session["user"] = student;
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
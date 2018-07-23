using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    public partial class RetrievePwd : System.Web.UI.Page
    {
        protected string account;
        protected void Page_Load(object sender, EventArgs e)
        {
            int state = Convert.ToInt32(Session["state"].ToString());
            if (state == 1)
            {
                Teacher tea = (Teacher)Session["loginuser"];
                account = tea.TeaAccount;
            }
            else if (state == 3)
            {
                Student stu = (Student)Session["loginuser"];
                account = stu.StuAccount;
            }
        }
    }
}
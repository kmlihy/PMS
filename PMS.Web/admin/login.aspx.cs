using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;

namespace PMS.Web.admin
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                string teaAccount = Request.QueryString["userName"].ToString();
                string pwd = Request.QueryString["pwd"].ToString();
                TeacherBll bll = new TeacherBll();
                //int row = bll.Login(teaAccount, pwd);
                // Response.Write("<script>alert(" + row + ");</script>");
            } catch {

            }
           
        }
    }
}
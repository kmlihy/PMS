using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMS.Web.admin
{
    public partial class adminViewScore : System.Web.UI.Page
    {
        public DataSet dsPlan, dsPro, ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            PlanBll planBll = new PlanBll();
            int state = Convert.ToInt32(Session["state"]);
            if(state == 1)
            {
                teacher = (Teacher)Session["loginuser"];
            }
            else if(state == 2)
            {
                teacher = (Teacher)Session["user"];
            }
            dsPlan = planBll.Select();
        }
    }
}
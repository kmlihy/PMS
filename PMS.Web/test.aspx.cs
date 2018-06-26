using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected string getName = "";
        protected int getCurrentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request["name"];
            string currentPage = Request["currentPage"];
            string op = Request["op"];
            if (op == "1")
            {
                getCurrentPage = int.Parse(currentPage) - 1;
                System.Diagnostics.Debug.WriteLine("op1当前页为" + getCurrentPage);
            }
            else if (op == "2")
            {
                getCurrentPage = int.Parse(currentPage) + 1;
                System.Diagnostics.Debug.WriteLine("op2当前页为" + getCurrentPage);
            }
            else
            {
                //getCurrentPage = int.Parse(currentPage);
            }
        }
    }
}
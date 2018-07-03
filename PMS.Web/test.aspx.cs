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
            BLL.PublicProcedureBll pub = new BLL.PublicProcedureBll();
            Model.TitleRecord tit = new Model.TitleRecord();
            Model.Student stu = new Model.Student();
            Model.Title title = new Model.Title();
            stu.StuAccount = "2121001";
            title.TitleId = 4;
            tit.student = stu;
            tit.title = title;
            pub.AddTitlerecord(tit);
        }
    }
}
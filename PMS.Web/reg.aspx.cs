using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PMS.BLL.Enums;

namespace PMS.Web
{
    public partial class reg : System.Web.UI.Page
    {
        protected DataSet dsColl = null, dsPro = null;
        CollegeBll collbll = new CollegeBll();
        ProfessionBll probll = new ProfessionBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }
        protected void getdata()
        {
            dsColl = collbll.Select();
            dsPro = probll.Select();
        }
    }
}
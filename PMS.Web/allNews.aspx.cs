using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    public partial class allNews : System.Web.UI.Page
    {
        protected DataSet ds = null, dsTea = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        string strteaType = "";
        private string strWhere = "";
        protected string roleId;
        protected string newsid;
        protected string newsType;
        protected void Page_Load(object sender, EventArgs e)
        {
            string account = "", teaAccount="";
            int college = 0;
            int state = Convert.ToInt32(Session["state"].ToString());
            if (state == 1)
            {
                Teacher tea = (Teacher)Session["loginuser"];
                account = tea.TeaAccount;
                college = tea.college.ColID;

            }
            else if(state == 0 || state == 2)
            {
                Teacher admin = (Teacher)Session["user"];
                account = admin.TeaAccount;
                college = admin.college.ColID;
            }
            else if (state == 3)
            {
                Student stu = (Student)Session["loginuser"];
                account = stu.StuAccount;
                college = stu.college.ColID;
                TitleRecordBll trBll = new TitleRecordBll();
                bool flag = trBll.selectBystuId(account);
                if (flag == true)
                {
                    TableBuilder tbd = new TableBuilder()
                    {
                        StrTable = "V_TitleRecord",
                        StrColumn = "titleRecordId",
                        IntColType = 0,
                        IntOrder = 0,
                        StrColumnlist = "*",
                        IntPageSize = 1,
                        IntPageNum = 1,
                        StrWhere = "stuAccount ='" + account + "'"
                    };
                    dsTea = trBll.SelectBypage(tbd, out count);
                    teaAccount = dsTea.Tables[0].Rows[0]["teaAccount"].ToString();
                }
            }
            if (!Page.IsPostBack)
            {
                roleId = Request.QueryString["roleId"];
                if (roleId == "0")
                {
                    strteaType = "teaType=0";
                    newsType = "学校公告";
                }
                else if (roleId == "1")
                {
                    strteaType = "teaType=1 and teaAccount = '"+ teaAccount + "'";
                    newsType = "学生公告";
                }
                else if (roleId == "2")
                {
                    strteaType = "teaType=2 and collegeId=" + college;
                    newsType = "学院公告";
                }
                getdata(strteaType);
            }
        }
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            NewsBll nb = new NewsBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_News",
                StrWhere = strteaType,
                IntColType = 2,
                IntOrder = 1,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "createTime",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = nb.SelectBypage(tabuilder, out count);
        }
    }
}
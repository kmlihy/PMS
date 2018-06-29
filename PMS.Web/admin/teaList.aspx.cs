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

namespace PMS.Web.admin
{
    public partial class teaList : System.Web.UI.Page
    {
        protected DataSet ds=null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize=1;
        protected String search = "";
        //分院
        protected DataSet colds = null;
        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (op=="add")
            {
                saveTeacher();
            }
            Search();
            //getdata(Search());
            //changepage();
            getdata(Search());
            colds = colbll.Select();
                
        }
        public void saveTeacher()
        {
            College college = new College();
            int  collegeId =Convert.ToInt32(Context.Request["CollegeId"]);
            int teaType = Convert.ToInt32(Context.Request["TeaType"]);
            string teaAccount = Context.Request["TeaAccount"].ToString();
            string pwd = Context.Request["Pwd"].ToString();
            string teaName = Context.Request["TeaName"].ToString();
            string sex = Context.Request["Sex"].ToString();
            string email = Context.Request["Email"].ToString();
            string tel = Context.Request["Tel"].ToString();
            Teacher tea = new Teacher();
            tea.college = college;
            college.ColID = collegeId;
            tea.TeaType = teaType;
            tea.TeaAccount = teaAccount;
            tea.TeaPwd = pwd;
            tea.TeaName = teaName;
            tea.Sex = sex;
            tea.Email = email;
            tea.Phone = tel;
            TeacherBll teabll = new TeacherBll();
            OpResult result = teabll.Insert(tea);
            if (result == OpResult.添加成功)
            {
                Response.Write("添加成功");
                Response.End();
            }
            else
            {
                Response.Write("添加失败");
                Response.End();
            }
        }

        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if(currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            BLL.TeacherBll sdao = new TeacherBll();
            TeacherBll pro = new TeacherBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrWhere = strWhere==null ? "": strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "teaAccount",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = pro.SelectBypage(tabuilder, out count);
        }

        //public void changepage() {
        //    string currentPage = Request.QueryString["currentPage"];
        //    getCurrentPage = int.Parse(currentPage);           
        //}

        public string Search() {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search==null) {
                    search = "";
                }
                else
                {
                    search = String.Format(" teaAccount={0} or teaName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }   
            }
            catch {
            }
            return search;
        }
    }
}
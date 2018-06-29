using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;
using System.Data;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class stuLIst : System.Web.UI.Page
    {
        protected DataSet prods = null;//专业
        protected DataSet colds = null;//院系

        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 2;
        protected String search = "";

        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();

        public void Page_Load(object sender, EventArgs e)
        {
            //prods = proBll.Select();
            //colds = colBll.Select();
            //Search();
            //getdata(Search());
            string op = Context.Request["op"];
            if (op == "add")
            {
                saveStudent();
                Search();
                getdata(Search());
                colds = colBll.Select();
                prods = proBll.Select();
            }
            if (!Page.IsPostBack)
            {
                Search();
                getdata(Search());
                colds = colBll.Select();
                prods = proBll.Select();
            }
        }
        //添加学生
        public void saveStudent()
        {
            try
            {
                string stuAccount = Context.Request["stuAccount"].ToString(),
                    pwd = Context.Request["pwd"].ToString(),
                    realName = Context.Request["realName"].ToString(),
                    sex = Context.Request["sex"].ToString(),
                    phone = Context.Request["phone"].ToString(),
                    email = Context.Request["email"].ToString();
                int proId = int.Parse(Context.Request["pro"].ToString());
                Profession prof = new Profession()
                {
                    ProId = proId
                };
                Student stu = new Student() {
                    StuAccount = stuAccount,
                    StuPwd = pwd,
                    RealName = realName,
                    Sex = sex,
                    Phone = phone,
                    Email = email,
                    profession = prof
                };
                StudentBll stuBll = new StudentBll();
                Result result = stuBll.Insert(stu);
                if(result == Result.添加成功)
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
            catch { }
        }
        //分页
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            BLL.StudentBll sdao = new StudentBll();
            StudentBll pro = new StudentBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Student",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "stuAccount",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = pro.SelectBypage(tabuilder, out count);
        }
        //查询
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format(" stuAccount={0} or realName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
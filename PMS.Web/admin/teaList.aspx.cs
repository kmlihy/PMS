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
    using Result = Enums.OpResult;
    public partial class teaList : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 3;
        protected String search = "";
        TeacherBll teabll = new TeacherBll();
        //分院
        protected DataSet colds = null;
        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (op == "add")
            {
                saveTeacher();
            }
            if (op == "change")
            {
                saveChange();
            }
            //删除教师
            if (op == "del")
            {
                delTeal();
                Search();
                getdata(Search());
            }
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
                colds = colbll.Select();
            }

        }
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string delteaAccount = Context.Request["TeaAccount"].ToString();
            Result row = Result.记录不存在;
            if (teabll.IsDelete("T_News", "teaAccount", delteaAccount) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (teabll.IsDelete("T_Title", "teaAccount", delteaAccount) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除执行
        public void delTeal()
        {
            string delteaAccount = Context.Request["TeaAccount"].ToString();
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
                Result result = teabll.Delete(delteaAccount);

                if (result == Result.删除成功)
                {
                    Response.Write("删除成功");
                    Response.End();
                }
                else
                {
                    Response.Write("删除失败");
                    Response.End();
                }
            }
            else
            {
                Response.Write("在其他表中有关联不能删除");
                Response.End();
            }
        }
        //添加教师
        public void saveTeacher()
        {
            College college = new College();
            int collegeId = Convert.ToInt32(Context.Request["CollegeId"]);
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
        //修改
        public void saveChange()
        {
            College college = new College();
            string teaName = Context.Request["TeaName"].ToString();
            string teaAccount = Context.Request["TeaAccount"].ToString();
            string teaEmal = Context.Request["TeaEmail"].ToString();
            string teaPhone = Context.Request["TeaPhone"].ToString();
            string pwd = Context.Request["Pwd"].ToString();
            string sex = Context.Request["Sex"].ToString();
            int collegeId = Convert.ToInt32(Context.Request["CollegeId"]);
            int teaType = Convert.ToInt32(Context.Request["TeaType"]);

            college.ColID = collegeId;
            Teacher tea = new Teacher();
            tea.college = college;
            tea.TeaAccount = teaAccount;
            tea.TeaPwd = pwd;
            tea.TeaName = teaName;
            tea.Phone = teaPhone;
            tea.Email = teaEmal;
            tea.Sex = sex;
            tea.TeaType = teaType;
            TeacherBll teabll = new TeacherBll();
            OpResult result = teabll.Updata(tea);
            if (result == OpResult.更新成功)
            {
                Response.Write("修改成功");
                Response.End();
            }
            else
            {
                Response.Write("修改失败");
                Response.End();
            }

        }
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TeacherBll pro = new TeacherBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrWhere = strWhere == null ? "" : strWhere,
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
                    search = String.Format(" teaAccount {0} or teaName {0} or collegeName {0} or phone {0} or Email {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
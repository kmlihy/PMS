using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class adminList : System.Web.UI.Page
    {
        TeacherBll teabll = new TeacherBll();
        CollegeBll collBll = new CollegeBll();
        Teacher tea = new Teacher();
        College coll = new College();
        //获取数据
        protected DataSet ds = null, dsColl = null;
        protected int count;
        protected int pageSize = 5;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected String search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string college = Request["collegeId"];
            string op = Context.Request["op"];
            //添加管理员
            if (op == "add")
            {
                saveAdmin();
                Search();
                getdata(Search());
            }
            //编辑管理员
            if (op == "edit")
            {
                editAdmin();
                Search();
                getdata(Search());
            }
            //删除管理员
            else if (op == "dele")
            {
                deleteCollege();
                Search();
                getdata(Search());
            }
            if (!Page.IsPostBack)
            {
                Search();
                getdata(Search());
            }
        }
        //获取数据
        public void getdata(string strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            //判断身份是否是管理员
            string strTeaType = "";
            if (strWhere == null || strWhere == "")
            {
                strTeaType = "teaType=2";
            }
            else
            {
                strTeaType = "teaType=2 and ";
            }
            //获取数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Teacher",
                StrColumn = "teaAccount",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "*",
                IntPageSize = pageSize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = strTeaType + strWhere
            };
            getCurrentPage = int.Parse(currentPage);
            ds = teabll.SelectBypage(tbd, out count);
            //获取学院所有信息
            dsColl = collBll.Select();
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
                    search = String.Format(" teaAccount={0} or teaName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
        //添加学院管理员
        public void saveAdmin()
        {
            string account = Context.Request["account"].ToString();
            string name = Context.Request["name"].ToString();
            string sex = Context.Request["sex"].ToString();
            string college = Context.Request["college"].ToString();
            string email = Context.Request["email"].ToString();
            string phone = Context.Request["phone"].ToString();
            //Response.Write(account + ":" + name + ":" + sex + ":" + college + ":" + email + ":" + phone);
            coll.ColID = int.Parse(college);
            tea.TeaAccount = account;
            tea.TeaName = name;
            tea.Sex = sex;
            tea.college = coll;
            tea.Email = email;
            tea.Phone = phone;
            tea.TeaPwd = "123456";
            tea.TeaType = 2;
            TeacherBll teaBll = new TeacherBll();
            Result result = teaBll.Insert(tea);
            if (result == Result.添加成功)
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
        //编辑学院管理员
        public void editAdmin()
        {
            string account = Context.Request["Account"].ToString();
            string name = Context.Request["Name"].ToString();
            string pwd = Context.Request["Pwd"].ToString();
            string sex = Context.Request["Sex"].ToString();
            string college = Context.Request["College"].ToString();
            string email = Context.Request["Email"].ToString();
            string phone = Context.Request["Phone"].ToString();
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "collegeId",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "collegeId",
                IntPageSize = 1,
                IntPageNum = 1,
                StrWhere = "collegeName = '" + college + "'"
            };
            dsColl = collBll.SelectBypage(tbd, out count);
            //Response.Write(account + ":" + name + ":" + sex + ":" + college + ":" + email + ":" + phone);
            Teacher tea = new Teacher();
            College coll = new College();
            coll.ColID = int.Parse(dsColl.Tables[0].Rows[0]["collegeId"].ToString());
            tea.TeaAccount = account;
            tea.TeaName = name;
            tea.TeaPwd = pwd;
            tea.Sex = sex;
            tea.college = coll;
            tea.Email = email;
            tea.Phone = phone;
            tea.TeaType = 2;
            TeacherBll teaBll = new TeacherBll();
            Result result = teaBll.Updata(tea);
            if (result == Result.更新成功)
            {
                Response.Write("更新成功");
                Response.End();
            }
            else
            {
                Response.Write("更新失败");
                Response.End();
            }
        }
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string account = Context.Request["Daccount"].ToString();
            Result row = Result.记录不存在;
            if (teabll.IsDelete("T_News", "teaAccount", account) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (teabll.IsDelete("T_Title", "teaAccount", account) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除
        public void deleteCollege()
        {
            string account = Context.Request["Daccount"].ToString();
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
                Result result = teabll.Delete(account);

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
    }
}
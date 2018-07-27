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
        TeacherBll teaBll = new TeacherBll();
        CollegeBll collBll = new CollegeBll();
        Teacher tea = new Teacher();
        College coll = new College();
        Result result;
        //获取数据
        protected DataSet ds = null, dsColl = null;
        protected int count;
        protected int pageSize = 5;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected String search = "";
        protected String strSearch = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string college = Request["collegeId"];
            string op = Context.Request["op"];
            //添加管理员
            if (op == "add")
            {
                insertAdmin();
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
                deleteAdmin();
                Search();
                getdata(Search());
            }
            if (!Page.IsPostBack)
            {
                Search();
                getdata(Search());
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
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
            ds = teaBll.SelectBypage(tbd, out count);
            //获取学院所有信息
            dsColl = collBll.Select();
        }
        /// <summary>
        /// 查询筛选方法
        /// </summary>
        /// <returns>返回查询参数</returns>
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                strSearch = Request.QueryString["search"];
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
                    search = String.Format(" teaAccount {0} or teaName {0} or collegeName {0} or sex {0} or phone {0} or Email {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        /// <summary>
        /// 添加学院管理员
        /// </summary>
        public void insertAdmin()
        {
            string account = Context.Request["account"].ToString();
            string name = Context.Request["name"].ToString();
            string sex = Context.Request["sex"].ToString();
            string college = Context.Request["college"].ToString();
            string email = Context.Request["email"].ToString();
            string phone = Context.Request["phone"].ToString();
            if (teaBll.selectByColl(Convert.ToInt32(college)))
            {
                Response.Write("该学院已设置过分院管理员");
                Response.End();
            }
            else if (teaBll.selectByteaId(account))
            {
                if (teaBll.GetModel(account).TeaType == 2)
                {
                    Response.Write("该教师已为分院管理员");
                    Response.End();
                }
            }
            else if (teaBll.selectByEmail(email))
            {//根据输入的邮箱查找是否已存在
                Response.Write("此邮箱已存在");
                Response.End();
            }
            else if (teaBll.selectByPhone(phone))
            {//根据输入的联系电话查找是否已存在
                Response.Write("此联系电话已存在");
                Response.End();
            }
            else
            {
                tea.TeaAccount = account;
                tea.TeaName = name;
                tea.Sex = sex;
                coll.ColID = int.Parse(college);
                tea.college = coll;
                tea.Email = email;
                tea.Phone = phone;
                tea.TeaPwd = Security.SHA256Hash("000000");
                tea.TeaType = 2;
                result = teaBll.Insert(tea);
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
        }
        /// <summary>
        /// 编辑学院管理员
        /// </summary>
        public void editAdmin()
        {
            result = Result.更新失败;
            string account = Context.Request["Account"].ToString();
            string name = Context.Request["Name"].ToString();
            string sex = Context.Request["Sex"].ToString();
            int college = Convert.ToInt32(Context.Request["College"].ToString());
            int oldCollegeId = Convert.ToInt32(Context.Request["oldCollegeId"].ToString());
            string oldPhone = Context.Request["oldPhone"].ToString();
            string oldEmail = Context.Request["oldEmail"].ToString();
            string email = Context.Request["Email"].ToString();
            string phone = Context.Request["Phone"].ToString();
            if (college != oldCollegeId)
            {
                if (teaBll.selectByColl(college))
                {
                    Response.Write("该学院已设置过分院管理员");
                    Response.End();
                }
            }
            else if(oldEmail != email)
            {
                if (teaBll.selectByEmail(email))
                {//根据输入的邮箱查找是否已存在
                    Response.Write("此邮箱已存在");
                    Response.End();
                }
            }
             else if(oldPhone != phone)
            {
                if (teaBll.selectByPhone(phone))
                {//根据输入的联系电话查找是否已存在
                    Response.Write("此联系电话已存在");
                    Response.End();
                }
            }
            else
            {
                tea.TeaAccount = account;
                tea.TeaName = name;
                tea.TeaPwd = teaBll.GetModel(account).TeaPwd;
                tea.Sex = sex;
                College coll = new College();
                coll.ColID = college;
                tea.college = coll;
                tea.Email = email;
                tea.Phone = phone;
                tea.TeaType = 2;
                result = teaBll.Updata(tea);
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
        }
        /// <summary>
        /// 判断是否能删除
        /// </summary>
        /// <returns>返回判断结果</returns>
        public Result IsdeleteAdmin()
        {
            string account = Context.Request["Daccount"].ToString();
            Result row = Result.记录不存在;
            if (teaBll.IsDelete("T_News", "teaAccount", account) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (teaBll.IsDelete("T_Title", "teaAccount", account) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void deleteAdmin()
        {
            string account = Context.Request["Daccount"].ToString();
            Result row = IsdeleteAdmin();
            if (row == Result.记录不存在)
            {
                Result result = teaBll.Delete(account);

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
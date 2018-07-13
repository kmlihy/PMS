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
        protected int getCurrentPage = 0;
        protected int count;
        protected int pagesize = 3;
        protected String search = "";
        protected String searchdrop = "";
        protected string showstr = null;
        //protected string showinput = null;

        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();
        StudentBll stuBll = new StudentBll();

        public void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string editorOp = Context.Request["editorOp"];
            string del = Context.Request["op"];
            string type = Request.QueryString["type"];
            if (!Page.IsPostBack)
            {
                getdata(Search());
                colds = colBll.Select();
                prods = proBll.Select();
            }
            if (op == "add")//添加
            {
                saveStudent();
            }
            if (editorOp == "editor")//编辑
            {
                editorStu();
            }
            if (del == "delete")//删除
            {
                deleteStu();
            }
            if (type == "drop")
            {
                getdata(Searchdrop());
            }
            if (type == "btn")
            {
                getdata(Search());
            }

            //查询按钮保存查询条件
            //if (search == null)
            //{
            //    showinput = "请输入查询条件";
            //}
            //else if (search != null && search.Length > 1)
            //{
            //    string sec = search.ToString();
            //    string[] secArray = sec.Split('%');
            //    string str = secArray[1].ToString();
            //    showinput = str;
            //}

        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <returns></returns>
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
                    search = String.Format("stuAccount {0} or sex {0} or realName {0} or collegeName {0} or phone {0} or Email {0} or proName {0} ", "like " + "'%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        /// <summary>
        /// 下拉查询保留查询条件
        /// </summary>
        /// <returns></returns>
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropstrWhere"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                    //下拉框保留查询条件
                    showstr = "0";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                    //下拉框保留查询条件
                    showstr = "0";
                }
                else
                {
                    //下拉框保留查询条件
                    showstr = searchdrop;
                    searchdrop = String.Format("proId={0} ", "'"+ searchdrop + "'");
                }
            }
            catch
            {
            }
            return searchdrop;
        }
        /// <summary>
        /// 编辑学生
        /// </summary>
        public void editorStu()
        {
            string stuNO = Context.Request["stuNO"].ToString(),
                   stuName = Context.Request["stuName"].ToString(),
                   stuSex = Context.Request["stuSex"].ToString(),
                   stuEmail = Context.Request["stuEmail"].ToString(),
                   stuPhone = Context.Request["stuPhone"].ToString(),
                   stuPwd = Context.Request["stuPwd"].ToString();
            int stuCollege = int.Parse(Context.Request["stuCollege"].ToString()),
                stuPro = int.Parse(Context.Request["stuPro"].ToString());
            College stuCol = new College()
            {
                ColID = stuCollege
            };
            Profession stup = new Profession() { ProId = stuPro};
            Student EditorStu = new Student()
            {
                StuAccount = stuNO,
                RealName = stuName,
                Sex = stuSex,
                Email = stuEmail,
                Phone = stuPhone,
                StuPwd = stuPwd,
                college = stuCol,
                profession = stup
            };
            StudentBll editorStuBll = new StudentBll();
            Result editorResult = editorStuBll.Updata(EditorStu);
            if (editorResult == Result.更新成功)
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
        /// <summary>
        /// 添加学生
        /// </summary>
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
        /// <summary>
        /// 实现分页
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
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
        /// <summary>
        /// 判断是否能删除学生
        /// </summary>
        /// <returns></returns>
        public Result isDeleteStu()
        {
            string stuId = Context.Request["stuId"].ToString();
            Result row = Result.记录不存在;
            if (stuBll.IsDelete("T_TitleRecord", "stuAccount", stuId) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        /// <summary>
        /// 删除学生
        /// </summary>
        public void deleteStu()
        {
            string stuId = Context.Request["stuId"].ToString();
            Result row = isDeleteStu();
            if(row == Result.记录不存在)
            {
                Result delResult = stuBll.delete(stuId);
                if(delResult == Result.删除成功)
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
                Response.Write("该学生在其他表中有关联，不能删除！");
                Response.End();
            }
        }
    }
}
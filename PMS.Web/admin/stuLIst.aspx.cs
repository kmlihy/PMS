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
    using PMS.DBHelper;
    using System.Text;
    using Result = Enums.OpResult;
    public partial class stuLIst : CommonPage
    {
        protected DataSet prods = null;//专业
        protected DataSet colds = null;//院系
        //添加的专业下拉框
        protected DataSet stuAddProds = null;
        protected DataSet ds = null;
        protected int getCurrentPage = 0;
        protected int count;
        protected int pagesize = 20;
        protected String search = "";
        protected String searchdrop = "";
        protected String searchCollege = "";
        protected String searchProAndCollege = "";

        protected string showstr = null;

        //输入框条件保存
        protected string showmsg = "";
        //学院下拉框条保存
        protected string showcollegedrop = "";
        //用户类型
        protected string userType = "";

        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();
        StudentBll stuBll = new StudentBll();
        RSACryptoService rsa = new RSACryptoService();
        Teacher tea = new Teacher();
        public void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string editorOp = Context.Request["editorOp"];
            //下拉专业id
            string proId = Request.QueryString["proId"];
            //下拉学院id
            string collegeId = Request.QueryString["collegeId"];
            //输入框信息
            string strsearch = Request.QueryString["search"];

            userType = Session["state"].ToString();

            if (userType == "0")
            {
                colds = colBll.Select();
                prods = proBll.Select();
                stuAddProds = proBll.Select();
                if (collegeId == null || collegeId == "0" || collegeId == "null")
                {
                    prods = proBll.Select();
                }
                else
                {
                    prods = proBll.SelectByCollegeId(int.Parse(collegeId));
                }
                if (proId != null && proId != "null" && collegeId == "null")
                {
                    //学院为空 专业不为空
                    getdata(Searchdrop());
                }
                else if (collegeId != null && collegeId != "null" && (proId == "null" || proId == "0"))
                {
                    //学院不为空 专业为空
                    getdata(SearchByCollege());
                }
                else if (collegeId != null && collegeId != "null" && proId != null && proId != "null")
                {
                    //两个都不为空
                    getdata(SearchProAndCollege());
                }
                else if (strsearch != null)
                {
                    getdata(Search());
                }
                else
                {
                    getdata("");
                    colds = colBll.Select();
                }

            }
            else if (userType == "2")
            {
                tea = (Teacher)Session["user"];
                int usercollegeId = tea.college.ColID;
                colds = colBll.Select();
                prods = proBll.SelectByCollegeId(usercollegeId);
                stuAddProds = proBll.SelectByCollegeId(usercollegeId);
                if (strsearch != null)
                {
                    getdata(Search());
                }
                else if (proId != null && proId != "null")
                {
                    getdata(Searchdrop());
                }
                else
                {
                    getdata("");
                }
            }
            if (op == "add")//添加
            {
                saveStudent();
            }
            if (editorOp == "editor")//编辑
            {
                editorStu();
            }
            if (op == "delete")//删除
            {
                deleteStu();
            }

            if (op == "stuadd")
            {
                //学院与专业下拉联动
                int addcollegeId = int.Parse(Context.Request["stuAddcollegeId"]);
                stuAddProds = proBll.SelectByCollegeId(addcollegeId);
                DataTable dt = stuAddProds.Tables[0];
                string data = DataTableToJson(dt);
                Response.Write(data);
                Response.End();
            }
            if (op=="reset") {
                //重置密码
                stuPasswordReset();
            }
        }

        public void stuPasswordReset() {
            string stuAccount = Context.Request["stuNO"].ToString();
            string stuPwd = rsa.Encrypt("000000");
            Result resetResult =stuBll.ResetPwd(stuAccount, stuPwd); 
            if (resetResult== Result.更新成功) {
                LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 重置学生" + stuAccount + "密码");
                Response.Write("重置成功");
                Response.End();
            }
            else {
                Response.Write("重置失败");
                Response.End();
            }
        }
        /// <summary>
        /// datatable转换成json
        /// </summary>
        /// <param name="table">需要转换的datatable</param>
        /// <returns></returns>
        public string DataTableToJson(DataTable table)
        {
            var JsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
            }
            return JsonString.ToString();
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
                    showmsg = search;
                    search = String.Format("stuAccount {0} or sex {0} or realName {0} or collegeName {0} or phone {0} or Email {0} or proName {0} ", "like " + "'%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        /// <summary>
        /// 专业下拉查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["proId"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                }
                else if (searchdrop == "0")
                {
                    searchdrop = "";
                }
                else
                {
                    //下拉框保留查询条件
                    showstr = searchdrop;
                    searchdrop = String.Format("proId={0} ", "'" + searchdrop + "'");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
            return searchdrop;
        }

        /// <summary>
        /// 学院下拉查询
        /// </summary>
        /// <returns></returns>
        public string SearchByCollege()
        {

            try
            {
                searchCollege = Request.QueryString["collegeId"];
                if (searchCollege.Length == 0)
                {
                    searchCollege = "";
                }
                else if (searchCollege == null)
                {
                    searchCollege = "";
                }
                else if (searchCollege == "0")
                {
                    searchCollege = "";
                }
                else
                {
                    //分院下拉搜索后条件保存
                    showcollegedrop = searchCollege;
                    searchCollege = String.Format(" collegeId={0}", searchCollege);
                }
            }
            catch
            {

            }
            return searchCollege;
        }

        public string SearchProAndCollege()
        {
            try
            {
                //学院下拉的条件
                searchCollege = Request.QueryString["collegeId"];
                //学院条件传到前台
                showcollegedrop = searchCollege;
                //批次的条件

                searchdrop = Request.QueryString["proId"];
                showstr = searchdrop;
                if (searchCollege == "0")
                {
                    searchCollege = "";
                    searchdrop = "";
                    searchProAndCollege = "";
                }
                else if (search == "0" && searchCollege != "0")
                {
                    searchdrop = "";
                    searchProAndCollege = String.Format(" collegeId={0} ", "'" + searchCollege + "'");
                }
                else
                {
                    searchProAndCollege = String.Format(" collegeId={0} and proId={1}", "'" + searchCollege + "'", " '" + searchdrop + "'");
                }
            }
            catch
            {

            }
            return searchProAndCollege;
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
                   oldPhone = Context.Request["oldPhone"].ToString(),
                   oldEmail = Context.Request["oldEmail"].ToString();
            int stuCollege = int.Parse(Context.Request["stuCollege"].ToString()),
                stuPro = int.Parse(Context.Request["stuPro"].ToString());
                try
                {
                    College stuCol = new College();
                    stuCol.ColID = stuCollege;
                    Profession stup = new Profession();
                    stup.ProId = stuPro;
                    Student EditorStu = new Student();
                    EditorStu.StuAccount = stuNO;
                    EditorStu.RealName = stuName;
                    EditorStu.Sex = stuSex;
                    EditorStu.college = stuCol;
                    EditorStu.profession = stup;
                    if (stuEmail != oldEmail && stuPhone == oldPhone)
                    {
                        if (stuBll.selectByEmail(stuEmail))
                        {//根据输入的邮箱查找是否已存在
                            Response.Write("此邮箱已存在");
                            Response.End();
                        }
                        else
                        {
                        EditorStu.Phone = oldPhone;
                        EditorStu.Email = stuEmail;
                        }
                    }
                    else if (stuEmail == oldEmail && stuPhone != oldPhone)
                    {
                        if (stuBll.selectByPhone(stuPhone))
                        {//根据输入的联系电话查找是否已存在
                            Response.Write("此联系电话已存在");
                            Response.End();
                        }
                        else
                        {
                            EditorStu.Phone = stuPhone;
                            EditorStu.Email = oldEmail;
                        }
                    }
                    else if (stuEmail == oldEmail && stuPhone == oldPhone)
                    {
                            EditorStu.Email = oldEmail;
                            EditorStu.Phone = oldPhone;
                    }
                    else
                    {
                        if (stuBll.selectByEmail(stuEmail))
                        {//根据输入的邮箱查找是否已存在
                            Response.Write("此邮箱已存在");
                            Response.End();
                        }
                        else if (stuBll.selectByPhone(stuPhone))
                        {//根据输入的联系电话查找是否已存在
                            Response.Write("此联系电话已存在");
                            Response.End();
                        }
                        else
                        {
                            EditorStu.Phone = stuPhone;
                            EditorStu.Email = stuEmail;
                        }
                    }
                    StudentBll editorStuBll = new StudentBll();
                    Result editorResult = editorStuBll.Updata(EditorStu);
                    if (editorResult == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 编辑学生" + stuNO + "信息");
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
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
                    //pwd = Context.Request["pwd"].ToString(),
                    realName = Context.Request["realName"].ToString(),
                    sex = Context.Request["sex"].ToString(),
                    phone = Context.Request["phone"].ToString(),
                    email = Context.Request["email"].ToString(),
                    proId = Context.Request["pro"].ToString();
                if (stuBll.selectByEmail(email))
                {//根据输入的邮箱查找是否已存在
                    Response.Write("此邮箱已存在");
                    Response.End();
                }
                else if (stuBll.selectByPhone(phone))
                {//根据输入的联系电话查找是否已存在
                    Response.Write("此联系电话已存在");
                    Response.End();
                }
                else
                {
                    Profession prof = new Profession()
                    {
                        ProId = Convert.ToInt32(proId)
                    };
                    string year = DateTime.Now.ToString("yyyy");
                    Student stu = new Student()
                    {
                        StuAccount = stuAccount,
                        StuPwd = rsa.Encrypt("000000"),
                        RealName = realName,
                        Sex = sex,
                        Phone = phone,
                        Email = email,
                        profession = prof,
                        finishYear=Convert.ToInt32(year)
                    };
                    StudentBll stuBll = new StudentBll();
                    if (stuBll.selectBystuId(stuAccount) == true)
                    {
                        Response.Write("该学生已存在，添加失败");
                        Response.End();
                    }
                    else
                    {
                        Result result = stuBll.Insert(stu);
                        if (result == Result.添加成功)
                        {
                            LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 添加学生" + stuAccount + "信息");
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
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
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
            string userType = Session["state"].ToString();
            string userCollege = "";
            //usertype=2 为分院管理员登录
            if (userType == "2")
            {
                Teacher tea = (Teacher)Session["user"];
                int userCollegeId = tea.college.ColID;
                if (strWhere == null || strWhere == "")
                {
                    userCollege = "collegeId=" + "'" + userCollegeId + "'";
                }
                else
                {
                    userCollege = "collegeId=" + "'" + userCollegeId + "'" + "and" + "(" + strWhere + ")";
                }
                StudentBll pro = new StudentBll();
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Student",
                    StrWhere = userCollege,
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
            else
            {
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
            try
            {
                if (row == Result.记录不存在)
                {
                    Result delResult = stuBll.delete(stuId);
                    if (delResult == Result.删除成功)
                    {
                        LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 删除学生" + stuId + "账号");
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
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
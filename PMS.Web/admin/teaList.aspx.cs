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
    using PMS.DBHelper;
    using System.IO;
    using Result = Enums.OpResult;
    public partial class teaList : CommonPage
    {
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 20;
        protected String search = "";
        protected int state;
        TeacherBll teabll = new TeacherBll();
        //分院
        protected DataSet colds = null;
        protected CollegeBll colbll = new CollegeBll();
        protected string showmsg = "";
        Teacher tealogin = new Teacher();
        protected void Page_Load(object sender, EventArgs e)
        {
            tealogin = (Teacher)Session["user"];
            state = Convert.ToInt32(Session["state"]);
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
            if (op== "import")
            {
                int collegeId;
                if (state == 0)
                {
                    collegeId = Convert.ToInt32(Context.Request["collegeId"]);
                }
                else
                {
                    collegeId = tealogin.college.ColID;
                }
                string path = Security.Decrypt(Request["fileName"]);
                DataTable dt = TableHelper.GetDistinctSelf(ExcelHelp.excelToDt(path, "excel"), "工号");
                int i = ImportHelper.Teacher(dt,collegeId);
                int row = ExcelHelp.excelToDt(path, "excel").Rows.Count;
                int repeat = row - i;
                if (i > 0)
                {
                    LogHelper.Info(this.GetType(), tealogin.TeaAccount + "教师信息导入 -" + i + " " + "条信息");
                    Response.Write("导入成功，总数据有" + row + "条，共导入" + i + "条数据，重复数据有" + repeat + "条");
                    Response.End();
                }
                else
                {
                    Response.Write("导入失败，总数据有" + row + "条，共导入" + i + "条数据，重复数据有" + repeat + "条");
                    Response.End();
                }
            }
            //if (op == "upload")
            //{
            //    upload();
            //}
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            colds = colbll.Select();
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        public void upload()
        {
            try
            {
                Teacher user = (Teacher)Session["user"];//获取当前用户账号作为文件夹名称
                HttpFileCollection file = HttpContext.Current.Request.Files;//从HTTP文件流读取上传文件
                if (file.Count > 0)
                {
                    //文件大小
                    long size = file[0].ContentLength;
                    //文件类型
                    string type = file[0].ContentType;
                    //文件名 IE浏览器文件名是绝对路径，服务器文件夹名称不支持（//），其他浏览器为文件名（兼容ie）
                    string filename = "";
                    if (filename.IndexOf("\\") != -1)//判断路径中是否包含\\
                    {
                        string[] a = filename.Split('\\');//分割字符串
                        filename = a[a.Length - 1].ToString();//获取数组最后一位作为文件夹名称

                    }
                    else
                    {
                        filename = file[0].FileName;//不是IE 直接返回文件名称作为文件夹名

                    }
                    //文件格式
                    string tp = System.IO.Path.GetExtension(filename);
                    if (tp == ".xls" || tp == ".xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/教师信息导入存储");//指定上传文件 在服务器保存路径
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");

                        string name = datetime + "-" + filename;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//路径合并

                        file[0].SaveAs(savePath);//存入服务器

                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable
                        TeacherBll bll = new TeacherBll();
                        int row = bll.upload(dt);
                        if (row > 0)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('导入失败');</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('导入成功');</script>");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('Excel格式不正确');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择上传文件');</script>");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
                this.Response.Write(ex.Message);
            }
        }

        /// <summary>
        /// 判断是否能删除
        /// </summary>
        /// <returns>查询结果</returns>
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

        /// <summary>
        /// 删除执行
        /// </summary>
        public void delTeal()
        {
            string delteaAccount = Context.Request["TeaAccount"].ToString();
            Result row = IsdeleteCollege();
            try
            {
                if (row == Result.记录不存在)
                {
                    Result result = teabll.Delete(delteaAccount);

                    if (result == Result.删除成功)
                    {
                        LogHelper.Info(this.GetType(), tealogin.TeaAccount + " - " + tealogin.TeaName + " - 删除" + delteaAccount + "教师账号");
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
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }

        /// <summary>
        /// 添加教师
        /// </summary>
        public void saveTeacher()
        {
            string teaAccount = Context.Request["TeaAccount"].ToString();
            if (!teabll.selectByteaId(teaAccount)) {
                try
                {
                    int collegeId = Convert.ToInt32(Context.Request["CollegeId"]);
                    //int teaType = Convert.ToInt32(Context.Request["TeaType"]);
                    //string pwd = Context.Request["Pwd"].ToString();
                    string teaName = Context.Request["TeaName"].ToString();
                    string sex = Context.Request["Sex"].ToString();
                    string email = Context.Request["Email"].ToString();
                    string tel = Context.Request["Tel"].ToString();
                    if (teabll.selectByEmail(email))
                    {//根据输入的邮箱查找是否已存在
                        Response.Write("此邮箱已存在");
                        Response.End();
                    }
                    else if (teabll.selectByPhone(tel))
                    {//根据输入的联系电话查找是否已存在
                        Response.Write("此联系电话已存在");
                        Response.End();
                    }
                    else
                    {
                        Teacher tea = new Teacher();
                        College college = new College();
                        Teacher teacher = teabll.GetModel(tealogin.TeaAccount);
                        if (state==0)
                        {
                            college.ColID = collegeId;
                        }
                        else
                        {
                            college.ColID = tealogin.college.ColID;
                        }
                        tea.college = college;
                        tea.TeaType = 1;
                        tea.TeaAccount = teaAccount;
                        RSACryptoService rsa = new RSACryptoService();
                        tea.TeaPwd = rsa.Encrypt("000000");
                        tea.TeaName = teaName;
                        tea.Sex = sex;
                        tea.Email = email;
                        tea.Phone = tel;
                        OpResult result = teabll.Insert(tea);
                        if (result == OpResult.添加成功)
                        {
                            LogHelper.Info(this.GetType(), tealogin.TeaAccount + " - " + tealogin.TeaName + " - 添加教师账号");
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
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }
            else
            {
                Response.Write("此账号已存在");
                Response.End();
            }
        }

        /// <summary>
        /// 编辑教师信息
        /// </summary>
        public void saveChange()
        {
            string teaName = Context.Request["TeaName"].ToString();
            string teaAccount = Context.Request["TeaAccount"].ToString();
            string teaEmal = Context.Request["TeaEmail"].ToString();
            string teaPhone = Context.Request["TeaPhone"].ToString();
            //string pwd = Context.Request["Pwd"].ToString();
            string sex = Context.Request["Sex"].ToString();
            int collegeId = Convert.ToInt32(Context.Request["CollegeId"]);
            string oldPhone = Context.Request["oldPhone"].ToString();
            string oldEmail = Context.Request["oldEmail"].ToString();
            int teaType;
            if (state==0)
            {
                teaType = Convert.ToInt32(Context.Request["TeaType"]);
            }
            else
            {
                teaType = 1;
            }
            if (teaEmal != oldEmail)
            {
                if (teabll.selectByEmail(teaEmal))
                {//根据输入的邮箱查找是否已存在
                    Response.Write("此邮箱已存在");
                    Response.End();
                }
            }
            else if (teaPhone != oldPhone)
            {
                if (teabll.selectByPhone(teaPhone))
                {//根据输入的联系电话查找是否已存在
                    Response.Write("此联系电话已存在");
                    Response.End();
                }
            }
            else
            {
                Teacher tea = new Teacher();
                College college = new College();
                try
                {
                    tealogin = (Teacher)Session["user"];
                    Teacher teacher = teabll.GetModel(tealogin.TeaAccount);
                    if (state == 0)
                    {
                        college.ColID = collegeId;
                    }
                    else
                    {
                        college.ColID = tealogin.college.ColID;
                    }
                    tea.college = college;
                    tea.TeaAccount = teaAccount;
                    tea.TeaPwd = teabll.GetModel(teaAccount).TeaPwd;
                    tea.TeaName = teaName;
                    tea.Phone = teaPhone;
                    tea.Email = teaEmal;
                    tea.Sex = sex;
                    tea.TeaType = teaType;
                    OpResult result = teabll.Updata(tea);
                    if (result == OpResult.更新成功)
                    {
                        LogHelper.Info(this.GetType(), tealogin.TeaAccount + " - " + tealogin.TeaName + " - 编辑" + teaAccount + "教师账号");
                        Response.Write("修改成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("修改失败");
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }

        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            //判断是哪个院系的管理员登录 只加载该院系下的教师
            //获取登录者的类型
            string userType = Session["state"].ToString();
            //string userType = "2";
            string usercollege = "";
            TeacherBll pro = new TeacherBll();
            if (userType == "2")
            {
                //如果是分院管理员只加载该分院的教师
                Teacher tea = (Teacher)Session["user"];
                int usercollegeId = tea.college.ColID;
                string strTeaType = "";
                if (strWhere == null || strWhere == "")
                {
                    strTeaType = "teaType=1 and ";
                    usercollege = "collegeId=" + "'" + usercollegeId + "'";
                }
                else
                {
                    strTeaType = "teaType=1 and ";
                    usercollege = "collegeId=" + "'" + usercollegeId + "'" + "and " + "(" + strWhere + ")";
                }
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Teacher",
                    StrWhere = strTeaType + usercollege,
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
            else if (userType == "0")
            {
                //如果是超管则加载所有教师包括分院管理员
                string strTeaType = "teaType = 1";
                if (strWhere !=null && strWhere!="") {
                    strTeaType = "teaType = 1 and" + "(" + strWhere + ")";
                }
                TableBuilder tabuilder = new TableBuilder()
                {

                    StrTable = "V_Teacher",
                    StrWhere = strTeaType,
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
        }
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <returns>查询条件</returns>
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
                    search = String.Format(" teaAccount {0} or sex {0} or teaName {0} or collegeName {0} or phone {0} or Email {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
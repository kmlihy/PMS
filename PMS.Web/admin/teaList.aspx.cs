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
    using System.IO;
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
        protected string showmsg="";

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
            if (op == "upload")
            {
                upload();
            }
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            colds = colbll.Select();
        }
        //批量导入
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
                this.Response.Write(ex.Message);
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
        //获取信息
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
            if (userType == "2") {
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
                    usercollege = "collegeId=" + "'" + usercollegeId+"'" + "and ";
                }
                TableBuilder tabuilder = new TableBuilder()
                {
                    StrTable = "V_Teacher",
                    StrWhere = strTeaType + usercollege + strWhere,
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
            else if (userType=="0")
            {
                //如果是超管则加载所有教师包括分院管理员
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
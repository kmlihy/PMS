using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;

    public partial class branchList : System.Web.UI.Page
    {
        CollegeBll coll = new CollegeBll();
        College college = new College();
        //获取数据
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        protected String search = "";
        protected String strSearch = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            //添加学院
            if (op == "add")
            {
                saveCollege();
                Search();
                getdata(Search());                
            }
            //编辑学院信息
            else if (op == "edit")
            {
                editCollege();
                Search();
                getdata(Search());
            }
            //删除学院
            else if (op == "dele")
            {
                deleteCollege();
                Search();
                getdata(Search());
            }
            else if (op == "upload")
            {
                upload();
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
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "collegeId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = coll.SelectBypage(tbd, out count);
        }
        //添加分院信息
        public void saveCollege()
        {
            string collegeName = Context.Request["collegeName"].ToString();
            college.ColName = collegeName;
            Result result = coll.Insert(college);
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
        //编辑分院信息
        public void editCollege()
        {
            int collegeId = int.Parse(Context.Request["id"].ToString());
            string collegeName = Context.Request["name"].ToString();
            College college = new College();
            college.ColID = collegeId;
            college.ColName = collegeName;
            //Response.Write(collegeName);
            CollegeBll coll = new CollegeBll();
            Result result = coll.Update(college);
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
        //查询
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
                    search = String.Format("collegeName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        //批量导入
        public void upload()
        {
            try
            {
                Teacher user = (Teacher)Session["user"];//取得登录用户用账号作为文件夹名称
                HttpFileCollection file = HttpContext.Current.Request.Files;//从HTTP文件流中读取上传文件
                if (file.Count > 0)
                {
                    //文件大小   
                    long size = file[0].ContentLength;
                    //文件类型   
                    string type = file[0].ContentType;
                    //文件名  IE浏览器文件名是绝对路径，服务器文件夹名不支持（\\），其他浏览器为文件名(兼容ie) 
                    string filename = "";
                    filename = file[0].FileName;
                    if (filename.IndexOf("\\") != -1)//判断路径中是否包含\\
                    {
                        string[] a = filename.Split('\\');//分割字符串
                        filename = a[a.Length - 1].ToString();//取数组最后一位作为文件夹名称
                    }
                    else
                    {
                        filename = file[0].FileName;//不是ie直接返回文件名称作为文件夹名
                    }
                    //文件格式   
                    string tp = System.IO.Path.GetExtension(filename);

                    if (tp == ".xls" || tp == "xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储");//指定上传文件在服务器上的保存路 
                        dir = new DirectoryInfo(savePath);
                        dir.Create();


                        savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储/" + user.TeaAccount + "");
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");

                        string name = datetime + "-" + filename;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//将路径合并

                        file[0].SaveAs(savePath);//存入服务器

                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable
                        CollegeBll bll = new CollegeBll();
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
                this.Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string collegeid = Context.Request["collegeid"].ToString();
            Result row = Result.记录不存在;
            if (coll.IsDelete("T_Plan", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (coll.IsDelete("T_Profession", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (coll.IsDelete("T_Teacher", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除
        public void deleteCollege()
        {
            string collegeid = Context.Request["collegeid"].ToString();
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
            Result result = coll.Delete(int.Parse(collegeid));

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
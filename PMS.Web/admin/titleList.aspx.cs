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
using static PMS.BLL.Enums;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class titleList : System.Web.UI.Page
    {
        protected DataSet ds = null;//储存标题表
        protected DataSet prods = null;//储存专业信息
        protected DataSet plads = null;//储存批次信息
        protected DataSet colds = null;//储存分院信息

        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        protected String search = "";
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "";
        protected string showstr = null;
        protected string showinput = null;
        protected string secSearch = "";

        TeacherBll teabll = new TeacherBll();//教师对象
        ProfessionBll probll = new ProfessionBll();//专业
        PlanBll plabll = new PlanBll();//批次业务逻辑
        TitleBll titbll = new TitleBll();//标题业务逻辑

        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string type = Request.QueryString["type"];
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            //编辑
            if (op == "edit")
            {
                editTitle();
                Search();
                getdata(Search());
            }
            //删除
            if (op == "del")
            {
                deleteTitle();
                Search();
                getdata(Search());
            }
            //批量导入
            if(op == "upload")
            {
                upload();
                Search();
                getdata(Search());
            }
            //选择文本
            if (type == "textSelect")
            {                
                getdata(Search());
            }
            //批次下拉菜单
            if(type == "plandrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                if(dropstrWhereplan == "0")
                {
                    getdata("");
                }
                string strWhere = string.Format(" planId = {0}", dropstrWhereplan);
                getdata(strWhere);
            }
            //专业下拉菜单
            if(type == "prodrop")
            {
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0}", dropstrWherepro);
                getdata(strWhere);
            }
            //所有下拉菜单
            if(type == "alldrop")
            {
                dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
                getdata(strWhere);
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TitleBll titbll = new TitleBll();
            Teacher tea = (Teacher)Session["loginuser"];
            string teaAccount = tea.TeaAccount;
            string account = "teaAccount = '" + teaAccount + "'";
            string Account = "teaAccount = '" + teaAccount + "' and ";
            TableBuilder tabuilder = new TableBuilder();
            tabuilder.StrTable = "V_Title";
            tabuilder.StrWhere = (strWhere == null || strWhere == "" ? account : Account + strWhere);
            tabuilder.IntColType = 0;
            tabuilder.IntOrder = 0;
            tabuilder.IntPageNum = int.Parse(currentPage);
            tabuilder.IntPageSize = pagesize;
            tabuilder.StrColumn = "titleId";
            tabuilder.StrColumnlist = "*";
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
            
            colds = colbll.Select();
            prods = probll.Select();
            plads = plabll.Select();
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
                if (search.Length == 0)
                {
                    search = "";
                    secSearch = "";
                }
                else if (search == null)
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    secSearch = search;
                    search = String.Format("titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }

        /// <summary>
        /// 编辑题目
        /// </summary>
        public void editTitle()
        {
            int titleId = int.Parse(Context.Request["saveTitleId"].ToString());
            string title = Context.Request["saveTitle"].ToString();

            string planId = Context.Request["savePlan"].ToString();
            string proId = Context.Request["saveProf"].ToString();
            string teaAccount = Context.Request["saveTea"].ToString();

            int limit = int.Parse(Context.Request["saveLimit"].ToString());
            DateTime createTime = Convert.ToDateTime(Context.Request["saveCreateTime"].ToString());
            string content = Context.Request["saveContent"].ToString();
            int selected = int.Parse(Context.Request["saveSelected"].ToString());
            
            Plan plan = new Plan();
            plan.PlanId = int.Parse(planId);

            Profession pro = new Profession();
            pro.ProId = int.Parse(proId);

            Teacher tea = new Teacher();
            tea.TeaAccount = teaAccount;

            TitleBll tbll = new TitleBll();
            Title getTitle = new Title();
            getTitle.TitleId = titleId;
            getTitle.title = title;
            getTitle.plan = plan;
            getTitle.profession = pro;
            getTitle.teacher = tea;
            getTitle.Limit = limit;
            getTitle.CreateTime = createTime;
            getTitle.TitleContent = content;
            getTitle.Selected = selected;

            Result result = tbll.Update(getTitle);
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

        /// <summary>
        /// 判断是否能删除
        /// </summary>
        /// <returns>返回判断结果</returns>
        public Result isDeleteTitle()
        {
            string titleId = Context.Request["deleteTitleId"].ToString();
            Result delResult = Result.记录不存在;
            if (titbll.IsDelete("T_TitleRecord", "titleId", titleId) == Result.关联引用)
            {
                delResult = Result.关联引用;
            }
            return delResult;
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        public void deleteTitle()
        {
            int titleId = int.Parse(Context.Request["deleteTitleId"].ToString());
            Result row = isDeleteTitle();
            if (row == Result.记录不存在)
            {
                Result result = titbll.Delete(titleId);
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

        /// <summary>
        /// 批量导入
        /// </summary>
        public void upload()
        {
            try
            {
                //Teacher user = (Teacher)Session["user"];//取得登录用户用账号作为文件夹名称
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

                    if (tp == ".xls" || tp == ".xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        //string savePath = Server.MapPath("~/upload/题目信息导入Excel文件存储/admin");//指定上传文件在服务器上的保存路径
                        //dir = new DirectoryInfo(savePath);
                        //dir.Create();
                        Teacher user = (Teacher)Session["user"];//获取当前用户账号作为文件夹名称

                        string savePath = Server.MapPath("~/upload/题目信息导入Excel文件存储/"+ user.TeaName);
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");

                        string name = datetime + "-" + filename;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//将路径合并

                        file[0].SaveAs(savePath);//存入服务器

                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable
                        TitleBll bll = new TitleBll();
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
                this.Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
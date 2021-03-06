﻿using PMS.BLL;
using PMS.DBHelper;
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
    public partial class titleList : CommonPage
    {
        protected DataSet ds = null;//储存标题表
        protected DataSet prods = null;//储存专业信息
        protected DataSet plads = null;//储存批次信息
        protected DataSet colds = null;//储存分院信息

        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 20;
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
        Teacher teacher = new Teacher();
        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            int state = Convert.ToInt32(Session["state"]);
            if(state == 0 || state == 2)
            {
                teacher = (Teacher)Session["user"];
            }
            else if(state == 1)
            {
                teacher = (Teacher)Session["loginuser"];
            }
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
            string alert = Request.QueryString["state"];
            if (alert == "1")
            {
                Response.Write("<script>alert('批次已激活，不可编辑')</script>");
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
            tabuilder.IntOrder = 1;
            tabuilder.IntPageNum = int.Parse(currentPage);
            tabuilder.IntPageSize = pagesize;
            tabuilder.StrColumn = "titleId";
            tabuilder.StrColumnlist = "*";
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
            //加载所有分院
            colds = colbll.Select();
            //加载登录教师所在分院的专业
            TableBuilder tabuilderPro = new TableBuilder();
            tabuilderPro.StrTable = "T_Profession";
            tabuilderPro.StrWhere = "collegeId = '" + tea.college.ColID + "'";
            tabuilderPro.IntColType = 0;
            tabuilderPro.IntOrder = 0;
            tabuilderPro.IntPageNum = 1;
            tabuilderPro.IntPageSize = 100;
            tabuilderPro.StrColumn = "proId";
            tabuilderPro.StrColumnlist = "*";
            prods = probll.SelectBypage(tabuilderPro,out count);
            //加载登录教师所在分院的批次
            TableBuilder tabuilderPlan = new TableBuilder();
            tabuilderPlan.StrTable = "T_Plan";
            tabuilderPlan.StrWhere = "collegeId = '" + tea.college.ColID + "'";
            tabuilderPlan.IntColType = 0;
            tabuilderPlan.IntOrder = 0;
            tabuilderPlan.IntPageNum = 1;
            tabuilderPlan.IntPageSize = 100;
            tabuilderPlan.StrColumn = "planId";
            tabuilderPlan.StrColumnlist = "*";
            plads = plabll.SelectBypage(tabuilderPlan,out count);
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
            int titleId = int.Parse(Context.Request["titleId"].ToString());
            string planId = Context.Request["planId"].ToString();
            TitleBll titleBll = new TitleBll();
            bool state = titleBll.selectByplanId(planId);
            if (state)
            {
                Response.Write("批次已激活，不可编辑");
                Response.End();
            }
            else
            {
                //Response.Redirect("addPaper.aspx?state=1");
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
            try
            {
                if (row == Result.记录不存在)
                {
                    Result result = titbll.Delete(titleId);
                    if (result == Result.删除成功)
                    {
                        LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 删除" + titleId + "题目");
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
                LogHelper.Error(this.GetType(), ex);
                this.Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        /// <summary>
        /// 批量删除前判断是否能删除
        /// </summary>
        /// <returns>Result对象</returns>
        public Result IsBatchDelete()
        {
            Result row = Result.记录不存在;
            string titleId = Context.Request["titleId"].ToString();
            string[] titleList = titleId.Split('?');
            for (int i = 0; i < titleList.Length; i++)
            {
                if (titbll.IsDelete("T_TitleRecord", "titleId", titleList[i]) == Result.关联引用)
                {
                    row = Result.关联引用;
                }
            }
            return row;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public void batchDeleteCollege()
        {
            string titleId = Context.Request["titleId"].ToString();
            string[] titleList = titleId.Split('?');
            Result row = IsBatchDelete();
            int count = 0;
            try
            {
                if (row == Result.记录不存在)
                {
                    for (int i = 0; i < titleList.Length - 1; i++)
                    {
                        int collId = int.Parse(titleList[i]);
                        Result result = titbll.Delete(collId);
                        if (result == Result.删除成功)
                        {
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 删除" + collId + "题目");
                            count++;
                        }
                    }
                    if (count == titleList.Length - 1)
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
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
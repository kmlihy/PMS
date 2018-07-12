using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class selectTopicList : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //专业
        protected DataSet prods = null;
        protected ProfessionBll probll = new ProfessionBll();
        //批次
        protected PlanBll planbll = new PlanBll();
        protected DataSet plands = null;
        TitleRecordBll titrecordbll = new TitleRecordBll();
        //学院
        protected DataSet bads = null;
        protected CollegeBll colbll = new CollegeBll();
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 2;
        protected String search = "";
        protected String searchdrop = "";
        protected String searanddrop = "";
        protected String searbatchdrop = "";
        protected string showstr = null;
        protected string showinput = null;
        protected string showbacthdrop = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.Form["op"];
            string op1 = Context.Request.QueryString["op"];
            //下拉专业ID
            string dropstrWhere = Request.QueryString["dropstrWhere"];
            //下拉批次Id
            string batchWhere = Request.QueryString["batchWhere"];
            //搜索信息
            string strsearch = Request.QueryString["search"];
            if (op == "del")
            {
                IsdeleteCollege();
                delPro();
            }
            //导出列表
            if(op1 == "export")
            {
                TitleRecordBll titlerd = new TitleRecordBll();
                string strWhere = string.Format(" where proId = 1");
                DataTable dt = titlerd.ExportExcel(strWhere);
                var path = Server.MapPath("~/upload/daochu.xls");
                ExcelHelper.x2003.TableToExcelForXLS(dt, path);
                downloadfile(path);
            }
            if (dropstrWhere != null && dropstrWhere != "null" && batchWhere == "null")
            {// 如果批次id为空，专业id不为空
                getPage(Searchdrop());
            }
            else if (batchWhere != null && batchWhere != "null" && (dropstrWhere == "null" || dropstrWhere=="0"))
            {// 如果专业id为空，批次id不为空
                getPage(batcchdrop());
            }
            else if (dropstrWhere != null && dropstrWhere != "null" && batchWhere != null && batchWhere != "null")
            {
                //两个都不为空
                getPage(SearchProAndBatch());
            }
            else if (strsearch != null)
            {
                getPage(Search());
            }
            else {
                getPage("");
            }

            bads = colbll.Select();
            prods = probll.Select();
            plands = planbll.Select();
        }

        public void downloadfile(string s_path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(s_path);
            HttpContext.Current.Response.ContentType = "application/ms-download";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.End();
        }

        //批次下拉查询
        public string batcchdrop()
        {
            try
            {
                searbatchdrop = Request.QueryString["batchWhere"];
                if (searbatchdrop.Length == 0)
                {
                    showstr = "0";
                }
                else if (searbatchdrop == null)
                {
                    searchdrop = "";
                }
                else if (searbatchdrop == "0")
                {
                    searbatchdrop = "";
                }
                else
                {
                    int.Parse(searbatchdrop);
                    //批次下拉搜索后条件保存
                    showbacthdrop = searbatchdrop;
                    searbatchdrop = String.Format(" planId={0}", "'" + searbatchdrop + "'");

                }
            }
            catch
            {

            }
            return searbatchdrop;
        }
        //专业和批次一起查询
        public string SearchProAndBatch()
        {
            try
            {
                //专业下拉的条件
                searchdrop = Request.QueryString["dropstrWhere"];
                //专业条件传到前台
                showstr = searchdrop;
                //批次的条件
                search = Request.QueryString["batchWhere"];
                showbacthdrop = search;
                if (searchdrop == "0")
                {
                    searchdrop = "";
                    search = "";
                    searanddrop = "";
                }
                else if (search == "0" && searchdrop != "0")
                {
                    search = "";
                    searanddrop = String.Format(" proId={0} ", "'" + searchdrop + "'");
                    //searanddrop = String.Format(" proId={0} and planId={1}", "'" + searchdrop + "'", " '" + search + "'");
                }
                else
                {
                    searanddrop = String.Format(" proId={0} and planId={1}", "'" + searchdrop + "'", " '" + search + "'");
                }
            }
            catch
            {

            }
            return searanddrop;
        }

        //专业下拉查询
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropstrWhere"];
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
                    //专业下拉搜索后条件保存
                    showstr = searchdrop;
                    searchdrop = String.Format(" proId={0}", "'" + searchdrop + "'");
                }
            }
            catch
            {

            }
            return searchdrop;
        }
        //搜索
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
                    //查询按钮点击后查询条件保存
                    showinput = search;
                    search = String.Format(" teaName {0} or title {0} or realName {0} or planName {0} or proName {0} or collegeName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string recordid = Context.Request["Recordid"].ToString();
            Result row = Result.记录不存在;
            if (titrecordbll.IsDelete("T_Student", "proId", recordid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (titrecordbll.IsDelete("T_Title", "proId", recordid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除
        public void delPro()
        {
            int recordid = int.Parse(Context.Request["Recordid"].ToString());
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
                Result result = titrecordbll.delete(recordid);

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
        //获取数据
        public void getPage(String strWhere)
        {

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TitleRecordBll titlerd = new TitleRecordBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titlerd.SelectBypage(tabuilder, out count);
        }
    }
}
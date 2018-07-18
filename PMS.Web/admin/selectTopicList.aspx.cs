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
        protected String searchcollege = "";
        protected String searchbatchAndcollege = "";
        protected string showstr = null;
        protected string showinput = null;
        protected string showbacthdrop = null;
        protected string showcollegedrop = null;

        //用户类型
        protected string userType = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request.Form["op"];
            string op1 = Context.Request.QueryString["op"];
            //下拉专业ID
            string dropstrWhere = Request.QueryString["dropstrWhere"];
            //下拉批次ID
            string batchWhere = Request.QueryString["batchWhere"];
            //下拉分院ID
            string collegeIdstWhere = Request.QueryString["collegeIdstrWhere"];
            //搜索信息
            string strsearch = Request.QueryString["search"];
            //获取登录者信息、判断是分院管理员还是超管
            userType = Session["state"].ToString();
            if (userType == "0")
            {
                //0为超级管理员
                bads = colbll.Select();
                prods = probll.Select();
                plands = planbll.Select();

                if (collegeIdstWhere != null && collegeIdstWhere != "null" && batchWhere == "null")
                {// 如果批次id为空，分院id不为空
                    getPage(Searchcollege());
                }
                else if (batchWhere != null && batchWhere != "null" && (collegeIdstWhere == "null" || collegeIdstWhere == "0"))
                {// 如果分院id为空，批次id不为空
                    getPage(batcchdrop());
                }
                else if (collegeIdstWhere != null && collegeIdstWhere != "null" && batchWhere != null && batchWhere != "null")
                {
                    //两个都不为空
                    getPage(SearchCollegeAndBatch());
                }
                else if (strsearch != null)
                {
                    getPage(Search());
                }
                else
                {
                    getPage("");
                }
            }
            else if (userType == "2")
            {
                //2为分院管理员
                //获取分管所在分院ID
                Teacher collegeAdmin = (Teacher)Session["user"];
                int collegeId = collegeAdmin.college.ColID;

                prods = probll.SelectByCollegeId(collegeId);
                plands = planbll.GetplanByCollegeId(collegeId);

                if (dropstrWhere != null && dropstrWhere != "null" && batchWhere == "null")
                {// 如果批次id为空，专业id不为空
                    getPage(Searchdrop());
                }
                else if (batchWhere != null && batchWhere != "null" && (dropstrWhere == "null" || dropstrWhere == "0"))
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
                else
                {
                    getPage("");
                }

            }
            else
            {
                prods = probll.Select();
                plands = planbll.Select();
                getPage("");
            }
            if (op == "del")
            {//删除
                IsdeleteCollege();
                delPro();
            }
            //导出列表
            if (op1 == "export")
            {
                string pro = Request.QueryString["dropstrWhere"];
                string batch = Request.QueryString["batchWhere"];
                string input = Request.QueryString["search"];
                string strWhere = "";
                if (input == null)
                {
                    if (pro == "null" && batch == "null")
                    {
                        strWhere = string.Format("");
                    }
                    else if (pro != "null" && batch == "null")
                    {
                        strWhere = string.Format(" where proId = {0}", "'" + pro + "'");
                    }
                    else if (pro == "null" && batch != "null")
                    {
                        strWhere = string.Format(" where planId = {0}", "'" + batch + "'");
                    }
                    else
                    {
                        strWhere = string.Format(" where planId = {0} and proId = {1}", "'" + batch + "'", "'" + pro + "'");
                    }
                }
                //如果不为空传 input里的值
                else
                {
                    strWhere = string.Format(" where teaName {0} or title {0} or realName {0} or planName {0} or proName {0} or collegeName {0}", "like '%" + input + "%'");
                }
                TitleRecordBll titlerd = new TitleRecordBll();
                var name = DateTime.Now.ToString("yyyyMMddhhmmss") + new Random(DateTime.Now.Second).Next(10000);
                DataTable dt = titlerd.ExportExcel(strWhere);
                if (dt != null && dt.Rows.Count > 0)
                {
                    var path = Server.MapPath("~/upload/选题记录导出/" + name + ".xls");
                    ExcelHelper.x2003.TableToExcelForXLS(dt, path);
                    downloadfile(path);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('查询不到数据，不能执行导出操作!')</script>");
                }
            }
        }
        /// <summary>
        /// //导出列表方法
        /// </summary>
        /// <param name="s_path">文件路径</param>

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

        /// <summary>
        /// 分院下拉查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
        public string Searchcollege()
        {
            try
            {
                searchcollege = Request.QueryString["collegeIdstrWhere"];
                if (searchcollege.Length == 0)
                {
                    searchcollege = "";
                }
                else if (searchcollege == null)
                {
                    searchcollege = "";
                }
                else if (searchcollege == "0")
                {
                    searchcollege = "";
                }
                else
                {
                    //专业下拉搜索后条件保存
                    showcollegedrop = searchcollege;
                    searchcollege = String.Format(" proId={0}", "'" + searchcollege + "'");
                }
            }
            catch
            {

            }
            return searchcollege;
        }

        /// <summary>
        /// 学院和批次一起查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
        public string SearchCollegeAndBatch()
        {
            try
            {
                //学院下拉的条件
                searchcollege = Request.QueryString["collegeIdstrWhere"];
                //学院条件传到前台
                showcollegedrop = searchcollege;
                //批次的条件
                search = Request.QueryString["batchWhere"];
                showbacthdrop = search;
                if (searchcollege == "0")
                {
                    searchcollege = "";
                    search = "";
                    searchbatchAndcollege = "";
                }
                else if (search == "0" && searchcollege != "0")
                {
                    search = "";
                    searchbatchAndcollege = String.Format(" proId={0} ", "'" + searchcollege + "'");
                    //searanddrop = String.Format(" proId={0} and planId={1}", "'" + searchdrop + "'", " '" + search + "'");
                }
                else
                {
                    searchbatchAndcollege = String.Format(" proId={0} and planId={1}", "'" + searchcollege + "'", " '" + search + "'");
                }
            }
            catch
            {

            }
            return searchbatchAndcollege;
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
        /// <summary>
        /// 专业和批次一起查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
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

        /// <summary>
        /// 专业下拉查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
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
        /// <summary>
        ///  //搜索
        /// </summary>
        /// <returns>返回查询字符串</returns>

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
        /// <summary>
        /// //判断是否能删除
        /// </summary>
        /// <returns>返回是否有关联的表</returns>

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

        /// <summary>
        /// 执行删除
        /// </summary>
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

        /// <summary>
        /// //获取数据
        /// </summary>
        /// <param name="strWhere">查询字符串</param>
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
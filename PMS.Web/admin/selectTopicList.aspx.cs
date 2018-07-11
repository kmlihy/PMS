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
            string type = Request.QueryString["type"];
            if (op == "del")
            {
                IsdeleteCollege();
                delPro();
            }
            if (type == "btn")
            {
                Search();
                getPage(Search());
            }
            else if (type == "drop")
            {
                Searchdrop();
                getPage(Searchdrop());
            }
            else if (type == "dropandbtn")
            {
                SearchBtnAndDrop();
                getPage(SearchBtnAndDrop());
            }
            else
            {
                getPage("");
            }

            bads = colbll.Select();
            prods = probll.Select();
            plands = planbll.Select();
            //专业下拉搜索后条件保存
            //if (searchdrop == null)
            //{
            //    showstr = "-请选择专业-";
            //}
            //else if (searchdrop != null && searchdrop.Length > 0)
            //{
            //    string sec = searchdrop.ToString();
            //    string[] secArray = sec.Split('=');
            //    if (secArray.Length > 1)
            //    {
            //        string str = secArray[0].ToString();
            //        showstr = str.Substring(0, str.Length);
            //    }
            //    else
            //    {
            //        string str = secArray[0].ToString();
            //        showstr = str;
            //    }
            //}
            //批次下拉搜索后条件保存
            if (searbatchdrop == null)
            {
                showbacthdrop = "-请选择批次-";
            }
            else if (searbatchdrop != null && searbatchdrop.Length > 0)
            {
                string sec = searbatchdrop.ToString();
                string[] secArray = sec.Split('=');
                if (secArray.Length > 1)
                {
                    string str = secArray[0].ToString();
                    showbacthdrop = str.Substring(0, str.Length);
                }
                else
                {
                    string str = secArray[0].ToString();
                    showbacthdrop = str;
                }
            }
            //查询按钮点击后查询条件保存
            if (search == null)
            {
                showinput = "请输入查询条件";
            }
            else if (search != null && search.Length > 1)
            {
                string sec = search.ToString();
                string[] secArray = sec.Split('%');
                if (secArray.Length > 0)
                {
                    string str = secArray[0].ToString();
                    showinput = str;
                }
                else
                {
                    string str = secArray[0].ToString();
                    showinput = str;
                }

            }
            else { }
        }
        //下拉加条件查询

        public string SearchBtnAndDrop()
        {
            try
            {
                //下拉的条件
                searchdrop = Request.QueryString["dropsearch"];
                //输入框的条件
                search = Request.QueryString["search"];
                searanddrop = String.Format(" proName={0} and teaName {1} or realName {1} or planName {1} or collegeName {1}", "'" + searchdrop + "'", "like '%" + search + "%'");
            }
            catch
            {

            }
            return searanddrop;
        }

        //下拉查询
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropsearch"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                    showstr = "0";
                }
                else if (searchdrop == null)
                {
                    showstr = "0";
                    searchdrop = "";
                }
                else
                {
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
                    search = String.Format(" teaName {0} or realName {0} or planName {0} or proName {0} or collegeName {0}", "like '%" + search + "%'");

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
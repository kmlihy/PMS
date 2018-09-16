using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMS.Web.admin
{
    public partial class adminViewScore : System.Web.UI.Page
    {
        public DataSet dsPlan, dsPro, ds;
        protected int count,pagesize = 5,getCurrentPage = 1;
        protected string search = "",strSearch = "", strWhere="";
        protected string proId="",planId="", order= "";
        Teacher teacher = new Teacher();
        PlanBll planBll = new PlanBll();
        ProfessionBll proBll = new ProfessionBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            int state = Convert.ToInt32(Session["state"]);
            if(state == 1)
            {
                teacher = (Teacher)Session["loginuser"];
            }
            else if(state == 2)
            {
                teacher = (Teacher)Session["user"];
            }
            dsPlan = planBll.getPlanByCid(teacher.college.ColID);
            dsPro = proBll.SelectByCollegeId(teacher.college.ColID);
            //展示数据
            string type = Request.QueryString["type"];
            order = Request.QueryString["order"];
            if (!IsPostBack)
            {
                if (order == "up")
                {
                    Search();
                    getdata(Search(), 0);
                }
                else
                {
                    Search();
                    getdata(Search(), 1);
                }
            }
            if (order == "down")
            {
                //批次下拉菜单
                if (type == "plandrop")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    if (planId == "0")
                    {
                        getdata("", 1);
                    }
                    string strWhere = string.Format(" planId = {0}", planId);
                    getdata(strWhere, 1);
                }
                //专业下拉菜单
                if (type == "prodrop")
                {
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    if (proId == "0")
                    {
                        getdata("", 1);
                    }
                    string strWhere = string.Format(" proId = {0}", proId);
                    getdata(strWhere, 1);
                }
                //所有下拉菜单
                if (type == "alldrop")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0} and planId = {1}", proId, planId);
                    getdata(strWhere, 1);
                }
            }else  if (order == "up")
            {
                //批次下拉菜单、升序
                if (type == "plandropUp")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    if (planId == "0")
                    {
                        getdata("", 0);
                    }
                    string strWhere = string.Format(" planId = {0}", planId);
                    getdata(strWhere, 0);
                }
                //专业下拉菜单、升序
                if (type == "prodropUp")
                {
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    if (proId == "0")
                    {
                        getdata("", 0);
                    }
                    string strWhere = string.Format(" proId = {0}", proId);
                    getdata(strWhere, 0);
                }
                //所有下拉菜单、升序
                if (type == "alldropUp")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0} and planId = {1}", proId, planId);
                    getdata(strWhere, 0);
                }
                //仅升序
                if (type == "up")
                {
                    getdata("", 0);
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        public void getdata(string strWhere,int order)
        {

            double guide=0.3, cross=0.2, defen=0.5;
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            string where;
            if (strWhere == "" || strWhere == null)
            {
                where = "collegeId =" + teacher.college.ColID;
            }
            else
            {
                where = "collegeId =" + teacher.college.ColID + " and " + strWhere;
            }
            //获取数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Score",
                StrColumn = "result",
                IntColType = 0,
                IntOrder = order,
                StrColumnlist = "(guideScore*"+guide+"+crossScore*"+cross+"+defenceScore*"+defen+") as result,realName,stuAccount,title,teaName",
                IntPageSize = pagesize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = where
            };
            getCurrentPage = int.Parse(currentPage);
            ds = proBll.SelectBypage(tbd, out count);
        }
        /// <summary>
        /// 查询筛选方法
        /// </summary>
        /// <returns>返回查询参数</returns>
        public string Search()
        {
            double guide = 0.3, cross = 0.2, defen = 0.5;
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                    strSearch = "";
                }
                else if (search == null)
                {
                    search = "";
                    strSearch = "";
                }
                else
                {
                    strSearch = search;
                    search = String.Format("stuAccount {0} or realName {0} or title {0} or teaName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
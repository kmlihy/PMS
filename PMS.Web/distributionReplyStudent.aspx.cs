using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class distributionReplyStudent : System.Web.UI.Page
    {
        public int getCurrentPage = 1, pagesize = 5, count;
        protected DataSet prods = null,colds = null,ds = null;
        protected string search = "",searchdrop = "",searchCollege = "",searchProAndCollege = "",showmsg = "";
        protected string showstr = null, showcollegedrop = "", userType = "";

        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();

        public void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
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
                prods = null;
                //prods = proBll.Select();
                if (collegeId == null || collegeId == "0" || collegeId == "null")
                {
                    //学院为空,专业为空
                    prods = null;
                    getdata("");
                }
                else
                {
                    prods = proBll.SelectByCollegeId(int.Parse(collegeId));
                    if(proId == "null" || proId == "0" || proId == null)
                    {
                        //学院不为空,专业为空
                        getdata(SearchByCollege());
                    }else if(proId != null && proId != "null" && proId != "0")
                    {
                        //两个都不为空
                        getdata(SearchProAndCollege());
                    }
                    else if(strsearch != null)
                    {
                        getdata(Search());
                    }
                }
            }
            else if (userType == "2")
            {
                Teacher tea = (Teacher)Session["user"];
                int usercollegeId = tea.college.ColID;
                colds = colBll.Select();
                prods = proBll.SelectByCollegeId(usercollegeId);
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
            catch
            {
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
        /// <summary>
        /// 学院、专业二级联动查询
        /// </summary>
        /// <returns></returns>
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
                    StrWhere = strWhere == null || strWhere == ""? "" : strWhere,
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
    }
}
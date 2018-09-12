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
        Teacher teacher = new Teacher();
        PlanBll planBll = new PlanBll();
        ProfessionBll proBll = new ProfessionBll();
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        public void getdata()
        {
            double guide=0.3, cross=0.2, defen=0.5;
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            //获取数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Score",
                StrColumn = "result",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "(guideScore*"+guide+"+crossScore*"+cross+"+defenScore*"+defen+") as result,realName,stuAccount,title,teaName",
                IntPageSize = pagesize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = strWhere
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
                    search = String.Format(" teaAccount {0} or teaName {0} or collegeName {0} or sex {0} or phone {0} or Email {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    using System.Text;
    using Result = Enums.OpResult;
    public partial class checkMediumQualityReport : System.Web.UI.Page
    {
        protected DataSet ds = null;
        protected Teacher teacher = null;
        protected string teaName = null;
        protected string teaAccount = null;
        protected string teaNnum = null;
        protected int count;
        protected int getCurrentPage = 1;
        protected int pagesize;
        protected String search = "";
        TeacherBll teaBll = new TeacherBll();
        TitleBll titleBll = new TitleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData(Search());
            }
        }
        /// <summary>
        /// 判断教师是否已经出题
        /// </summary>
        /// <returns></returns>
        //public Result isExitTeacher()
        //{
        //    teacher = (Teacher)Session["loginuser"];
        //    teaAccount = teacher.TeaAccount;
        //    Result row = Result.记录不存在;
        //    if(teaBll.IsDelete("T_Title","teaAccount",teaAccount) == Result.关联引用)
        //    {
        //        row = Result.关联引用;
        //    }
        //    return row;
        //}
        /// <summary>
        /// 获取数据并分页
        /// </summary>
        public void getData(String strWhere)
        {
            //teacher = (Teacher)Session["loginuser"];
            //teaAccount = teacher.TeaAccount;
            teaAccount = "10010";
            string str = "";
            if(strWhere == null || strWhere == "")
            {
                str = "teaAccount =" + "'" + teaAccount + "'";
            }
            else
            {
                str = "teaAccount =" + "'" + teaAccount + "'" + " and " + strWhere;
            }
            string currentPage = Context.Request.QueryString["currentPage"];
            pagesize = 3;
            if(currentPage == null || currentPage == "")
            {
                currentPage = "1";
            }
            TableBuilder tableBuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = str,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = titleBll.SelectBypage(tableBuilder, out count);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                if(search.Length == 0 || search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format("stuAccount {0} or realName {0} proName {0} ", "like '%" + search + "%'");
                }
            }
            catch { }
            return search;
        }
    }
}
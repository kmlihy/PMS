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
        TeacherBll teaBll = new TeacherBll();
        TitleBll titleBll = new TitleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();
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
        /// 获取数据
        /// </summary>
        public void getData()
        {
            string currentPage = Context.Request.QueryString["currentPage"];
            teaAccount = "10010";
            //teacher = (Teacher)Session["loginuser"]; 
            string countPage = Request.QueryString["currentPage"];
            string str = "teaAccount =" + "'" + teaAccount + "'";
            TableBuilder tableBuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = str,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = 1,
                IntPageSize = 2,
                StrColumn = "teaAccount",
                StrColumnlist = "*"
            };
            //getCurrentPage = int.Parse(countPage);
            ds = titleBll.SelectBypage(tableBuilder, out count);
        }
    }
}
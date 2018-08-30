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
        TeacherBll teaBll = new TeacherBll();
        TitleBll titleBll = new TitleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            myStudent();
        }
        /// <summary>
        /// 判断教师是否已经出题
        /// </summary>
        /// <returns></returns>
        public Result isExitTeacher()
        {
            teacher = (Teacher)Session["loginuser"];
            teaAccount = teacher.TeaAccount;
            Result row = Result.记录不存在;
            if(teaBll.IsDelete("T_Title","teaAccount",teaAccount) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        public void myStudent()
        {
            teacher = (Teacher)Session["loginuser"];
            teaAccount = teacher.TeaAccount;
            Result row = isExitTeacher();
            if(row == Result.记录不存在)
            {
                Response.Write("你还没有出题！");
            }
            else
            {
                TableBuilder tablBuilder = new TableBuilder()
                {
                    StrTable = "V_Title",
                    StrWhere = "",
                    IntColType = 0,
                    IntOrder = 0,
                    IntPageNum = 1,
                    IntPageSize = 10,
                    StrColumn = "titleId",
                    StrColumnlist = "*"
                };
                ds = titleBll.SelectBypage(tablBuilder, out count);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    teaNnum = ds.Tables[0].Rows[i]["teaAccout"].ToString();
                }
            }
        }
    }
}
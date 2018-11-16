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
    public partial class highQualityPaperList : CommonPage
    {
        TeacherBll teaBll = new TeacherBll();
        CollegeBll collBll = new CollegeBll();
        Teacher tea = new Teacher();
        College coll = new College();
        Result result;
        //获取数据
        protected DataSet ds = null, dsColl = null;
        protected int count;
        protected int pagesize = 5;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected String search = "";
        protected String strSearch = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        public void getdata(string strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            //判断身份是否是管理员
            string strTeaType = "";
            if (strWhere == null || strWhere == "")
            {
                strTeaType = "teaType=2";
            }
            else
            {
                strTeaType = "teaType=2 and ";
            }
            //获取数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Score",
                StrColumn = "score",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "*",
                IntPageSize = pagesize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = strTeaType + strWhere
            };
            getCurrentPage = int.Parse(currentPage);
            ds = teaBll.SelectBypage(tbd, out count);
            //获取学院所有信息
            dsColl = collBll.Select();
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
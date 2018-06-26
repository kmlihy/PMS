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
    public partial class selectTopicList : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //专业
        protected DataSet prods = null;
        protected ProfessionBll probll = new ProfessionBll();
        //学院
        protected DataSet bads = null;
        protected CollegeBll colbll = new CollegeBll();
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string test = Request["collegeselect"];
            //selectChange("select * from V_Profession");
            getData("", getCurrentPage);
            changepage();
            bads = colbll.Select();
            prods = probll.Select();
        }

        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="strWhere"> 查询条件</param>
        /// <param name="pageNum">当前加载页数</param>
        public void getData(string strWhere, int IntPageNum)
        {
            TableBuilder tabuilder = new TableBuilder("V_TitleRecord", "titleRecordId", 0, 0, "*", 2, IntPageNum, strWhere);
            ds = probll.SelectBypage(tabuilder, out count);
            count = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
        }
        public void changepage()
        {
            try
            {
                string currentPage = Request.QueryString["currentPage"];
                getCurrentPage = int.Parse(currentPage);
            }
            catch { }
            if (getCurrentPage < 1)
            {
                getCurrentPage = 1;
            }
            else if (getCurrentPage > count)
            {
                getCurrentPage = count;
            }
            ViewState["page"] = getCurrentPage;
        }
        /// <summary>
        /// 学院与专业的联动
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        ///
        public void selectChange(string strWhere)
        {
            TableBuilder tabuilder = new TableBuilder("V_Profession", "proId", 0, 0, "*", 2, 1, strWhere);
            ds = probll.SelectBypage(tabuilder, out count);
            count = count % pagesize == 0 ? count / pagesize : count / pagesize + 1;
        }
    }
}
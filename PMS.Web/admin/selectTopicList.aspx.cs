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
        protected void Page_Load(object sender, EventArgs e)
        {
            getPage("", 1);
            bads = colbll.Select();
            prods = probll.Select();
        }

        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="strWhere"> 查询条件</param>
        /// <param name="pageNum">当前加载页数</param>
        public void getPage(string strWhere, int pageNum)
        {
            TableBuilder tbuilder = new TableBuilder("V_TitleRecord", "titleRecordId", 0, 0, "*", 2, pageNum, strWhere);
            int pageCount;
            ds = probll.SelectBypage(tbuilder, out pageCount);
        }
    }
}
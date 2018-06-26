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
    public partial class proList : System.Web.UI.Page
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
            getPage("", 1);
            prods = probll.Select();
            changepage();
            getPage("", getCurrentPage);
            bads = colbll.Select();

        }
        /// <summary>
        /// 列表加载
        /// </summary>
        /// <param name="strWhere"> 查询条件</param>
        /// <param name="pageNum">当前加载页数</param>
        public void getPage(string strWhere,int pageNum)
        {
            TableBuilder tabuilder = new TableBuilder("V_Profession","proId",0,0,"*",1, pageNum, strWhere);
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
    }
}
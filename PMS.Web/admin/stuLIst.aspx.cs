﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;
using System.Data;

namespace PMS.Web.admin
{
    public partial class stuLIst : System.Web.UI.Page
    {
        protected DataSet prods = null;//专业
        protected DataSet colds = null;//院系

        //protected int count;//总页数
        //protected int pagesize = 1;//每页显示个数
        //protected int getCurrentPage = 1;//获取当前页
        //protected String search = "";

        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 2;
        protected String search = "";

        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();

        public void Page_Load(object sender, EventArgs e)
        {
            prods = proBll.Select();
            colds = colBll.Select();
            Search();
            getdata(Search());
        }
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            BLL.StudentBll sdao = new StudentBll();
            StudentBll pro = new StudentBll();
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Student",
                StrWhere = strWhere == null ? "" : strWhere,
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
                    search = String.Format(" stuAccount={0} or realName={0} or collegeName={0} or phone={0} or Email={0} ", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
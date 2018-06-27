﻿using PMS.BLL;
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
    public partial class branchList : System.Web.UI.Page
    {
        //获取数据
        CollegeBll collbll = new CollegeBll();
        protected DataSet ds = null;
        protected int count;
        protected int pageSize = 1;
        //分页
        protected int getCurrentPage = 1;
        //查询
        protected string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //首次获取数据
            getdata("", 1);
            //分页
            changepage();
            //根据分页条件获取数据
            getdata("", getCurrentPage);
        }
        //获取数据
        public void getdata(string strWhere,int pageNum)
        {
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "collegeId",
                IntColType = 0,
                IntOrder = 0,
                StrColumnlist = "*",
                IntPageSize = pageSize,
                IntPageNum = pageNum,
                StrWhere = strWhere
            };
            ds = collbll.SelectBypage(tbd,out count);
            count = count % pageSize == 0 ? count / pageSize : count / pageSize + 1;
        }
        //按条件查询
        public void query()
        {
        }
        //分页
        public void changepage()
        {
            try
            {
                string currentPage = Request.QueryString["currentPage"];
                getCurrentPage = int.Parse(currentPage);
            }
            catch { }
            if (getCurrentPage <= 1)
            {
                getCurrentPage = 1;
            }
            else if (getCurrentPage >= count)
            {
                getCurrentPage = count;
            }
            ViewState["page"] = getCurrentPage;
        }
        protected void insert()
        {
            string collName = Request.QueryString["collName"];
            College coll = new College();
            coll.ColName = collName;
            collbll.Insert(coll);
        }
    }
}
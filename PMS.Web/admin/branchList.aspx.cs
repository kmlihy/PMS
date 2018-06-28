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
    using Result = Enums.OpResult;

    public partial class branchList : System.Web.UI.Page
    {
        //获取数据
        protected DataSet ds = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        protected String search = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (op == "add")
            {
                saveCollege();
                Search();
                getdata(Search());                
            }
            if (!Page.IsPostBack)
            {
                Search();
                getdata(Search());
            }     
        }

        public void saveCollege()
        {
            string collegeName = Context.Request["collegeName"].ToString();
            College college = new College();
            college.ColName = collegeName;
            CollegeBll coll = new CollegeBll();
            Result result = coll.Insert(college);
            if (result == Result.添加成功)
            {
                Response.Write("添加成功");
                Response.End();
            }
            else
            {
                Response.Write("添加失败");
                Response.End();
            }
        }

        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            CollegeBll coll = new CollegeBll();
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "collegeId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = coll.SelectBypage(tbd, out count);
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
                    search = String.Format("collegeName={0}", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
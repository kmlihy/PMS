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
    public partial class titleReadList : CommonPage
    {
        protected DataSet ds = null, dsPro = null, dsPlan = null, dsColl = null;//储存标题表、专业、批次、分院信息
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 20;
        protected String search = "";
        protected String dropstrWhereplan = "";
        protected String dropstrWherepro = "", dropstrWhereColl="";
        protected string showstr = null;
        protected string showinput = null;
        protected string secSearch = "";
        protected string state = "";

        TeacherBll teabll = new TeacherBll();
        ProfessionBll probll = new ProfessionBll();
        PlanBll plabll = new PlanBll();

        protected CollegeBll colbll = new CollegeBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            state = Session["state"].ToString();
            if (!IsPostBack)
            {
                string op = Context.Request["op"];
                string type = Request.QueryString["type"];
                getdata(Search());
                //选择文本
                if (type == "textSelect" || type == null)
                {
                    getdata(Search());
                }
                //批次下拉菜单
                if (type == "plandrop")
                {
                    dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                    if (dropstrWhereplan == "0")
                    {
                        getdata("");
                    }
                    string strWhere = string.Format(" planId = {0}", dropstrWhereplan);
                    getdata(strWhere);
                }
                //专业下拉菜单
                if (type == "prodrop")
                {
                    dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0}", dropstrWherepro);
                    getdata(strWhere);
                }
                //分院下拉菜单
                if (type == "Colldrop")
                {
                    dropstrWhereColl = Context.Request.QueryString["dropstrWhereColl"].ToString();
                    Session["collegeId"] = dropstrWhereColl;
                    string strWhere = string.Format(" collegeId = {0}", dropstrWhereColl);
                    getdata(strWhere);
                }
                //分院、专业下拉菜单
                if(type == "collAndPro")
                {
                    dropstrWhereColl = Context.Request.QueryString["dropstrWhereColl"].ToString();
                    dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format("collegeId = {0} and proId = {1}", dropstrWhereColl, dropstrWherepro);
                    getdata(strWhere);
                }
                //分院、批次下拉框
                if(type == "collAndPlan")
                {
                    dropstrWhereColl = Context.Request.QueryString["dropstrWhereColl"].ToString();
                    dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                    string strWhere = string.Format("collegeId = {0} and planId = {1}", dropstrWhereColl, dropstrWhereplan);
                    getdata(strWhere);
                }
                //分管所有下拉菜单
                if (type == "alldrop")
                {
                    dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                    dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0} and planId = {1}", dropstrWherepro, dropstrWhereplan);
                    getdata(strWhere);
                }
                //超管所有下拉菜单
                if (type == "allDrop")
                {
                    dropstrWhereColl = Context.Request.QueryString["dropstrWhereColl"].ToString();
                    dropstrWhereplan = Context.Request.QueryString["dropstrWhereplan"].ToString();
                    dropstrWherepro = Context.Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format("collegeId = {0} and proId = {1} and planId = {2}", dropstrWhereColl, dropstrWherepro, dropstrWhereplan);
                    getdata(strWhere);
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        public void getdata(String strWhere)
        {
            string where="";
            Teacher teacher = new Teacher();
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            if (state == "0")
            {
                where = "";
                dsColl = colbll.Select();
                dsPro = probll.SelectByCollegeId(Convert.ToInt32(Session["collegeId"]));
                dsPlan = plabll.getPlanByCid(Convert.ToInt32(Session["collegeId"]));
            }
            else if (state == "1")
            {
                teacher = (Teacher)Session["loginuser"];
                where = "collegeId = '" + teacher.college.ColID + "'";
                dsPro = probll.SelectByCollegeId(teacher.college.ColID);
                dsPlan = plabll.getPlanByCid(teacher.college.ColID);
            }
            else if (state == "2")
            {
                teacher = (Teacher)Session["user"];
                where = "collegeId = '" + teacher.college.ColID + "'";
                dsPro = probll.SelectByCollegeId(teacher.college.ColID);
                dsPlan = plabll.getPlanByCid(teacher.college.ColID);
            }
            TitleBll titbll = new TitleBll();
            TableBuilder tabuilder = new TableBuilder();
            tabuilder.StrTable = "V_Title";
            tabuilder.StrWhere = (strWhere == null || strWhere=="" ? where : strWhere);
            tabuilder.IntColType = 0;
            tabuilder.IntOrder = 1;
            tabuilder.IntPageNum = int.Parse(currentPage);
            tabuilder.IntPageSize = pagesize;
            tabuilder.StrColumn = "titleId";
            tabuilder.StrColumnlist = "*";
            getCurrentPage = int.Parse(currentPage);
            ds = titbll.SelectBypage(tabuilder, out count);
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
                if (search.Length == 0)
                {
                    search = "";
                    secSearch = "";
                }
                else if (search == null || search == "null")
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    if (state == "0")
                    {
                        secSearch = search;
                        search = String.Format("titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                    }
                    else if (state == "1")
                    {
                        Teacher teacher = (Teacher)Session["loginuser"];
                        secSearch = search;
                        search = String.Format("collegeId = '"+ teacher.college.ColID + "' and titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                    }
                    else
                    {
                        Teacher teacher = (Teacher)Session["user"];
                        secSearch = search;
                        search = String.Format("collegeId = '" + teacher.college.ColID + "' and titleId {0} or title {0} or createTime {0} or selected {0} or limit {0} or proName {0} or planName {0} or teaName {0} ", "like '%" + search + "%'");
                    }
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
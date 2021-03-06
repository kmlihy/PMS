﻿using PMS.BLL;
using PMS.DBHelper;
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
    public partial class excellentList : CommonPage
    {

        public DataSet dsPlan, dsPro, ds;
        protected int count, pagesize = 20, getCurrentPage = 1, state;
        protected string search = "", strSearch = "", strWhere = "";
        protected string proId = "", planId = "", order = "";
        Teacher teacher = new Teacher();
        PlanBll planBll = new PlanBll();
        ProfessionBll proBll = new ProfessionBll();
        ScoreBll scoreBll = new ScoreBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request.QueryString["op"];
            //获取数据
            state = Convert.ToInt32(Session["state"]);
            if (state == 0)
            {
                dsPlan = planBll.Select();
                dsPro = proBll.Select();
                teacher = (Teacher)Session["user"];
            }
            else
            {
                if (state == 1)
                {
                    teacher = (Teacher)Session["loginuser"];
                }
                else if (state == 2)
                {
                    teacher = (Teacher)Session["user"];
                }
                dsPlan = planBll.getPlanByCid(teacher.college.ColID);
                dsPro = proBll.SelectByCollegeId(teacher.college.ColID);
            }
            //展示数据
            string type = Request.QueryString["type"];
            order = Request.QueryString["order"];
            if (!IsPostBack)
            {
                Search();
                getdata(Search());
            }
            //导出列表
            if (op == "export")
            {
                try
                {
                    //获取成绩占比
                    Score scoreRatio = scoreBll.getRatio();
                    double guide = scoreRatio.guideRatio,
                        cross = scoreRatio.crossRatio,
                        defen = scoreRatio.defenceRatio,
                        excellent = scoreRatio.excellent;
                    //分院id
                    int collegeId = teacher.college.ColID;
                    //专业id
                    string pro = Request.QueryString["dropstrWherepro"];
                    //批次Id
                    string batch = Request.QueryString["dropstrWhereplan"];
                    //输入框条件
                    string input = Request.QueryString["search"];
                    string strWhere = "(guideScore*" + guide + "+crossScore*" + cross + "+defenceScore*" + defen + ")>=" + excellent;

                    if (state == 2)
                    {
                        if (input == null)
                        {
                            if ((pro == null || pro == "0") && batch == null || pro == "0")
                            {
                                strWhere += string.Format(" where collegeId = {0}", collegeId);
                            }
                            else if (pro != null && batch == null)
                            {
                                strWhere += string.Format(" where proId = {0} and collegeId = {1}", "'" + pro + "'", collegeId);
                            }
                            else if ((pro == null || pro == "0") && batch != null)
                            {
                                strWhere += string.Format(" where planId = {0} and collegeId = {1}", "'" + batch + "'", collegeId);
                            }
                            else
                            {
                                strWhere += string.Format(" where planId = {0} and proId = {1} and collegeId = {2}", "'" + batch + "'", "'" + pro + "'", collegeId);
                            }
                        }
                        //如果不为空传 input里的值
                        else
                        {
                            strWhere += string.Format(" where (teaName {0} or title {0} or realName {0} or planName {0} or proName {0}) and collegeId = {1}", "like '%" + input + "%'", collegeId);
                        }
                    }
                    else if(state == 0)
                    {
                        if (input == null)
                        {
                            if (pro == null && batch == null)
                            {
                                strWhere += "";
                            }
                            else if (pro != null && batch == null)
                            {
                                strWhere += string.Format(" where proId = {0}", "'" + pro + "'");
                            }
                            else if ((pro == null || pro == "0") && batch != null)
                            {
                                strWhere += string.Format(" where planId = {0}", "'" + batch + "'");
                            }
                            else
                            {
                                strWhere += string.Format(" where planId = {0} and proId = {1}", "'" + batch + "'", "'" + pro + "'");
                            }
                        }
                        //如果不为空传 input里的值
                        else
                        {
                            strWhere += string.Format(" where (teaName {0} or title {0} or realName {0} or planName {0} or proName {0})", "like '%" + input + "%'");
                        }
                    }
                    else
                    {
                        if (input == null)
                        {
                            strWhere += string.Format(" where collegeId = {0}", collegeId);
                        }
                        //如果不为空传 input里的值
                        else
                        {
                            strWhere += string.Format(" where (teaName {0} or title {0} or realName {0} or planName {0} or proName {0}) and collegeId = {1}", "like '%" + input + "%'", collegeId);
                        }
                    }

                    var name = "优质论文" + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random(DateTime.Now.Second).Next(10000);
                    DataTable dt = scoreBll.ExportExcel(strWhere, scoreRatio);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var path = Server.MapPath("~/download/学生成绩导出/" + name + ".xls");
                        ExcelHelper.x2007.TableToExcelForXLSX(dt, path);
                        downloadfile(path);
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>alert('查询不到数据，不能执行导出操作!')</script>");
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }
            //批次下拉菜单
            if (type == "plandrop")
            {
                planId = Request.QueryString["dropstrWhereplan"].ToString();
                if (planId == "0")
                {
                    getdata("");
                }
                else
                {
                    string strWhere = string.Format(" planId = {0}", planId);
                    getdata(strWhere);
                }
            }
            //专业下拉菜单
            if (type == "prodrop")
            {
                proId = Request.QueryString["dropstrWherepro"].ToString();
                if (proId == "0")
                {
                    getdata("");
                }
                else
                {
                    string strWhere = string.Format(" proId = {0}", proId);
                    getdata(strWhere);
                }
            }
            //所有下拉菜单
            if (type == "alldrop")
            {
                planId = Request.QueryString["dropstrWhereplan"].ToString();
                proId = Request.QueryString["dropstrWherepro"].ToString();
                string strWhere = string.Format(" proId = {0} and planId = {1}", proId, planId);
                getdata(strWhere);
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        public void getdata(string strWhere)
        {
            Score scoreRatio = scoreBll.getRatio();
            double guide,cross,defen,excellent;
            if (scoreRatio==null)
            {
                guide = 0;
                cross = 0;
                defen = 0;
                excellent = 0;
            }
            else
            {
                guide = scoreRatio.guideRatio;
                cross = scoreRatio.crossRatio;
                defen = scoreRatio.defenceRatio;
                excellent = scoreRatio.excellent;
            }
            
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            string where= "(guideScore*" + guide + "+crossScore*" + cross + "+defenceScore*" + defen + ")>=" + excellent;
            if (state == 2)
            {
                if (strWhere == "" || strWhere == null)
                {
                    where += " and collegeId =" + teacher.college.ColID;
                }
                else
                {
                    where += " and collegeId =" + teacher.college.ColID + " and (" + strWhere + ")";
                }
            }
            else if(state == 0)
            {
                if (strWhere != "" && strWhere != null)
                {
                    where += " and (" + strWhere + ")";
                }
            }
            else
            {
                where += " and teaAccount = " + teacher.TeaAccount;
            }
            //获取数据
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "V_Score",
                StrColumn = "result",
                IntColType = 0,
                IntOrder = 1,
                StrColumnlist = "(guideScore*" + guide + "+crossScore*" + cross + "+defenceScore*" + defen + ") as result,realName,stuAccount,title,teaName,collegeName",
                IntPageSize = pagesize,
                IntPageNum = int.Parse(currentPage),
                StrWhere = where
            };
            getCurrentPage = int.Parse(currentPage);
            ds = proBll.SelectBypage(tbd, out count);
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
                if (search == null)
                {
                    search = "";
                    strSearch = "";
                }
                else if (search.Length == 0)
                {
                    search = "";
                    strSearch = "";
                }
                else
                {
                    strSearch = search;
                    search = String.Format("stuAccount {0} or realName {0} or title {0} or teaName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        /// <summary>
        /// //导出列表方法
        /// </summary>
        /// <param name="s_path">文件路径</param>
        public void downloadfile(string s_path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(s_path);
            HttpContext.Current.Response.ContentType = "application/ms-download";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Type", "application/octet-stream");
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(file.Name, System.Text.Encoding.UTF8));
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            HttpContext.Current.Response.WriteFile(file.FullName);
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.End();
        }
    }
}
using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PMS.DBHelper;

namespace PMS.Web.admin
{
    public partial class adminViewScore : CommonPage
    {
        public DataSet dsPlan, dsPro, ds;
        protected int count,pagesize = 5,getCurrentPage = 1,state;
        protected string search = "",strSearch = "", strWhere="";
        protected string proId="",planId="", order= "";
        Teacher teacher = new Teacher();
        PlanBll planBll = new PlanBll();
        ProfessionBll proBll = new ProfessionBll();
        ScoreBll scoreBll = new ScoreBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request.QueryString["op"];
            //获取数据
            state = Convert.ToInt32(Session["state"]);
            if(state == 1)
            {
                teacher = (Teacher)Session["loginuser"];
            }
            else if(state == 2)
            {
                teacher = (Teacher)Session["user"];
            }
            dsPlan = planBll.getPlanByCid(teacher.college.ColID);
            dsPro = proBll.SelectByCollegeId(teacher.college.ColID);
            //展示数据
            string type = Request.QueryString["type"];
            order = Request.QueryString["order"];
            if (!IsPostBack)
            {
                if (order == "up")
                {
                    Search();
                    getdata(Search(), 0);
                }
                else
                {
                    Search();
                    getdata(Search(), 1);
                }
            }
            //导出列表
            if (op == "export")
            {
                try
                {
                    //获取成绩占比
                    Score scoreRatio = scoreBll.getRatio();
                    double guide = scoreRatio.guideRatio, cross = scoreRatio.crossRatio, defen = scoreRatio.defenceRatio;
                    //分院id
                    int collegeId = teacher.college.ColID;
                    //专业id
                    string pro = Request.QueryString["dropstrWherepro"];
                    //批次Id
                    string batch = Request.QueryString["dropstrWhereplan"];
                    //输入框条件
                    string input = Request.QueryString["search"];
                    string strWhere = "";

                    if (state == 2)
                    {
                        if (input == null)
                        {
                            if ((pro == null || pro == "0") && batch == null || pro == "0")
                            {
                                strWhere = string.Format(" where collegeId = {0}", collegeId);
                            }
                            else if (pro != "null" && batch == "null")
                            {
                                strWhere = string.Format(" where proId = {0} and collegeId = {1}", "'" + pro + "'", collegeId);
                            }
                            else if ((pro == "null" || pro == "0") && batch != "null")
                            {
                                strWhere = string.Format(" where planId = {0} and collegeId = {1}", "'" + batch + "'", collegeId);
                            }
                            else
                            {
                                strWhere = string.Format(" where planId = {0} and proId = {1} and collegeId = {2}", "'" + batch + "'", "'" + pro + "'", collegeId);
                            }
                        }
                        //如果不为空传 input里的值
                        else
                        {
                            strWhere = string.Format(" where (teaName {0} or title {0} or realName {0} or planName {0} or proName {0}) and collegeId = {1}", "like '%" + input + "%'", collegeId);
                        }
                    }
                    else
                    {
                        if (input == null)
                        {
                            strWhere = string.Format(" where collegeId = {0}", collegeId);
                        }
                        //如果不为空传 input里的值
                        else
                        {
                            strWhere = string.Format(" where (teaName {0} or title {0} or realName {0} or planName {0} or proName {0}) and collegeId = {1}", "like '%" + input + "%'", collegeId);
                        }
                    }

                    var name = "学生成绩" + DateTime.Now.ToString("yyyyMMddhhmmss") + new Random(DateTime.Now.Second).Next(10000);
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
            if (order == "down")
            {
                //批次下拉菜单
                if (type == "plandrop")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    if (planId == "0")
                    {
                        getdata("", 1);
                    }
                    string strWhere = string.Format(" planId = {0}", planId);
                    getdata(strWhere, 1);
                }
                //专业下拉菜单
                if (type == "prodrop")
                {
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    if (proId == "0")
                    {
                        getdata("", 1);
                    }
                    string strWhere = string.Format(" proId = {0}", proId);
                    getdata(strWhere, 1);
                }
                //所有下拉菜单
                if (type == "alldrop")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0} and planId = {1}", proId, planId);
                    getdata(strWhere, 1);
                }
            }else  if (order == "up")
            {
                //批次下拉菜单、升序
                if (type == "plandropUp")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    if (planId == "0")
                    {
                        getdata("", 0);
                    }
                    string strWhere = string.Format(" planId = {0}", planId);
                    getdata(strWhere, 0);
                }
                //专业下拉菜单、升序
                if (type == "prodropUp")
                {
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    if (proId == "0")
                    {
                        getdata("", 0);
                    }
                    string strWhere = string.Format(" proId = {0}", proId);
                    getdata(strWhere, 0);
                }
                //所有下拉菜单、升序
                if (type == "alldropUp")
                {
                    planId = Request.QueryString["dropstrWhereplan"].ToString();
                    proId = Request.QueryString["dropstrWherepro"].ToString();
                    string strWhere = string.Format(" proId = {0} and planId = {1}", proId, planId);
                    getdata(strWhere, 0);
                }
                //仅升序
                if (type == "up")
                {
                    getdata("", 0);
                }
            }
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        public void getdata(string strWhere,int order)
        {
            Score scoreRatio = scoreBll.getRatio();
            if (scoreRatio != null)
            {
                double guide = scoreRatio.guideRatio, cross = scoreRatio.crossRatio, defen = scoreRatio.defenceRatio;
                string currentPage = Request.QueryString["currentPage"];
                if (currentPage == null || currentPage.Length <= 0)
                {
                    currentPage = "1";
                }
                string where;
                if (state == 2)
                {
                    if (strWhere == "" || strWhere == null)
                    {
                        where = "collegeId =" + teacher.college.ColID;
                    }
                    else
                    {
                        where = "collegeId =" + teacher.college.ColID + " and " + strWhere;
                    }
                }
                else
                {
                    where = "teaAccount = " + teacher.TeaAccount;
                }
                //获取数据
                TableBuilder tbd = new TableBuilder()
                {
                    StrTable = "V_Score",
                    StrColumn = "result",
                    IntColType = 0,
                    IntOrder = order,
                    StrColumnlist = "(guideScore*" + guide + "+crossScore*" + cross + "+defenceScore*" + defen + ") as result,realName,stuAccount,title,teaName",
                    IntPageSize = pagesize,
                    IntPageNum = int.Parse(currentPage),
                    StrWhere = where
                };
                getCurrentPage = int.Parse(currentPage);
                ds = proBll.SelectBypage(tbd, out count);
            }
        }
        /// <summary>
        /// 查询筛选方法
        /// </summary>
        /// <returns>返回查询参数</returns>
        public string Search()
        {
            double guide = 0.3, cross = 0.2, defen = 0.5;
            try
            {
                search = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                    strSearch = "";
                }
                else if (search == null)
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
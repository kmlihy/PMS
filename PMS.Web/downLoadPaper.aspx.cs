using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.Model;
using PMS.BLL;
using System.Data;
using PMS.DBHelper;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class downLoadPaper : System.Web.UI.Page
    {
        public DataSet ds;
        public Path path, paperPath;
        public string teaAccount, searchdrop, search, currentPage, secSearch,op,download;
        public int getCurrentPage = 1, pagesize=5, count, collegeId;
        Teacher tea = new Teacher();
        protected void Page_Load(object sender, EventArgs e)
        {
            tea = (Teacher)Session["loginuser"];
            TitleRecordBll trbll = new TitleRecordBll();
            PathBll pathBll = new PathBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            collegeId = teacher.college.ColID;
            string addop = Context.Request.Form["op"];
            string type = Request.QueryString["type"];
            op = Request["op"];
            try
            {
                if (op == "add")
                {
                    string stuAccount = Request["stuAccount"];
                    string opinion = Request["opinion"];
                    GuideRecordBll guideBll = new GuideRecordBll();
                    GuideRecord guide = new GuideRecord();
                    DataSet dsTR = trbll.GetByAccount(stuAccount);
                    int i = dsTR.Tables[0].Rows.Count - 1;
                    guide.opinion = opinion;
                    TitleRecord titleRecord = new TitleRecord();
                    titleRecord.TitleRecordId = Convert.ToInt32(dsTR.Tables[0].Rows[i]["titleRecordId"].ToString());
                    guide.titleRecord = titleRecord;
                    guide.dateTime = DateTime.Now;
                    path = pathBll.Select(titleRecord.TitleRecordId, stuAccount);
                    guide.path = path;
                    path.titleRecord = titleRecord;
                    path.state = 1;
                    path.type = 0;
                    Result result = pathBll.updateState(path);
                    if (result == Result.更新成功)
                    {
                        Result row = guideBll.Insert(guide);
                        if (row == Result.添加成功)
                        {
                            StudentBll studentBll = new StudentBll();
                            Student stu = studentBll.GetModel(stuAccount);
                            LogHelper.Info(this.GetType(), tea.TeaAccount + tea.TeaName + "-对-" + stuAccount + stu.RealName + "学生的指导记录");
                            Response.Write("提交成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("提交失败");
                            Response.End();
                        }
                    }
                    else
                    {
                        Response.Write("提交失败");
                        Response.End();
                    }
                }
                else if (op == "download")
                {
                    download = "download";
                    string account = Request["stuAccount"];
                    Path getTitleRecordId = pathBll.getTitleRecordId(account);
                    int titleRecordId = getTitleRecordId.titleRecord.TitleRecordId;
                    paperPath = pathBll.Select(titleRecordId, account);
                    //Response.Redirect(paperPath.paperPath);
                    Response.Write("<script>$('#loadHref').href = '" + paperPath.paperPath + "';</script>");
                    //Response.End();
                }
                if (!IsPostBack)
                {
                    Search();
                    getPage(Search());
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        //下拉框搜索
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["dropsearch"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                }
                else
                {
                    searchdrop = String.Format(" proId={0}", "'" + searchdrop + "'");

                }
            }
            catch
            {

            }
            return searchdrop;
        }

        //获取表格数据
        public void getPage(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }

            CrossBll crossBll = new CrossBll();
            teaAccount = tea.TeaAccount;
            string where1 = "teaAccount = " + teaAccount;
            string where2 = "teaAccount = " + teaAccount + " and " + strWhere;
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_TitleRecord",
                StrWhere = strWhere == null || strWhere == "" ? where1 : where2,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "titleRecordId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = crossBll.SelectBypage(tabuilder, out count);
        }

        //输入框搜索
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
                else if (search == null)
                {
                    search = "";
                    secSearch = "";
                }
                else
                {
                    secSearch = search;
                    search = String.Format("realName {0} or stuAccount {0} or title {0} ", "like '%" + search + "%'");
                }
            }
            catch
            {

            }
            return search;
        }
    }
}
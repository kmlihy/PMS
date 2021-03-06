﻿using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class distributionReplyStudent : CommonPage
    {
        public int getCurrentPage = 1, pagesize = 5, count;
        protected DataSet prods = null,colds = null,ds = null;
        protected string search = "",searchdrop = "",searchCollege = "",searchProAndCollege = "",showmsg = "";
        protected string showstr = null, showcollegedrop = "", userType = "";
        protected string leaderAccount,memberAccount,recordAccount;

        DefenceBll defenceBll = new DefenceBll();
        ProfessionBll proBll = new ProfessionBll();
        CollegeBll colBll = new CollegeBll();
        Result row = Result.添加失败;
        Teacher tea = new Teacher();
        public void Page_Load(object sender, EventArgs e)
        {
            tea = (Teacher)Session["user"];
            string op = Context.Request["op"];
            //下拉专业id
            string proId = Request.QueryString["proId"];
            //下拉学院id
            string collegeId = Request.QueryString["collegeId"];
            //输入框信息
            string strsearch = Request.QueryString["search"];
            try
            {
                userType = Session["state"].ToString();
                if (op == "add")
                {
                    addStudent();
                    if (row == Result.添加成功)
                    {
                        Response.Write("添加成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("添加成功");
                        Response.End();
                    }
                }
                if (!IsPostBack)
                {
                    string defenGroupId = Request.QueryString["defenGroupId"];
                    Session["defenGroupId"] = defenGroupId;
                }
                if (userType == "0")
                {
                    colds = colBll.Select();
                    prods = null;
                    //prods = proBll.Select();
                    if (collegeId == null || collegeId == "0" || collegeId == "null")
                    {
                        //学院为空,专业为空
                        prods = null;
                        getdata("");
                    }
                    else
                    {
                        prods = proBll.SelectByCollegeId(int.Parse(collegeId));
                        if (proId == "null" || proId == "0" || proId == null)
                        {
                            //学院不为空,专业为空
                            getdata(SearchByCollege());
                        }
                        else if (proId != null && proId != "null" && proId != "0")
                        {
                            //两个都不为空
                            getdata(SearchProAndCollege());
                        }
                        else if (strsearch != null)
                        {
                            getdata(Search());
                        }
                    }
                }
                else if (userType == "2")
                {
                    int usercollegeId = tea.college.ColID;
                    colds = colBll.Select();
                    prods = proBll.SelectByCollegeId(usercollegeId);
                    if (strsearch != null)
                    {
                        getdata(Search());
                    }
                    else if (proId != null && proId != "null")
                    {
                        getdata(Searchdrop());
                    }
                    else
                    {
                        getdata("");
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        /// <summary>
        /// 查询方法
        /// </summary>
        /// <returns></returns>
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
                    showmsg = search;
                    search = String.Format("stuAccount {0} or sex {0} or realName {0} or collegeName {0} or phone {0} or Email {0} or proName {0} ", "like " + "'%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }

        /// <summary>
        /// 专业下拉查询
        /// </summary>
        /// <returns>返回查询字符串</returns>
        public string Searchdrop()
        {
            try
            {
                searchdrop = Request.QueryString["proId"];
                if (searchdrop.Length == 0)
                {
                    searchdrop = "";
                }
                else if (searchdrop == null)
                {
                    searchdrop = "";
                }
                else if (searchdrop == "0")
                {
                    searchdrop = "";
                }
                else
                {
                    //下拉框保留查询条件
                    showstr = searchdrop;
                    searchdrop = String.Format("proId={0} ", "'" + searchdrop + "'");
                }
            }
            catch
            {
            }
            return searchdrop;
        }

        /// <summary>
        /// 学院下拉查询
        /// </summary>
        /// <returns></returns>
        public string SearchByCollege()
        {

            try
            {
                searchCollege = Request.QueryString["collegeId"];
                if (searchCollege.Length == 0)
                {
                    searchCollege = "";
                }
                else if (searchCollege == null)
                {
                    searchCollege = "";
                }
                else if (searchCollege == "0")
                {
                    searchCollege = "";
                }
                else
                {
                    //分院下拉搜索后条件保存
                    showcollegedrop = searchCollege;
                    searchCollege = String.Format(" collegeId={0}", searchCollege);
                }
            }
            catch
            {

            }
            return searchCollege;
        }

        /// <summary>
        /// 学院、专业二级联动查询
        /// </summary>
        /// <returns></returns>
        public string SearchProAndCollege()
        {
            try
            {
                //学院下拉的条件
                searchCollege = Request.QueryString["collegeId"];
                //学院条件传到前台
                showcollegedrop = searchCollege;
                //批次的条件

                searchdrop = Request.QueryString["proId"];
                showstr = searchdrop;
                if (searchCollege == "0")
                {
                    searchCollege = "";
                    searchdrop = "";
                    searchProAndCollege = "";
                }
                else if (search == "0" && searchCollege != "0")
                {
                    searchdrop = "";
                    searchProAndCollege = String.Format(" collegeId={0} ", "'" + searchCollege + "'");
                }
                else
                {
                    searchProAndCollege = String.Format(" collegeId={0} and proId={1}", "'" + searchCollege + "'", " '" + searchdrop + "'");
                }
            }
            catch
            {

            }
            return searchProAndCollege;
        }

        /// <summary>
        /// 实现分页
        /// </summary>
        /// <param name="strWhere">搜索条件</param>
        /// 
        public void getdata(String strWhere)
        {
            DefenceGroup defenceGroup = defenceBll.SelectGroup(Convert.ToInt32(Session["defenGroupId"]));
            if (defenceGroup != null)
            {
                leaderAccount = defenceGroup.leader;
                memberAccount = defenceGroup.member;
                recordAccount = defenceGroup.recorder;
                string currentPage = Request.QueryString["currentPage"];
                if (currentPage == null || currentPage.Length <= 0)
                {
                    currentPage = "1";
                }
                string userType = Session["state"].ToString();
                string userCollege = "";
                //usertype=2 为分院管理员登录
                if (userType == "2")
                {
                    int userCollegeId = tea.college.ColID;
                    if (strWhere == null || strWhere == "")
                    {
                        userCollege = @"collegeId = "+ userCollegeId + " and teaAccount not like "+leaderAccount+ " and teaAccount not like "+memberAccount+ " and teaAccount not like "+recordAccount
                            + " and crossTea not like "+leaderAccount+ " and crossTea not like "+memberAccount+ " and crossTea not like "+recordAccount+" and state=0";
                    }
                    else
                    {
                        userCollege = @"collegeId = " + userCollegeId + " and teaAccount not like " + leaderAccount + " and teaAccount not like " + memberAccount + " and teaAccount not like " + recordAccount
                            + " and crossTea not like " + leaderAccount + " and crossTea not like " + memberAccount + " and crossTea not like " + recordAccount + " and state=0 and "+strWhere;
                    }
                    StudentBll pro = new StudentBll();
                    TableBuilder tabuilder = new TableBuilder()
                    {
                        StrTable = "V_DefenAndStudent",
                        StrWhere = userCollege,
                        IntColType = 0,
                        IntOrder = 0,
                        IntPageNum = int.Parse(currentPage),
                        IntPageSize = pagesize,
                        StrColumn = "titleRecordId",
                        StrColumnlist = "titleRecordId,collegeName,proName,stuAccount,realName"
                    };
                    getCurrentPage = int.Parse(currentPage);
                    ds = pro.SelectBypage(tabuilder, out count);
                }
            }
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <returns></returns>
        public Result addStudent()
        {
            string stuAccount = Request["stuAccount"];
            string[] stuList = stuAccount.Split('?');
            for (int i = 0; i < stuList.Length-1; i++)
            {
                TitleRecordBll titleBll = new TitleRecordBll();
                TitleRecord titleRecord = titleBll.getRtId(stuList[i]);
                int titleRecordId = titleRecord.TitleRecordId;
                DefenceBll defenceBll = new DefenceBll();
                DefenceRecord defence = new DefenceRecord();
                defence.titleRecord = titleRecord;
                DefenceGroup defenceGroup = new DefenceGroup();
                int defenId = Convert.ToInt32(Session["defenGroupId"]);
                defenceGroup.defenGroupId = defenId;
                defence.defenceGroup = defenceGroup;
                row = defenceBll.InsertStudent(defence);
                StudentBll stuBll = new StudentBll();
                Student student = stuBll.GetModel(stuList[i]);
                string stu = stuList[i];
                student.state = 1;
                Result result = stuBll.Updata(student);
                if(row !=Result.添加成功 || result != Result.更新成功)
                {
                    Response.Write("添加失败");
                    Response.End();
                    break;
                }
                else
                {
                    LogHelper.Info(this.GetType(), tea.TeaAccount + " - " + tea.TeaName + " - 添加" + defenId + "答辩小组学生 - " + student.StuAccount + " - " + student.RealName);
                }
            }
            return row;
        }
    }
}
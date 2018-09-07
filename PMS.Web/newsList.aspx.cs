using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    public partial class newsList : CommonPage
    {
        protected DataSet dsSadmin = null;
        protected DataSet dsAdmin = null;
        protected DataSet dsTea = null;
        protected DataSet ds;
        int intPageCount;
        protected String userType = "";

        protected string state;//获取登录者
        protected Teacher admin;//获取管理员实体
        protected Teacher teacher;//获取教师实体
        protected Student stu;//获取学生实体
        protected int colId;//获取学院ID
        protected string teaId;//获取教师ID
        protected College col;//获取学院实体
        protected TitleRecord titleRecord;//获取选题记录实体
        protected string stuAccount;//定义学号
        protected int titleId;//定义题目编号
        protected Student stuTitleRecord;//选题学生
        protected Title title;//题目实体
        //protected Teacher titleTeacher;
        NewsBll bll = new NewsBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            //根据登录者判断加载公告
            loadNewsList();
            //查询超级管理员管理员的公告信息
            schoolNews();
            //查询管理员的公告信息
            collegeNews();
            //查询教师的公告信息
            teacherNews();
        }
        /// <summary>
        /// 查询超级管理员管理员的公告信息
        /// </summary>
        public void schoolNews()
        {
            TableBuilder tableBuilder = new TableBuilder();
            tableBuilder.StrTable = "V_News";
            tableBuilder.StrColumn = "createTime";
            tableBuilder.IntColType = 2;
            tableBuilder.IntOrder = 1;
            tableBuilder.StrColumnlist = "*";
            tableBuilder.IntPageSize = 5;
            tableBuilder.IntPageNum = 1;
            tableBuilder.StrWhere = "teaType = 0";
            dsSadmin = bll.SelectBypage(tableBuilder, out intPageCount);
        }

        /// <summary>
        /// 查询管理员的公告信息
        /// </summary>
        public void collegeNews()
        {
            TableBuilder tableBuilder1 = new TableBuilder();
            tableBuilder1.StrTable = "V_News";
            tableBuilder1.StrColumn = "createTime";
            tableBuilder1.IntColType = 2;
            tableBuilder1.IntOrder = 1;
            tableBuilder1.StrColumnlist = "*";
            tableBuilder1.IntPageSize = 5;
            tableBuilder1.IntPageNum = 1;
            tableBuilder1.StrWhere = "teaType = 2 and collegeId=" + colId;
            dsAdmin = bll.SelectBypage(tableBuilder1, out intPageCount);
        }

        /// <summary>
        /// 查询教师的公告信息
        /// </summary>
        public void teacherNews()
        {
            TableBuilder tableBuilder2 = new TableBuilder();
            tableBuilder2.StrTable = "V_News";
            tableBuilder2.StrColumn = "createTime";
            tableBuilder2.IntColType = 2;
            tableBuilder2.IntOrder = 1;
            tableBuilder2.StrColumnlist = "*";
            tableBuilder2.IntPageSize = 5;
            tableBuilder2.IntPageNum = 1;
            tableBuilder2.StrWhere = "teaType = 1 and teaAccount='" + teaId + "'";
            dsTea = bll.SelectBypage(tableBuilder2, out intPageCount);
        }

        /// <summary>
        /// 根据登录者判断加载公告
        /// </summary>
        public void loadNewsList()
        {
            state = Session["state"].ToString();
            if (state == "0" || state == "2")//根据登录的管理员只显示相关公告
            {
                admin = (Teacher)Session["user"];
                colId = admin.college.ColID;
                teaId = admin.TeaAccount;
            }
            else if(state == "1")//根据登录的教师只显示相关公告
            {
                teacher = (Teacher)Session["loginuser"];
                colId = teacher.college.ColID;
                teaId = teacher.TeaAccount;
            }
            else//根据登录的学生只显示相关公告
            {
                stu = (Student)Session["loginuser"];
                col = stu.college;
                colId = col.ColID;
                stuAccount = stu.StuAccount;
                TitleRecordBll recordBll = new TitleRecordBll();
                ds = recordBll.Select();
                if (ds!=null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (stuAccount == ds.Tables[0].Rows[i]["stuAccount"].ToString())
                        {
                            TitleBll titleBll = new TitleBll();
                            titleId = int.Parse(ds.Tables[0].Rows[i]["titleId"].ToString());
                            title = titleBll.GetTitle(titleId);
                            teaId = title.teacher.TeaAccount;
                        }
                    }
                }
            }
        }
    }
}
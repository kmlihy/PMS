using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PMS.BLL.Enums;

namespace PMS.Web.admin
{
    public partial class proList : System.Web.UI.Page
    {
        //列表
        protected DataSet ds = null;
        //专业
        protected ProfessionBll probll2 = new ProfessionBll();
        //分院
        protected DataSet colds = null;
        protected CollegeBll colbll = new CollegeBll();
        //当前页数
        protected int getCurrentPage = 1;
        //总页
        protected int count;
        //每页的行数
        protected int pagesize = 3;
        //查询条件
        public String search = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            string op = Context.Request.Form["op"];
            if (op == "add")
            {
                saveProfession();
                Search();
                getPage(Search());
            }
            if (op == "change")
            {
                saveChange();
                Search();
                getPage(Search());
            }
            if (!IsPostBack)
            {
                getPage(search);
                colds = colbll.Select();
            }
        }
        //添加专业
        public void saveProfession()
        {
            College college = new College();
            string proName = Context.Request["proName"].ToString();
            int collegeId = Convert.ToInt32(Context.Request["collegeId"]);
            Profession pro = new Profession();
            college.ColID = collegeId;
            pro.college = college;
            pro.ProName = proName;
            ProfessionBll probll = new ProfessionBll();
            OpResult result = probll.Insert(pro);
            if (result == OpResult.添加成功)
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
        //修改
        public void saveChange() {
            College college = new College();
            string proName = Context.Request["proName"].ToString();
            int proId = Convert.ToInt32(Context.Request["ProId"]);
            int collegeId = Convert.ToInt32(Context.Request["collegeId"]);
            Profession pro = new Profession();
            college.ColID = collegeId;
            pro.college = college;
            pro.ProId = proId;
            pro.ProName = proName;
            ProfessionBll probll = new ProfessionBll();
            OpResult result = probll.Update(pro);
            if (result == OpResult.更新成功)
            {
                Response.Write("修改成功");
                Response.End();
            }
            else
            {
                Response.Write("修改失败");
                Response.End();
            }
        }
        //列表
        public void getPage(String strWhere)
        {

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Profession",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "proId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = probll2.SelectBypage(tabuilder, out count);
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
                    search = String.Format(" proName={0} or collegeName={0} ", "'" + search + "'");
                }
            }
            catch
            {
            }
            return search;
        }
    }
}
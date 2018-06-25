using PMS.BLL;
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
        int count = 1;
        protected string where ="";
        protected int pageNum = 1;
        protected int pageSize = 5;
        protected DataSet ds = null;
        CollegeBll collbll = new CollegeBll();
        //分页
        protected string getName = "";
        protected int getCurrentPage = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据
            getdata(where, pageNum, pageSize);
            //分页
            string name = Request["name"];
            string currentPage = Request["currentPage"];
            string op = Request["op"];
            if (op == "1")
            {
                getCurrentPage = int.Parse(currentPage) - 1;
                System.Diagnostics.Debug.WriteLine("op1当前页为：" + getCurrentPage);
            }
            else if (op == "2")
            {
                getCurrentPage = int.Parse(currentPage) + 1;
                System.Diagnostics.Debug.WriteLine("op2当前页为：" + getCurrentPage);
            }
            else
            {
                //getCurrentPage = int.Parse(currentPage);
            }
        }
        //获取数据
        public void getdata(string strWhere,int pageNum, int pageSize)
        {
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrColumn = "collegeId",
                IntColType = 1,
                IntOrder = 0,
                StrColumnlist = "collegeName",
                IntPageSize = pageSize,
                IntPageNum = pageNum,
                StrWhere = strWhere
            };
            ds = collbll.SelectBypage(tbd,out count);
        }
    }
}
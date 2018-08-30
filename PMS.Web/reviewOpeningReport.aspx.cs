using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class reviewOpeningReport : CommonPage
    {
        public string stuAccount, stuName, proName, title, teaName;
        public OpenReport or;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            Teacher teacher = (Teacher)Session["loginuser"];
            string teaAccount = teacher.TeaAccount;
            DataSet ds = trbll.GetByAccount(teaAccount);
            int titleRecordId = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string stuaccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                if (stuaccount == "15612200017")
                {
                    stuAccount = stuaccount;
                    stuName = ds.Tables[0].Rows[i]["realName"].ToString();
                    proName = ds.Tables[0].Rows[i]["proName"].ToString();
                    title = ds.Tables[0].Rows[i]["title"].ToString();
                    titleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                    break;
                }
            }
            teaName = teacher.TeaName;
            OpenReportBll orbll = new OpenReportBll();
            or = orbll.Select(titleRecordId);
            string op = Request["op"];
            if(op == "review")
            {
                string teacherOpinion = Request["teacherOpinion"];
                Result row = orbll.teaInsert(titleRecordId, teacherOpinion);
                if(row == Result.添加成功)
                {
                    Response.Write("提交成功");
                    Response.End();
                }
                else
                {
                    Response.Write("提交失败");
                    Response.End();
                }
            }
        }
    }
}
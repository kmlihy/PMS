﻿using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class openingReport : CommonPage
    {
        public string stuAccount, stuName, profession, title, teaName;
        public int state, planId, titleRecordId;
        OpenReportBll orbll = new OpenReportBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            Student student = (Student)Session["loginuser"];
            stuAccount = student.StuAccount;
            stuName = student.RealName;
            profession = student.profession.ProName;
            DataSet dsTR = trbll.GetByAccount(stuAccount);

            OpenReport openReport = trbll.getState(titleRecordId);
            state = openReport.state;

            if (dsTR==null)
            {
                state = 0;
            }
            else
            {
                for (int i = 0; i < dsTR.Tables[0].Rows.Count; i++)
                {
                    string stuaccount = dsTR.Tables[0].Rows[i]["stuAccount"].ToString();
                    if (stuaccount == stuAccount)
                    {
                        title = dsTR.Tables[0].Rows[0]["title"].ToString();
                        teaName = dsTR.Tables[0].Rows[0]["teaName"].ToString();
                        planId = Convert.ToInt32(dsTR.Tables[0].Rows[0]["planId"].ToString());
                        titleRecordId = Convert.ToInt32(dsTR.Tables[0].Rows[0]["titleRecordId"].ToString());
                        break;
                    }
                }
            }
            
            Result result = orbll.isOpenReport(stuAccount, planId);
            if (result==Result.记录存在)
            {
                state = 1;
                insert();
            }
            else
            {
                state = 0;
            }
        }
        private void insert()
        {
            string op = Context.Request["op"];
            if (op == "add")
            {
                string meaning = Request["meaning"];
                string trend = Request["trend"];
                string content = Request["content"];
                string plan = Request["plan"];
                string method = Request["method"];
                string outline = Request["outline"];
                string reference = Request["reference"];
                OpenReport open = new OpenReport();
                TitleRecord titleRecord = new TitleRecord();
                titleRecord.TitleRecordId = titleRecordId;
                open.titleRecord = titleRecord;
                open.meaning = meaning;
                open.trend = trend;
                open.content = content;
                open.plan = plan;
                open.method = method;
                open.outline = outline;
                open.reference = reference;
                open.reportTime = DateTime.Now;
                Result row = orbll.stuInsert(open);
                open.state = 2;
                Result result = orbll.updateState(open);
                if (row == Result.添加成功 && result==Result.更新成功)
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
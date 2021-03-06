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

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class mediiumQuality : CommonPage
    {
        public string stuAccount, stuName, proName, collegeName, title, teaName;
        public string planFinishSituation,teacherOpinion;
        public int state,mstate;
        public string content;
        public MedtermQuality mq = new MedtermQuality();
        PathBll pathBll = new PathBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            MedtermQualityBll mqbll = new MedtermQualityBll();
            MedtermQuality medterm = new MedtermQuality();
            state =Convert.ToInt32(Session["state"].ToString());
            int titleRecordId = 0;
            string op = Request["op"];
            if (!IsPostBack)
            {
                string stuAccount = Request.QueryString["stuAccount"];
                if (stuAccount != null)
                {
                    Session["stuAccount"] = stuAccount;
                }
                else
                {
                    if (state == 3)
                    {
                        Student student = (Student)Session["loginuser"];
                        stuAccount = student.StuAccount;
                    }
                    else
                    {
                        stuAccount = Session["stuAccount"].ToString();
                    }
                }
            }
            if (state == 1)
            {
                Teacher teacher = (Teacher)Session["loginuser"];
                string teaAccount = teacher.TeaAccount;
                string acount = Session["stuAccount"].ToString();
                TitleRecord titleRecord = trbll.getRtIdByTea(acount,teaAccount);
                TitleRecord stuTitle = trbll.GetTitleRecord(titleRecord.TitleRecordId);
                mq = mqbll.Select(titleRecord.TitleRecordId);
                if (mq == null)
                {
                    content = "学生未提交中期质量检查";
                }
                else
                {
                    planFinishSituation = mq.planFinishSituation;
                    stuAccount = acount;
                    stuName = stuTitle.student.RealName;
                    proName = stuTitle.profession.ProName;
                    title = stuTitle.title.title;
                    collegeName = teacher.college.ColName;
                    teaName = teacher.TeaName;
                    MedtermQuality medtermQuality = mqbll.getState(titleRecord.TitleRecordId);
                    mstate = medtermQuality.state;
                    if (mstate == 3)
                    {
                        teacherOpinion = mq.teacherOpinion;
                    }
                }
                if (op == "teacher")
                {
                    try
                    {
                        string opinion = Request["teacher"];
                        medterm.teacherOpinion = opinion;
                        medterm.dateTime = DateTime.Now;
                        medterm.titleRecord = titleRecord;
                        medterm.state = 3;
                        Result row = mqbll.teaInsert(medterm);
                        if (row == Result.添加成功)
                        {
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 教师提交 - " + stuTitle.student.StuAccount + " - " + stuTitle.student.RealName + " - 学生的中期质量报告意见");
                            Response.Write("提交成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("提交失败");
                            Response.End();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Error(this.GetType(), ex);
                    }
                }
            }
            else if(state == 3)
            {
                try
                {
                    Student student = (Student)Session["loginuser"];
                    stuAccount = student.StuAccount;
                    stuName = student.RealName;
                    proName = student.profession.ProName;
                    collegeName = student.college.ColName;
                    DataSet ds = trbll.GetByAccount(stuAccount);
                    TitleRecordBll titleRecordBll = new TitleRecordBll();
                    TitleRecord titleRecord = titleRecordBll.getRtId(stuAccount);
                    int rtId = titleRecord.TitleRecordId;
                    Result result = pathBll.selectByTitleRecordId(rtId.ToString());
                    if (ds == null)
                    {
                        content = "暂未选题";
                    }
                    else
                    {
                        if (result == Result.记录存在)
                        {
                            mq = mqbll.Select(titleRecord.TitleRecordId);
                            if (mq != null)
                            {
                                planFinishSituation = mq.planFinishSituation;
                            }
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                string stuaccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                                if (stuaccount == stuAccount)
                                {
                                    title = ds.Tables[0].Rows[0]["title"].ToString();
                                    teaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                                    titleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                                    break;
                                }
                            }
                            MedtermQuality medtermQuality = mqbll.getState(titleRecordId);
                            mstate = medtermQuality.state;
                            if (mstate == 3)
                            {
                                teacherOpinion = mq.teacherOpinion;
                            }

                        }
                        else
                        {
                            content = "暂未提交论文";
                        }
                    }
                    if (op == "student")
                    {
                        string plan = Request["student"];
                        medterm.planFinishSituation = plan;
                        medterm.dateTime = DateTime.Now;
                        titleRecord.TitleRecordId = titleRecordId;
                        medterm.titleRecord = titleRecord;
                        medterm.state = 2;
                        Result row = mqbll.stuInsert(medterm);
                        if (row == Result.添加成功)
                        {
                            LogHelper.Info(this.GetType(), student.StuAccount + " - " + student.RealName + " - 学生提交中期质量报告");
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
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }
        }
    }
}
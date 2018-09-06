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
    public partial class mediiumQuality : CommonPage
    {
        public string stuAccount, stuName, proName, collegeName, title, teaName;
        public int state;
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
            if (state == 1)
            {
                Teacher teacher = (Teacher)Session["loginuser"];
                string teaAccount = teacher.TeaAccount;
                DataSet ds = trbll.GetByAccount(teaAccount);
                if (ds==null)
                {
                    content = "学生未提交中期质量检查";
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string stuaccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                        if (stuaccount == "15612200017")
                        {
                            stuAccount = stuaccount;
                            stuName = ds.Tables[0].Rows[i]["realName"].ToString();
                            proName = ds.Tables[0].Rows[i]["proName"].ToString();
                            title = ds.Tables[0].Rows[i]["title"].ToString();
                            break;
                        }
                    }
                    collegeName = teacher.college.ColName;
                    teaName = teacher.TeaName;
                }
            }
            else if(state == 3)
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
                if (result==Result.记录存在)
                {
                    if (ds == null)
                    {
                        content = "暂未选题";
                    }
                    else
                    {
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
                    }
                }
                else
                {
                    content = "暂未选题";
                }
                
            }
            string op = Request["op"];
            if(op == "student")
            {
                string plan = Request["student"];
                medterm.planFinishSituation = plan;
                medterm.dateTime = DateTime.Now;
                medterm.titleRecord.TitleRecordId = titleRecordId;
                Result row = mqbll.stuInsert(medterm);
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
            else if(op == "teacher")
            {
                string opinion = Request["teacher"];
                medterm.teacherOpinion = opinion;
                medterm.dateTime = DateTime.Now;
                medterm.titleRecord.TitleRecordId = titleRecordId;
                Result row = mqbll.teaInsert(medterm);
                if (row == Result.添加成功)
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
            mq = mqbll.Select(titleRecordId);
        }
    }
}
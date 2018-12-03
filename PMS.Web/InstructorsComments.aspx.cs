using PMS.BLL;
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
    public partial class InstructorsComments : CommonPage
    {
        public DataSet getData, dsTitle;
        TitleRecordBll titlebll = new TitleRecordBll();
        TitleBll titleBll = new TitleBll();
        Score scoreModel = new Score();
        ScoreBll sbll = new ScoreBll();
        PathBll pathBll = new PathBll();
        string stuAccount;
        public int planId, titleRecordId,checkState,midState,paperState;
        Teacher teacher = new Teacher();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stuAccount = Request.QueryString["stuAccount"];
                titleRecordId = Convert.ToInt32(Request.QueryString["titleRecordId"]);
                if (stuAccount != null)
                {
                    Session["stuAccount"] = stuAccount;
                    Session["titleRecordId"] = titleRecordId;
                }
                else
                {
                    stuAccount = Session["stuAccount"].ToString();
                    titleRecordId = Convert.ToInt32(Session["titleRecordId"].ToString());
                }
            }
            //获取查重报告状态
            Path path = pathBll.getState(titleRecordId,1);
            if (path == null)
            {
                checkState = 0;
            }
            else
            {
                checkState = path.state;
            }
            //获取中期质量报告状态
            MedtermQualityBll qualityBll = new MedtermQualityBll();
            MedtermQuality medterm = qualityBll.getState(titleRecordId);
            if (medterm == null)
            {
                midState = 0;
            }
            else
            {
                midState = medterm.state;
            }
            //获取论文完成状态
            Path pathPaper = pathBll.getState(titleRecordId, 0);
            if (pathPaper == null)
            {
                paperState = 0;
            }
            else
            {
                paperState = pathPaper.state;
            }
            getData = titlebll.GetByAccount(stuAccount);
            int i = getData.Tables[0].Rows.Count - 1;
            planId = Convert.ToInt32(getData.Tables[0].Rows[i]["planId"]);
            int proId = Convert.ToInt32(getData.Tables[0].Rows[i]["proId"]);
            teacher = (Teacher)Session["loginuser"];
            TeacherBll teaBll = new TeacherBll();
            int a = teacher.college.ColID;
            dsTitle = teaBll.getByColl(teacher.college.ColID,teacher.TeaAccount);
            string op = Request["op"];
            if (op == "submit")
            {
                insert();
            }
        }

        public void insert()
        {
            //获取评定及成绩
            double score = Convert.ToDouble(Request["score"]);
            string investigation = Request["investigation"];
            string practice = Request["practice"];
            string solveProblem = Request["solveProblem"];
            string workAttitude = Request["workAttitude"];
            string quality = Request["quality"];
            string evaluate = Request["evaluate"];
            string innovate = Request["innovate"];
            string crossTea = Request["crossTea"];
            //添加评定及成绩
            Student student = new Student();
            Plan plan = new Plan();
            try
            {
                student.StuAccount = stuAccount;
                plan.PlanId = planId;
                scoreModel.student = student;
                scoreModel.plan = plan;
                scoreModel.guideScore = score;
                scoreModel.investigation = investigation;
                scoreModel.practice = practice;
                scoreModel.solveProblem = solveProblem;
                scoreModel.workAttitude = workAttitude;
                scoreModel.paperDesign = quality;
                scoreModel.innovate = innovate;
                scoreModel.evaluate = evaluate;
                //添加交叉指导教师
                CrossBll crossBll = new CrossBll();
                PathBll pathBll = new PathBll();
                TitleRecord titleRecord = new TitleRecord();
                Cross cross = new Cross();
                Path path = new Path();
                Teacher teacher = new Teacher();
                titleRecord.TitleRecordId = titleRecordId;
                cross.titleRecord = titleRecord;
                teacher.TeaAccount = crossTea;
                cross.teacher = teacher;

                path.titleRecord = titleRecord;
                path.state = 3;
                path.type = 0;
                Result state = pathBll.updateState(path);
                if (state == Result.更新成功)
                {
                    Result recordState = titlebll.updateState(titleRecord.TitleRecordId);
                    if (recordState == Result.更新成功)
                    {
                        Result result = crossBll.Insert(cross);
                        if (result == Result.添加成功)
                        {
                            StudentBll studentBll = new StudentBll();
                            Student stu = studentBll.GetModel(stuAccount);
                            TeacherBll teacherBll = new TeacherBll();
                            Teacher tea = teacherBll.GetModel(crossTea);
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 教师指定 - " + stuAccount + " - " + stu.RealName + " - 学生的交叉指导教师 - " + teacher + " - " + tea.TeaName);
                            Result row = sbll.insertInstructorsComments(scoreModel);
                            if (row == Result.添加成功)
                            {
                                LogHelper.Info(this.GetType(), teacher.TeaAccount + " - " + teacher.TeaName + " - 教师添加 - " + stuAccount + " - " + stu.RealName + " - 学生的指导成绩及评定");
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
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
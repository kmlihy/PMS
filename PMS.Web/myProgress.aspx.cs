using PMS.BLL;
using PMS.Model;
using System;
using System.Data;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class myGrogress : CommonPage
    {
        protected string title;//题目
        protected int titleId;//题目ID
        protected string stuNO = null;//学生学号
        protected DateTime startTime;//选题开始时间
        protected DateTime endTime;//选题结束时间
        protected DateTime selectTime;//学生的选题时间
        protected string planId;//批次ID
        protected string titleRecordId = null;//选题记录ID
        protected DateTime opTime;//提交开题报告时间
        protected string teacherOpenning;//教师开题报告审核意见
        protected int opCount;
        protected Student student;
        protected OpenReport opReport;
        protected string state;//登录类型

        protected Path path;//论文和查重报告存储路径
        protected DataSet pathds;
        protected Result pathRe;
        protected Path pathState;//获取数据库state字段

        protected MedtermQuality mq;//中期质量报告

        protected bool isGuide;//判断是否有交叉知道记录

        protected DataSet ds;
        protected DataSet titleDs;
        protected DataSet scoreDs;
        protected DataSet crossGuideDs;
        protected DataSet corssDs;
        protected DataSet defenceDs;
        public DataSet checkReport;
        TitleRecordBll Record = new TitleRecordBll();
        PlanBll planBll = new PlanBll();
        OpenReportBll opBll = new OpenReportBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            getData();
        }
        public void getData()
        {
            PathBll pathBll = new PathBll();
            MedtermQualityBll mqBll = new MedtermQualityBll();
            ScoreBll scoreBll = new ScoreBll();
            GuideRecordBll guideBll = new GuideRecordBll();
            CrossBll crossBll = new CrossBll();
            DefenceBll dfBll = new DefenceBll();
            state = Session["state"].ToString();
            if(state == "3")
            {
                student = (Student)Session["loginuser"];
                stuNO = student.StuAccount;
                if (Record.selectBystuId(stuNO)==true)
                {
                    ds = Record.GetByAccount(stuNO);
                    title = ds.Tables[0].Rows[0]["title"].ToString();//获取标题
                    planId = ds.Tables[0].Rows[0]["planId"].ToString();//获取批次ID
                    Plan plan = planBll.Select(int.Parse(planId));//获取批次信息
                    startTime = plan.StartTime;//批次开始时间
                    endTime = plan.EndTime;//批次结束时间
                    string dsTime = ds.Tables[0].Rows[0]["createTime"].ToString();
                    selectTime = Convert.ToDateTime(dsTime);//学生选定题目时间

                    //获取选题记录ID来取得学生开题报告的信息
                    titleRecordId = ds.Tables[0].Rows[0]["titleRecordId"].ToString();
                    if (opBll.selectByRecordId(int.Parse(titleRecordId)) == true)
                    {
                        opReport = opBll.Select(int.Parse(titleRecordId));
                        opTime = opReport.reportTime;
                        teacherOpenning = opReport.teacherOpinion;
                        pathRe = pathBll.selectByTitleRecordId(titleRecordId);
                        if (pathRe == Result.记录存在)
                        {
                            Path pathRecordId = pathBll.getTitleRecordId(stuNO);
                            TitleRecord tr = pathRecordId.titleRecord;
                            pathds = pathBll.getModel(tr.TitleRecordId, stuNO);//遍历路径信息(type为0时)
                            checkReport = pathBll.getCheckReport(tr.TitleRecordId, stuNO);//查重
                            mq = mqBll.Select(tr.TitleRecordId);//遍历中期质量报告
                            scoreDs = scoreBll.Select(stuNO, int.Parse(planId));//获取学生成绩
                            crossGuideDs = crossBll.Select(tr.TitleRecordId);//遍历交叉指导信息
                            corssDs = crossBll.SelectByStu(stuNO);
                            defenceDs = dfBll.getModel(tr.TitleRecordId.ToString());//遍历答辩记录信息
                        }
                    }
                }
                //else
                //{
                //    Response.Write("你还没有选题，请先进行选题");
                //}
            }
            else
            {
                Response.Write("管理员和教师没有进度条");
            }
        }

    }
}
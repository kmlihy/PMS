using PMS.Dao;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    /// <summary>
    /// 开题报告业务处理类
    /// </summary>
    public class OpenReportBll
    {
        OpenReportDao odao = new OpenReportDao();
        /// <summary>
        /// 学生提交开题报告
        /// </summary>
        /// <param name="report">开题报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result stuInsert(OpenReport report)
        {
            int row = odao.stuInsert(report);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 教师提交评阅开题报告意见
        /// </summary>
        /// <param name="report">开题报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result teaInsert(int titleRecordId, string teacherOpinion)
        {
            int row = odao.teaInsert(titleRecordId, teacherOpinion);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 根据选题记录id获取开题报告对象
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public OpenReport Select(int titleRecordId)
        {
            DataSet ds = odao.Select(titleRecordId);
            OpenReport or = new OpenReport();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count - 1;
                or.meaning = ds.Tables[0].Rows[i]["meaning"].ToString();
                or.content = ds.Tables[0].Rows[i]["openContent"].ToString();
                or.method = ds.Tables[0].Rows[i]["method"].ToString();
                or.outline = ds.Tables[0].Rows[i]["outline"].ToString();
                or.plan = ds.Tables[0].Rows[i]["openPlan"].ToString();
                or.reference = ds.Tables[0].Rows[i]["reference"].ToString();
                //or.titleRecord.TitleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                //or.reportTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["reportTime"].ToString());
                or.trend = ds.Tables[0].Rows[i]["trend"].ToString();
                or.teacherOpinion = ds.Tables[0].Rows[i]["teacherOpinion"].ToString();
                or.deanOpinion = ds.Tables[0].Rows[i]["deanOpinion"].ToString();
                return or;
            }
            else
            {
                return null;
            }
        }
        public bool selectByRecordId(int titleRecordId)
        {
            int count = odao.selectByRecordId(titleRecordId);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

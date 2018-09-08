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
        /// 根据选题记录id更新state
        /// </summary>
        /// <param name="state">state完成状态</param>
        /// <param name="titleRecordId"选题记录id</param>
        /// <returns></returns>
        public Result updateState(int state, int titleRecordId)
        {
            int row = odao.updateState(state, titleRecordId);
            if (row > 0)
            {
                return Result.更新成功;
            }
            else
            {
                return Result.更新失败;
            }
        }
        /// <summary>
        /// 教师提交评阅开题报告意见
        /// </summary>
        /// <param name="openId">开题报告记录id</param>
        /// <param name="teacherOpinion">教师意见</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result teaInsert(int openId, string teacherOpinion)
        {
            int row = odao.teaInsert(openId, teacherOpinion);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 分院院长提交评阅开题报告意见
        /// </summary>
        /// <param name="openId">开题报告记录id</param>
        /// <param name="teacherOpinion">教师意见</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result deanInsert(int openId, string teacherOpinion)
        {
            int row = odao.deanInsert(openId, teacherOpinion);
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
                or.openId = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                or.meaning = ds.Tables[0].Rows[i]["meaning"].ToString();
                or.content = ds.Tables[0].Rows[i]["openContent"].ToString();
                or.method = ds.Tables[0].Rows[i]["method"].ToString();
                or.outline = ds.Tables[0].Rows[i]["outline"].ToString();
                or.plan = ds.Tables[0].Rows[i]["openPlan"].ToString();
                or.reference = ds.Tables[0].Rows[i]["reference"].ToString();
                TitleRecord titleRecord = new TitleRecord();
                titleRecord.TitleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                or.titleRecord = titleRecord;
                or.reportTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["reportTime"].ToString());
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

        public Result isOpenReport(string stuAccount, int planId)
        {
            int count = odao.isOpenReport(stuAccount,planId);
            if (count>0)
            {
                return Result.记录存在;
            }
            else
            {
                return Result.记录不存在;
            }
        }
        /// <summary>
        /// 根据选题记录ID查看是否提交了开题报告
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
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

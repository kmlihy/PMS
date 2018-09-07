using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    /// <summary>
    /// 开题报告数据库操作类
    /// </summary>
    public class OpenReportDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 学生提交开题报告
        /// </summary>
        /// <param name="openReport">开题报告实体</param>
        /// <returns>返回受影响行数</returns>
        public int stuInsert(OpenReport openReport)
        {
            try
            {
                string cmdText = "insert into T_OpeningReport(titleRecordId,meaning,trend,openContent,openPlan,method,outline,reference,reportTime) values(@titleRecordId, @meaning, @trend, @content, @plan, @method, @outline, @reference, @reportTime)";
                string[] param = { "@titleRecordId", "@meaning", "@trend", "@content", "@plan", "@method", "@outline", "@reference", "@reportTime" };
                object[] values = { openReport.titleRecord.TitleRecordId, openReport.meaning, openReport.trend, openReport.content, openReport.plan, openReport.method,openReport.outline ,openReport.reference, openReport.reportTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 通过选题记录id更新state
        /// </summary>
        /// <param name="openReport"></param>
        /// <returns></returns>
        public int updateState(OpenReport openReport)
        {
            try
            {
                string cmdText = "UPDATE T_OpeningReport SET state = @state WHERE ID IN(SELECT TOP 1 ID FROM  T_OpeningReport WHERE titleRecordId = @titleRecordId ORDER BY ID DESC)";
                string[] param = { "@state", "@titleRecordId" };
                string[] values = { openReport.state.ToString(), openReport.titleRecord.TitleRecordId.ToString() };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 教师提交开题报告评阅意见
        /// </summary>
        /// <param name="openReport">开题报告实体</param>
        /// <returns>受影响行数</returns>
        public int teaInsert(int titleRecordId, string teacherOpinion)
        {
            try
            {
                string cmdText = "insert into T_OpeningReport(titleRecordId,teacherOpinion) values(@titleRecordId,@teacherOpinion)";
                string[] param = { "@titleRecordId","@teacherOpinion" };
                object[] values = { titleRecordId, teacherOpinion};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据选题记录id获取学生开题报告信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns>开题报告数据集</returns>
        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_OpeningReport where titleRecordId=@titleRecordId";
                String[] param = { "@titleRecordId" };
                String[] values = { titleRecordId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 判断是否选题
        /// </summary>
        /// <param name="stuAccount"></param>
        /// <param name="planId"></param>
        /// <returns></returns>
        public int isOpenReport(string stuAccount,int planId)
        {
            string sql = "select count(titleRecordId) from V_TitleRecord where planId=@planId and stuAccount=@stuAccount";
            string[] param = { "@planId", "@stuAccount" };
            object[] values = { planId,stuAccount };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }
        /// <summary>
        /// 查询是否有开题报告提交记录
        /// </summary>
        /// <param name="titleRecordId">选题记录ID</param>
        /// <returns>影响行数</returns>
        public int selectByRecordId(int titleRecordId)
        {
            string sql = "select titleRecordId from T_OpeningReport where titleRecordId = @recordId";
            string[] param = { "@recordId" };
            object[] values = { titleRecordId };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }
    }
}

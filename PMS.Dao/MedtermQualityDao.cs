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
    /// 中期质量报告数据库操作类
    /// </summary>
    public class MedtermQualityDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 学生提交中期质量报告
        /// </summary>
        /// <param name="medterm">中期质量报告实体</param>
        /// <returns>受影响行数</returns>
        public int stuInsert(MedtermQuality medterm)
        {
            try
            {
                string cmdText = "insert into T_MedtermQuality(titleRecordId,planFinishSituation,dateTime) values(@titleRecordId,@planFinishSituation,@dateTime)";
                string[] param = { "@titleRecordId", "@planFinishSituation", "@dateTime" };
                object[] values = { medterm.titleRecord.TitleRecordId, medterm.planFinishSituation, medterm.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 教师给出中期质量报告评语意见
        /// </summary>
        /// <param name="medterm">中期质量报告实体</param>
        /// <returns>受影响行数</returns>
        public int teaInsert(MedtermQuality medterm)
        {
            try
            {
                string cmdText = "update T_MedtermQuality set teacherOpinion = @teacherOpinion,dateTime= @dateTime where titleRecordId=@titleRecordId";
                string[] param = { "@titleRecordId", "@teacherOpinion", "@dateTime" };
                object[] values = { medterm.titleRecord.TitleRecordId, medterm.teacherOpinion, medterm.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 督导处给出中期质量报告评语意见
        /// </summary>
        /// <param name="medterm">中期质量报告实体</param>
        /// <returns>受影响行数</returns>
        public int superInsert(MedtermQuality medterm)
        {
            try
            {
                string cmdText = "insert into T_MedtermQuality(titleRecordId,supervisionOpinion,guideGroupOpinion,dateTime) values(@titleRecordId,@supervisionOpinion,@guideGroupOpinion,@dateTime)";
                string[] param = { "@titleRecordId", "@supervisionOpinion,", "@guideGroupOpinion", "@dateTime" };
                object[] values = { medterm.titleRecord.TitleRecordId, medterm.supervisionOpinion, medterm.guideGroupOpinion, medterm.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据选题记录id查找中期检查信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns>中期检查记录数据集</returns>
        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_MedtermQuality where titleRecordId=@titleRecordId";
                String[] param = { "@titleRecordId" };
                String[] values = { titleRecordId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取中期质量完成状态state
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public MedtermQuality getState(int titleRecordId)
        {
            string sql = "select top 1 state from T_MedtermQuality where titleRecordId=@titleRecordId order by midId desc";
            string[] param = { "@titleRecordId"};
            object[] values = { titleRecordId };
            MedtermQuality medtermQuality = new MedtermQuality();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                medtermQuality.state = reader.GetInt32(0);
            }
            reader.Close();
            return medtermQuality;
        }
        /// <summary>
        /// 更新state
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public int updateState(MedtermQuality medtermQuality)
        {
            try
            {
                string cmdText = "UPDATE T_MedtermQuality SET state = @state WHERE midId IN(SELECT TOP 1 midId FROM  T_MedtermQuality WHERE titleRecordId = @titleRecordId ORDER BY midId DESC)";
                string[] param = { "@state", "@titleRecordId" };
                object[] values = { medtermQuality.state, medtermQuality.titleRecord.TitleRecordId };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

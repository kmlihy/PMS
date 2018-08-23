using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
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
                string cmdText = "insert into T_MedtermQuality(titleRecordId,teacherOpinion,dateTime) values(@titleRecordId,@teacherOpinion,@dateTime)";
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
    }
}

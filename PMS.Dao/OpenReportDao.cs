using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
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
                string cmdText = "insert into T_OpeningReport(titleRecordId,titleBasis,designContent,designMethod,designRate,referenceMaterial,reportTime) values(@titleRecordId,@titleBasis,@designContent,@designMethod,@designRate,@referenceMaterial,@reportTime)";
                string[] param = { "@titleRecordId","@titleBasis","@designContent","@designMethod","@designRate","@referenceMaterial", "@reportTime" };
                object[] values = { openReport.titleRecord.TitleRecordId, openReport.titleBasis, openReport.designContent, openReport.designMethod, openReport.designRate, openReport.referenceMaterial, openReport.reportTime };
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
        public int teaInsert(OpenReport openReport)
        {
            try
            {
                string cmdText = "insert into T_OpeningReport(titleRecordId,teacherOpinion) values(@titleRecordId,@teacherOpinion)";
                string[] param = { "@titleRecordId","@teacherOpinion" };
                object[] values = { openReport.titleRecord.TitleRecordId, openReport.teacherOpinion};
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

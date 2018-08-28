using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
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

        public OpenReport Select(int titleRecordId)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from T_OpenReport ");
                strSql.Append(" where titleRecordId=@titleRecordId");
                String[] param = { "@titleRecordId" };
                String[] values = { titleRecordId.ToString() };
                DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
                OpenReport open = new OpenReport();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["meaning"].ToString() != "")
                    {
                        open.meaning = ds.Tables[0].Rows[0]["meaning"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["trend"].ToString() != "")
                    {
                        open.trend = ds.Tables[0].Rows[0]["trend"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["content"].ToString() != "")
                    {
                        open.content = ds.Tables[0].Rows[0]["content"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["method"].ToString() != "")
                    {
                        open.method = ds.Tables[0].Rows[0]["method"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["outline"].ToString() != "")
                    {
                        open.outline = ds.Tables[0].Rows[0]["outline"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["plan"].ToString() != "")
                    {
                        open.plan = ds.Tables[0].Rows[0]["plan"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["reference"].ToString() != "")
                    {
                        open.reference = ds.Tables[0].Rows[0]["reference"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["reportTime"].ToString() != "")
                    {
                        open.reportTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["reportTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["titleRecordId"].ToString() != "")
                    {
                        open .titleRecord.TitleRecordId = int.Parse(ds.Tables[0].Rows[0]["titleRecordId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["teacherOpinion"].ToString() != "")
                    {
                        open.teacherOpinion = ds.Tables[0].Rows[0]["teacherOpinion"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["deanOpinion"].ToString() != "")
                    {
                        open.deanOpinion = ds.Tables[0].Rows[0]["deanOpinion"].ToString();
                    }
                }
                return open;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

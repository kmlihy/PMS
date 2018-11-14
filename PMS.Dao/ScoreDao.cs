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
    /// 成绩数据库操作类
    /// </summary>
    public class ScoreDao
    {
        private SQLHelper db = new SQLHelper();
        
        /// <summary>
        /// 插入指导评价
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public int insertInstructorsComments(Score score)
        {
            try
            {
                string cmdText = "insert into T_Score(stuAccount,planId,guideScore,investigation,practice,solveProblem,workAttitude,paperDesign,innovate,evaluate) values(@stuAccount,@planId,@guideScore,@investigation,@practice,@solveProblem,@workAttitude,@paperDesign,@innovate,@evaluate)";
                string[] param = { "@stuAccount", "@planId", "@guideScore", "@investigation", "@practice", "@solveProblem", "@workAttitude", "@paperDesign", "@innovate", "@evaluate" };
                object[] values = { score.student.StuAccount, score.plan.PlanId, score.guideScore, score.investigation, score.practice, score.solveProblem, score.workAttitude, score.paperDesign, score.innovate ,score.evaluate};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入交叉指导论文
        /// </summary>
        /// <param name="score">分数实体</param>
        /// <returns>受影响行数</returns>
        public int updateCrossGuide(Score score)
        {
            try
            {
                string cmdText = "update T_Score set crossScore=@crossScore,material=@material,paperDesign=@paperDesign,workload=@workload,crossInnovate=@crossInnovate,crossEvaluate=@crossEvaluate where stuAccount=@stuAccount and planId=@planId";
                string[] param = { "@stuAccount", "@planId", "@crossScore", "@material", "@paperDesign", "@workload", "@crossInnovate", "@crossEvaluate" };
                object[] values = { score.student.StuAccount, score.plan.PlanId, score.crossScore, score.material, score.paperDesign, score.workload, score.crossInnovate, score.crossEvaluate };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 插入答辩成绩
        /// </summary>
        /// <param name="score">分数实体</param>
        /// <returns>受影响行数</returns>
        public int updatereplyPanelsOpinion(Score score)
        {
            try
            {
                string cmdText = "update T_Score set reportContent=@reportContent,reportTime=@reportTime,defence=@defence,defenInnovate=@defenInnovate,defenceScore=@defenceScore,defenEvaluate=@defenEvaluate where stuAccount=@stuAccount and planId=@planId";
                string[] param = { "@stuAccount", "@planId", "@reportContent", "@reportTime", "@defence", "@defenInnovate", "@defenceScore", "@defenEvaluate" };
                object[] values = { score.student.StuAccount, score.plan.PlanId,score.reportContent,score.reportTime,score.defence,score.defenInnovate, score.defenceScore,score.defenEvaluate };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据学生账号、批次id获取成绩
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="planId">批次id</param>
        /// <returns></returns>
        public DataSet Select(string stuAccount,int planId)
        {
            try
            {
                string cmdText = "select * from T_Score where stuAccount=@stuAccount and planId = @planId";
                String[] param = { "@stuAccount", "@planId" };
                String[] values = { stuAccount, planId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 通过titleRecordId获取当前状态
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public Score getState(string titleRecordId)
        {
            string sql = "select state from T_DefenceRecord where titleRecordId=@titleRecordId";
            string[] param = { "@titleRecordId" };
            object[] values = { titleRecordId };
            Score score = new Score();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                score.state = reader.GetInt32(0);
            }
            reader.Close();
            return score;
        }
        /// <summary>
        /// 开放成绩
        /// </summary>
        /// <param name="state">更新成绩查看状态</param>
        /// <param name="planId">批次id</param>
        /// <returns></returns>
        public int openScore(int state, int planId)
        {
            try
            {
                string cmdText = "update T_Score set openState=@state where planId=@planId";
                string[] param = { "@state", "@planId" };
                object[] values = { state, planId };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取成绩开放状态
        /// </summary>
        /// <param name="openState">开放状态</param>
        /// <param name="planId">批次id</param>
        /// <returns></returns>
        public int selectSate(int openState, int planId)
        {
            string sql = "select COUNT(scoreId) from T_Score where openState=@openState and planId=@planId";
            string[] param = { "@openState", "@planId" };
            object[] values = { openState, planId };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 导出成Excel表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回一个DataTable的选题记录集合</returns>
        public DataTable ExportExcel(string strWhere,Score score)
        {
            String cmdText = string.Format("select stuAccount as 学号,realName as 姓名,title as 题目,teaName as 出题教师,guideScore as 指导分数,crossScore as 交叉指导分数,defenceScore as 答辩成绩,(guideScore*"+ score.guideRatio + "+crossScore*"+ score.crossRatio + "+defenceScore*"+ score.defenceRatio + ") as 总成绩 from V_Score {0}", strWhere);
            DataSet ds = db.FillDataSet(cmdText, null, null);
            DataTable dt = null;
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 添加成绩占比
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>添加结果</returns>
        public int insertRatio(Score score)
        {
            try
            {
                string cmdText = "insert into T_OptionScore(guide,crossGuide,defen,excellent) values(@guide,@crossGuide,@defen,@excellent)";
                string[] param = { "@guide", "@crossGuide", "@defen", "@excellent"};
                object[] values = { score.guideRatio, score.crossRatio, score.defenceRatio,score.excellent };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取成绩占比
        /// </summary>
        /// <returns></returns>
        public Score getRatio()
        {
            string cmdText = "select guide,crossGuide,defen,excellent from T_OptionScore";
            DataSet ds = db.FillDataSet(cmdText, null, null);
            Score score = new Score();
            if (ds.Tables[0].Rows.Count > 0 && ds != null)
            {
                score.guideRatio = Convert.ToDouble(ds.Tables[0].Rows[0]["guide"]);
                score.crossRatio = Convert.ToDouble(ds.Tables[0].Rows[0]["crossGuide"]);
                score.defenceRatio = Convert.ToDouble(ds.Tables[0].Rows[0]["defen"]);
                score.excellent = Convert.ToDouble(ds.Tables[0].Rows[0]["excellent"]);
                return score;
            }
            else
            {
                return null;
            }
        }
    }
}

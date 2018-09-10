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
    }
}

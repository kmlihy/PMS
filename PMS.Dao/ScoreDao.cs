using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
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
        /// 学生提交论文路径
        /// </summary>
        /// <param name="path">文件路径实体</param>
        /// <returns>受影响行数</returns>
        public int Insert(Score score)
        {
            try
            {
                string cmdText = "insert into T_Score(stuAccount,planId,score,remarks,assess,evaluate) values(@stuAccount,@planId,@score,@remarks,@assess,@evaluate)";
                string[] param = { "@stuAccount", "@planId", "@score", "@remarks","@assess","@evaluate" };
                object[] values = { score.student.StuAccount, score.plan.PlanId, score.score, score.remarks, score.assess, score.evaluate };
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

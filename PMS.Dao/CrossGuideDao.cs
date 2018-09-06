using PMS.Model;
using PMS.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace PMS.Dao
{
    /// <summary>
    /// 交叉评阅数据库操作类
    /// </summary>
    public class CrossGuideDao
    {
        SQLHelper db = new SQLHelper();
        
        /// <summary>
        /// 添加交叉评阅记录
        /// </summary>
        /// <param name="cross"></param>
        /// <returns></returns>
        public int Insert(CrossGuide cross)
        {
            try
            {
                string cmdText = "insert into T_CrossGuide(crossId,guideOpinion) values(@crossId,@guideOpinion)";
                string[] param = { "@crossId", "@guideOpinion" };
                object[] values = { cross.cross.crossId, cross.guideOpinion};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 根据选题记录id查找交叉指导记录
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from V_CrossGuide where titleRecordId=@titleRecordId";
                String[] param = { "@titleRecordId" };
                String[] values = { titleRecordId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
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
                string cmdText = "update T_Score set score=@score,remarks=@remarks,material=@material,paperDesign=@paperDesign,workload=@workload,innovate=@innovate,evaluate=evaluate where stuAccount=@stuAccount and planId=@planId";
                string[] param = { "@stuAccount", "@planId", "@score", "@remarks", "@material", "@paperDesign", "@workload", "@innovate", "@evaluate" };
                object[] values = { score.student.StuAccount, score.plan.PlanId, score.score, score.remarks, score.material, score.paperDesign, score.workload, score.innovate, score.evaluate };
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

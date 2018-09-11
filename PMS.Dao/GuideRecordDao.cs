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
    /// 指导记录数据库操作类
    /// </summary>
    public class GuideRecordDao
    {
        private SQLHelper db = new SQLHelper();
       
        /// <summary>
        /// 教师提交论文指导意见
        /// </summary>
        /// <param name="guideRecord">指导记录实体</param>
        /// <returns>受影响行数</returns>
        public int Insert(GuideRecord guideRecord)
        {
            try
            {
                string cmdText = "insert into T_GuideRecord(titleRecordId,opinion,pathId,dateTime) values(@titleRecordId,@opinion,@pathId,@dateTime)";
                string[] param = { "@titleRecordId", "@opinion", "@pathId", "@dateTime" };
                object[] values = { guideRecord.titleRecord.TitleRecordId, guideRecord.opinion, guideRecord.path.pathId, guideRecord.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 通过选题记录id，学生账号获取指导记录信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public DataSet Select(int titleRecordId, string stuAccount)
        {
            try
            {
                string cmdText = "select * from V_TitleRecord where titleRecordId = @titleRecordId and stuAccount = @stuAccount";
                string[] param = { "@titleRecordId", "@stuAccount" };
                object[] values = { titleRecordId, stuAccount };
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
        /// 根据选题记录id查找指导记录
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_GuideRecord where titleRecordId=@titleRecordId";
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
        
    }
}

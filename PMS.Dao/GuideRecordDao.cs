using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
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
                string cmdText = "insert into T_GuideRecord(titleRecordId,opinion,paperPath,dateTime) values(@titleRecordId,@opinion,@paperPath,@dateTime)";
                string[] param = { "@titleRecordId", "@opinion", "@paperPath", "@dateTime" };
                object[] values = { guideRecord.titleRecord.TitleRecordId,guideRecord.opinion,guideRecord.paperPath,guideRecord.dateTime };
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

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
        /// 根据学生或教师账号获取选题记录信息
        /// </summary>
        /// <param name="account">学生或教师账号</param>
        /// <returns>选题记录对象</returns>
        public DataSet GetByAccount(string account)
        {
            try
            {
                string cmdText = "select * from V_Cross where stuAccount = @account or teaAccount = @account";
                string[] param = { "@account" };
                object[] values = { account };
                DataSet ds = db.FillDataSet(cmdText, param, values);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

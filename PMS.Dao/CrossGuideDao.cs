﻿using PMS.Model;
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
                string cmdText = "insert into T_CrossGuide(titleRecordId,guideOpinion) values(@titleRecordId,@guideOpinion)";
                string[] param = { "@titleRecordId", "@guideOpinion" };
                object[] values = { cross.titleRecord.TitleRecordId, cross.guideOpinion};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 根据选题记录id查找
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_CrossGuide where titleRecordId=@titleRecordId";
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
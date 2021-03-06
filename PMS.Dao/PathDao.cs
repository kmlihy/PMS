﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PMS.DBHelper;
using PMS.Model;

namespace PMS.Dao
{
    /// <summary>
    /// 文件路径数据库操作类
    /// </summary>
    public class PathDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 学生提交论文路径
        /// </summary>
        /// <param name="path">文件路径实体</param>
        /// <returns>受影响行数</returns>
        public int InsertThesis(Path path)
        {
            try
            {
                string cmdText = "insert into T_Path(titleRecordId,pathTitle,path,dateTime) values(@titleRecordId,@title,@paperPath,@dateTime)";
                string[] param = { "@titleRecordId", "@title", "@paperPath", "@dateTime" };
                object[] values = { path.titleRecord.TitleRecordId,path.title,path.paperPath,path.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 学生提交查重报告
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public int InsertReport(Path path)
        {
            try
            {
                string cmdText = "insert into T_Path(titleRecordId,pathTitle,path,dateTime,type) values(@titleRecordId,@title,@paperPath,@dateTime,@type)";
                string[] param = { "@titleRecordId", "@title", "@paperPath", "@dateTime" ,"@type"};
                object[] values = { path.titleRecord.TitleRecordId, path.title, path.paperPath, path.dateTime ,path.type=1};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 更新文件完成状态state
        /// </summary>
        /// <param name="path">路径实体对象</param>
        /// <returns></returns>
        public int updateState(Path path)
        {
            try
            {
                string cmdText = "UPDATE T_Path SET state = @state WHERE pathId IN(SELECT TOP 1 pathId FROM  T_Path WHERE titleRecordId = @titleRecordId and type=@type ORDER BY pathId DESC)";
                string[] param = { "@state" , "@titleRecordId", "@type" };
                object[] values = { path.state,path.titleRecord.TitleRecordId, path.type};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 查询是否有论文
        /// </summary>
        /// <param name="stuAccount">titleRecordId</param>
        /// <returns>影响行数</returns>
        public int selectByTitleRecordId(string titleRecordId)
        {
            string sql = "select count(pathId) from T_Path where titleRecordId=@titleRecordId and type=0";
            string[] param = { "@titleRecordId" };
            object[] values = { titleRecordId };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }
        /// <summary>
        /// 通过选题记录id获取最新state
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public Path getState(int titleRecordId,int type)
        {
            string sql = "select top 1 state from T_Path where titleRecordId=@titleRecordId and type=@type order by pathId desc";
            string[] param = { "@titleRecordId", "@type" };
            object[] values = { titleRecordId ,type };
            Path path = new Path();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                if (reader.GetInt32(0) == 0)
                {
                    path = null;
                }
                else
                {
                    path.state = reader.GetInt32(0);
                }
            }
            reader.Close();
            return path;
        }

        /// <summary>
        /// 通过学生账号查找到当前最近的titleRecordId
        /// </summary>
        /// <param name="stuAccount">学号</param>
        /// <returns></returns>
        public Path getTitleRecordId(string stuAccount)
        {
            string sql = "select top 1 titleRecordId from T_TitleRecord where stuAccount=@Account order by createTime desc";
            string[] param = { "@Account" };
            object[] values = { stuAccount };
            Path path = new Path();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                TitleRecord titleRecord = new TitleRecord();
                titleRecord.TitleRecordId = reader.GetInt32(0);
                path.titleRecord = titleRecord;
            }
            reader.Close();
            return path;
        }

        public DataSet Select(int titleRecordId,string stuAccount)
        {
            try
            {
                string cmdText = "select * from V_Path where titleRecordId = @titleRecordId and stuAccount = @stuAccount and type =0";
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
        /// 获取查重报告
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet checkReport(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from V_Path where titleRecordId = @titleRecordId and type =1";
                string[] param = { "@titleRecordId" };
                object[] values = { titleRecordId };
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

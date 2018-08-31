using System;
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
        public int Insert(Path path)
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

        public DataSet Select(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_Path where titleRecordId = @titleRecordId";
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

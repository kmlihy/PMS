using System;
using System.Collections.Generic;
using System.Data;
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
                string cmdText = "insert into T_Path(title,paperPath,dateTime) values(@title,@paperPath,@dateTime)";
                string[] param = { "@title", "@paperPath", "@dateTime" };
                object[] values = { path.title,path.paperPath,path.dateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

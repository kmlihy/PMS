using PMS.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    public class ImportHelper
    {
        //学院导入
        public static int College(DataTable dt)
        {
            DataTable dt2 = DeduplicationByCollege(dt);
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, tran);
            int rows = dt2.Rows.Count;
            try
            {
                int count = dt2.Columns.Count;
                sqlbulkcopy.DestinationTableName = "T_College";
                dt2.Columns["学院名称"].ColumnName = "collegeName";
                for (int i = 0; i < count; i++)
                {
                    sqlbulkcopy.ColumnMappings.Add(dt2.Columns[i].ColumnName, dt2.Columns[i].ColumnName);
                }
                sqlbulkcopy.WriteToServer(dt2);
                tran.Commit();
            }
            catch (System.Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                sqlbulkcopy.Close();
                conn.Close();
            }
            return rows;
        }

        //学院信息去重
        private static DataTable DeduplicationByCollege(DataTable dt1)
        {
            dt1.Columns.Add("collegeId").SetOrdinal(0);
            DataTable deDuplication = new DataTable();
            deDuplication.Columns.Add("collegeId", typeof(int));
            deDuplication.Columns.Add("学院名称", typeof(string));
            CollegeDao collegeDao = new CollegeDao();
            DataTable dt2 = collegeDao.Select().Tables[0];
            if (dt1!=null&&dt2!=null)
            {
                DataRowCollection count = dt1.Rows;
                foreach (DataRow row in count)//遍历excel数据集
                {
                    try
                    {
                        string collegeName = row[1].ToString();
                        DataRow[] rows = dt2.Select(string.Format("collegeName='{0}'", collegeName));
                        if (rows.Length == 0)//判断如果DataRow.Length为0，即该行excel数据不存在于表A中，就插入到dt3
                        {
                            deDuplication.Rows.Add(row[0], row[1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            return deDuplication;
        }
    }
}

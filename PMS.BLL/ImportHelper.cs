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
            deDuplication.Columns.Add("collegeName", typeof(string));
            CollegeBll collegeBll = new CollegeBll();
            DataTable dt2 = collegeBll.Select().Tables[0];
            if (dt1!=null)
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

        //专业导入
        public static int Major(DataTable dt,int collegeId)
        {
            DataTable dt2 = DeduplicationByMajor(dt, collegeId);
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, tran);
            int rows = dt2.Rows.Count;
            try
            {
                int count = dt2.Columns.Count;
                sqlbulkcopy.DestinationTableName = "T_Profession";
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

        //专业信息去重
        private static DataTable DeduplicationByMajor(DataTable dt1,int collegeId)
        {
            dt1.Columns.Add("proId").SetOrdinal(0);
            DataColumn dc = new DataColumn("collegeId", typeof(int));
            dc.DefaultValue = collegeId;
            dt1.Columns.Add(dc);
            DataTable deDuplication = new DataTable();
            deDuplication.Columns.Add("proId", typeof(int));
            deDuplication.Columns.Add("proName", typeof(string));
            deDuplication.Columns.Add("collegeId", typeof(int));
            ProfessionBll professionBll = new ProfessionBll();
            DataTable dt2 = professionBll.selectColName().Tables[0];
            if (dt1 != null)
            {
                DataRowCollection count = dt1.Rows;
                foreach (DataRow row in count)//遍历excel数据集
                {
                    try
                    {
                        string proName = row[1].ToString();
                        DataRow[] rows = dt2.Select(string.Format("proName='{0}'", proName));
                        if (rows.Length == 0)//判断如果DataRow.Length为0，即该行excel数据不存在于表A中，就插入到dt3
                        {
                            deDuplication.Rows.Add(row[0], row[1],row[2]);
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

        //教师导入
        public static int Teacher(DataTable dt, int collegeId)
        {
            DataTable dt2 = DeduplicationByTea(dt, collegeId);
            string connectionString = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlTransaction tran = conn.BeginTransaction();
            SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.CheckConstraints, tran);
            int rows = dt2.Rows.Count;
            try
            {
                int count = dt2.Columns.Count;
                sqlbulkcopy.DestinationTableName = "T_Teacher";
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

        //教师信息去重
        private static DataTable DeduplicationByTea(DataTable dt1, int collegeId)
        {
            RSACryptoService rSA = new RSACryptoService();
            string pwd = "000000";
            DataColumn dcPwd = new DataColumn("teaPwd", typeof(string));
            dcPwd.DefaultValue = rSA.Encrypt(pwd);
            dt1.Columns.Add(dcPwd);
            DataColumn dcCol = new DataColumn("collegeId", typeof(int));
            dcCol.DefaultValue = collegeId;
            dt1.Columns.Add(dcCol);
            DataColumn dcteaType = new DataColumn("teaType", typeof(int));
            dcteaType.DefaultValue = 1;
            dt1.Columns.Add(dcteaType);
            DataTable deDuplication = new DataTable();
            deDuplication.Columns.Add("teaAccount", typeof(string));
            deDuplication.Columns.Add("teaPwd", typeof(string));
            deDuplication.Columns.Add("teaName", typeof(string));
            deDuplication.Columns.Add("sex", typeof(string));
            deDuplication.Columns.Add("phone", typeof(string));
            deDuplication.Columns.Add("Email", typeof(string));
            deDuplication.Columns.Add("collegeId", typeof(int));
            deDuplication.Columns.Add("teaType", typeof(int));
            TeacherBll teacherBll = new TeacherBll();
            DataTable dt2 = teacherBll.SelectTeaAcount().Tables[0];
            if (dt1 != null)
            {
                DataRowCollection count = dt1.Rows;
                foreach (DataRow row in count)//遍历excel数据集
                {
                    try
                    {
                        string teaAccount = row[0].ToString();
                        DataRow[] rows = dt2.Select(string.Format("teaAccount='{0}'", teaAccount));
                        if (rows.Length == 0)//判断如果DataRow.Length为0，即该行excel数据不存在于表A中，就插入到dt3
                        {
                            deDuplication.Rows.Add(row[0], row[5], row[1],row[2],row[3],row[4],row[6],row[7]);
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

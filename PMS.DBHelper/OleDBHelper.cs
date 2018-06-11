using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace PMS.DBHelper
{
    /// <summary>
    /// OleDB数据源操作类
    /// </summary>
    public class OleDBHelper
    {
        private string strConn;
        private OleDbConnection conn = null;

        /// <summary>
        /// 构造数据源操作类
        /// </summary>
        /// <param name="sourceName">数据源文件名</param>
        public OleDBHelper(string sourceName)
        {
            if (sourceName != "")
            {
                strConn = string.Format("Provider=Microsoft.Jet.Oledb.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", sourceName);
                conn = new OleDbConnection(strConn);
            }
            else
            {
                throw new Exception("指定的Excel文件不存在");
            }
        }

        private void OpenConn()
        {
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        private void CloseConn()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private OleDbCommand CreateCommand(string cmdText, string[] param, object[] values)
        {
            OleDbCommand myCmd = new OleDbCommand(cmdText, conn);
            for (int i = 0; i < param.Length; i++)
            {
                myCmd.Parameters.AddWithValue(param[i], values[i]);
            }
            return myCmd;
        }

        /// <summary>
        /// 根据命令语句返回数据集
        /// </summary>
        /// <param name="cmdText">命令语句</param>
        /// <param name="param">参数数组，若没有参数可以设置为空</param>
        /// <param name="values">参数值数组，只有当param不为空时有效</param>
        /// <returns></returns>
        public DataTable FillDataTable(string cmdText, string[] param, object[] values)
        {
            OpenConn();
            OleDbCommand cmd;
            if (param != null)
            {
                cmd = CreateCommand(cmdText, param, values);
            }
            else
            {
                cmd = new OleDbCommand(cmdText, conn);
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseConn();
            return dt;
        }

        /// <summary>
        /// 返回指定文件所包含的工作簿列表；如果有WorkSheet，就返回以工作簿名字命名的ArrayList，否则返回空
        /// </summary>
        /// <param name="strFilePath">要获取的Excel</param>
        /// <returns>如果有WorkSheet，就返回以工作簿名字命名的ArrayList，否则返回空</returns>
        public ArrayList GetExcelWorkSheets(string strFilePath)
        {
            OpenConn();
            ArrayList alTables = new ArrayList();
            DataTable dt = new DataTable();
            dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            if (dt == null)
            {
                throw new Exception("无法获取指定Excel的架构");
            }
            foreach (DataRow dr in dt.Rows)
            {
                string tempName = dr["Table_Name"].ToString();
                int iDolarIndex = tempName.IndexOf('$');
                if (iDolarIndex > 0)
                {
                    tempName = tempName.Substring(0, iDolarIndex);
                }

                //修正某些工作薄名称为汉字的表无法正确识别的BUG。
                if (tempName[0] == '\'')
                {
                    if (tempName[tempName.Length - 1] == '\'')
                    {
                        tempName = tempName.Substring(1, tempName.Length - 2);
                    }
                    else
                    {
                        tempName = tempName.Substring(1, tempName.Length - 1);
                    }

                }
                if (!alTables.Contains(tempName))
                {
                    alTables.Add(tempName);
                }
            }

            CloseConn();

            if (alTables.Count == 0)
            {
                return null;
            }
            return alTables;
        }

        /// <summary>
        /// 获取指定路径、指定工作簿名称的Excel数据
        /// </summary>
        /// <param name="FilePath">文件存储路径</param>
        /// <param name="WorkSheetName">工作簿名称</param>
        /// <returns>如果找到了数据会返回一个完整的Table，否则返回异常</returns>
        public DataTable GetExcelData(string FilePath, string WorkSheetName)
        {
            OpenConn();
            DataTable dtExcel = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [" + WorkSheetName + "$]", conn);

            adapter.FillSchema(dtExcel, SchemaType.Mapped);
            adapter.Fill(dtExcel);
            CloseConn();
            dtExcel.TableName = WorkSheetName;

            return dtExcel;
        }
    }
}

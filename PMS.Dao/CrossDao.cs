using PMS.Model;
using PMS.DBHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PMS.Dao
{
    public class CrossDao
    {
        SQLHelper db = new SQLHelper();
        /// <summary>
        /// 为学生添加交叉指导教师
        /// </summary>
        /// <param name="cross">交叉指导对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(Cross cross)
        {
            try
            {
                string cmdText = "insert into T_Cross(titleRecordId,teaAccount) values(@titleRecordId,@teaAccount)";
                string[] param = { "@titleRecordId", "@teaAccount" };
                object[] values = { cross.titleRecord.TitleRecordId, cross.teacher.TeaAccount };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据教师账号查找交叉指导数据
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <returns></returns>
        public DataSet Select(string teaAccount)
        {
            try
            {
                string cmdText = "select * from T_Cross where teaAccount=@teaAccount";
                String[] param = { "@teaAccount" };
                String[] values = { teaAccount };
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
        /// 根据学生账号查找交叉指导数据
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public DataSet SelectByStu(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from V_Cross where titleRecordId=@titleRecordId";
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

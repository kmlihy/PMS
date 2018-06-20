using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    /// <summary>
    /// 专业信息数据库操作类
    /// </summary>
    public class ProfessionDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 添加一条专业信息
        /// </summary>
        /// <param name="pro">要添加的专业对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(Profession pro)
        {
            try
            {
                string cmdText = "insert into T_Profession(proName, collegeId) values(@proName, @collegeId)";
                string[] param = { "@proName", "@collegeId" };
                object[] values = { pro.ProName, pro.college.ColID };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 修改一个专业信息
        /// </summary>
        /// <param name="pro">要修改的专业信息对象</param>
        /// <returns>受影响行数</returns>
        public int Update(Profession pro)
        {
            try
            {
                string cmdText = "update T_Profession set proName = @proName,collegeId = @collegeId where  proId = @proId";
                string[] param = { "@proName", "@collegeId", "@proId" };
                object[] values = { pro.ProName, pro.college.ColID, pro.ProId };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 查询所有的专业信息
        /// </summary>
        /// <returns>类型为DataSet的专业信息列表</returns>
        public DataSet Select()
        {
            try
            {
                string cmdText = "select * from V_Profession";
                DataSet ds = db.FillDataSet(cmdText, null, null);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据ID查询一个专业信息
        /// </summary>
        /// <param name="proId">要查询的专业ID</param>
        /// <returns>类型为DataSet的专业信息列表</returns>
        public DataSet Select(int proId)
        {
            try
            {
                string cmdText = "select * from V_Profession where proId = @proId";
                string[] param = { "@proId" };
                object[] values = { proId };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 模糊查询专业信息
        /// </summary>
        /// <param name="likeName">模糊查询条件</param>
        /// <returns>返回一个类型为DataSet的专业信息列表</returns>
        public DataSet Select(string likeName)
        {
            try
            {
                string cmdText = "select * from V_Profession where proName like %@likeName%";
                string[] param = { "@proId" };
                object[] values = { likeName };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 获取一个专业对象
        /// </summary>
        /// <param name="proId">要获取的专业ID</param>
        /// <returns>返回一个类型为Profession的专业对象</returns>
        public Profession GetProfession(int proId)
        {
            try
            {
                string cmdText = "select * from V_Profession where proId = @proId";
                string[] param = { "@proId" };
                object[] values = { proId };
                College college = new College();
                Profession profession = new Profession();
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if(ds.Tables[0].Rows[0]["proId"].ToString() != "" && ds.Tables[0].Rows[0]["proId"].ToString() == proId.ToString())
                    {
                        profession.ProId = int.Parse(ds.Tables[0].Rows[0]["proId"].ToString());
                    }
                    if(ds.Tables[0].Rows[0]["proName"].ToString() != "")
                    {
                        profession.ProName = ds.Tables[0].Rows[0]["proName"].ToString();
                    }
                    if(ds.Tables[0].Rows[0]["collegeId"].ToString() != null)
                    {
                        college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["collegeName"].ToString() != null)
                    {
                        college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                    }
                    if (college != null)
                    {
                        profession.college = college;
                        return profession;
                    }
                }
                return profession;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

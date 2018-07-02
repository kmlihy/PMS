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
    /// 学院信息数据库操作类
    /// </summary>
    public class CollegeDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 添加一个分院信息
        /// </summary>
        /// <param name="college">要添加的学院对象</param>
        /// <returns>返回受影响行数</returns>
        public int Insert(College college)
        {
            try
            {
                string cmdText = "insert into T_College(collegeName) values(@collName)";
                string[] param = { "@collName" };
                object[] values = { college.ColName };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 修改一个学院的名称
        /// </summary>
        /// <param name="college">要修改的学院对象</param>
        /// <returns>返回受影响行数</returns>
        public int Update(College college)
        {
            try
            {
                string cmdText = "update T_College set collegeName = @collName where collegeId = @collId";
                string[] param = { "@collName", "@collId" };
                object[] values = { college.ColName, college.ColID };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有学院信息
        /// </summary>
        /// <returns>类型为DataSet的学院信息列表</returns>
        public DataSet Select()
        {
            try
            {
                string cmdText = "select * from T_College";
                DataSet ds = db.FillDataSet(cmdText, null, null);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据ID查询一个学院的信息
        /// </summary>
        /// <param name="collId">要查询的学院ID</param>
        /// <returns>类型为DataSet的学院信息列表</returns>
        public DataSet Select(int collId)
        {
            try
            {
                string cmdText = "select * from T_College where collegeId = @collId";
                string[] param = { "@collId" };
                object[] values = { collId };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 模糊查询得到一个学院信息
        /// </summary>
        /// <param name="likeName">模糊查询的条件</param>
        /// <returns>类型为DataSet的学院信息列表</returns>
        public DataSet Select(string likeName)
        {
            try
            {
                string cmdText = "select * from T_College where collegeName like %@likeName%";
                string[] param = { "@likeName" };
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
        /// 根据ID删除一个学院信息
        /// </summary>
        /// <param name="collId">学院ID</param>
        /// <returns>受影响行数</returns>
        public int Delete(int collId)
        {
            try
            {
                string cmdText = "delete T_College where collegeId = @collId";
                string[] param = { "@collId" };
                object[] values = { collId };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据ID得到一个学院对象
        /// </summary>
        /// <param name="collId">学院ID</param>
        /// <returns>类型为College的学院信息对象</returns>
        public College GetCollege(int collId)
        {
            try
            {
                string cmdText = "select * from T_College where collegeId = @collId";
                string[] param = { "@collId" };
                object[] values = { collId };
                College college = new College();
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "" && ds.Tables[0].Rows[0]["collegeId"].ToString() == collId.ToString())
                    {
                        college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                    {
                        college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();                        
                    }
                    return college;
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

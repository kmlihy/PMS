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
    /// 批次信息数据库操作类
    /// </summary>
    public class PlanDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 添加一个批次信息
        /// </summary>
        /// <param name="plan">要添加的批次对象</param>
        /// <returns>受影响行数</returns>
        public int Insert(Plan plan)
        {
            try
            {
                string cmdText = "insert into T_Plan(planName, startTime, endTime, state, collegeId) values(@planName,@startTime,@endTime,@state,@collegeId)";
                string[] param = { "@planName", "@startTime", "@endTime", "@state", "@collegeId" };
                object[] values = { plan.PlanName, plan.StartTime, plan.EndTime, plan.State, plan.college.ColID };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 修改一个批次信息
        /// </summary>
        /// <param name="plan">要修改的批次对象</param>
        /// <returns>受影响行数</returns>
        public int Update(Plan plan)
        {
            try
            {
                string cmdText = "update T_Plan set planName = @planName, startTime = @startTime, endTime = @endTime, "
                        + "state = @state, collegeId = @collegeId where planId = @planId";
                string[] param = { "@planName", "@startTime", "@endTime", "@state", "@collegeId", "@planId" };
                object[] values = { plan.PlanName, plan.StartTime, plan.EndTime, plan.State, plan.college.ColID, plan.PlanId };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据ID删除一个批次信息
        /// </summary>
        /// <param name="planId">批次ID</param>
        /// <returns>返回受影响行数</returns>
        public int Delete(int planId)
        {
            try
            {
                string cmdText = "delete T_Plan where planId = @planId";
                string[] param = { "@planId" };
                object[] values = { planId };
                int row = db.ExecuteNoneQuery(cmdText, param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 查询所有的批次信息
        /// </summary>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select()
        {
            try
            {
                string cmdText = "select * from V_Plan";
                DataSet ds = db.FillDataSet(cmdText, null, null);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据批次ID查询一个批次信息
        /// </summary>
        /// <param name="planId">要查询的批次ID</param>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select(int planId)
        {
            try
            {
                string cmdText = "select * from V_Plan where planId = @planId";
                string[] param = { "@planId" };
                object[] values = { planId };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 模糊查询批信息
        /// </summary>
        /// <param name="likeName">模糊查询的条件</param>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select(string likeName)
        {
            try
            {
                string cmdText = "select * from V_Plan where planName like %@likeName%";
                string[] param = { "@planId" };
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
        /// 获得一个批次对象
        /// </summary>
        /// <param name="planId">要获得的批次对象ID</param>
        /// <returns>返回一个类型为Plan的批次信息对象</returns>
        public Plan GetPlan(int planId)
        {
            try
            {
                string cmdText = "select * from V_Plan where planId = @planId";
                string[] param = { "@planId" };
                object[] values = { planId };
                Plan plan = new Plan();
                College college = new College();
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["planId"].ToString() != "" && ds.Tables[0].Rows[0]["planId"].ToString() == planId.ToString())
                    {
                        plan.PlanId = int.Parse(ds.Tables[0].Rows[0]["planId"].ToString());

                        if (ds.Tables[0].Rows[0]["planName"].ToString() != "")
                        {
                            plan.PlanName = ds.Tables[0].Rows[0]["planName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                        {
                            plan.StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["endTime"].ToString() != "")
                        {
                            plan.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["endTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                        {
                            plan.State = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                        {
                            plan.State = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                        {
                            college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                        {
                            college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                        }
                        if (college != null)
                        {
                            plan.college = college;
                            return plan;
                        }                        
                    }                    
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetplanBycollegeId(int collegeId)
        {
            try {
                string cmdText = "select * from V_Plan where collegeId = @collegeId";
                string[] param = { "@collegeId" };
                object[] values = { collegeId };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null)
                {
                    return ds;
                }
                return null;

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

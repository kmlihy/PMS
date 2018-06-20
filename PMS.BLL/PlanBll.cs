using PMS.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Model;
    using System.Data;
    using Result = Enums.OpResult;
    /// <summary>
    /// 批次信息业务处理类
    /// </summary>
    public class PlanBll
    {
        private PlanDao dao = new PlanDao();

        /// <summary>
        /// 添加一条批次信息
        /// </summary>
        /// <param name="plan">要添加的批次对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(Plan plan)
        {
            int row = dao.Insert(plan);
            if(row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 修改一条批次信息
        /// </summary>
        /// <param name="plan">要修改的批次对象</param>
        /// <returns>成功返回Result.更新成功，失败返回Result.更新失败</returns>
        public Result Update(Plan plan)
        {
            int row = dao.Update(plan);
            if(row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }

        /// <summary>
        /// 查询所有批次信息
        /// </summary>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select()
        {
            DataSet ds =  dao.Select();
            if(ds != null && ds.Tables[0].Rows.Count > 0){
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据ID查询批次信息
        /// </summary>
        /// <param name="planId">要查询的批次ID</param>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select(int planId)
        {
            DataSet ds = dao.Select(planId);
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }


    }
}

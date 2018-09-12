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
        private PublicProcedure pubpro = new PublicProcedure();

        /// <summary>
        /// 添加一条批次信息
        /// </summary>
        /// <param name="plan">要添加的批次对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(Plan plan)
        {
            int row = dao.Insert(plan);
            if (row > 0)
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
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>1代表该记录被引用过不能删除，0代表没被引用过可以删除</returns>
        public Result IsDelete(string table, string primarykeyname, string primarykey)
        {
            int row = pubpro.isDelete(table, primarykeyname, primarykey);
            if (row > 0)
            {
                return Result.关联引用;
            }
            else
            {
                return Result.记录不存在;
            }
        }

        /// <summary>
        /// 根据ID删除一个批次信息
        /// </summary>
        /// <param name="planId">批次ID</param>
        /// <returns>成功返回Result.删除成功，失败返回Result.删除失败</returns>
        public Result Delete(int planId)
        {
            int row = dao.Delete(planId);
            if (row > 0)
            {
                return Result.删除成功;
            }
            else
            {
                return Result.删除失败;
            }
        }

        /// <summary>
        /// 查询所有批次信息
        /// </summary>
        /// <returns>类型为DataSet的批次信息列表</returns>
        public DataSet Select()
        {
            DataSet ds = dao.Select();
            return ds;
        }
        /// <summary>
        /// 通过学院id查找批次
        /// </summary>
        /// <param name="collegeId">学院id</param>
        /// <returns></returns>
        public DataSet getPlanByCid(int collegeId)
        {
            DataSet ds = dao.getPlanByCid(collegeId);
            return ds;
        }

        /// <summary>
        /// 根据条间分页查询所有学员信息
        /// </summary>
        /// <param name="tab">参数实体</param>
        /// <param name="intPageCount">总页数（输出参数）</param>
        /// <returns>类型为DataSet的分页学院信息列表集</returns>
        public DataSet SelectBypage(TableBuilder tab, out int intPageCount)
        {
            int pagecount = 0;
            DataSet ds = pubpro.SelectBypage(tab, out intPageCount);
            intPageCount = pagecount;
            return ds;
        }

        /// <summary>
        /// 根据ID查询批次信息
        /// </summary>
        /// <param name="planId">要查询的批次ID</param>
        /// <returns>类型为Plan的批次对象</returns>
        public Plan Select(int planId)
        {
            Plan plan = dao.GetPlan(planId);
            if (plan != null)
            {
                return plan;
            }
            return null;
        }

        /// <summary>
        /// 根据学院ID查询批次信息
        /// </summary>
        /// <param name="collegeId">要查询的学院ID</param>
        /// <returns>返回类型为DataSet的批次信息列表</returns>
        public DataSet GetplanByCollegeId(int collegeId)
        {
            DataSet ds = dao.GetplanBycollegeId(collegeId);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }
        public Plan getPlanId(int collegeId, string startTime)
        {
            return dao.getPlanId(collegeId, startTime);
        }
    }
}

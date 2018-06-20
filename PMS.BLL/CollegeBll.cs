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
    /// 学院信息业务处理类
    /// </summary>
    public class CollegeBll
    {
        private CollegeDao dao = new CollegeDao();

        /// <summary>
        /// 添加学院信息业务方法
        /// </summary>
        /// <param name="coll">要添加的学院对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(College coll)
        {
            int row = dao.Insert(coll);
            if(row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 修改学院信息业务方法
        /// </summary>
        /// <param name="coll">要修改的学院对象</param>
        /// <returns>成功返回Result.更新成功，失败返回Result.更新失败</returns>
        public Result Update(College coll)
        {
            int row = dao.Update(coll);
            if(row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }

        /// <summary>
        /// 查询所有学院信息
        /// </summary>
        /// <returns>类型为DataSet的学院信息列表</returns>
        public DataSet Select()
        {
            DataSet ds = dao.Select();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据ID查询所有学院信息
        /// </summary>
        /// <param name="collId">要查询的学院ID</param>
        /// <returns>类型为DataSet的学院信息列表</returns>
        public DataSet Select(int collId)
        {
            DataSet ds = dao.Select(collId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
    }
}

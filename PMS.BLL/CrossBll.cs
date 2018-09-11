using PMS.Dao;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    public class CrossBll
    {
        CrossDao crossDao = new CrossDao();
        /// <summary>
        /// 为学生添加交叉指导教师
        /// </summary>
        /// <param name="cross">交叉指导对象</param>
        /// <returns>受影响行数</returns>
        public Result Insert(Cross cross)
        {
            int row = crossDao.Insert(cross);
            if (row > 0)
            {
                return Result.添加成功;
            }
            else
            {
                return Result.添加失败;
            }
        }
        /// <summary>
        /// 根据教师账号查找交叉指导数据
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <returns></returns>
        public DataSet Select(string teaAccount)
        {
            DataSet ds = crossDao.Select(teaAccount);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }
    }
}

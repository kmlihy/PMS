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
        private PublicProcedure pubpro = new PublicProcedure();
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
        public DataSet SelectByTea(string teaAccount)
        {
            DataSet ds = crossDao.SelectByTea(teaAccount);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据学生账号查找交叉指导记录
        /// </summary>
        /// <param name="stuAccounr">学生账号</param>
        /// <returns></returns>
        public DataSet SelectByStu(string stuAccounr)
        {
            DataSet ds = crossDao.SelectByStu(stuAccounr);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据选题记录id查找交叉指导数据
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet Select(int titleRecordId)
        {
            DataSet ds = crossDao.Select(titleRecordId);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据条间分页查询所有选题记录信息
        /// </summary>
        /// <param name="tab">参数实体</param>
        /// <param name="intPageCount">总页数（输出参数）</param>
        /// <returns>类型为DataSet的分页选题记录信息列表集</returns>
        public DataSet SelectBypage(TableBuilder tab, out int intPageCount)
        {
            DataSet ds = pubpro.SelectBypage(tab, out intPageCount);
            return ds;
        }
    }
}

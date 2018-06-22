using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Dao;
    using Model;
    using System.Data;
    using Result = Enums.OpResult;
    /// <summary>
    /// 选题记录信息业务处理类
    /// </summary>
    public class TitleRecordBll
    {
        private TitleRecordDao dao = new TitleRecordDao();
        private PublicProcedure pubpro = new PublicProcedure();

        /// <summary>
        /// 添加一条选题记录信息
        /// </summary>
        /// <param name="record">要添加的选题记录对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(TitleRecord record)
        {
            int row = dao.Insert(record);
            if(row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 修改一条选题记录信息
        /// </summary>
        /// <param name="record">要修改的选题记录对象</param>
        /// <returns>成功返回Result.更新成功，失败返回Result.更新失败</returns>
        public Result Update(TitleRecord record)
        {
            int row = dao.Update(record);
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
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
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 查询所有选题记录信息
        /// </summary>
        /// <returns>类型为DataSet的选题记录信息列表</returns>
        public DataSet Select()
        {
            DataSet ds = dao.Select();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 根据选题记录ID查询一个批次信息
        /// </summary>
        /// <param name="planId">要查询的选题记录ID</param>
        /// <returns>类型为DataSet的选题记录信息列表</returns>
        public TitleRecord Select(int recordId)
        {
            TitleRecord plan = dao.GetTitleRecord(recordId);
            if (plan != null)
            {
                return plan;
            }
            return null;
        }
    }
}

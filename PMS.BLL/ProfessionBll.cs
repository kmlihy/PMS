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
    /// 专业信息业务处理类
    /// </summary>
    public class ProfessionBll
    {
        private ProfessionDao dao = new ProfessionDao();
        private PublicProcedure pubpro = new PublicProcedure();

        /// <summary>
        /// 添加一个专业信息
        /// </summary>
        /// <param name="pro">要添加的专业对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(Profession pro)
        {
            int row = dao.Insert(pro);
            if(row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 修改一个专业信息
        /// </summary>
        /// <param name="pro">要修改的专业对象</param>
        /// <returns>成功返回Result.更新成功，失败返回Result.更新失败</returns>
        public Result Update(Profession pro)
        {
            int row = dao.Update(pro);
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }

        /// <summary>
        /// 查询所有专业信息
        /// </summary>
        /// <returns>类型为DataSet的专业信息列表</returns>
        public DataSet Select()
        {
            DataSet ds = dao.Select();
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

            DataSet ds = pubpro.SelectBypage(tab, out intPageCount);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据ID查询专业信息
        /// </summary>
        /// <param name="proId">要查询的专业ID</param>
        /// <returns>类型为DataSet的专业信息列表</returns>
        public Profession Select(int proId)
        {
            Profession pro = dao.GetProfession(proId);
            if (pro != null)
            {
                return pro;
            }
            return null;
        }
    }
}

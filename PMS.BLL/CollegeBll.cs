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
        private PublicProcedure pubpro = new PublicProcedure();

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
        /// 判断在另外一张表中是否有数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>1代表该记录被引用过不能删除，0代表没被引用过可以删除</returns>
        public Result IsDelete(string table, string primarykeyname, string primarykey)
        {
            int row = pubpro.isDelete(table, primarykeyname, primarykey);
            if(row > 0)
            {
                return Result.关联引用;
            }
            else
            {
                return Result.记录不存在;
            }
        }

        /// <summary>
        /// 根据ID删除学院信息
        /// </summary>
        /// <param name="collId">学院ID</param>
        /// <returns>成功返回Result.删除成功，失败Result.删除失败</returns>
        public Result Delete(int collId)
        {
            int row = dao.Delete(collId);
            if(row > 0)
            {
                return Result.删除成功;
            }
            else
            {
                return Result.删除失败;
            }
        }

        /// <summary>
        /// 查询所有学院信息
        /// </summary>
        /// <returns>类型为DataSet的学院信息列表</returns>
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
        public DataSet SelectBypage(TableBuilder tab,out int intPageCount)
        {
            int pagecount;
            DataSet ds = pubpro.SelectBypage(tab, out pagecount);
            intPageCount = pagecount;
            return ds;
        }

        /// <summary>
        /// 根据ID查询学院信息
        /// </summary>
        /// <param name="collId">要查询的学院ID</param>
        /// <returns>类型为College的学院对象</returns>
        public College getSelect(int collId)
        {
            College coll = dao.GetCollege(collId);
            if(coll != null)
            {
                return coll;
            }
            return null;
        }
    }
}

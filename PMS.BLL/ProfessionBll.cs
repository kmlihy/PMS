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
        /// 判断专业名称的存在
        /// </summary>
        /// <param name="ProName"></param>
        /// <returns></returns>
        public Result isProName(string ProName)
        {
            int row = dao.isProName(ProName);
            if (row > 0)
            {
                return Result.记录存在;
            }
            else
            {
                return Result.记录不存在;
            }
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
        /// 根据ID删除专业信息
        /// </summary>
        /// <param name="proId">专业ID</param>
        /// <returns>成功返回Result.删除成功，失败返回Result.删除失败</returns>
        public Result Delete(int proId)
        {
            int row = dao.Delete(proId);
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
            return ds;
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
        /// <summary>
        /// 根据专业所属分院ID查询专业
        /// </summary>
        /// <param name="collegeId">该专业所属分院ID</param>
        /// <returns>类型为DataSet的专业信息列表</returns>
        public DataSet SelectByCollegeId(int collegeId) {
            DataSet pro = dao.GetProfessionByCollegeId(collegeId);
            if (pro!=null) {
                return pro;
            }
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public Result upload(DataTable dt)
        {
            int row = dao.upload(dt);
            if(row > 0)
            {
                return Result.添加失败;
            }
            else
            {
                return Result.添加成功;
            }
        }
    }
}

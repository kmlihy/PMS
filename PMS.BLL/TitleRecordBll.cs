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
        /// 通过学生账号取到选题记录id
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public TitleRecord getRtId(string stuAccount)
        {
            return dao.getRtId(stuAccount);
        }

        public TitleRecord getRtIdByTea(string stuAccount, string teaAccount)
        {
            return dao.getRtIdByTea(stuAccount,teaAccount);
        }

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
        /// 根据学生账号查找是否有选题记录
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public bool selectBystuId(string stuAccount)
        {
            int count = dao.selectBystuId(stuAccount);
            if (count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        ///<param name = "table" > 表名 </ param >
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>管理引用代表数据存在不可删除，记录不存在表示可以删除</returns>
        public Enums.OpResult IsDelete(string table, string primarykeyname, string primarykey)
        {
            int row = pubpro.isDelete(table, primarykeyname, primarykey);
            if (row > 0)
            {
                return Enums.OpResult.关联引用;
            }
            else
            {
                return Enums.OpResult.记录不存在;
            }
        }
        /// <summary>
        /// 根据id删除一条记录
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns>返回结果</returns>
        public Result delete(int titleRecordId)
        {
            int row = dao.delete(titleRecordId);
            if (row>0)
            {
                return Result.删除成功;
            }
            else
            {
                return Result.删除失败;
            }
        }

        /// <summary>
        /// 导出成Excel表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回一个DataTable的选题记录集合</returns>
        public DataTable ExportExcel(string strWhere)
        {
            DataTable dt = dao.ExportExcel(strWhere);
            if(dt != null && dt.Rows.Count > 0)
            {
                return dt;
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
        /// 根据学生或教师账号获取选题记录信息
        /// </summary>
        /// <param name="account">学生或教师账号</param>
        /// <returns>选题记录对象</returns>
        public DataSet GetByAccount(string account)
        {
            DataSet ds = dao.GetByAccount(account);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            return null;
        }
    }
}

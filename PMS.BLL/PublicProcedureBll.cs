using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using static PMS.BLL.Enums;

namespace PMS.BLL
{
     public class PublicProcedureBll
    {
        PMS.Dao.PublicProcedure dao = new Dao.PublicProcedure();

        /// <summary>
        /// 根据TableBuilder实体返回DataSet数据
        /// </summary>
        /// <param name="tablebuilder"></param>
        /// <param name="intPageCount"></param>
        /// <returns></returns>
        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount)
        {
            int pagecount;
            DataSet ds = dao.SelectBypage(tablebuilder, out pagecount);
            intPageCount = pagecount;
            return ds;
        }

        /// <summary>
        /// 添加选题记录使题目的选题人数加1
        /// </summary>
        /// <param name="titlerecord">选题记录实体</param>
        /// <returns>返回0代表失败返回其他表示添加数据成功(返回的值是选题记录的主键)/returns>
        public int AddTitlerecord(TitleRecord titlerecord)
        {
            int isSuccess = 0;
            dao.AddTitlerecord(titlerecord,out isSuccess);
            if (isSuccess == 0)
            {
                return 0;
            }
            else {
                return isSuccess;
            }
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>管理引用代表数据存在不可删除，记录不存在表示可以删除</returns>
        public OpResult isDelete(string table, string primarykeyname, string primarykey)
        {
            int row = dao.isDelete(table, primarykeyname, primarykey);
            if (row>0) {
                return OpResult.关联引用;
            }
            else {
                return OpResult.记录不存在;
            }
        }
     }
}

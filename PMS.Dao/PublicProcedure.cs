using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    public class PublicProcedure
    {
        private SQLHelper db = new SQLHelper();

        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("sp_page ");
            SqlParameter[] values = {
                new SqlParameter("@strTable", SqlDbType.VarChar),
                new SqlParameter("@strColumn", SqlDbType.VarChar),
                new SqlParameter("@intColType", SqlDbType.Int),
                new SqlParameter("@intOrder", SqlDbType.Int),
                new SqlParameter("@strColumnlist", SqlDbType.VarChar),
                new SqlParameter("@intPageSize", SqlDbType.Int),
                new SqlParameter("@intPageNum", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar),
                new SqlParameter("@intPageCount", SqlDbType.Int)
            };
            values[0].Value = tablebuilder.StrTable;
            values[1].Value = tablebuilder.StrColumn;
            values[2].Value = tablebuilder.IntColType;
            values[3].Value = tablebuilder.IntOrder;
            values[4].Value = tablebuilder.StrColumnlist;
            values[5].Value = tablebuilder.IntPageSize;
            values[6].Value = tablebuilder.IntPageNum;
            values[7].Value = tablebuilder.StrWhere;
            values[8].Direction = ParameterDirection.Output;

            DataSet ds = db.FillDataSetBySP(strSql.ToString(), values);
            intPageCount = Convert.ToInt32(values[8].Value);
            return ds;
        }
        /// <summary>
        /// 添加选题记录使题目的选题人数加1
        /// </summary>
        /// <param name="titlerecord">选题记录实体</param>
        /// <returns></returns>
        public DataSet AddTitlerecord(TitleRecord titlerecord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("AddTitlerecord");
            SqlParameter[] values = {
                new SqlParameter("@stuAccount", SqlDbType.VarChar),
                new SqlParameter("@titleId", SqlDbType.Int),
                new SqlParameter("@defeseTeamId", SqlDbType.Int),
            };
            values[0].Value = titlerecord.title;
            values[1].Value = titlerecord.student;
            values[2].Value = titlerecord.DefeseTeamId;
            DataSet ds = db.FillDataSetBySP(strSql.ToString(), values);
            return ds;
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        /// <param name="table">表名</param>
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns></returns>
        public int isDelete(string table,string primarykeyname, string primarykey) {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select count(*) as count from @table where @primarykeyname=@primarykey");
            string[] param = { "@table", "@primarykeyname", "@primarykey"};
            object[] values = {table,primarykey,primarykeyname};
            DataSet ds =db.FillDataSet(strBuilder.ToString(),param,values);
            if (int.Parse(ds.Tables[0].Rows[0]["count"].ToString()) > 0)
            {
                return 1;
            }
            else {
                return 0;
            }
        }
    }
}

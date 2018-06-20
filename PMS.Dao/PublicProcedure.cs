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
    }
}

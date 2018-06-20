using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PMS.DBHelper;

namespace PMS.Dao
{
    class News
    {
        SQLHelper db = new SQLHelper();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public DataSet select(String search)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_News");
            strSql.Append("where @search");
            String[] param = { "@search" };
            String[] value = { search };
            return db.FillDataSet(strSql.ToString(),param,value);
        }
    }
}

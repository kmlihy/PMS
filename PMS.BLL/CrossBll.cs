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
        CrossDao crossDao = new CrossDao();
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

        public DataSet Select(string teaAccount)
        {
            DataSet ds = crossDao.Select(teaAccount);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }
    }
}

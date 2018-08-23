using PMS.Dao;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    /// <summary>
    /// 成绩业务处理类
    /// </summary>
    public class ScoreBll
    {
        ScoreDao sdao = new ScoreDao();
        public Result Insert(Score score)
        {
            int row = sdao.Insert(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
    }
}

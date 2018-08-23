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
    /// 指导记录业务处理类
    /// </summary>
    public class GuideRecordBll
    {
        /// <summary>
        /// 添加一条指导记录
        /// </summary>
        /// <param name="guide">指导记录对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(GuideRecord guide)
        {
            GuideRecordDao gdao = new GuideRecordDao();
            int row = gdao.Insert(guide);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
    }
}

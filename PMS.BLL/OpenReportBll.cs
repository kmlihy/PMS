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
    /// 开题报告业务处理类
    /// </summary>
    public class OpenReportBll
    {
        OpenReportDao odao = new OpenReportDao();
        /// <summary>
        /// 学生提交开题报告
        /// </summary>
        /// <param name="report">开题报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result stuInsert(OpenReport report)
        {
            int row = odao.stuInsert(report);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 教师提交评阅开题报告意见
        /// </summary>
        /// <param name="report">开题报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result teaInsert(OpenReport report)
        {
            int row = odao.teaInsert(report);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
    }
}

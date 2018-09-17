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
    /// <summary>
    /// 成绩业务处理类
    /// </summary>
    public class ScoreBll
    {
        ScoreDao sdao = new ScoreDao();
        /// <summary>
        /// 添加指导成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>添加结果</returns>
        public Result insertInstructorsComments(Score score)
        {
            int row = sdao.insertInstructorsComments(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 添加交叉指导成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns></returns>
        public Result updateCrossGuide(Score score)
        {
            int row = sdao.updateCrossGuide(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            else
            {
                return Result.添加失败;
            }
        }

        /// <summary>
        /// 通过titleRecordId获取当前状态
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public Score getState(string titleRecordId)
        {
            return sdao.getState(titleRecordId);
        }

        /// <summary>
        /// 答辩小组意见及成绩评定等级
        /// </summary>
        /// <param name="score">成绩实体类</param>
        /// <returns>返回添加失败或者成功</returns>
        public Result updatereplyPanelsOpinion(Score score)
        {
            int row = sdao.updatereplyPanelsOpinion(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        public Result openScore(int state, int planId)
        {
            int row = sdao.openScore(state, planId);
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }
        public Result selectSate(int openState, int planId)
        {
            int row = sdao.selectSate(openState, planId);
            if (row > 0)
            {
                return Result.记录存在;
            }
            return Result.记录不存在;
        }
        /// <summary>
        /// 根据学生账号、批次id获取成绩
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="planId">批次id</param>
        /// <returns></returns>
        public DataSet Select(string stuAccount, int planId)
        {
            DataSet ds = sdao.Select(stuAccount, planId);
            if (ds != null)
            {
                return ds;
            }
            return null;
        }

        /// <summary>
        /// 导出成Excel表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回一个DataTable的选题记录集合</returns>
        public DataTable ExportExcel(string strWhere,Score score)
        {
            DataTable dt = sdao.ExportExcel(strWhere,score);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 添加成绩占比
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>添加结果</returns>
        public Result insertRatio(Score score)
        {
            int row = sdao.insertRatio(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }

        /// <summary>
        /// 获取成绩占比
        /// </summary>
        /// <returns></returns>
        public Score getRatio()
        {
            return sdao.getRatio();
        }
    }
}

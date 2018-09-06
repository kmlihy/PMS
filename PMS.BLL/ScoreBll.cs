﻿using PMS.Dao;
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
        /// 添加成绩
        /// </summary>
        /// <param name="score">成绩对象</param>
        /// <returns>添加结果</returns>
        public Result insertCrossGuide(Score score)
        {
            int row = sdao.insertCrossGuide(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        public Result insertInstructorsComments(Score score)
        {
            int row = sdao.insertInstructorsComments(score);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        public Result insertreplyPanelsOpinion(Score score)
        {
            int row = sdao.insertreplyPanelsOpinion(score);
            if (row>0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
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
    }
}

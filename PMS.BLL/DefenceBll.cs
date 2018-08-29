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
    /// 答辩业务处理类
    /// </summary>
    public class DefenceBll
    {
        DefenceDao dedao = new DefenceDao();
        /// <summary>
        /// 添加答辩小组
        /// </summary>
        /// <param name="defence">答辩小组对象</param>
        /// <returns></returns>
        public Result InsertGroup(DefenceGroup defence)
        {
            int row = dedao.InsertGroup(defence);
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
        /// 根据答辩小组id查找答辩小组
        /// </summary>
        /// <param name="defenGroupId">答辩小组id</param>
        /// <returns></returns>
        public DefenceGroup SelectGroup(int defenGroupId)
        {
            DataSet ds = dedao.SelectGroup(defenGroupId);
            DefenceGroup defence = new DefenceGroup();
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                defence.leader = ds.Tables[0].Rows[0]["leader"].ToString();
                defence.member = ds.Tables[0].Rows[0]["member"].ToString();
                defence.recorder = ds.Tables[0].Rows[0]["recorder"].ToString();
                defence.plan.PlanId = Convert.ToInt32(ds.Tables[0].Rows[0]["planId"].ToString());
                return defence;
            }
            return null;
        }

        /// <summary>
        /// 添加答辩记录
        /// </summary>
        /// <param name="defence">答辩记录对象</param>
        /// <returns></returns>
        public Result InsertRecord(DefenceRecord defence)
        {
            int row = dedao.InsertRecord(defence);
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
        /// 根据选题记录id查找答辩记录信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DefenceRecord SelectRecord(int titleRecordId)
        {
            DataSet ds = dedao.SelectRecord(titleRecordId);
            DefenceRecord defence = new DefenceRecord();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                defence.titleRecord.TitleRecordId = Convert.ToInt32(ds.Tables[0].Rows[0]["titleRecordId"].ToString());
                defence.defenceGroup.defenGroupId = Convert.ToInt32(ds.Tables[0].Rows[0]["member"].ToString());
                defence.recordContent = ds.Tables[0].Rows[0]["recordContent"].ToString();
                return defence;
            }
            return null;
        }
    }
}

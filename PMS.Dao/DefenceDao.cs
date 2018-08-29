﻿using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    /// <summary>
    /// 答辩数据访问类
    /// </summary>
    public class DefenceDao
    {
        private SQLHelper db = new SQLHelper();
        /// <summary>
        /// 添加答辩小组
        /// </summary>
        /// <param name="defence">答辩小组对象</param>
        /// <returns>受影响行数</returns>
        public int InsertGroup(DefenceGroup defence)
        {
            try
            {
                string cmdText = "insert into T_DefenceGroup(leader,member,recorder,planId) values(@leader,@member,@recorder,@planId)";
                string[] param = { "@leader", "@member", "@recorder", "@planId" };
                object[] values = { defence.leader, defence.member, defence.recorder, defence.plan.PlanId };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据答辩小组id查找答辩小组
        /// </summary>
        /// <param name="defenGroupId">答辩小组id</param>
        /// <returns></returns>
        public DataSet SelectGroup(int defenGroupId)
        {
            try
            {
                string cmdText = "select * from T_DefenceGroup where defenGroupId=@defenGroupId";
                String[] param = { "@defenGroupId" };
                String[] values = { defenGroupId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 添加答辩记录
        /// </summary>
        /// <param name="defence">答辩记录对象</param>
        /// <returns></returns>
        public int InsertRecord(DefenceRecord defence)
        {
            try
            {
                string cmdText = "insert into T_DefenceRecord(titleRecordId,defenGroupId,recordContent) values(@titleRecordId,@defenGroupId,@recordContent)";
                string[] param = { "@titleRecordId", "@defenGroupId", "@recordContent" };
                object[] values = { defence.titleRecord.TitleRecordId, defence.defenceGroup.defenGroupId, defence.recordContent };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 根据选题记录id查找答辩记录信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet SelectRecord(int titleRecordId)
        {
            try
            {
                string cmdText = "select * from T_DefenceGroup where titleRecordId=@titleRecordId";
                String[] param = { "@titleRecordId" };
                String[] values = { titleRecordId.ToString() };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                if (ds != null)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

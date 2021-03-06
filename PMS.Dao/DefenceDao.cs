﻿using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    /// <summary>
    /// 答辩数据库操作类
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
                string cmdText = "insert into T_DefenceGroup(leader,member,recorder,planId,leaderName,memberName,recordName) values(@leader,@member,@recorder,@planId,@leaderName,@memberName,@recordName)";
                string[] param = { "@leader", "@member", "@recorder", "@planId" , "@leaderName", "@memberName" , "@recordName" };
                object[] values = { defence.leader, defence.member, defence.recorder, defence.plan.PlanId ,defence.leaderName,defence.memberName,defence.recordName};
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

        public int isGroup(string titleRecordId)
        {
            string sql = "select count(defenRecordId) from T_DefenceRecord where titleRecordId=@titleRecordId";
            string[] param = { "@titleRecordId" };
            object[] values = { titleRecordId };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 通过defenGroupId分别取到leader，member，recorder
        /// </summary>
        /// <param name="dgId">defenGroupId</param>
        /// <returns></returns>
        public DefenceGroup getTeaId(string dgId)
        {
            string sql = "select leader,member,recorder from T_DefenceGroup where defenGroupId=@dgId";
            string[] param = { "@dgId" };
            object[] values = { dgId };
            DefenceGroup defenceGroup = new DefenceGroup();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                defenceGroup.leader = reader.GetString(0);
                defenceGroup.member = reader.GetString(1);
                defenceGroup.recorder = reader.GetString(2);
            }
            reader.Close();
            return defenceGroup; ;
        }

        /// <summary>
        /// 通过选题记录id取到答辩小组id
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DefenceGroup getDgId(string titleRecordId)
        {
            string sql = "select top 1 defenGroupId from T_DefenceRecord where titleRecordId=@titleRecordId order by defenRecordId desc";
            string[] param = { "@titleRecordId" };
            object[] values = { titleRecordId };
            DefenceGroup defenceGroup = new DefenceGroup();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                defenceGroup.defenGroupId = reader.GetInt32(0);
            }
            reader.Close();
            return defenceGroup; ;
        }

        /// <summary>
        /// 添加答辩记录
        /// </summary>
        /// <param name="defence">答辩记录对象</param>
        /// <returns></returns>
        public int UpdateRecord(DefenceRecord defence)
        {
            try
            {
                string cmdText = "update T_DefenceRecord set recordContent = @recordContent , dateTime=@dateTime where titleRecordId = @titleRecordId";
                string[] param = { "@titleRecordId", "@recordContent","@dateTime" };
                object[] values = { defence.titleRecord.TitleRecordId, defence.recordContent ,defence.dateTime};
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
        public DataSet SelectRecord(string titleRecordId)
        {
            try
            {
                string cmdText = "select * from V_DefenceRecord where titleRecordId=@titleRecordId";
                String[] param = { "@titleRecordId" };
                String[] values = {titleRecordId };
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
        /// 添加答辩学生
        /// </summary>
        /// <param name="defence">答辩记录对象</param>
        /// <returns></returns>
        public int InsertStudent(DefenceRecord defence)
        {
            try
            {
                string cmdText = "insert into T_DefenceRecord(titleRecordId,defenGroupId) values(@titleRecordId,@defenGroupId)";
                string[] param = { "@titleRecordId", "@defenGroupId" };
                object[] values = { defence.titleRecord.TitleRecordId, defence.defenceGroup.defenGroupId };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除答辩记录
        /// </summary>
        /// <param name="defenRecordId">答辩记录id</param>
        /// <returns></returns>
        public int DelRecord(int defenRecordId)
        {
            try
            {
                string cmdText = "delete from T_DefenceRecord where defenRecordId = @defenRecordId";
                string[] param = { "@defenRecordId"};
                object[] values = { defenRecordId.ToString()};
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

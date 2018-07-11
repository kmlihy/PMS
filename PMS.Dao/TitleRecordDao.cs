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
    /// 选题记录信息数据库操作类
    /// </summary>
    public class TitleRecordDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 添加一条选题记录信息
        /// </summary>
        /// <param name="record">选题信息实体</param>
        /// <returns>受影响行数</returns>
        public int Insert(TitleRecord record)
        {
            try
            {
                string cmdText = "insert into T_TitleRecord(stuAccount, titleId, defeseTeamId, recordCreateTime) values(@stuAccount,@titleId,@defeseTeamId,@recordCreateTime)";
                string[] param = { "@stuAccount", "@titleId", "@defeseTeamId", "@recordCreateTime" };
                object[] values = { record.student.StuAccount, record.title.TitleId, record.DefeseTeamId, record.recordCreateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 修改一条选题记录信息
        /// </summary>
        /// <param name="record">选题信息实体</param>
        /// <returns>受影响行数</returns>
        public int Update(TitleRecord record)
        {
            try
            {
                string cmdText = "update T_TitleRecord set stuAccount = @stuAccount, titleId = @titleId, defeseTeamId = @defeseTeamId, recordCreateTime = @recordCreateTime "
                                + " where titleRecordId = @titleRecordId";
                string[] param = { "@stuAccount", "@titleId", "@defeseTeamId", "@titleRecordId", "@recordCreateTime" };
                object[] values = { record.student.StuAccount, record.title.TitleId, record.DefeseTeamId, record.TitleRecordId, record.recordCreateTime };
                int row = db.ExecuteNoneQuery(cmdText.ToString(), param, values);
                return row;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 根据选题记录id删除一条选题记录
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns>受影响行数</returns>
        public int delete(int titleRecordId)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("delete T_TitleRecord");
            stringBuilder.Append(" where titleRecordId = @titleRecordId");
            string[] param = { "@titleRecordId" };
            object[] value = { titleRecordId };
            int row = db.ExecuteNoneQuery(stringBuilder.ToString(), param, value);
            return row;
        }

        /// <summary>
        /// 查询所有的选题记录信息
        /// </summary>
        /// <returns>类型为DataSet的选题记录信息列表</returns>
        public DataSet Select()
        {
            try
            {
                string cmdText = "select * from V_TitleRecord";
                DataSet ds = db.FillDataSet(cmdText, null, null);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 根据选题记录ID查询一个批次信息
        /// </summary>
        /// <param name="planId">要查询的选题记录ID</param>
        /// <returns>类型为DataSet的选题记录信息列表</returns>
        public DataSet Select(int recordId)
        {
            try
            {
                string cmdText = "select * from V_TitleRecord where titleRecordId = @titleRecordId";
                string[] param = { "@titleRecordId" };
                object[] values = { recordId };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 导出成Excel表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回一个DataTable的选题记录集合</returns>
        public DataTable ExportExcel(string strWhere)
        {
            String cmdText = string.Format("select titleRecordId as 题目编号,title as 题目名称,stuAccount as 学生学号,realName as 学生姓名,teaAccount as 教师工号,teaName as 教师名称,collegeName as 所属学院,planName as 所属批次,createTime as 选题时间 from V_TitleRecord {0}",strWhere);
            DataSet ds = db.FillDataSet(cmdText, null, null);
            DataTable dt = null;
            if(ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 获得一个选题记录信息
        /// </summary>
        /// <param name="recordId">要获得的选题记录ID</param>
        /// <returns>返回一个类型为TitleRecord的选题记录对象</returns>
        public TitleRecord GetTitleRecord(int recordId)
        {
            try
            {
                string cmdText = "select * from V_TitleRecord where titleRecordId = @titleRecordId";
                string[] param = { "@titleRecordId" };
                object[] values = { recordId };
                DataSet ds = db.FillDataSet(cmdText, param, values);

                TitleRecord titleRecord = new TitleRecord();
                Student student = new Student();
                Title title = new Title();
                Plan plan = new Plan();
                Profession prodession = new Profession();
                Teacher teacher = new Teacher();
                College college = new College();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["titleRecordId"].ToString() != "" && ds.Tables[0].Rows[0]["titleRecordId"].ToString() == recordId.ToString())
                    {
                        titleRecord.TitleRecordId = int.Parse(ds.Tables[0].Rows[0]["titleRecordId"].ToString());
                        if (ds.Tables[0].Rows[0]["stuAccount"].ToString() != "")
                        {
                            student.StuAccount = ds.Tables[0].Rows[0]["stuAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["titleId"].ToString() != "")
                        {
                            title.TitleId = int.Parse(ds.Tables[0].Rows[0]["titleId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["defeseTeamId"].ToString() != "")
                        {
                            titleRecord.DefeseTeamId = int.Parse(ds.Tables[0].Rows[0]["defeseTeamId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["stuPwd"].ToString() != "")
                        {
                            student.StuPwd = ds.Tables[0].Rows[0]["stuPwd"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["realName"].ToString() != "")
                        {
                            student.RealName = ds.Tables[0].Rows[0]["realName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                        {
                            student.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["phone"].ToString() != "")
                        {
                            student.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                        {
                            student.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["proId"].ToString() != "")
                        {
                            prodession.ProId = int.Parse(ds.Tables[0].Rows[0]["proId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["proName"].ToString() != "")
                        {
                            prodession.ProName = ds.Tables[0].Rows[0]["proName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["title"].ToString() != "")
                        {
                            title.title = ds.Tables[0].Rows[0]["title"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["titleContent"].ToString() != "")
                        {
                            title.TitleContent = ds.Tables[0].Rows[0]["titleContent"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["createTime"].ToString() != "")
                        {
                            title.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["selected"].ToString() != "")
                        {
                            title.Selected = int.Parse(ds.Tables[0].Rows[0]["selected"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["limit"].ToString() != "")
                        {
                            title.Limit = int.Parse(ds.Tables[0].Rows[0]["limit"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["planId"].ToString() != "")
                        {
                            plan.PlanId = int.Parse(ds.Tables[0].Rows[0]["planId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["planName"].ToString() != "")
                        {
                            plan.PlanName = ds.Tables[0].Rows[0]["planName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["teaAccount"].ToString() != "")
                        {
                            teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["teaName"].ToString() != "")
                        {
                            teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["recordCreateTime"].ToString() != "")
                        {
                            titleRecord.recordCreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["recordCreateTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                        {
                            college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                        {
                            college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                        }
                        if (student != null && title != null && plan != null && prodession != null && teacher != null)
                        {
                            titleRecord.student = student;
                            titleRecord.title = title;
                            titleRecord.plan = plan;
                            titleRecord.profession = prodession;
                            titleRecord.teacher = teacher;
                            return titleRecord;
                        }
                    }                    
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

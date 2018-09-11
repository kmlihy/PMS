using PMS.DBHelper;
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
        /// 根据学生或教师账号获取选题记录信息
        /// </summary>
        /// <param name="account">学生或教师账号</param>
        /// <returns>选题记录对象</returns>
        public DataSet GetByAccount(string account)
        {
            try
            {
                string cmdText = "select * from V_TitleRecord where stuAccount = @account or teaAccount = @account";
                string[] param = { "@account" };
                object[] values = { account };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return ds;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 查询是否有选题记录
        /// </summary>
        /// <param name="stuAccount">学号</param>
        /// <returns>影响行数</returns>
        public int selectBystuId(string stuAccount)
        {
            string sql = "select count(stuAccount) from T_TitleRecord where stuAccount=@Account";
            string[] param = { "@Account" };
            object[] values = { stuAccount };
            return Convert.ToInt32(db.ExecuteScalar(sql,param,values));
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
        /// 通过学生账号取到选题记录id
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public TitleRecord getRtId(string stuAccount)
        {
            string sql = "select top 1 titleRecordId from T_TitleRecord where stuAccount=@Account order by createTime desc";
            string[] param = { "@Account" };
            object[] values = { stuAccount };
            TitleRecord titleRecord = new TitleRecord();
            SqlDataReader reader = db.ExecuteReader(sql,param,values);
            while (reader.Read())
            {
                titleRecord.TitleRecordId = reader.GetInt32(0);
            }
            reader.Close();
            return titleRecord;
        }

        /// <summary>
        /// 获取开题报告的state
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public OpenReport getState(int titleRecordId)
        {
            string sql = "select top 1 state from T_OpeningReport where titleRecordId=@titleRecordId order by ID desc";
            string[] param = { "@titleRecordId" };
            object[] values = { titleRecordId };
            OpenReport openReport = new OpenReport();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                openReport.state = reader.GetInt32(0);
            }
            reader.Close();
            return openReport;
        }

        /// <summary>
        /// 通过学生和老师账号获取titleRecordId
        /// </summary>
        /// <param name="stuAccount"></param>
        /// <param name="teaAccount"></param>
        /// <returns></returns>
        public TitleRecord getRtIdByTea(string stuAccount,string teaAccount)
        {
            string sql = "select top 1 titleRecordId from V_TitleRecord where stuAccount=@stuAccount and teaAccount=@teaAccount order by titleRecordId desc";
            string[] param = { "@stuAccount", "teaAccount" };
            object[] values = { stuAccount,teaAccount };
            TitleRecord titleRecord = new TitleRecord();
            SqlDataReader reader = db.ExecuteReader(sql, param, values);
            while (reader.Read())
            {
                titleRecord.TitleRecordId = reader.GetInt32(0);
            }
            reader.Close();
            return titleRecord; ;
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
                    int i = ds.Tables[0].Rows.Count - 1;
                    if (ds.Tables[0].Rows[i]["titleRecordId"].ToString() != "" && ds.Tables[0].Rows[i]["titleRecordId"].ToString() == recordId.ToString())
                    {
                        titleRecord.TitleRecordId = int.Parse(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                        if (ds.Tables[0].Rows[i]["stuAccount"].ToString() != "")
                        {
                            student.StuAccount = ds.Tables[0].Rows[i]["stuAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["titleId"].ToString() != "")
                        {
                            title.TitleId = int.Parse(ds.Tables[0].Rows[i]["titleId"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["realName"].ToString() != "")
                        {
                            student.RealName = ds.Tables[0].Rows[i]["realName"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["sex"].ToString() != "")
                        {
                            student.Sex = ds.Tables[0].Rows[i]["sex"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["phone"].ToString() != "")
                        {
                            student.Phone = ds.Tables[0].Rows[i]["phone"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["Email"].ToString() != "")
                        {
                            student.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["proId"].ToString() != "")
                        {
                            prodession.ProId = int.Parse(ds.Tables[0].Rows[i]["proId"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["proName"].ToString() != "")
                        {
                            prodession.ProName = ds.Tables[0].Rows[i]["proName"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["title"].ToString() != "")
                        {
                            title.title = ds.Tables[0].Rows[i]["title"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["titleContent"].ToString() != "")
                        {
                            title.TitleContent = ds.Tables[0].Rows[i]["titleContent"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["createTime"].ToString() != "")
                        {
                            title.CreateTime = DateTime.Parse(ds.Tables[0].Rows[i]["createTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["selected"].ToString() != "")
                        {
                            title.Selected = int.Parse(ds.Tables[0].Rows[i]["selected"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["limit"].ToString() != "")
                        {
                            title.Limit = int.Parse(ds.Tables[0].Rows[i]["limit"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["planId"].ToString() != "")
                        {
                            plan.PlanId = int.Parse(ds.Tables[0].Rows[i]["planId"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["planName"].ToString() != "")
                        {
                            plan.PlanName = ds.Tables[0].Rows[i]["planName"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["teaAccount"].ToString() != "")
                        {
                            teacher.TeaAccount = ds.Tables[0].Rows[i]["teaAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["teaName"].ToString() != "")
                        {
                            teacher.TeaName = ds.Tables[0].Rows[i]["teaName"].ToString();
                        }
                        if (ds.Tables[0].Rows[i]["recordCreateTime"].ToString() != "")
                        {
                            titleRecord.recordCreateTime = DateTime.Parse(ds.Tables[0].Rows[i]["recordCreateTime"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["collegeId"].ToString() != "")
                        {
                            college.ColID = int.Parse(ds.Tables[0].Rows[i]["collegeId"].ToString());
                        }
                        if (ds.Tables[0].Rows[i]["collegeName"].ToString() != "")
                        {
                            college.ColName = ds.Tables[0].Rows[i]["collegeName"].ToString();
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

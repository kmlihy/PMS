using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.DBHelper;
using PMS.Model;
using System.Data;
using System.Data.SqlClient;

namespace PMS.Dao
{
    /// <summary>
    /// 教师管理员数据库操作类
    /// </summary>
    public class TeacherDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 根据账号与密码获取教师信息
        /// </summary>
        /// <param name="teaAccount">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataSet Select(string teaAccount)
        {
            string cmdText = "select * from T_Teacher where teaAccount = @teaAccount";
            string[] param = { "@teaAccount"};
            object[] values = { teaAccount};
            DataSet ds = db.FillDataSet(cmdText, param, values);            
            return ds;
        }

        /// <summary>
        /// 查询老师账号
        /// </summary>
        /// <returns></returns>
        public DataSet SelectTeaAcount()
        {
            string cmdText = "select teaAccount from T_Teacher";
            DataSet ds = db.FillDataSet(cmdText, null, null);
            return ds;
        }

        /// <summary>
        /// 根据学院ID获取教师信息
        /// </summary>
        /// <param name="teaAccount">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataSet getByColl(int collegeId,string teaAccount)
        {
            string cmdText = "select * from T_Teacher where teaType=1 and collegeId = @collegeId and teaAccount not like @teaAccount";
            string[] param = { "@collegeId", "@teaAccount" };
            object[] values = { collegeId, teaAccount };
            DataSet ds = db.FillDataSet(cmdText, param, values);
            return ds;
        }

        /// <summary>
        /// 向数据库添加一条教师数据
        /// </summary>
        /// <param name="student">教师实体</param>
        /// <returns>受影响行数</returns>
        public int Insert(Teacher teacher)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Teacher(");
            strSql.Append("teaAccount,teaPwd,teaName,sex,phone,Email,collegeId,teaType");
            strSql.Append(") values (");
            strSql.Append("@teaAccount,@teaPwd,@teaName,@sex,@phone,@Email,@collegeId,@teaType)");
            String[] param = { "@teaAccount", "@teaPwd", "@teaName", "@sex", "@phone", "@Email", "@collegeId","@teaType" };
            String[] values = { teacher.TeaAccount, teacher.TeaPwd, teacher.TeaName, teacher.Sex, teacher.Phone, teacher.Email, teacher.college.ColID.ToString(), teacher.TeaType.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 删除教师数据
        /// </summary>
        /// <param name="TeaAccount">教师主键</param>
        /// <returns>受影响行数</returns>
        public int delete(String TeaAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Teacher");
            strSql.Append(" where teaAccount=@teaAccount");
            String[] param = { "@teaAccount" };
            String[] values = { TeaAccount.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 更新教师数据
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns>受影响行数</returns>
        public int Updata(Teacher teacher)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Teacher set ");
            strSql.Append("teaPwd=@teaPwd,");
            strSql.Append("teaName=@teaName,");
            strSql.Append("sex=@sex,");
            strSql.Append("phone=@phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("state=@state,");
            strSql.Append("collegeId=@collegeId,");
            strSql.Append("teaType=@teaType");
            strSql.Append(" where teaAccount=@teaAccount");
            String[] param = { "@teaPwd", "@teaName", "@sex", "@phone", "@Email", "@state", "@collegeId","@teaType", "@teaAccount" };
            String[] values = { teacher.TeaPwd, teacher.TeaName, teacher.Sex, teacher.Phone, teacher.Email, teacher.state.ToString(), teacher.college.ColID.ToString(), teacher.TeaType.ToString(), teacher.TeaAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 更新教师密码
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <param name="teaPwd">教师密码</param>
        /// <returns></returns>
        public int UpdataPwd(string teaAccount, string teaPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Teacher set teaPwd=@teaPwd where teaAccount=@teaAccount");
            String[] param = { "@teaPwd", "@teaAccount" };
            String[] values = { teaPwd, teaAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 根据老师的账号取得实体对象
        /// </summary>
        /// <param name="TeaAccount">老师账号</param>
        /// <returns>Teacher</returns>
        public DataSet GetTeacher(String TeaAccount)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from V_Teacher ");
                strSql.Append(" where teaAccount=@teaAccount");
                String[] param = { "@teaAccount" };
                String[] values = { TeaAccount.ToString() };
                DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
                
                return ds;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///批量导入教师信息 
        /// </summary>
        /// <param name="dt">教师信息列表</param>
        /// <returns>row大于0代表失败，row 小于0代表成功</returns>
        public int upload(DataTable dt)
        {
            string tableName = "T_Teacher";
            List<SqlBulkCopyColumnMapping> list = new List<SqlBulkCopyColumnMapping>();
            list.Add(new SqlBulkCopyColumnMapping("教师工号", "teaAccount"));
            list.Add(new SqlBulkCopyColumnMapping("教师密码", "teaPwd"));
            list.Add(new SqlBulkCopyColumnMapping("教师姓名", "teaName"));
            list.Add(new SqlBulkCopyColumnMapping("教师性别", "sex"));
            list.Add(new SqlBulkCopyColumnMapping("教师电话", "phone"));
            list.Add(new SqlBulkCopyColumnMapping("教师邮箱", "Email"));
            list.Add(new SqlBulkCopyColumnMapping("教师类型", "teaType"));
            list.Add(new SqlBulkCopyColumnMapping("教师所属分院编号", "collegeId"));

            int row = db.BulkInsert(dt, tableName, list);
            return row;
        }
        
        /// <summary>
        /// 查询该教师账号是否存在
        /// </summary>
        /// <param name="stuAccount">工号</param>
        /// <returns>符合条件的记录条数</returns>
        public int selectByteaId(string teaAccount)
        {
            string sql = "select count(teaAccount) from T_Teacher where teaAccount=@teaAccount";
            string[] param = { "@teaAccount" };
            object[] values = { teaAccount };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 查询联系电话是否存在
        /// </summary>
        /// <param name="phone">联系电话</param>
        /// <returns>符合条件的记录条数</returns>
        public int SelectByPhone(string phone)
        {
            string sql = "select count(teaAccount) from T_Teacher where phone = @phone";
            string[] param = { "@phone" };
            object[] values = { phone };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 查询邮箱是否存在
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <returns>符合条件的记录条数</returns>
        public int SelectByEmail(string email)
        {
            string sql = "select count(teaAccount) from T_Teacher where Email = @email";
            string[] param = { "@email" };
            object[] values = { email };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 查询该学院是否已设置过管理员
        /// </summary>
        /// <param name="collegeId">学院ID</param>
        /// <returns>符合条件的记录条数</returns>
        public int SelectByColl(int collegeId)
        {
            string sql = "select count(teaAccount) from T_Teacher where collegeId = @collegeId and teaType = 2";
            string[] param = { "@collegeId" };
            object[] values = { collegeId };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }
        /// <summary>
        /// 通过学院id获取教师信息
        /// </summary>
        /// <param name="collegeId">学院id</param>
        /// <returns></returns>
        public DataSet getLeaderByColl(int collegeId,string teaAccount1,string teaAccount2)
        {
            try
            {
                string cmdText = "select * from T_Teacher where collegeId=@collegeId and teaAccount not like @teaAccount1 and teaAccount not like @teaAccount2 and teaType=1 and state=0";
                string[] param = { "@collegeId" , "@teaAccount1", "@teaAccount2" };
                object[] values = { collegeId , teaAccount1 ,teaAccount2};
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet getMemberByColl(int collegeId, string teaAccount1, string teaAccount2)
        {
            try
            {
                string cmdText = "select * from T_Teacher where collegeId=@collegeId and teaAccount not like @teaAccount1 and teaAccount not like @teaAccount2 and teaType=1 and state=0";
                string[] param = { "@collegeId", "@teaAccount1", "@teaAccount2" };
                object[] values = { collegeId, teaAccount1, teaAccount2 };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet getRecordByColl(int collegeId, string teaAccount1, string teaAccount2)
        {
            try
            {
                string cmdText = "select * from T_Teacher where collegeId=@collegeId and teaAccount not like @teaAccount1 and teaAccount not like @teaAccount2 and teaType=1 and state=0";
                string[] param = { "@collegeId", "@teaAccount1", "@teaAccount2" };
                object[] values = { collegeId, teaAccount1, teaAccount2 };
                DataSet ds = db.FillDataSet(cmdText, param, values);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 更新教师状态
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public int updateState(Teacher teacher)
        {
            try
            {
                string cmdText = "update T_Teacher set state=@state where collegeId=@collegeId";
                string[] param = { "@state", "@collegeId" };
                object[] values = { teacher.state, teacher.college.ColID };
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

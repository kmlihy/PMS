using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.DBHelper;
using PMS.Model;
using System.Data;

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
        public DataSet Select(string teaAccount, string pwd)
        {
            string cmdText = "select * from T_Teacher where teaAccount = @teaAccount and teaPwd = @teaPwd";
            string[] param = { "@teaAccount","@teaPwd" };
            object[] values = { teaAccount, pwd };
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
            String[] param = { "@teaAccount", "@teaPwd", "@teaName", "@sex", "@phone", "@Email", "@collegeId，@teaType" };
            String[] values = { teacher.TeaAccount, teacher.TeaPwd, teacher.TeaName, teacher.Sex, teacher.Phone, teacher.Email, teacher.college.ColID.ToString(), teacher.TeaType.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 删除教师数据
        /// </summary>
        /// <param name="TeaAccount">教师主键</param>
        /// <returns>受影响行数</returns>
        public int delete(int TeaAccount)
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
            strSql.Append("collegeId=@collegeId");
            strSql.Append("teaType=@teaType,");
            strSql.Append(" where teaAccount=@teaAccount");
            String[] param = { "@teaAccount", "@teaPwd", "@teaName", "@sex", "@phone", "@Email", "@collegeId，@teaType", "@teaAccount" };
            String[] values = { teacher.TeaPwd, teacher.TeaName, teacher.Sex, teacher.Phone, teacher.Email, teacher.college.ColID.ToString(), teacher.TeaType.ToString(), teacher.TeaAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 根据条件查询教师
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <returns>DataSet</returns>
        public DataSet Select(String search)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  T_Teacher ");
            strSql.Append(" where @search");
            String[] param = { "@search" };
            String[] values = { search };
            return db.FillDataSet(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 根据老师的账号取得实体对象
        /// </summary>
        /// <param name="TeaAccount">老师账号</param>
        /// <returns>Teacher</returns>
        public Teacher GetModel(int TeaAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Teacher ");
            strSql.Append(" where teaAccount=@teaAccount");
            String[] param = { "@teaAccount" };
            String[] values = { TeaAccount.ToString() };
            DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
            Teacher teacher = new Teacher();
            if (ds.Tables[0].Rows.Count > 0)
            {
                teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                teacher.TeaPwd = ds.Tables[0].Rows[0]["teaPwd"].ToString();
                teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                teacher.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                teacher.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                teacher.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                //并未完成
            }
            else
            {
            }
            return teacher;
        }
    }
}

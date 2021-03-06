﻿using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.Dao
{
    public class StudentDao
    {
        private SQLHelper db = new SQLHelper();

        /// <summary>
        /// 根据账号与密码获取学生信息
        /// </summary>
        /// <param name="stuAccount">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataSet SelectStuAcount()
        {
            string cmdText = "select stuAccount from T_Student";
            DataSet ds = db.FillDataSet(cmdText, null, null);
            return ds;
        }

        public DataSet Select(string stuAccount)
        {
            string cmdText = "select * from T_Student where stuAccount = @stuAccount";
            string[] param = { "@stuAccount" };
            object[] values = { stuAccount };
            DataSet ds = db.FillDataSet(cmdText, param, values);
            return ds;
        }

        /// <summary>
        /// 查询联系电话是否存在
        /// </summary>
        /// <param name="phone">联系电话</param>
        /// <returns>符合条件的记录条数</returns>
        public int SelectByPhone(string phone)
        {
            string sql = "select count(stuAccount) from T_Student where phone = @phone";
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
            string sql = "select count(stuAccount) from T_Student where Email = @email";
            string[] param = { "@email" };
            object[] values = { email };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 查询该账号是否存在
        /// </summary>
        /// <param name="stuAccount">学号</param>
        /// <returns>符合条件的记录条数</returns>
        public int selectBystuId(string stuAccount)
        {
            string sql = "select count(stuAccount) from T_Student where stuAccount=@Account";
            string[] param = { "@Account" };
            object[] values = { stuAccount };
            return Convert.ToInt32(db.ExecuteScalar(sql, param, values));
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        public int Insert(Student student)
        {
            string cmdText = "insert into T_Student(stuAccount,stuPwd,realName,sex,phone,Email,proId,finishYear) values (@stuAccount,@stuPwd,@realName,@sex,@phone,@Email,@proId,@finishYear)";
            String[] param = { "@stuAccount", "@stuPwd", "@realName", "@sex", "@phone", "@Email", "@proId" , "@finishYear" };
            String[] values = { student.StuAccount, student.StuPwd, student.RealName, student.Sex, student.Phone, student.Email, student.profession.ProId.ToString() ,student.finishYear.ToString()};
            return db.ExecuteNoneQuery(cmdText, param, values);
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="StuAccount">学生主键</param>
        /// <returns></returns>
        public int delete(String StuAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete T_Student ");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@stuAccount" };
            String[] values = { StuAccount.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        public int Updata(Student student)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Student set ");
            strSql.Append("realName=@realName,");
            strSql.Append("sex=@sex,");
            strSql.Append("phone=@phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("state=@state,");
            strSql.Append("proId=@proId");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@realName", "@sex", "@phone", "@Email", "@state", "@proId", "@stuAccount" };
            String[] values = { student.RealName, student.Sex, student.Phone, student.Email, student.state.ToString(), student.profession.ProId.ToString(), student.StuAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 更新学生密码
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="stuPwd">学生密码</param>
        /// <returns></returns>
        public int UpdataPwd(string stuAccount, string stuPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Student set stuPwd=@stuPwd where stuAccount=@stuAccount");
            String[] param = { "@stuPwd", "@stuAccount" };
            String[] values = { stuPwd, stuAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 重置学生密码
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="resetPwd">重置的密码</param>
        /// <returns></returns>
        public int ResetPassword(string stuAccount, string resetPwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Student set stuPwd = @resetPwd where stuAccount = @stuAccount");
            String[] param = { "@stuAccount", "@resetPwd" };
            String[] values = { stuAccount, resetPwd };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 根据学生的账号取得实体对象
        /// </summary>
        /// <param name="StuAccount">学生账号</param>
        /// <returns>Student</returns>
        public DataSet GetStudent(String TeaAccount)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * from V_Student ");
                strSql.Append(" where stuAccount=@stuAccount");
                String[] param = { "@stuAccount" };
                String[] values = { TeaAccount.ToString() };
                DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

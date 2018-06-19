using PMS.DBHelper;
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
        /// 添加学生
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        public int Insert(Student student)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Student(");
            strSql.Append("stuAccount,stuPwd,realName,sex,phone,Email,proId");
            strSql.Append(") values (");
            strSql.Append("@stuAccount,@stuPwd,@realName,@sex,@phone,@Email,@proId);");
            String[] param = { "@stuAccount", "@stuPwd", "@realName", "@sex", "@phone", "@Email", "@proId" };
            String[] values = { student.StuAccount, student.StuPwd, student.RealName, student.Sex, student.Phone, student.Email, student.profession.college.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="StuAccount">学生主键</param>
        /// <returns></returns>
        public int delete(int StuAccount)
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
            strSql.Append("stuPwd=@stuPwd,");
            strSql.Append("realName=@realName,");
            strSql.Append("sex=@sex,");
            strSql.Append("phone=@phone,");
            strSql.Append("Email=@Email");
            strSql.Append("proId=@proId,");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@stuPwd", "@realName", "@sex", "@phone", "@Email", "@proId", "@stuAccount" };
            String[] values = { student.StuPwd, student.RealName, student.Sex, student.Phone, student.Email, student.profession.college.ToString(), student.StuAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }
        /// <summary>
        /// 根据条件查询学生
        /// </summary>
        /// <param name="search">搜索条件</param>
        /// <returns>DataSet</returns>
        public DataSet Select(String search)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from  T_Student ");
            strSql.Append(" where @search");
            String[] param = { "@search" };
            String[] values = { search };
            return db.FillDataSet(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 根据学生的账号取得实体对象
        /// </summary>
        /// <param name="StuAccount">学生账号</param>
        /// <returns>Student</returns>
        public Student GetModel(int TeaAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_Student ");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@stuAccount" };
            String[] values = { TeaAccount.ToString() };
            DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
            Student student = new Student();
            if (ds.Tables[0].Rows.Count > 0)
            {
                student.StuAccount = ds.Tables[0].Rows[0]["stuAccount"].ToString();
                student.StuPwd = ds.Tables[0].Rows[0]["stuPwd"].ToString();
                student.RealName = ds.Tables[0].Rows[0]["realName"].ToString();
                student.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                student.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                student.Email = ds.Tables[0].Rows[0]["Email"].ToString();
            }
            else
            {
                // Else block. If condition is false, execute these statements.
            }
            return student;
        }
    }
}

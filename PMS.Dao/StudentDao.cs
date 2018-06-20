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
            String[] values = { student.StuAccount, student.StuPwd, student.RealName, student.Sex, student.Phone, student.Email, student.profession.ProId.ToString() };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
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
            strSql.Append("stuPwd=@stuPwd,");
            strSql.Append("realName=@realName,");
            strSql.Append("sex=@sex,");
            strSql.Append("phone=@phone,");
            strSql.Append("Email=@Email,");
            strSql.Append("proId=@proId");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@stuPwd", "@realName", "@sex", "@phone", "@Email", "@proId", "@stuAccount" };
            String[] values = { student.StuPwd, student.RealName, student.Sex, student.Phone, student.Email, student.profession.ProId.ToString(), student.StuAccount };
            return db.ExecuteNoneQuery(strSql.ToString(), param, values);
        }

        /// <summary>
        /// 根据学生的账号取得实体对象
        /// </summary>
        /// <param name="StuAccount">学生账号</param>
        /// <returns>Student</returns>
        public Student GetStudent(String TeaAccount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from V_Student ");
            strSql.Append(" where stuAccount=@stuAccount");
            String[] param = { "@stuAccount" };
            String[] values = { TeaAccount.ToString() };
            DataSet ds = db.FillDataSet(strSql.ToString(), param, values);
            Student student = new Student();
            Profession profession = new Profession();
            College college = new College();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["stuAccount"].ToString() != "")
                {
                    student.StuAccount = ds.Tables[0].Rows[0]["stuAccount"].ToString();
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
                    profession.ProId = int.Parse(ds.Tables[0].Rows[0]["proId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["proName"].ToString() != "")
                {
                    profession.ProName = ds.Tables[0].Rows[0]["proName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                {
                    college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                {
                    college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                }
                if (profession != null) {
                    student.profession = profession;
                }
                if (college != null)
                {
                    student.college = college;
                }

            }
            else
            {
                // Else block. If condition is false, execute these statements.
            }
            return student;
        }
    }
}

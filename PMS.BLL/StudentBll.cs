using PMS.Dao;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    public class StudentBll
    {
        StudentDao dao = new StudentDao();

        private PublicProcedure pdao = new PublicProcedure();

        /// <summary>
        /// 登录操作
        /// </summary>
        /// <param name="stuAccount"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Student Login(string stuAccount, string pwd)
        {
            DataSet dds = dao.Select(stuAccount);
            //string  stuPwd = ds.Tables[0].Rows[0]["stuPwd"].ToString();
            if (dds != null && dds.Tables[0].Rows.Count == 1)
            {
                DataRow row = dds.Tables[0].Rows[0];
                RSACryptoService rsa = new RSACryptoService();
                if (row["stuAccount"].ToString() == stuAccount && rsa.Decrypt(row["stuPwd"].ToString()) == pwd)
                {
                    Student student = new Student();
                    Profession profession = new Profession();
                    College college = new College();
                    DataSet ds = dao.GetStudent(stuAccount);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["stuAccount"].ToString() != "")
                        {
                            student.StuAccount = ds.Tables[0].Rows[0]["stuAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["stuPwd"].ToString() != "")
                        {
                            student.StuPwd = rsa.Decrypt(ds.Tables[0].Rows[0]["stuPwd"].ToString());
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
                        if (profession != null)
                        {
                            student.profession = profession;
                        }
                        if (college != null)
                        {
                            student.college = college;
                        }
                    }
                    //填充属性
                    return student;
                }
            }
            return null;
        }

        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        public Enums.OpResult Insert(Student student)
        {
            int count = dao.Insert(student);
            if (count > 0)
            {
                return Enums.OpResult.添加成功;
            }
            else
            {
                return Enums.OpResult.添加失败;
            }
        }

        /// <summary>
        /// 判断在另外一张表中是否有数据
        /// </summary>
        ///<param name = "table" > 表名 </ param >
        /// <param name="primarykeyname">主键列</param>
        /// <param name="primarykey">主键参数</param>
        /// <returns>管理引用代表数据存在不可删除，记录不存在表示可以删除</returns>
        public Enums.OpResult IsDelete(string table, string primarykeyname, string primarykey)
        {
            int row = pdao.isDelete(table, primarykeyname, primarykey);
            if (row>0)
            {
                return Enums.OpResult.关联引用;
            }
            else
            {
                return Enums.OpResult.记录不存在;
            }
        }

        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="StuAccount">学生主键</param>
        /// <returns></returns>
        public Enums.OpResult delete(String StuAccount)
        {
            int count = dao.delete(StuAccount);
            if (count > 0)
            {
                return Enums.OpResult.删除成功;
            }
            else
            {
                return Enums.OpResult.删除失败;
            }
        }

        /// <summary>
        /// 更新学生
        /// </summary>
        /// <param name="student">学生实体</param>
        /// <returns></returns>
        public Enums.OpResult Updata(Student student)
        {
            int count = dao.Updata(student);
            if (count > 0)
            {
                return Enums.OpResult.更新成功;
            }
            else
            {
                return Enums.OpResult.更新失败;
            }
        }

        /// <summary>
        /// 更新学生密码
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="stuPwd">学生密码</param>
        /// <returns></returns>
        public Enums.OpResult UpdataPwd(string stuAccount,string stuPwd)
        {
            int count = dao.UpdataPwd(stuAccount, stuPwd);
            if (count > 0)
            {
                return Enums.OpResult.更新成功;
            }
            else
            {
                return Enums.OpResult.更新失败;
            }
        }
        /// <summary>
        /// 重置学生密码
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <param name="resetPwd">hash后的密码</param>
        /// <returns></returns>
        public Enums.OpResult ResetPwd(string stuAccount, string resetPwd)
        {
            int count = dao.ResetPassword(stuAccount, resetPwd);
            if (count > 0)
            {
                return Enums.OpResult.更新成功;
            }
            else
            {
                return Enums.OpResult.更新失败;
            }
        }

        /// <summary>
        /// 得到学生实体对象
        /// </summary>
        /// <param name="TeaAccount">学生账号</param>
        /// <returns>学生实体</returns>
        public Student GetModel(String stuAccount)
        {
            Student student = new Student();
            Profession profession = new Profession();
            College college = new College();
            DataSet ds = dao.GetStudent(stuAccount);
            RSACryptoService rsa = new RSACryptoService();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["stuAccount"].ToString() != "")
                {
                    student.StuAccount = ds.Tables[0].Rows[0]["stuAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["stuPwd"].ToString() != "")
                {
                    student.StuPwd = rsa.Decrypt(ds.Tables[0].Rows[0]["stuPwd"].ToString());
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
                if (profession != null)
                {
                    student.profession = profession;
                }
                if (college != null)
                {
                    student.college = college;
                }
            }
            return student;
        }

        /// <summary>
        /// 根据学生账号查找是否已存在
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public bool selectBystuId(string stuAccount)
        {
            int count = dao.selectBystuId(stuAccount);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查找联系电话是否已存在
        /// </summary>
        /// <param name="stuAccount">联系电话</param>
        /// <returns>查找结果</returns>
        public bool selectByPhone(string phone)
        {
            int count = dao.SelectByPhone(phone);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 查找邮箱是否已存在
        /// </summary>
        /// <param name="stuAccount">邮箱</param>
        /// <returns>查找结果</returns>
        public bool selectByEmail(string email)
        {
            int count = dao.SelectByEmail(email);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据TableBuilder实体返回DataSet数据
        /// </summary>
        /// <param name="tablebuilder"></param>
        /// <param name="intPageCount"></param>
        /// <returns></returns>
        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount)
        {
            int pagecount;
            DataSet ds = pdao.SelectBypage(tablebuilder, out pagecount);
            intPageCount = pagecount;
            return ds;
        }
    }
}

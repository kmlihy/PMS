﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Model;
using PMS.Dao;

namespace PMS.BLL
{
    using System.Data;
    using Result = Enums.OpResult;

    public class TeacherBll
    {
        private TeacherDao dao = new TeacherDao();
        private PublicProcedure pdao = new PublicProcedure();

        /// <summary>
        /// 教师登录
        /// </summary>
        /// <param name="teaAccount"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Teacher Login(string teaAccount, string pwd)
        {
            DataSet dataSet = dao.Select(teaAccount);
            
            if (dataSet != null && dataSet.Tables[0].Rows.Count == 1)
            {
                DataRow row = dataSet.Tables[0].Rows[0];
                DataSet ds = dao.GetTeacher(row["teaAccount"].ToString());
                RSACryptoService rsa = new RSACryptoService();
                if (row["teaAccount"].ToString() == teaAccount && rsa.Decrypt(row["teaPwd"].ToString()) == pwd)
                {

                    Teacher teacher = new Teacher();
                    College college = new College();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["teaAccount"].ToString() != "")
                        {
                            teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["teaPwd"].ToString() != "")
                        {
                            teacher.TeaPwd = rsa.Decrypt(ds.Tables[0].Rows[0]["teaPwd"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["teaName"].ToString() != "")
                        {
                            teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                        {
                            teacher.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["phone"].ToString() != "")
                        {
                            teacher.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                        {
                            teacher.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["teaType"].ToString() != "")
                        {
                            teacher.TeaType = int.Parse(ds.Tables[0].Rows[0]["teaType"].ToString());
                        }
                        if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                        {
                            college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());

                        }
                        if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                        {
                            college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                        }
                        if (college != null)
                        {
                            teacher.college = college;
                        }
                    }
                    else
                    {
                    }
                    return teacher;
                }
            }
            return null;
        }
        /// <summary>
        /// 查询教师工号
        /// </summary>
        /// <returns></returns>
        public DataSet SelectTeaAcount()
        {
            return dao.SelectTeaAcount();
        }

        /// <summary>
        /// 添加教师
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        public Enums.OpResult Insert(Teacher teacher)
        {
            int count = dao.Insert(teacher);
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
        /// 更新教师
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        public Result updateState(Teacher teacher)
        {
            int row = dao.updateState(teacher);
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
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
            if (row > 0)
            {
                return Enums.OpResult.关联引用;
            }
            else
            {
                return Enums.OpResult.记录不存在;
            }
        }

        /// <summary>
        /// 删除教师
        /// </summary>
        /// <param name="TeaAccount">教师主键</param>
        /// <returns></returns>
        public Enums.OpResult Delete(String TeaAccount)
        {
            int count = dao.delete(TeaAccount);
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
        /// 更新教师
        /// </summary>
        /// <param name="teacher">教师实体</param>
        /// <returns></returns>
        public Enums.OpResult Updata(Teacher teacher)
        {
            int count = dao.Updata(teacher);
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
        /// 更新教师密码
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <param name="teaPwd">教师密码</param>
        /// <returns></returns>
        public Enums.OpResult UpdataPwd(string teaAccount, string teaPwd)
        {
            int count = dao.UpdataPwd(teaAccount, teaPwd);
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
        /// 得到教师实体对象
        /// </summary>
        /// <param name="TeaAccount">教师账号</param>
        /// <returns>教师实体</returns>
        public Teacher GetModel(String TeaAccount)
        {
            DataSet ds = dao.GetTeacher(TeaAccount);
            Teacher teacher = new Teacher();
            College college = new College();
            RSACryptoService rsa = new RSACryptoService();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["teaAccount"].ToString() != "")
                {
                    teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                }
                if (ds.Tables[0].Rows[0]["teaPwd"].ToString() != "")
                {
                    teacher.TeaPwd = rsa.Decrypt(ds.Tables[0].Rows[0]["teaPwd"].ToString());
                }
                if (ds.Tables[0].Rows[0]["teaName"].ToString() != "")
                {
                    teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    teacher.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["phone"].ToString() != "")
                {
                    teacher.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    teacher.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["teaType"].ToString() != "")
                {
                    teacher.TeaType = int.Parse(ds.Tables[0].Rows[0]["teaType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                {
                    college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());

                }
                if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                {
                    college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                }
                if (college != null)
                {
                    teacher.college = college;
                }
            }
            else
            {
            }
            return teacher;
        }

        /// <summary>
        /// 得到教师实体对象，除密码
        /// </summary>
        /// <param name="TeaAccount">教师账号</param>
        /// <returns>教师实体</returns>
        public Teacher getModel(String TeaAccount)
        {
            DataSet ds = dao.GetTeacher(TeaAccount);
            Teacher teacher = new Teacher();
            College college = new College();
            RSACryptoService rsa = new RSACryptoService();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["teaAccount"].ToString() != "")
                {
                    teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                }
                //if (ds.Tables[0].Rows[0]["teaPwd"].ToString() != "")
                //{
                //    teacher.TeaPwd = ds.Tables[0].Rows[0]["teaPwd"].ToString();
                //}
                if (ds.Tables[0].Rows[0]["teaName"].ToString() != "")
                {
                    teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                {
                    teacher.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["phone"].ToString() != "")
                {
                    teacher.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email"].ToString() != "")
                {
                    teacher.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                }
                if (ds.Tables[0].Rows[0]["teaType"].ToString() != "")
                {
                    teacher.TeaType = int.Parse(ds.Tables[0].Rows[0]["teaType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                {
                    college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());

                }
                if (ds.Tables[0].Rows[0]["collegeName"].ToString() != "")
                {
                    college.ColName = ds.Tables[0].Rows[0]["collegeName"].ToString();
                }
                if (college != null)
                {
                    teacher.college = college;
                }
            }
            else
            {
            }
            return teacher;
        }

        /// <summary>
        /// 根据TableBuilder实体返回DataSet数据
        /// </summary>
        /// <param name="tablebuilder"></param>
        /// <param name="intPageCount"></param>
        /// <returns></returns>
        public DataSet SelectBypage(TableBuilder tablebuilder, out int intPageCount) {
            int pagecount;
            DataSet ds= pdao.SelectBypage(tablebuilder, out pagecount);
            intPageCount = pagecount;
            return ds;
        }
        
        /// <summary>
        /// 批量导入
        /// </summary>
        /// <param name="dt">存储Excel数据的DataTable对象</param>
        /// <returns></returns>
        public int upload(DataTable dt)
        {
            int row = dao.upload(dt);
            return row;
        }

        /// <summary>
        /// 根据教师账号查找是否已存在
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <returns></returns>
        public bool selectByteaId(string teaAccount)
        {
            int count = dao.selectByteaId(teaAccount);
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
        /// 查询该学院是否已设置过管理员
        /// </summary>
        /// <param name="collegeId">学院ID</param>
        /// <returns>查找结果</returns>
        public bool selectByColl(int collegeId)
        {
            int count = dao.SelectByColl(collegeId);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataSet getLeaderByColl(int collegeId, string teaAccount1,string teaAccount2)
        {
            return dao.getLeaderByColl(collegeId, teaAccount1, teaAccount2);
        }
        public DataSet getMemberByColl(int collegeId, string teaAccount1, string teaAccount2)
        {
            return dao.getMemberByColl(collegeId, teaAccount1, teaAccount2);
        }
        public DataSet getRecordByColl(int collegeId, string teaAccount1, string teaAccount2)
        {
            return dao.getRecordByColl(collegeId, teaAccount1, teaAccount2);
        }

        /// <summary>
        /// 根据学院ID获取教师信息
        /// </summary>
        /// <param name="teaAccount">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public DataSet getByColl(int collegeId, string teaAccount)
        {
            return dao.getByColl(collegeId, teaAccount);
        }
    }
}

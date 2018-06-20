using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teaAccount"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public Teacher Login(string teaAccount, string pwd)
        {
            DataSet ds = dao.Select(teaAccount, pwd);
            if(ds!=null && ds.Tables[0].Rows.Count == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if(row["teaAccount"].ToString() == teaAccount && row["teaPwd"].ToString() == pwd)
                {
                    Teacher teacher = dao.GetTeacher(row["teaAccount"].ToString());
                    //填充属性
                    return teacher;
                }
            }
            return null;
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
        /// 删除教师
        /// </summary>
        /// <param name="TeaAccount">教师主键</param>
        /// <returns></returns>
        public Enums.OpResult delete(String TeaAccount)
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
                return Enums.OpResult.删除成功;
            }
            else
            {
                return Enums.OpResult.删除失败;
            }
        }
        /// <summary>
        /// 得到教师实体对象
        /// </summary>
        /// <param name="TeaAccount">教师账号</param>
        /// <returns>教师实体</returns>
        public Teacher GetModel(String TeaAccount)
        {
            return dao.GetTeacher(TeaAccount);
        }
    }
}

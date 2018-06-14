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
                    Teacher teacher = new Teacher();
                    //填充属性
                    return teacher;
                }
            }
            return null;
        }

        public Result Add(Teacher teacher)
        {
            return Result.添加失败;
        } 
    }
}

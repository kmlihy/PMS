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
        public int Login(string teaAccount, string pwd)
        {
            DataSet data = dao.Select(teaAccount, pwd);
            if(data.Tables[0].Rows.Count > 0)
            {
                return 1;
            }
            return 0;
        }

        public Result Add(Teacher teacher)
        {
            return Result.添加失败;
        } 
    }
}

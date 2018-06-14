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
        /// 根据用户类型获取教师信息
        /// </summary>
        /// <param name="userType">1：教师 0：管理员</param>
        /// <returns></returns>
        public DataSet Select(int userType)
        {
            return null;
        }

        /// <summary>
        /// 向数据库中新增教师记录
        /// </summary>
        /// <param name="teacher">教师对象</param>
        /// <returns>返回受影响的行数</returns>
        public int Insert(Teacher teacher)
        {
            return 0;
        }
    }
}

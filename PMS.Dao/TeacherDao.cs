using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.DBHelper;
using PMS.Model;

namespace PMS.Dao
{
    /// <summary>
    /// 教师管理员数据库操作类
    /// </summary>
    public class TeacherDao
    {
        private SQLHelper db = new SQLHelper();

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Model;
using PMS.Dao;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    public class TeacherBll
    {
        private TeacherDao dao = new TeacherDao();

        public Result Add(Teacher teacher)
        {
            return Result.添加失败;
        } 
    }
}

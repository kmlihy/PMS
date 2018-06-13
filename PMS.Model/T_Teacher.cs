using System;
using System.Data;
namespace PMS.Model
{

    /// <summary>T_Teacher</summary>
    [Serializable()]
    public class T_Teacher
    {
        /// <summary>教师管理员账号</summary>
        public string teaAccount { get; set; }

        /// <summary>教师管理员密码</summary>
        public string teaPwd { get; set; }
        
        /// <summary>教师管理员姓名</summary>
        public string teaName { get; set; }
       
        /// <summary>教师管理员性别</summary>
        public string sex { get; set; }
        
        /// <summary>教师管理员联系电话</summary>
        public string phone { get; set; }
        
        /// <summary>教师管理员邮箱</summary>
        public string Email { get; set; }
        
        /// <summary>分院id(外键分院表)</summary>
        public int collegeId { get; set; }
        
        /// <summary>角色身份类型(教师1,管理员2,超级管理员3)</summary>
        public int teaType { get; set; }

        public T_Teacher() { }

    }
}

using System;
using System.Data;
namespace PMS.Model
{

    /// <summary>T_Teacher</summary>
    [Serializable()]
    public class Teacher
    {
        /// <summary>
        /// 教师管理员账号
        /// </summary>
        public string TeaAccount { get; set; }

        /// <summary>
        /// 教师管理员密码
        /// </summary>
        public string TeaPwd { get; set; }
        
        /// <summary>
        /// 教师管理员姓名
        /// </summary>
        public string TeaName { get; set; }
       
        /// <summary>
        /// 教师管理员性别
        /// </summary>
        public string Sex { get; set; }
        
        /// <summary>
        /// 教师管理员联系电话
        /// </summary>
        public string Phone { get; set; }
        
        /// <summary>
        /// 教师管理员邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 判断教师是否被分配到答辩小组
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 分院id(外键分院表)
        /// </summary>
        public College college { get; set; }

        /// <summary>
        /// 角色身份类型(超级管理员0,教师1,管理员2)
        /// </summary>
        public int TeaType { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Teacher() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="teaAccount"></param>
        /// <param name="teaPwd"></param>
        /// <param name="teaName"></param>
        /// <param name="sex"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="state">判断教师是否被分配到答辩小组</param>
        /// <param name="college"></param>
        /// <param name="teaType"></param>
        public Teacher(string teaAccount, string teaPwd, string teaName, string sex, string phone, string email, int state, College college, int teaType)
        {
            TeaAccount = teaAccount;
            TeaPwd = teaPwd;
            TeaName = teaName;
            Sex = sex;
            Phone = phone;
            Email = email;
            this.state = state;
            this.college = college;
            TeaType = teaType;
        }


    }
}

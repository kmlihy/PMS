using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 学生实体类
    /// </summary>
    public class Student
    {       
        /// <summary>
        /// 学生用户名
        /// </summary>
        public string StuAccount { get; set; }

        /// <summary>
        /// 学生密码
        /// </summary>
        public string StuPwd { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 判断学生是否被分配到答辩小组
        /// </summary>
        public int state { get; set; }

        /// <summary>
        /// 学生所属专业
        /// </summary>
        public Profession profession { get; set; }

        /// <summary>
        /// 学生所属学院
        /// </summary>
        public College college { get; set; }

        public int finishYear { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Student() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="stuAccount">学生用户名</param>
        /// <param name="stuPwd">学生密码</param>
        /// <param name="realName">学生姓名</param>
        /// <param name="sex">学生性别</param>
        /// <param name="phone">联系电话</param>
        /// <param name="email">邮箱</param>
        /// <param name="state">判断学生是否被分配到答辩小组</param>
        /// <param name="profession">学生所属专业</param>
        /// <param name="college">学生所属学院</param>
        public Student(string stuAccount, string stuPwd, string realName, string sex, string phone, string email,int state, Profession profession,College college)
        {
            StuAccount = stuAccount;
            StuPwd = stuPwd;
            RealName = realName;
            Sex = sex;
            Phone = phone;
            Email = email;
            this.state = state;
            this.profession = profession;
            this.college = college;
        }
    }
}

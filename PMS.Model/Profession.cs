using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 专业实体类
    /// </summary>
    public class Profession
    {
        /// <summary>
        /// 专业编号
        /// </summary>
        public int ProId { get; set; }
        
        /// <summary>
        /// 专业名称
        /// </summary>
        public string ProName { get; set; }

        /// <summary>
        /// 专业所属学院
        /// </summary>
        public College college { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Profession(){ }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="proId">专业编号</param>
        /// <param name="proName">专业名称</param>
        /// <param name="college">专业所属学院</param>
        public Profession(int proId, string proName, College college)
        {
            ProId = proId;
            ProName = proName;
            this.college = college;
        }
    }
}

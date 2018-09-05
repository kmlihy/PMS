using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    public class Cross
    {
        /// <summary>
        /// 交叉指导id
        /// </summary>
        public int crossId { set; get; }
        /// <summary>
        /// 选题记录对象
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 教师对象
        /// </summary>
        public Teacher teacher { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Cross() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录对象</param>
        /// <param name="teacher">教师对象</param>
        public Cross(TitleRecord titleRecord, Teacher teacher)
        {
            this.titleRecord = titleRecord;
            this.teacher = teacher;
        }
    }
}

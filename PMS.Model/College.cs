using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 分院
    /// </summary>
    public class College
    {
        /// <summary>
        /// 分院编号
        /// </summary>
        public int ColID { get; set; }

        /// <summary>
        /// 分院名称
        /// </summary>
        public string ColName { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public College() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="ColID">分院编号</param>
        /// <param name="ColName">分院名称</param>
        public College(int ColID, string ColName)
        {
            this.ColID = ColID;
            this.ColName = ColName;
        }
    }
}

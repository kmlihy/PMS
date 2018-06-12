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

        public College() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 选题批次
    /// </summary>
    public class Plan
    {
        /// <summary>
        /// 选题批次编号
        /// </summary>
        public int PlanId { get; set; }
        /// <summary>
        /// 选题批次名
        /// </summary>
        public string PlanName { get; set; }
        /// <summary>
        /// 选题开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 选题截止时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 批次状态0代表未激活，1代表激活
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 批次所属分院
        /// </summary>
        public College college { get; set; }

        public Plan() { }
    }
}

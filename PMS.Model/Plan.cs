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

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Plan() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="planId">选题批次编号</param>
        /// <param name="planName">选题批次名</param>
        /// <param name="startTime">选题开始时间</param>
        /// <param name="endTime">选题截止时间</param>
        /// <param name="state">批次状态0代表未激活，1代表激活</param>
        /// <param name="college">批次所属分院</param>
        public Plan(int planId, string planName, DateTime startTime, DateTime endTime, int state, College college)
        {
            PlanId = planId;
            PlanName = planName;
            StartTime = startTime;
            EndTime = endTime;
            State = state;
            this.college = college;
        }
    }
}

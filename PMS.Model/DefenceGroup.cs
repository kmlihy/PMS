using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 答辩实体类
    /// </summary>
    public class DefenceGroup
    {
        /// <summary>
        /// 答辩小组id
        /// </summary>
        public int defenGroupId { set; get; }
        /// <summary>
        /// 组长
        /// </summary>
        public string leader { set; get; }
        public string leaderName { get; set; }
        /// <summary>
        /// 成员
        /// </summary>
        public string member { set; get; }
        public string memberName { get; set; }
        /// <summary>
        /// 记录员
        /// </summary>
        public string recorder { set; get; }
        public string recordName { get; set; }
        /// <summary>
        /// 批次id
        /// </summary>
        public Plan plan { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public DefenceGroup() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="leader">组长</param>
        /// <param name="member">成员</param>
        /// <param name="recorder">记录员</param>
        /// <param name="planId">批次id</param>
        public DefenceGroup(string leader,string member, string recorder, Plan plan)
        {
            this.leader = leader;
            this.member = member;
            this.recorder = recorder;
            this.plan = plan;
        }
    }
}

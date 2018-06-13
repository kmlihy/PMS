using System;
using System.Data;

namespace PMS.Model
{
    /// <summary>选题记录表</summary>
    public class T_TitleRecord
    {
        /// <summary>选题记录id</summary>
        public int titleRecordId { get; set;}
        /// <summary>学生id(外键学生表)</summary>
        public string stuAccount{ get; set; }
        /// <summary>题目id(外键题目表)</summary>
        public int titleId{ get; set; }
        /// <summary>答辩小组id</summary>
        public int defeseTeamId{ get; set; }
    }
}

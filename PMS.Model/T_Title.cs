using System;
using System.Data;

namespace PMS.Model
{
    /// <summary>题目表实体</summary>
    public class T_Title
    {
        /// <summary>题目id</summary>
        public int titleId{ get;  set;}
        /// <summary>题目标题</summary>
        public string title{ get; set; }
        /// <summary>题目内容</summary>
        public string titleContent { get; set; }
        /// <summary>添加时间</summary>
        public System.DateTime createTime { get; set; }
        /// <summary>已选人数</summary>
        public int selected { get; set; }
        /// <summary>题目限制选择人数</summary>
        public int limit { get; set; }
        /// <summary>批次id(外键批次表)</summary>
        public int planId { get; set; }
        /// <summary>出题人id(外键教师表)</summary>
        public string teaAccount{ get; set; }
        /// <summary>专业id(外键专业表)</summary>
        public int proId { get; set; }
    }
}

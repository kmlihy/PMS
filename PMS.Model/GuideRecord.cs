using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 指导记录实体类
    /// </summary>
    public class GuideRecord
    {
        /// <summary>
        /// 选题记录id
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 指导意见
        /// </summary>
        public string opinion { set; get; }
        /// <summary>
        /// 论文路径信息
        /// </summary>
        public Path path { set; get; }
        /// <summary>
        /// 指导意见提交时间
        /// </summary>
        public DateTime dateTime { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public GuideRecord()
        {}
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录id</param>
        /// <param name="opinion">指导教师意见</param>
        /// <param name="paperPath">论文路径信息</param>
        /// <param name="dateTime">指导意见提交时间</param>
        public GuideRecord(TitleRecord titleRecord, string opinion, Path path, DateTime dateTime)
        {
            this.titleRecord = titleRecord;
            this.opinion = opinion;
            this.path = path;
            this.dateTime = dateTime;
        }
    }
}

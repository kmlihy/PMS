using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    public class DefenceRecord
    {
        /// <summary>
        /// 答辩记录id
        /// </summary>
        public int defenRecordId { set; get; }
        /// <summary>
        /// 选题记录对象
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 答辩小组对象
        /// </summary>
        public DefenceGroup defenceGroup { set; get; }
        /// <summary>
        /// 答辩记录内容
        /// </summary>
        public string recordContent { set; get; }
        public DateTime dateTime { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public DefenceRecord() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录对象</param>
        /// <param name="defenceRecord">答辩小组对象</param>
        /// <param name="recordContent">答辩记录内容</param>
        public DefenceRecord(TitleRecord titleRecord, DefenceRecord defenceRecord, string recordContent,DateTime dateTime)
        {
            this.titleRecord = titleRecord;
            this.defenceGroup = defenceGroup;
            this.recordContent = recordContent;
            this.dateTime = dateTime;
        }
    }
}

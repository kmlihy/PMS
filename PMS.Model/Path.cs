using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 文件路径实体类
    /// </summary>
    public class Path
    {
        /// <summary>
        /// 路径id
        /// </summary>
        public int pathId { set; get; }
        /// <summary>
        /// 文件标题
        /// </summary>
        public string title { set; get; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string paperPath { set; get; }
        /// <summary>
        /// 文件上传时间
        /// </summary>
        public DateTime dateTime { set; get; }
        /// <summary>
        /// 选题记录实体对象
        /// </summary>
        public TitleRecord titleRecord { get; set; } 
        /// <summary>
        /// 文件类型（0为论文，1为查重报告）
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 文件完成状态
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Path() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="pathId">路径id</param>
        /// <param name="title">标题</param>
        /// <param name="path">路径</param>
        /// <param name="dateTime">上传时间</param>
        /// <param name="titleRecord">选题记录实体对象</param>
        /// <param name="type">文件类型（0为论文，1为查重报告）</param>
        /// <param name="state">文件完成状态</param>
        public Path(int pathId,string title, string path, DateTime dateTime, TitleRecord titleRecord,int type,int state)
        {
            this.pathId = pathId;
            this.title = title;
            this.paperPath = path;
            this.dateTime = dateTime;
            this.titleRecord = titleRecord;
            this.type = type;
            this.state = state;
        }
    }
}

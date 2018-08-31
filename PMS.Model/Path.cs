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
        public TitleRecord titleRecord { get; set; } 
        public int type { get; set; }
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
        public Path(int pathId,string title, string path, DateTime dateTime,int type)
        {
            this.pathId = pathId;
            this.title = title;
            this.paperPath = path;
            this.dateTime = dateTime;
            this.type = type;
        }
    }
}

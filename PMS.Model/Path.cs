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
        /// 标题
        /// </summary>
        public string title { set; get; }
        /// <summary>
        /// 路径
        /// </summary>
        public string paperPath { set; get; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime dateTime { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Path() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="path">路径</param>
        /// <param name="dateTime">上传时间</param>
        public Path(string title, string path, DateTime dateTime)
        {
            this.title = title;
            this.paperPath = path;
            this.dateTime = dateTime;
        }
    }
}

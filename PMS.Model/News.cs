using System;
using System.Data;
namespace PMS.Model
{
    /// <summary>TNews(公告表实体类)</summary>
    [Serializable()]
    public class News
    {

        /// <summary>公告id</summary>
        public int newsId { get; set; }
       
        /// <summary>公告标题</summary>
        public string newsTitle { get; set; }
    
        /// <summary>公告内容</summary>
        public string newsContent { get; set; }
       
        /// <summary>公告发布时间</summary>
        public System.DateTime createTime { get; set; }
    
        /// <summary>公告发布人(外键教师信息表)</summary>
        public string teaAccount { get; set; }

        public News() { }
        
    }
}

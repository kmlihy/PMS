using System;
using System.Data;
namespace PMS.Model
{
    /// <summary>
    /// TNews(公告表实体类)
    /// </summary>
    [Serializable()]
    public class News
    {  
        /// <summary>
        /// 公告id
        /// </summary>
        public int NewsId { get; set; }
       
        /// <summary>
        /// 公告标题
        /// </summary>
        public string NewsTitle { get; set; }
    
        /// <summary>
        /// 公告内容
        /// </summary>
        public string NewsContent { get; set; }
       
        /// <summary>
        /// 公告发布时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    
        /// <summary>
        /// 公告发布人(外键教师信息表)
        /// </summary>
        public Teacher teacher { get; set; }

        /// <summary>
        /// 分院信息（外键分院表）
        /// </summary>
        public College college { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public News() { }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="newsId"></param>
        /// <param name="newsTitle"></param>
        /// <param name="newsContent"></param>
        /// <param name="createTime"></param>
        /// <param name="teacher"></param>
        public News(int newsId, string newsTitle, string newsContent, DateTime createTime, Teacher teacher)
        {
            NewsId = newsId;
            NewsTitle = newsTitle;
            NewsContent = newsContent;
            CreateTime = createTime;
            this.teacher = teacher;
        }

    }
}

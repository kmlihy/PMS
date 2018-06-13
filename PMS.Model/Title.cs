using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 题目表实体
    /// </summary>
    public class Title
    {
        /// <summary>
        /// 默认构造方法
        /// </summary>
        public Title() {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="titleId">题目id</param>
        /// <param name="title">题目标题</param>
        /// <param name="titleContent">题目内容</param>
        /// <param name="createTime">添加时间</param>
        /// <param name="selected">已选人数</param>
        /// <param name="limit">题目限制选择人数</param>
        /// <param name="plan">批次表</param>
        /// <param name="teacher">教师表</param>
        /// <param name="profession">专业表</param>
        public Title(int titleId, string title, string titleContent, DateTime createTime, int selected, int limit, Plan plan, Teacher teacher, Profession profession)
        {
            TitleId = titleId;
            this.title = title;
            TitleContent = titleContent;
            CreateTime = createTime;
            Selected = selected;
            Limit = limit;
            this.plan = plan;
            this.teacher = teacher;
            this.profession = profession;
        }

        /// <summary>题目id</summary>
        public int TitleId { get; set; }
        /// <summary>题目标题</summary>
        public string title { get; set; }
        /// <summary>题目内容</summary>
        public string TitleContent { get; set; }
        /// <summary>添加时间</summary>
        public System.DateTime CreateTime { get; set; }
        /// <summary>已选人数</summary>
        public int Selected { get; set; }
        /// <summary>题目限制选择人数</summary>
        public int Limit { get; set; }
        /// <summary>(题目所属批次)</summary>
        public Plan plan { get; set; }
        /// <summary>(题目所属教师)</summary>
        public Teacher teacher { get; set; }
        /// <summary>(题目所属专业)</summary>
        public Profession profession { get; set; }
    }
}

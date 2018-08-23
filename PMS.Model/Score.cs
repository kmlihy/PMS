using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 成绩实体类
    /// </summary>
    public class Score
    {
        /// <summary>
        /// 学生实体
        /// </summary>
        public Student student { set; get; }
        /// <summary>
        /// 批次实体
        /// </summary>
        public Plan plan { set; get; }
        /// <summary>
        /// 成绩
        /// </summary>
        public double score { set; get; }
        /// <summary>
        /// 备注（如：答辩成绩）
        /// </summary>
        public string remarks { set; get; }
        /// <summary>
        /// 评定等级
        /// </summary>
        public string assess { set; get; }
        /// <summary>
        /// 评价
        /// </summary>
        public string evaluate { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Score() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="student">学生</param>
        /// <param name="plan">批次</param>
        /// <param name="score">成绩</param>
        /// <param name="remarks">备注</param>
        /// <param name="assess">评定等级</param>
        /// <param name="evaluate">评价</param>
        public Score(Student student, Plan plan, double score, string remarks, string assess,string evaluate)
        {
            this.student = student;
            this.plan = plan;
            this.score = score;
            this.remarks = remarks;
            this.assess = assess;
            this.evaluate = evaluate;
        }
    }
}

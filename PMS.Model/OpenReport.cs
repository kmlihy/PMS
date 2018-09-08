using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 开题报告实体类
    /// </summary>
    public class OpenReport
    {
        /// <summary>
        /// 开题报告记录ID
        /// </summary>
        public int openId { set; get; }
        /// <summary>
        /// 选题记录对象
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 选题目的、价值和意义
        /// </summary>
        public string meaning { set; get; }
        /// <summary>
        /// 本课题在国内外的研究状况及发展趋势
        /// </summary>
        public string trend { set; get; }
        /// <summary>
        /// 主要研究内容
        /// </summary>
        public string content { set; get; }
        /// <summary>
        /// 实验设计计划（内容简介）
        /// </summary>
        public string plan { set; get; }
        /// <summary>
        /// 完成设计（论文）的条件、方法及措施
        /// </summary>
        public string method { set; get; }
        /// <summary>
        /// 设计（论文）拟定提纲
        /// </summary>
        public string outline { set; get; }
        /// <summary>
        /// 主要参考文献（研究综述：作者、题目、杂志、卷号、页码）
        /// </summary>
        public string reference { set; get; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime reportTime { set; get; }
        /// <summary>
        /// 指导教师意见及建议
        /// </summary>
        public string teacherOpinion { set; get; }
        /// <summary>
        /// 分院院长意见
        /// </summary>
        public string deanOpinion { set; get; }
        public int state { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OpenReport() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="openId">开题报告记录ID</param>
        /// <param name="titleRecord">选题记录对象</param>
        /// <param name="meaning">选题目的、价值和意义</param>
        /// <param name="trend">本课题在国内外的研究状况及发展趋势</param>
        /// <param name="content">主要研究内容</param>
        /// <param name="plan">实验设计计划（内容简介）</param>
        /// <param name="method">完成设计（论文）的条件、方法及措施</param>
        /// <param name="outline">设计（论文）拟定提纲</param>
        /// <param name="reference">主要参考文献（研究综述：作者、题目、杂志、卷号、页码）</param>
        /// <param name="teacherOpinion">指导教师意见及建议</param>
        /// <param name="deanOpinion">分院院长意见</param>
        /// <param name="reportTime">提交时间</param>
        public OpenReport(int openId,TitleRecord titleRecord,string meaning, string trend, string content, string plan, string method, string outline, string reference, string teacherOpinion, string deanOpinion,DateTime reportTime,int state )
        {
            this.openId = openId;
            this.titleRecord = titleRecord;
            this.meaning = meaning;
            this.trend = trend;
            this.content = content;
            this.plan = plan;
            this.method = method;
            this.outline = outline;
            this.reference = reference;
            this.teacherOpinion = teacherOpinion;
            this.deanOpinion = deanOpinion;
            this.reportTime = reportTime;
            this.state = state;
        }
    }
}

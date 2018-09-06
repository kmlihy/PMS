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
        /// 指导成绩
        /// </summary>
        public double guideScore { set; get; }
        /// <summary>
        /// 交叉指导成绩
        /// </summary>
        public double crossScore { set; get; }
        /// <summary>
        /// 答辩成绩
        /// </summary>
        public double defenceScore { set; get; }
        /// <summary>
        /// 答辩state
        /// </summary>
        public int state { set; get; }
        /// <summary>
        /// 调查论证
        /// </summary>
        public string investigation { get; set; }
        /// <summary>
        /// 实践能力
        /// </summary>
        public string practice { get; set; }
        /// <summary>
        /// 分析、解决问题能力
        /// </summary>
        public string solveProblem { get; set; }
        /// <summary>
        /// 工作态度
        /// </summary>
        public string workAttitude { get; set; }
        /// <summary>
        /// 质量
        /// </summary>
        public string quality { get; set; }
        /// <summary>
        /// 翻译资料综述材料
        /// </summary>
        public string material { get; set; }
        /// <summary>
        /// 论文（设计）质量
        /// </summary>
        public string paperDesign { get; set; }
        /// <summary>
        /// 工作量及难度
        /// </summary>
        public string workload { get; set; }
        /// <summary>
        /// 报告内容
        /// </summary>
        public string reportContent { get; set; }
        /// <summary>
        /// 报告时间
        /// </summary>
        public string reportTime { get; set; }
        /// <summary>
        /// 答辩
        /// </summary>
        public string defence { get; set; }
        /// <summary>
        /// 创新
        /// </summary>
        public string innovate { get; set; }
        /// <summary>
        /// 评价
        /// </summary>
        public string evaluate { set; get; }
        /// <summary>
        /// 判断成绩是否开放给学生查看;0为未开放，1为已开放
        /// </summary>
        public int openState { set; get; }
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
        /// <param name="openState">判断成绩是否开放给学生查看;0为未开放，1为已开放</param>
        public Score(Student student, Plan plan, double guideScore, double crossScore, double denfenceScore, string remarks, string assess,string evaluate,int openState, int state)
        {
            this.student = student;
            this.plan = plan;
            this.guideScore = guideScore;
            this.crossScore = crossScore;
            this.defenceScore = denfenceScore;
            this.investigation = investigation;
            this.practice = practice;
            this.evaluate = evaluate;
            this.solveProblem = solveProblem;
            this.workAttitude = workAttitude;
            this.quality = quality;
            this.material = material;
            this.paperDesign = paperDesign;
            this.workload = workload;
            this.reportContent = reportContent;
            this.reportTime = reportTime;
            this.defence = defence;
            this.innovate = innovate;
            this.openState = openState;
        }
    }
}

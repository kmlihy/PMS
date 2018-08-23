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
        /// 选题记录id
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 选题依据
        /// </summary>
        public string titleBasis { set; get; }
        /// <summary>
        /// 设计研究的主要内容
        /// </summary>
        public string designContent { set; get; }
        /// <summary>
        /// 主要设计研究方法
        /// </summary>
        public string designMethod { set; get; }
        /// <summary>
        /// 设计研究进度计划
        /// </summary>
        public string designRate { set; get; }
        /// <summary>
        /// 主要参考资料
        /// </summary>
        public string referenceMaterial { set; get; }
        /// <summary>
        /// 指导教师意见
        /// </summary>
        public string teacherOpinion { set; get; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime reportTime { set; get; }
        /// <summary>
        /// 开题小组意见
        /// </summary>
        public string opneGroupOpinion { set; get; }
        /// <summary>
        /// 分院毕业作业(论文)指导小组审定意见
        /// </summary>
        public string guideGroupOpinion { set; get; }
        
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OpenReport() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录id</param>
        /// <param name="titleBasis">选题依据</param>
        /// <param name="designContent">设计研究的主要内容</param>
        /// <param name="designMethod">主要设计研究方法</param>
        /// <param name="designRate">设计研究进度计划</param>
        /// <param name="referenceMaterial">主要参考资料</param>
        /// <param name="teacherOpinion">指导教师意见</param>
        /// <param name="reportTime">开题报告创建时间</param>
        /// <param name="opneGroupOpinion">开题小组意见</param>
        /// <param name="guideGroupOpinion">分院毕业作业（论文）指导小组审定意见</param>
        public OpenReport(TitleRecord titleRecord,string titleBasis, string designContent, string designMethod, string designRate, string referenceMaterial, string teacherOpinion, DateTime reportTime, string opneGroupOpinion, string guideGroupOpinion )
        {
            this.titleRecord = titleRecord;
            this.titleBasis = titleBasis;
            this.designContent = designContent;
            this.designMethod = designMethod;
            this.designRate = designRate;
            this.referenceMaterial = referenceMaterial;
            this.teacherOpinion = teacherOpinion;
            this.reportTime = reportTime;
            this.opneGroupOpinion = opneGroupOpinion;
            this.guideGroupOpinion = guideGroupOpinion;
        }
    }
}

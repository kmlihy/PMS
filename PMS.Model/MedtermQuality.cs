using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 中期质量报告实体类
    /// </summary>
    public class MedtermQuality
    {
        /// <summary>
        /// 选题记录id
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 期中按计划完成情况
        /// </summary>
        public string planFinishSituation { set; get; }
        /// <summary>
        /// 指导教师意见
        /// </summary>
        public string teacherOpinion { set; get; }
        /// <summary>
        /// 督导处抽查意见
        /// </summary>
        public string supervisionOpinion { set; get; }
        /// <summary>
        /// 指导小组意见
        /// </summary>
        public string guideGroupOpinion { set; get; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime dateTime { set; get; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public MedtermQuality() { }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录id</param>
        /// <param name="planFinishSituation">期中按计划完成情况</param>
        /// <param name="teacherOpinion">指导教师意见</param>
        /// <param name="supervisionOpinion">督导处抽查意见</param>
        /// <param name="guideGroupOpinion">指导小组意见</param>
        /// <param name="dateTime">上传时间</param>
        public MedtermQuality(TitleRecord titleRecord, string planFinishSituation, string teacherOpinion, string supervisionOpinion, string guideGroupOpinion, DateTime dateTime)
        {
            this.titleRecord = titleRecord;
            this.planFinishSituation = planFinishSituation;
            this.teacherOpinion = teacherOpinion;
            this.supervisionOpinion = supervisionOpinion;
            this.guideGroupOpinion = guideGroupOpinion;
            this.dateTime = dateTime;
        }
    }
}

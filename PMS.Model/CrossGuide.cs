using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMS.Model
{
    /// <summary>
    /// 交叉评阅实体类
    /// </summary>
    public class CrossGuide
    {
        /// <summary>
        /// 选题记录对象
        /// </summary>
        public TitleRecord titleRecord { set; get; }
        /// <summary>
        /// 交叉指导教师意见
        /// </summary>
        public string guideOpinion { set; get; }
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public CrossGuide() { }
        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="titleRecord">选题记录对象</param>
        /// <param name="guideOpinion">交叉指导教师意见</param>
        public CrossGuide(TitleRecord titleRecord,string guideOpinion)
        {
            this.titleRecord = titleRecord;
            this.guideOpinion = guideOpinion;
        }
    }
}

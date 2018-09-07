using PMS.Dao;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    /// <summary>
    /// 中期质量报告业务处理类
    /// </summary>
    public class MedtermQualityBll
    {
        MedtermQualityDao mdao = new MedtermQualityDao();
        /// <summary>
        /// 学生提交中期质量检查报告
        /// </summary>
        /// <param name="medterm">中期质量报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result stuInsert(MedtermQuality medterm)
        {
            int row = mdao.stuInsert(medterm);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 教师提交评阅中期质量意见
        /// </summary>
        /// <param name="medterm">中期质量报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result teaInsert(MedtermQuality medterm)
        {
            int row = mdao.teaInsert(medterm);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 督导处、指导小组提交评阅中期质量意见
        /// </summary>
        /// <param name="medterm">中期质量报告对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result superInsert(MedtermQuality medterm)
        {
            int row = mdao.superInsert(medterm);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 根据选题记录id获取中期检查对象
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public MedtermQuality Select(int titleRecordId)
        {
            DataSet ds = mdao.Select(titleRecordId);
            MedtermQuality or = new MedtermQuality();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count - 1;
                or.planFinishSituation = ds.Tables[0].Rows[i]["planFinishSituation"].ToString();
                or.teacherOpinion = ds.Tables[0].Rows[i]["teacherOpinion"].ToString();
                or.supervisionOpinion = ds.Tables[0].Rows[i]["supervisionOpinion"].ToString();
                or.guideGroupOpinion = ds.Tables[0].Rows[i]["guideGroupOpinion"].ToString();
                or.dateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["dateTime"].ToString());
                return or;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据教师账号查找中期检查信息
        /// </summary>
        /// <param name="teaAccount">教师账号</param>
        /// <returns></returns>
        public DataSet SelectByTea(string teaAccount)
        {
            return mdao.SelectByTea(teaAccount);
        }
    }
}

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
    /// 交叉评阅业务处理类
    /// </summary>
    public class CrossGuideBll
    {
        private PublicProcedure pubpro = new PublicProcedure();
        CrossGuideDao cgdao = new CrossGuideDao();
        /// <summary>
        /// 添加交叉评阅记录
        /// </summary>
        /// <param name="cross"></param>
        /// <returns></returns>
        public Result InsertGroup(CrossGuide cross)
        {
            int row = cgdao.Insert(cross);
            if (row > 0)
            {
                return Result.添加成功;
            }
            else
            {
                return Result.添加失败;
            }
        }

        /// <summary>
        /// 根据选题记录id查找
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public CrossGuide Select(int titleRecordId)
        {
            DataSet ds = cgdao.Select(titleRecordId);
            CrossGuide cross = new CrossGuide();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count-1;
                cross.titleRecord.TitleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                cross.guideOpinion = ds.Tables[0].Rows[i]["guideOpinion"].ToString();
                return cross;
            }
            return null;
        }

        /// <summary>
        /// 根据条间分页查询所有选题记录信息
        /// </summary>
        /// <param name="tab">参数实体</param>
        /// <param name="intPageCount">总页数（输出参数）</param>
        /// <returns>类型为DataSet的分页选题记录信息列表集</returns>
        public DataSet SelectBypage(TableBuilder tab, out int intPageCount)
        {
            DataSet ds = pubpro.SelectBypage(tab, out intPageCount);
            return ds;
        }
    }
}

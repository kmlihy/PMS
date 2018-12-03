using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Model;
using PMS.Dao;
using System.Data;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    /// <summary>
    /// 文件路径业务处理类
    /// </summary>
    public class PathBll
    {
        PathDao pdao = new PathDao();
        /// <summary>
        /// 添加一条文件路径信息
        /// </summary>
        /// <param name="path">要添加的路径对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result InsertThesis(Path path)
        {
            int row = pdao.InsertThesis(path);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 通过选题记录id获取最新路径表state
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public Path getState(int titleRecordId,int type)
        {
            return pdao.getState(titleRecordId,type);
        }

        /// <summary>
        /// 查询是否有论文
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public Result selectByTitleRecordId(string titleRecordId)
        {
            int row = pdao.selectByTitleRecordId(titleRecordId);
            if (row>0)
            {
                return Result.记录存在;
            }
            else
            {
                return Result.记录不存在;
            }
        }
        /// <summary>
        /// 学生提交查重报告
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public Result InsertReport(Path path)
        {
            int row = pdao.InsertReport(path);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
        /// <summary>
        /// 通过选题记录id更新state
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Result updateState(Path path)
        {
            int row = pdao.updateState(path);
            if (row > 0)
            {
                return Result.更新成功;
            }
            return Result.更新失败;
        }
        /// <summary>
        /// 通过学生账号获取选题记录id
        /// </summary>
        /// <param name="stuAccount">学生账号</param>
        /// <returns></returns>
        public Path getTitleRecordId(string stuAccount)
        {
            return pdao.getTitleRecordId(stuAccount);
        }

        /// <summary>
        /// 通过选题记录id获取路径信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public DataSet getModel(int titleRecordId,string stuAccount)
        {
            return pdao.Select(titleRecordId, stuAccount);
        }
        /// <summary>
        /// 查重报告进度
        /// </summary>
        /// <param name="titleRecordId"></param>
        /// <returns></returns>
        public DataSet getCheckReport(int titleRecordId)
        {
            return pdao.checkReport(titleRecordId);
        }

        /// <summary>
        /// 通过选题记录id获取最新的路径信息
        /// </summary>
        /// <param name="titleRecordId">选题记录id</param>
        /// <returns></returns>
        public Path Select(int titleRecordId,string stuAccount)
        {
            DataSet ds = pdao.Select(titleRecordId,stuAccount);
            Path path = new Path();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count - 1;
                path.pathId = Convert.ToInt32(ds.Tables[0].Rows[i]["pathId"].ToString());
                path.title = ds.Tables[0].Rows[i]["pathTitle"].ToString();
                path.paperPath = ds.Tables[0].Rows[i]["path"].ToString();
                path.dateTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["dateTime"].ToString());
                return path;
            }
            return null;
        }
    }
}

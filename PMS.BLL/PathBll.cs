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

        public Path getTitleRecordId(string stuAccount)
        {
            return pdao.getTitleRecordId(stuAccount);
        }
        public DataSet getModel(int titleRecordId)
        {
            return pdao.Select(titleRecordId);
        }
        public Path Select(int titleRecordId)
        {
            DataSet ds = pdao.Select(titleRecordId);
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

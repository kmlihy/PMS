using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Model;
using PMS.Dao;

namespace PMS.BLL
{
    using Result = Enums.OpResult;
    /// <summary>
    /// 文件路径业务处理类
    /// </summary>
    public class PathBll
    {
        /// <summary>
        /// 添加一条文件路径信息
        /// </summary>
        /// <param name="path">要添加的路径对象</param>
        /// <returns>成功返回Result.添加成功，失败返回Result.添加失败</returns>
        public Result Insert(Path path)
        {
            PathDao pdao = new PathDao();
            int row = pdao.Insert(path);
            if (row > 0)
            {
                return Result.添加成功;
            }
            return Result.添加失败;
        }
    }
}

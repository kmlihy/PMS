using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.Dao;
using PMS.Model;

namespace PMS.BLL
{
    using System.Data;
    using Result = Enums.OpResult;
    public class NewsBll
    {
        private NewsDao dao = new NewsDao();

        /// <summary>
        /// 添加公告
        /// </summary>
        /// <param name="news">公告实体</param>
        /// <returns>返回处理结果</returns>
        public Enums.OpResult Insert(News news)
        {
            int count = dao.Insert(news);
            if (count>0)
            {
                return Result.添加成功;
            }
            else
            {
                return Result.添加失败;
            }
           
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="newsId">公告id</param>
        /// <returns>返回处理结果</returns>
        public Enums.OpResult Delete(int newsId)
        {
            int count = dao.Delete(newsId);
            if (count>0)
            {
                return Result.删除成功;
            }
            else
            {
                return Result.删除失败;
            }
        }

        public Enums.OpResult Update(News news)
        {
            int count = dao.Update(news);
            if (count>0)
            {
                return Result.更新成功;
            }
            else
            {
                return Result.更新失败;
            }
        }
        /// <summary>
        /// 根据id查询公告信息
        /// </summary>
        /// <param name="newsId">公告id</param>
        /// <returns>返回结果集</returns>
        public DataSet Select(int newsId)
        {
            DataSet ds = dao.Select(newsId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据公告名称进行模糊查询
        /// </summary>
        /// <param name="newsTitle">公告名称</param>
        /// <returns>返回查询结果</returns>
        public DataSet Select(string newsTitle)
        {
            DataSet ds = dao.Select(newsTitle);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据公告id查询出结果
        /// </summary>
        /// <param name="newsId">公告id</param>
        /// <returns>返回实体</returns>
        public News GetNews(int newsId)
        {
            return dao.GetNews(newsId);
        }
    }
}

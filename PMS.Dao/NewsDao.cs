using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using PMS.DBHelper;
using PMS.Model;
namespace PMS.Dao
{
    /// <summary>
    /// 公告数据库操作类
    /// </summary>
    
   public class NewsDao
   {
        private SQLHelper db = new SQLHelper();
        /// <summary>
        /// 向数据库中添加一条公告信息
        /// </summary>
        /// <param name="news">公告实体</param>
        /// <returns>受影响行数</returns>
        public int Insert(News news)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("insert into T_News ");
            strBuilder.Append("values(");
            strBuilder.Append("@newsTitle,@newsContent,@createTime,@teaAccount)");
            string[] param = { "@newsTitle","@newsContent","@createTime","@teaAccount" };
            object[] values = {news.NewsTitle,news.NewsContent,news.CreateTime,news.teacher.TeaAccount.ToString() };
            return db.ExecuteNoneQuery(strBuilder.ToString(),param,values);
        }

        /// <summary>
        /// 根据公告id删除一条公告信息
        /// </summary>
        /// <param name="NewsId">公告id</param>
        /// <returns>受影响行数</returns>
        public int Delete(int NewsId)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("delete T_News where ");
            strBuilder.Append("newsId = @newsId");
            string[] param = {"@newsId" };
            string[] values = {NewsId.ToString() };
            return db.ExecuteNoneQuery(strBuilder.ToString(),param,values);
        }

        /// <summary>
        /// 通过公告id修改一条公告记录
        /// </summary>
        /// <param name="news">公告实体</param>
        /// <returns>受影响行数</returns>
        public int Update(News news)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("update T_News set ");
            strBuilder.Append("newsTitle=@newsTitle,");
            strBuilder.Append("newsContent=@newsContent,");
            strBuilder.Append("createTime=@createTime,");
            strBuilder.Append("teaAccount=@teaAccount ");
            strBuilder.Append("where newsId=@newsId");
            string[] param = {"@newsId", "@newsTitle", "@newsContent","@createTime", "@teaAccount", };
            string[] values = {news.NewsId.ToString(),news.NewsTitle,news.NewsContent,news.CreateTime.ToString(),news.teacher.TeaAccount };
            return db.ExecuteNoneQuery(strBuilder.ToString(),param,values);
        }

        /// <summary>
        /// 通过公告id查询公告信息
        /// </summary>
        /// <param name="newsId">公告id</param>
        /// <returns>返回结果集</returns>
        public DataSet Select(int newsId)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("slect * from V_News");
            strBuilder.Append("where newsId=@newsId");
            string[] param = { "newsId" };
            string[] values = { newsId.ToString() };
            return db.FillDataSet(strBuilder.ToString(), param, values);
        }

        /// <summary>
        /// 根据公告名称进行模糊查询
        /// </summary>
        /// <param name="newsTitle">公告名称</param>
        /// <returns>查询结果</returns>
        public DataSet Select(string newsTitle)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("select * from V_News");
            strBuilder.Append("where newsTitle like");
            strBuilder.Append("%@newsTitle%");
            string[] param = { "@newsTitle" };
            string[] values = { newsTitle };
            DataSet ds = db.FillDataSet(strBuilder.ToString(), param, values);
            return ds;
        }

        public News GetNews(int newsId)
        {
            try
            {
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.Append("select * from V_News where ");
                strBuilder.Append("newsId=@newsId");
                string[] param = { "@newsId " };
                string[] values = { newsId.ToString() };
                DataSet ds = db.FillDataSet(strBuilder.ToString(), param, values);
                News news = new News();
                Teacher teacher = new Teacher();
                College college = new College();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["newsId"].ToString() != "" && newsId.ToString() == ds.Tables[0].Rows[0]["newsId"].ToString())
                    {
                        news.NewsId = int.Parse(ds.Tables[0].Rows[0]["newsId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["newsTitle"].ToString() != "")
                    {
                        news.NewsTitle = ds.Tables[0].Rows[0]["newsTitle"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["newsContent"].ToString() != "")
                    {
                        news.NewsContent = ds.Tables[0].Rows[0]["newsContent"].ToString();
                    }
                    if (DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString()) != null)
                    {
                        news.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["teaAccount"].ToString() != "")
                    {
                        teacher.TeaAccount = ds.Tables[0].Rows[0]["teaAccount"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["teaPwd"].ToString() != "")
                    {
                        teacher.TeaPwd = ds.Tables[0].Rows[0]["teaPwd"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["teaName"].ToString() != "")
                    {
                        teacher.TeaName = ds.Tables[0].Rows[0]["teaName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["sex"].ToString() != "")
                    {
                        teacher.Sex = ds.Tables[0].Rows[0]["sex"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["phone"].ToString() != "")
                    {
                        teacher.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["email"].ToString() != "")
                    {
                        teacher.Email = ds.Tables[0].Rows[0]["email"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["collegeId"].ToString() != "")
                    {
                        college.ColID = int.Parse(ds.Tables[0].Rows[0]["collegeId"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["teaType"].ToString() != null)
                    {
                        teacher.TeaType = int.Parse(ds.Tables[0].Rows[0]["teaType"].ToString());
                    }
                    if (teacher != null)
                    {
                        news.teacher = teacher;
                    }
                    if (college != null)
                    {
                        news.college = college;
                    }

                }
                return news;
            }
            catch (Exception)
            {

                throw;
            }
        }
   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class addNews : CommonPage
    {
        TitleBll titleBll = new TitleBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (op == "add")
            {
                try
                {
                    string newsTitle = Request["newsTitle"].ToString();
                    string content = Request["content"].ToString();
                    //TODO将从登录的Session中取到公告发布对象
                    int state = Convert.ToInt32(Session["state"]);
                    if (state == 0 || state == 2)
                    {
                        Teacher teacher = (Teacher)Session["user"];
                        NewsBll bll = new NewsBll();
                        News news = new News();
                        news.NewsTitle = newsTitle;
                        news.NewsContent = HttpUtility.UrlDecode(content);
                        news.teacher = teacher;
                        news.CreateTime = DateTime.Now;
                        Result result = bll.Insert(news);
                        if (result == Result.添加成功)
                        {
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + teacher.TeaName + "发布公告");
                            Response.Write("添加成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("添加失败");
                            Response.End();
                        }
                    }
                    else
                    {
                        Teacher teacher = (Teacher)Session["loginuser"];
                        NewsBll bll = new NewsBll();
                        News news = new News();
                        news.NewsTitle = newsTitle;
                        news.NewsContent = HttpUtility.UrlDecode(content);
                        news.teacher = teacher;
                        news.CreateTime = DateTime.Now;
                        Result result = bll.Insert(news);
                        if (result == Result.添加成功)
                        {
                            LogHelper.Info(this.GetType(), teacher.TeaAccount + teacher.TeaName + "发布公告");
                            Response.Write("添加成功");
                            Response.End();
                        }
                        else
                        {
                            Response.Write("添加失败");
                            Response.End();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.Error(this.GetType(), ex);
                }
            }
        }
    }
}
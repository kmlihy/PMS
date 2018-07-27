using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;
    public partial class addNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            if (op == "add")
            {
                string newsTitle = Request["newsTitle"].ToString();
                string content = Request["content"].ToString();
                //TODO将从登录的Session中取到公告发布对象
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
    }
}
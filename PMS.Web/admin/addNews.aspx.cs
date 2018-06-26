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
    public partial class addNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else
            {
                string newsTitle = Request.Form["newsTitle"].ToString();
                string content = Request.Form["content"].ToString();
                //TODO将从登录的Session中取到公告发布对象
                //Teacher teacher = (Teacher)Session["user"];
                if (newsTitle != null && content != null)
                {
                    NewsBll bll = new NewsBll();
                    News news = new News();
                    news.NewsTitle = newsTitle;
                    news.NewsContent = content;
                    news.teacher = new Teacher { TeaAccount = "admin" };
                    news.CreateTime = DateTime.Now;
                    Enums.OpResult enums = bll.Insert(news);
                    if (enums.Equals(Enums.OpResult.添加成功))
                    {
                        Response.Write("<script>alert('发布成功')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('发布失败')</script>");
                    }
                }
            }
      
        }
    }
}
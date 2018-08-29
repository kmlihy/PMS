using PMS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection files = Request.Files;
            string msg = string.Empty;
            string error = string.Empty;
            if (files.Count > 0)
            {
                Student student = (Student)Session["loginuser"];
                string stuAccount = student.StuAccount;
                string stuName = student.RealName;
                string director = Server.MapPath("/upload/"+ stuAccount + stuName+"/");
                if (!Directory.Exists(director))
                {
                    Directory.CreateDirectory(director);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                string path = director + System.IO.Path.GetFileName(now + "-" + files[0].FileName);
                if (File.Exists(path))
                {
                    msg = "上传失败，文件存在";
                }
                else
                {
                    files[0].SaveAs(path);
                    msg = "上传成功";
                }
                string res = "{ error:'" + error + "', msg:'" + msg + "'}";
                Response.Write(res);
                Response.End();
            }
        }
    }
}
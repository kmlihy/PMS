using PMS.BLL;
using PMS.DBHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
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
                string director = Server.MapPath(@"/upload/importExcel/"); //上传目录
                if (!Directory.Exists(director))
                {
                    Directory.CreateDirectory(director);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                string filePath = now + "-" + files[0].FileName.Replace(" ", "");
                string path = director + Path.GetFileName(filePath);
                string extension = System.IO.Path.GetExtension(path).ToLower();
                if (extension == ".xls" || extension == ".xlsx")
                {
                    if (File.Exists(path))
                    {
                        msg = "上传失败，文件存在";
                    }
                    if ((files[0].ContentLength / 1000) > 1024000)
                    {
                        msg = "文件大小超过限制";
                    }

                    else
                    {
                        files[0].SaveAs(path);
                        //返回json数据
                        msg = "上传成功";
                        LogHelper.Info(this.GetType(), "admin - 文件上传 "+" "+path);
                    }
                    string res = "{ error:'" + error + "', msg:'" + msg + "',filePath:'" + Security.Encrypt(path) + "'}";
                    Response.Write(res);
                    Response.End();
                }
                else
                {
                    string res = "{ error:'只允许上传.xls或者.xlsx格式的文件', msg:'只允许上传.xls或者.xlsx格式的文件'}";
                    Response.Write(res);
                    Response.End();
                }
            }
            else
            {
                string res = "{ error:'未选择文件', msg:'未选择文件'}";
                Response.Write(res);
                Response.End();
            }
        }
    }
}
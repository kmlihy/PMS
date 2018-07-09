using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PMS.Model;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class test : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            string op = Context.Request["op"];
            if (!IsPostBack)
            {

            }
            else
            {
                if (op == "upload")
                {
                    upload();
                }
            }


        }

        public void upload()
        {
            try
            {
                Teacher user = (Teacher)Session["user"];//取得登录用户用账号作为文件夹名称
                HttpFileCollection file = HttpContext.Current.Request.Files;//从HTTP文件流中读取上传文件
                if (file.Count > 0)
                {
                    //文件大小   
                    long size = file[0].ContentLength;
                    //文件类型   
                    string type = file[0].ContentType;
                    //文件名  IE浏览器文件名是绝对路径，服务器文件夹名不支持（\\），其他浏览器为文件名(兼容ie) 
                    string filename = "";
                    filename = file[0].FileName;
                    if (filename.IndexOf("\\") != -1)//判断路径中是否包含\\
                    {
                        string[] a = filename.Split('\\');//分割字符串
                        filename = a[a.Length - 1].ToString();//取数组最后一位作为文件夹名称
                    }
                    else
                    {
                        filename = file[0].FileName;//不是ie直接返回文件名称作为文件夹名
                    }
                    //文件格式   
                    string tp = System.IO.Path.GetExtension(filename);

                    if (tp == ".xls" || tp == "xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储");//指定上传文件在服务器上的保存路 
                        dir = new DirectoryInfo(savePath);
                        dir.Create();


                        savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储/" + user.TeaAccount + "");
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");

                        string name = datetime + "-" + filename;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//将路径合并

                        file[0].SaveAs(savePath);//存入服务器

                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable
                        CollegeBll bll = new CollegeBll();
                        int row = bll.upload(dt);
                        if (row > 0)
                        {
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('导入失败');</script>");
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('导入成功');</script>");
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('Excel格式不正确');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "js", "<script>alert('请选择上传文件');</script>");
                }
            }
            catch (Exception ex)
            {
                this.Response.Write(ex.Message);
            }
        }
    }
}
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
        protected string getName = "";
        protected int getCurrentPage = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Context.Request["op"];
            string path = Context.Request["Path"];
            if (op == "upload")
            {
                try
                {
                    //"C:\\Users\\潘江涛\\Desktop\\新建 XLS 工作表.xls"
                   
                    //Teacher user =(Teacher)Session["user"];//取得登录用户用账号作为文件夹名称
                    string x = path.Replace('\\', '*');
                    string[] path1 = x.Split('*');
                    string fileName = "";
                    fileName = path1[path1.Length - 1];
                    System.Diagnostics.Debug.WriteLine(fileName);
                    
                    string eddstring = path.Substring(path.Length - 4);//获取后四位后缀进行判断
                    if (eddstring == ".xls" || eddstring == "xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储");//指定上传文件在服务器上的保存路 //获取服务器根目录
                        dir= new DirectoryInfo(savePath);
                        dir.Create();

                        savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储/");
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");

                        string name = datetime + "-"+fileName;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//将路径合并

                        DataTable data = ExcelHelper.GetDataTable(path);//从上传的目录里读取数据

                        ExcelHelper.x2003.TableToExcelForXLS(data, savePath);//将读出的数据给定路径存入到服务器中

                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable

                        //CollegeBll bll = new CollegeBll();
                        ProfessionBll bll = new ProfessionBll();
                        Result row = bll.upload(dt);
                        if (row == Result.添加失败)
                        {
                            Response.Write("导入失败");
                        }
                        else
                        {
                            Response.Write("导入成功");
                        }
                    }
                    else
                    {
                        this.Response.Write("Excel格式不正确");
                    }
                }
                catch (Exception ex)
                {
                    this.Response.Write(ex.Message);
                }
            }

        }
    }
}
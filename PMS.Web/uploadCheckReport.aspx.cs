using PMS.BLL;
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
    using Result = Enums.OpResult;
    public partial class uploadCheckReport : System.Web.UI.Page
    {
        PathBll pathBll = new PathBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string account = student.StuAccount;

            HttpFileCollection files = Request.Files;
            string msg = string.Empty;
            string error = string.Empty;
            if (files.Count > 0)
            {
                string stuAccount = student.StuAccount;
                string stuName = student.RealName;
                string year = DateTime.Now.ToString("yyyy");
                string absPath = "/upload/学生/" + stuAccount + stuName + "/论文/" + year + "/";
                string director = Server.MapPath(absPath);
                if (!Directory.Exists(director))
                {
                    Directory.CreateDirectory(director);
                }
                string now = DateTime.Now.ToString("yyyyMMddHHmmss");
                string path = director + System.IO.Path.GetFileName(now + "-" + files[0].FileName);
                string fileName = absPath + now + "-" + files[0].FileName;
                if (File.Exists(path))
                {
                    msg = "上传失败，文件存在";
                }
                else
                {
                    string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    files[0].SaveAs(path);

                    Model.Path _path = pathBll.getTitleRecordId(account);
                    int titleRecordId = _path.titleRecord.TitleRecordId;

                    Model.Path insertPath = new Model.Path();
                    TitleRecord titleRecord = new TitleRecord();
                    titleRecord.TitleRecordId = titleRecordId;
                    insertPath.titleRecord = titleRecord;
                    string docx = files[0].FileName.Substring(0, files[0].FileName.Length - 4);
                    if (docx.Contains("."))
                    {
                        docx = docx.Replace(".","");
                    }
                    else
                    {
                        docx = files[0].FileName.Substring(0, files[0].FileName.Length - 4);
                    }
                    insertPath.title = docx;
                    insertPath.paperPath = fileName;
                    insertPath.dateTime = Convert.ToDateTime(time);
                    Result result = pathBll.InsertReport(insertPath);
                    insertPath.state = 2;
                    Result row = pathBll.updateState(insertPath);
                    if (result == Result.添加成功 && row == Result.更新成功)
                    {
                        msg = "上传成功";
                    }
                    else
                    {
                        msg = "上传失败";
                    }
                }
                string res = "{ error:'" + error + "', msg:'" + msg + "'}";
                Response.Write(res);
                Response.End();
            }
        }
    }
}
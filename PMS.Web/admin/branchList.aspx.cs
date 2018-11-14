using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web.admin
{
    using Result = Enums.OpResult;

    public partial class branchList : CommonPage
    {
        CollegeBll collBll = new CollegeBll();
        College college = new College();
        Result result;
        //获取数据
        protected DataSet ds = null, dsColl = null;
        protected int getCurrentPage = 1;
        protected int count;
        protected int pagesize = 5;
        protected String search = "";
        protected String strSearch = "";
        Teacher user;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = (Teacher)Session["user"];
            string op = Context.Request["op"];
            //第一次加载页面时
            if (!Page.IsPostBack)
            {
                Search();
                getdata(Search());
            }
            //添加学院
            if (op == "add")
            {
                saveCollege();
                Search();
                getdata(Search());                
            }
            //编辑学院信息
            else if (op == "edit")
            {
                editCollege();
                Search();
                getdata(Search());
            }
            //批量上传
            else if (op == "upload")
            {
                upload();
                Search();
                getdata(Search());
            }
            //删除学院
            else if (op == "dele")
            {
                deleteCollege();
                Search();
                getdata(Search());
            }
            //批量删除
            else if (op == "batchDel")
            {
                batchDeleteCollege();
                Search();
                getdata(Search());
            }
        }
        
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        public void getdata(String strWhere)
        {
            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tbd = new TableBuilder()
            {
                StrTable = "T_College",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "collegeId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = collBll.SelectBypage(tbd, out count);
        }
        
        /// <summary>
        /// 添加分院信息
        /// </summary>
        public void saveCollege()
        {
            string collegeName = Context.Request["collegeName"].ToString();
            bool flag = true;
            try
            {
                dsColl = collBll.Select();
                for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                {
                    if (collegeName == dsColl.Tables[0].Rows[i]["collegeName"].ToString())
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    result = Result.添加失败;
                    Response.Write("学院已存在");
                    Response.End();
                }
                else
                {
                    college.ColName = collegeName;
                    result = collBll.Insert(college);
                    if (result == Result.添加成功)
                    {
                        LogHelper.Info(this.GetType(), user.TeaAccount + " - " + user.TeaName + " - 添加" + collegeName);
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
        
        /// <summary>
        /// 编辑分院信息
        /// </summary>
        public void editCollege()
        {
            int collegeId = int.Parse(Context.Request["id"].ToString());
            string collegeName = Context.Request["name"].ToString();
            bool flag = true;
            try
            {
                dsColl = collBll.Select();
                for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                {
                    if (collegeName == dsColl.Tables[0].Rows[i]["collegeName"].ToString())
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    result = Result.更新失败;
                    Response.Write("学院名已存在");
                    Response.End();
                }
                else
                {
                    college.ColID = collegeId;
                    college.ColName = collegeName;
                    result = collBll.Update(college);
                    if (result == Result.更新成功)
                    {
                        LogHelper.Info(this.GetType(), user.TeaAccount + user.TeaName + "-编辑" + collegeId + "学院");
                        Response.Write("更新成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("更新失败");
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }

        /// <summary>
        /// 查询筛选方法
        /// </summary>
        /// <returns>返回查询参数</returns>
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
                strSearch = Request.QueryString["search"];
                if (search.Length == 0)
                {
                    search = "";
                }
                else if (search == null)
                {
                    search = "";
                }
                else
                {
                    search = String.Format("collegeName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }

        /// <summary>
        /// 批量导入
        /// </summary>
        public void upload()
        {
            try
            {
                //Teacher user = (Teacher)Session["user"];//取得登录用户用账号作为文件夹名称
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

                    if (tp == ".xls" || tp == ".xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储/admin");//指定上传文件在服务器上的保存路径
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        //savePath = Server.MapPath("~/upload/学院信息导入Excel文件存储/admin" + "");
                        //dir = new DirectoryInfo(savePath);
                        //dir.Create();

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
                this.Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }

        /// <summary>
        /// 单个删除前判断是否能删除
        /// </summary>
        /// <returns>返回判断结果</returns>
        public Result IsdeleteCollege()
        {
            Result row = Result.记录不存在;
            string collegeid = Context.Request["collegeid"].ToString();
            if (collBll.IsDelete("T_Plan", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (collBll.IsDelete("T_Profession", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (collBll.IsDelete("T_Teacher", "collegeId", collegeid) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public void deleteCollege()
        {
            string collegeid = Context.Request["collegeid"].ToString();
            try
            {
                Result row = IsdeleteCollege();
                if (row == Result.记录不存在)
                {
                    Result result = collBll.Delete(int.Parse(collegeid));
                    if (result == Result.删除成功)
                    {
                        LogHelper.Info(this.GetType(), user.TeaAccount + user.TeaName + "-删除" + collegeid + "学院");
                        Response.Write("删除成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("删除失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("在其他表中有关联不能删除");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }

        /// <summary>
        /// 批量删除前判断是否能删除
        /// </summary>
        /// <returns>Result对象</returns>
        public Result IsBatchDelete()
        {
            Result row = Result.记录不存在;
            string collId = Context.Request["collId"].ToString();
            string[] collList = collId.Split('?');
            for (int i = 0; i < collList.Length; i++)
            {
                if (collBll.IsDelete("T_Plan", "collegeId", collList[i]) == Result.关联引用)
                {
                    row = Result.关联引用;
                }
                if (collBll.IsDelete("T_Profession", "collegeId", collList[i]) == Result.关联引用)
                {
                    row = Result.关联引用;
                }
                if (collBll.IsDelete("T_Teacher", "collegeId", collList[i]) == Result.关联引用)
                {
                    row = Result.关联引用;
                }
            }
            return row;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public void batchDeleteCollege()
        {
            try
            {
                string collegeid = Context.Request["collId"].ToString();
                string[] collList = collegeid.Split('?');
                Result row = IsBatchDelete();
                int count = 0;
                if (row == Result.记录不存在)
                {
                    for (int i = 0; i < collList.Length - 1; i++)
                    {
                        int collId = int.Parse(collList[i]);
                        Result result = collBll.Delete(collId);
                        if (result == Result.删除成功)
                        {
                            LogHelper.Info(this.GetType(), user.TeaAccount + user.TeaName + "-删除" + collId + "学院");
                            count++;
                        }
                    }
                    if (count == collList.Length - 1)
                    {
                        Response.Write("删除成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("删除失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("在其他表中有关联不能删除");
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
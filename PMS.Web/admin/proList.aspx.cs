﻿using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PMS.BLL.Enums;

namespace PMS.Web.admin
{
    using System.IO;
    using Result = Enums.OpResult;
    public partial class proList : System.Web.UI.Page
    {

        //列表
        protected DataSet ds = null;
        //专业
        protected ProfessionBll probll2 = new ProfessionBll();
        //分院
        protected DataSet colds = null;
        protected CollegeBll colbll = new CollegeBll();
        //当前页数
        protected int getCurrentPage = 1;
        //总页
        protected int count;
        //每页的行数
        protected int pagesize = 3;
        //查询条件
        public String search = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //添加专业
            string op = Context.Request.Form["op"];
            if (op == "add")
            {
                saveProfession();
                Search();
                getPage(Search());
            }
            //修改专业
            if (op == "change")
            {
                saveChange();
                Search();
                getPage(Search());
            }
            //删除专业
            if (op == "del")
            {
                delPro();
                Search();
                getPage(Search());
            }
            if (op == "upload")
            {
                upload();
            }
            if (!IsPostBack)
            {
                getPage(Search());
                colds = colbll.Select();
            }
        }
        //添加专业
        public void saveProfession()
        {
            College college = new College();
            string proName = Context.Request["proName"].ToString();
            int collegeId = Convert.ToInt32(Context.Request["collegeId"]);
            Profession pro = new Profession();
            college.ColID = collegeId;
            pro.college = college;
            pro.ProName = proName;
            ProfessionBll probll = new ProfessionBll();
            OpResult result = probll.Insert(pro);
            if (result == OpResult.添加成功)
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
        //判断是否能删除
        public Result IsdeleteCollege()
        {
            string delproId = Context.Request["DelProId"].ToString();
            Result row = Result.记录不存在;
            if (probll2.IsDelete("T_Student", "proId", delproId) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            if (probll2.IsDelete("T_Title", "proId", delproId) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        //删除
        public void delPro()
        {
            int proId = int.Parse(Context.Request["DelProId"].ToString());
            Result row = IsdeleteCollege();
            if (row == Result.记录不存在)
            {
                Result result = probll2.Delete(proId);

                if (result == Result.删除成功)
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
        //修改
        public void saveChange()
        {
            College college = new College();
            string proName = Context.Request["proName"].ToString();
            int proId = Convert.ToInt32(Context.Request["ProId"]);
            int collegeId = Convert.ToInt32(Context.Request["collegeId"]);
            Profession pro = new Profession();
            college.ColID = collegeId;
            pro.college = college;
            pro.ProId = proId;
            pro.ProName = proName;
            ProfessionBll probll = new ProfessionBll();
            OpResult result = probll.Update(pro);
            if (result == OpResult.更新成功)
            {
                Response.Write("修改成功");
                Response.End();
            }
            else
            {
                Response.Write("修改失败");
                Response.End();
            }
        }
        //列表数据获取
        public void getPage(String strWhere)
        {

            string currentPage = Request.QueryString["currentPage"];
            if (currentPage == null || currentPage.Length <= 0)
            {
                currentPage = "1";
            }
            TableBuilder tabuilder = new TableBuilder()
            {
                StrTable = "V_Profession",
                StrWhere = strWhere == null ? "" : strWhere,
                IntColType = 0,
                IntOrder = 0,
                IntPageNum = int.Parse(currentPage),
                IntPageSize = pagesize,
                StrColumn = "proId",
                StrColumnlist = "*"
            };
            getCurrentPage = int.Parse(currentPage);
            ds = probll2.SelectBypage(tabuilder, out count);
        }
        public string Search()
        {
            try
            {
                search = Request.QueryString["search"];
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
                    search = String.Format(" proName {0} or collegeName {0}", "like '%" + search + "%'");
                }
            }
            catch
            {
            }
            return search;
        }
        //批量导入
        public void upload()
        {
            try
            {
                Teacher user = (Teacher)Session["user"];//获取当前用户账号作为文件夹名称
                HttpFileCollection file = HttpContext.Current.Request.Files;//从HTTP文件流读取上传文件
                if (file.Count > 0)
                {
                    //文件大小
                    long size = file[0].ContentLength;
                    //文件类型
                    string type = file[0].ContentType;
                    //文件名 IE浏览器文件名是绝对路径，服务器文件夹名称不支持(//),其他浏览器为文件名（兼容IE）
                    string filename = "";
                    if (filename.IndexOf("\\") != -1)//判断路径中是否包含\\
                    {
                        string[] a = filename.Split('\\');//分割字符串
                        filename = a[a.Length - 1].ToString();//获取数组 最后一位作为文件夹名称
                    }
                    else
                    {
                        filename = file[0].FileName;//不是IE 直接返回文件名称作为文件夹名称
                    }
                    //文件格式
                    string tp = System.IO.Path.GetExtension(filename);
                    if (tp == ".xls" || tp == "xlsx")
                    {
                        DirectoryInfo dir;
                        //将文件导入服务器
                        string savePath = Server.MapPath("~/upload/专业信息导入存储");//指定上传文件，在服务器保存路径
                        dir = new DirectoryInfo(savePath);
                        dir.Create();

                        DateTime d = DateTime.Now;
                        string datetime = d.ToString("yyyyMMddHHmmss");
                        string name = datetime + "-" + filename;//将当前时间作为文件名称
                        savePath = savePath + "\\" + name;//路径合并
                        file[0].SaveAs(savePath);//存入服务器
                        var dt = ExcelHelper.GetDataTable(savePath);//从服务器路径读取数据成DataTable
                        TeacherBll bll = new TeacherBll();
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
                Response.Write(ex.Message);
            }
        }
    }
}
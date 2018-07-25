﻿using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    using Result = Enums.OpResult;


    public partial class paperDetail : System.Web.UI.Page
    {
        string stuId = "";
        PublicProcedureBll pbll = new PublicProcedureBll();
        StudentBll stuBll = new StudentBll();

        protected Title titleId = null;
        protected string titleid;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student stu = (Student)Session["loginuser"];
            stuId = stu.StuAccount;

            string op = Context.Request.QueryString["op"];

            titleid = Request.QueryString["titleId"].ToString();
            TitleBll nb = new TitleBll();
            titleId = nb.GetTitle(int.Parse(titleid));

            if (op == "selectTitle")
            {
                StusecltTitle();
            }
        }
        /// <summary>
        /// //判断是否已选题
        /// </summary>
        /// <returns>返回是否已选题</returns>
        public Result isExist()
        {
            //如果存在关联即表示已选，反之则未选
            //string stuId = Context.Request["stuId"].ToString();
            Result row = Result.记录不存在;
            if (stuBll.IsDelete("T_TitleRecord", "stuAccount", stuId) == Result.关联引用)
            {
                row = Result.关联引用;
            }
            return row;
        }
        /// <summary>
        /// 执行选题操作
        /// </summary>
        public void StusecltTitle()
        {
            //string stuId = Context.Request["stuId"].ToString();
            int titleid = int.Parse(Context.Request.QueryString["titleId"]);
            Title dstitle = new Title();
            TitleBll titleSelect = new TitleBll();
            dstitle = titleSelect.GetTitle(titleid);

            int limited = int.Parse(dstitle.Limit.ToString());
            int selected = int.Parse(dstitle.Selected.ToString());
            if (selected < limited)
            {
                Result row = isExist();
                if (row == Result.记录不存在)
                {

                    TitleRecord titleRecord = new TitleRecord();
                    Student student = new Student();
                    student.StuAccount = stuId;
                    titleRecord.student = student;
                    Title title = new Title();
                    title.TitleId = titleid;
                    titleRecord.title = title;

                    int rows = pbll.AddTitlerecord(titleRecord);
                    if (rows > 0)
                    {
                        Response.Write("选题成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("选题失败");
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("已选题");
                    Response.End();
                }
            }
            else
            {
                Response.Write("已达上限");
                Response.End();
            }

        }
    }
}
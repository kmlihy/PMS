﻿using PMS.BLL;
using PMS.DBHelper;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static PMS.BLL.Enums;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class reg : System.Web.UI.Page
    {
        protected DataSet dsColl = null, dsPro = null, dsStu = null;
        protected int count;
        protected string collid;
        Result result;
        CollegeBll collbll = new CollegeBll();
        ProfessionBll probll = new ProfessionBll();
        Profession pro = new Profession();
        StudentBll stuBll = new StudentBll();
        College coll = new College();
        Student stu = new Student();
        protected string college;
        protected string profession;
        protected string account;
        protected string name;
        protected string sex;
        protected string pwd;
        protected string email;
        protected string phone;


        protected void Page_Load(object sender, EventArgs e)
        {
            //获取学院
            dsColl = collbll.Select();
            //获取专业
            if (Context.Request["op"] != null)
            {
                string op = Context.Request["op"].ToString();
                if (op == "load"|| string.Compare(Request.RequestType, "get", true) == 0)
                {
                    getPro();
                }
                else if (op == "add")
                {
                     insert();
                    
                }
            }

        }
        //获取专业
        protected void getPro()
        {
            dsPro = probll.Select();
            int count = dsPro.Tables[0].Rows.Count;
            collid = Context.Request["collegeId"].ToString();
            TableBuilder tbd = new TableBuilder();
            tbd.StrTable = "T_Profession";
            tbd.StrColumn = "proId";
            tbd.IntColType = 0;
            tbd.IntOrder = 0;
            tbd.StrColumnlist = "*";
            tbd.IntPageSize = count;
            tbd.IntPageNum = 1;
            tbd.StrWhere = collid=="" ? "" : "collegeId = " + int.Parse(collid);
            dsPro = probll.SelectBypage(tbd, out count);
        }
        //添加学生
        protected void insert()
        {
            college = Context.Request["collegeId"].ToString();
            profession = Context.Request["profession"].ToString();
            account = Context.Request["account"].ToString();
            name = Context.Request["name"].ToString();
            sex = Context.Request["sex"].ToString();
            pwd = Context.Request["pwd"].ToString();
            email = Context.Request["email"].ToString();
            phone = Context.Request["phone"].ToString();
            string year = DateTime.Now.ToString("yyyy");
            //根据输入的邮箱、联系电话查找是否已存在
            result = Result.添加失败;
            try
            {
                bool flagEmail = stuBll.selectByEmail(email);
                bool flagPhone = stuBll.selectByPhone(phone);
                if (flagEmail)
                {
                    Response.Write("此邮箱已存在");
                    Response.End();
                }
                else if (flagPhone)
                {
                    Response.Write("此联系电话已存在");
                    Response.End();
                }
                else
                {
                    pro.ProId = int.Parse(profession);
                    coll.ColID = int.Parse(college);
                    stu.college = coll;
                    stu.Email = email;
                    stu.Phone = phone;
                    stu.profession = pro;
                    stu.RealName = name;
                    stu.Sex = sex;
                    stu.StuAccount = account;
                    stu.StuPwd = pwd;
                    stu.finishYear = Convert.ToInt32(year);
                    result = stuBll.Insert(stu);
                    if (result == Result.添加成功)
                    {
                        LogHelper.Info(this.GetType(), account + " - " + name + " - 学生注册");
                        Response.Write("注册成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("注册失败");
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
    }
}
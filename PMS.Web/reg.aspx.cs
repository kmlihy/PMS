using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        Result result;
        CollegeBll collbll = new CollegeBll();
        ProfessionBll probll = new ProfessionBll();
        Profession pro = new Profession();
        StudentBll stuBll = new StudentBll();
        College coll = new College();
        Student stu = new Student();

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取学院
            dsColl = collbll.Select();
            //获取专业
            if (Context.Request["op"] != null)
            {
                string op = Context.Request["op"].ToString();
                if (op == "load")
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
            string collid = Context.Request["collegeId"].ToString();
            TableBuilder tbd = new TableBuilder();
            tbd.StrTable = "T_Profession";
            tbd.StrColumn = "proId";
            tbd.IntColType = 0;
            tbd.IntOrder = 0;
            tbd.StrColumnlist = "*";
            tbd.IntPageSize = count;
            tbd.IntPageNum = 1;
            tbd.StrWhere = "collegeId = " + int.Parse(collid);
            dsPro = probll.SelectBypage(tbd, out count);
        }
        //添加学生
        protected void insert()
        {
            string college = Context.Request["collegeId"].ToString();
            string profession = Context.Request["profession"].ToString();
            string account = Context.Request["account"].ToString();
            string name = Context.Request["name"].ToString();
            string sex = Context.Request["sex"].ToString();
            string pwd = Context.Request["name"].ToString();
            string email = Context.Request["email"].ToString();
            string phone = Context.Request["phone"].ToString();
            //根据输入的账号获取学生信息
            stu = stuBll.GetModel(account);
            string strEmail = stu.Email;
            string strPhone = stu.Phone;
            if (email == strEmail && phone == strPhone)
            {
                result = Result.添加失败;
                Response.Write("此联系电话、邮箱已存在");
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
                result = stuBll.Insert(stu);
                if (result == Result.添加成功)
                {
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
    }
}
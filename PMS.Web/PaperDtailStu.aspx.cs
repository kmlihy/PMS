using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PMS.BLL;
using PMS.Model;

namespace PMS.Web
{
    using Result = Enums.OpResult;
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected Title titleId;
        protected DataSet ds;

        protected string stuAccount = "";
        protected Student stu;
        protected string showTitle = "";
        protected string showTitleContent = "";
        protected string showTeaName = "";
        protected string teaAccount;
        protected string teaName;
        protected string sex;
        protected string college;
        protected string phone;
        protected string email;

        StudentBll stuBll = new StudentBll();
        TitleBll titleBll = new TitleBll();
        TitleRecordBll titleRecordBll = new TitleRecordBll();
        TeacherBll tbll = new TeacherBll();
        Teacher teacher = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            stu = (Student)Session["loginuser"];
            stuAccount = stu.StuAccount.ToString();
            ds = titleRecordBll.Select();
            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (stuAccount == ds.Tables[0].Rows[i]["stuAccount"].ToString())
                    {
                        string tId = ds.Tables[0].Rows[i]["titleId"].ToString();
                        titleId = titleBll.GetTitle(int.Parse(tId));
                        showTitle = titleId.title.ToString();
                        showTitleContent = titleId.TitleContent.ToString();
                        showTeaName = titleId.teacher.TeaName.ToString();
                        break;
                    }
                    else
                    {
                        showTitle = "";
                        showTitleContent = "";
                        showTeaName = "";
                    }
                }
            }
            string op = Context.Request.QueryString["op"];
            if (op == "selectTitle")
            {
                StusecltTitle();
            }
            teacher = tbll.GetModel(titleId.teacher.TeaAccount);
            teaName = teacher.TeaName;
            sex = teacher.Sex;
            college = teacher.college.ColName;
            phone = teacher.Phone;
            email = teacher.Email;
            teaAccount = teacher.TeaAccount;
        }
        public void StusecltTitle()
        {
            string titleid = Context.Request.QueryString["titleId"];
            TitleRecord titleRecord = new TitleRecord();
            //TODO 后期从session里获取学生对象
            //Student student =  (Student)Session["user"];               
            Student student = new Student();
            titleRecord.student = stu;
            Title title = new Title();
            title.TitleId = int.Parse(titleid);
            titleRecord.title = title;
            PublicProcedureBll pbll = new PublicProcedureBll();
            int rows = pbll.AddTitlerecord(titleRecord);
            if (rows > 0)
            {
                //Response.Write("选题成功");
                //刷新iframe父页面
                Response.Write("<script>alert('选题成功');</script>");
                Response.Write("<script>parent.location.reload();</script>");
                Response.Write("<script>$('#iframe').src='admin/PaperDtailStu.aspx';</script>");
                //Response.Write("<script>window.location.href=PaperDtailStu.aspx;</script>");
                //Response.Redirect("PaperDtailStu.aspx");
                Response.End();
                
            }
            else
            {
                Response.Write("<script>alert('选题失败');</script>");
                Response.End();
            }
        }

    }
} 
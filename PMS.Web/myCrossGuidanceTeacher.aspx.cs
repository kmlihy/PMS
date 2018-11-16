using PMS.Model;
using PMS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PMS.Web
{
    public partial class myCrossGuidanceTeacher : CommonPage
    {
        public DataSet dsCross=null;
        public string name, sex, phone, email,opninion;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll trecordBll = new TitleRecordBll();
            DataSet ds =trecordBll.GetByAccount(stuAccount);
            if (ds==null)
            {
                opninion = "<h4 class='text-primary'>还未指定交叉指导教师，请耐心等待</h4>";
            }
            else
            {
                int i = ds.Tables[0].Rows.Count - 1;
                int titleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                CrossBll crossBll = new CrossBll();
                DataSet dsTea = crossBll.Select(titleRecordId);
                int j = dsTea.Tables[0].Rows.Count - 1;
                if (j < 0)
                {
                    opninion = "<h4 class='text-primary'>还未指定交叉指导教师，请耐心等待</h4>";
                }
                else
                {
                    name = dsTea.Tables[0].Rows[j]["teaName"].ToString();
                    sex = dsTea.Tables[0].Rows[j]["teaSex"].ToString();
                    phone = dsTea.Tables[0].Rows[j]["teaPhone"].ToString();
                    email = dsTea.Tables[0].Rows[j]["teaEmail"].ToString();
                    dsCross = crossBll.SelectByStu(student.StuAccount);
                    if (dsCross != null)
                    {
                        int a = dsCross.Tables[0].Rows.Count - 1;
                        if (a >= 0)
                        {
                            opninion = "教师回复：" + dsCross.Tables[0].Rows[a]["crossEvaluate"].ToString();
                        }
                        else
                        {
                            opninion = "<h4 class='text-primary'>教师未提交，请耐心等待</h4>";
                        }
                    }
                    else
                    {
                        opninion = "<h4 class='text-primary'>教师未提交，请耐心等待</h4>";
                    }
                }
            }
        }
    }
}
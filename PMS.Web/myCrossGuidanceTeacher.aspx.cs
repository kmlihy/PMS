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
    public partial class myCrossGuidanceTeacher : System.Web.UI.Page
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
                opninion = "<h2>还未指定交叉指导教师，请耐心等待</h2>";
            }
            else
            {
                int i = ds.Tables[0].Rows.Count - 1;
                int titleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
                CrossGuideBll crossBll = new CrossGuideBll();
                DataSet dsTea = crossBll.Select(titleRecordId);
                int j = dsTea.Tables[0].Rows.Count - 1;
                if (j < 0)
                {
                    opninion = "<h2>还未指定交叉指导教师，请耐心等待</h2>";
                }
                else
                {
                    name = dsTea.Tables[0].Rows[j]["teaName"].ToString();
                    sex = dsTea.Tables[0].Rows[j]["teaSex"].ToString();
                    phone = dsTea.Tables[0].Rows[j]["teaPhone"].ToString();
                    email = dsTea.Tables[0].Rows[j]["teaEmail"].ToString();
                    dsCross = crossBll.Select(titleRecordId);
                    if (dsCross != null)
                    {
                        int a = dsCross.Tables[0].Rows.Count - 1;
                        opninion = "教师最新回复：" + dsCross.Tables[0].Rows[a]["guideOpinion"].ToString();
                    }
                    else
                    {
                        opninion = "<h2>教师未提交，请耐心等待</h2>";
                    }
                }
            }
        }
    }
}
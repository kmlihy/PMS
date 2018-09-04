using PMS.BLL;
using PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
    public partial class myGuideTeacher : System.Web.UI.Page
    {
        public DataSet dsGuide;
        public string name, sex, phone, email, opinion;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll trecordBll = new TitleRecordBll();
            DataSet ds = trecordBll.GetByAccount(stuAccount);
            int i = ds.Tables[0].Rows.Count-1;
            int titleRecordId = Convert.ToInt32(ds.Tables[0].Rows[i]["titleRecordId"].ToString());
            name = ds.Tables[0].Rows[i]["teaName"].ToString();
            sex = ds.Tables[0].Rows[i]["teaSex"].ToString();
            phone = ds.Tables[0].Rows[i]["teaPhone"].ToString();
            email = ds.Tables[0].Rows[i]["teaEmail"].ToString();
            GuideRecordBll guideBll = new GuideRecordBll();
            dsGuide = guideBll.Select(titleRecordId);
            if (dsGuide != null)
            {
                int j = dsGuide.Tables[0].Rows.Count - 1;
                if (j<0)
                {
                    opinion = "<h3>教师未回复，请耐心等待</h3>";
                }
                else
                {
                    opinion = "教师回复：" + dsGuide.Tables[0].Rows[j]["opinion"].ToString();
                }
            }
            else
            {
                opinion = "<h3>教师未回复，请耐心等待</h3>";
            }
        }
    }
}
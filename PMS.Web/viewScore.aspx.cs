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
    public partial class viewScore : System.Web.UI.Page
    {
        public string stuAccount, stuName, proName, title;
        public double score;
        public int titleRecordId,state;
        public string content;
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleRecordBll trbll = new TitleRecordBll();
            CrossGuideBll crossGuideBll = new CrossGuideBll();
            ScoreBll sbll = new ScoreBll();
            Student student = (Student)Session["loginuser"];
            stuAccount = student.StuAccount;
            stuName = student.RealName;
            proName = student.profession.ProName;
            DataSet dsTR = trbll.GetByAccount(stuAccount);
            if (dsTR == null)
            {
                Response.Write("<h4>暂未选题</h4>");
                Response.End();
            }
            else
            {
                int planId = 0;
                for (int i = 0; i < dsTR.Tables[0].Rows.Count; i++)
                {
                    string stuaccount = dsTR.Tables[0].Rows[i]["stuAccount"].ToString();
                    if (stuaccount == stuAccount)
                    {
                        titleRecordId = Convert.ToInt32(dsTR.Tables[0].Rows[0]["titleRecordId"].ToString());
                        title = dsTR.Tables[0].Rows[0]["title"].ToString();
                        planId = Convert.ToInt32(dsTR.Tables[0].Rows[0]["planId"].ToString());
                        break;
                    }
                }
                Score _score = sbll.getState(titleRecordId.ToString());
                state = _score.state;
                if (state == 0 || state == 1 || state == 2)
                {
                    content = "暂无成绩";
                }
                else
                {
                    //获取成绩
                    DataSet ds = sbll.Select(stuAccount, planId);
                    int openState = Convert.ToInt32(ds.Tables[0].Rows[0]["openState"].ToString());
                    if (openState == 0)
                    {
                        Response.Write("成绩还未开放查询，请耐心等待");
                        Response.End();
                    }
                    else
                    {
                        double guideScore = 0, crossScore = 0, defenceScore = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string remarks = ds.Tables[0].Rows[i]["remarks"].ToString();
                            if (remarks == "指导成绩")
                            {
                                guideScore = Convert.ToDouble(ds.Tables[0].Rows[i]["score"].ToString());
                            }
                            else if (remarks == "交叉评阅")
                            {
                                crossScore = Convert.ToDouble(ds.Tables[0].Rows[i]["score"].ToString());
                            }
                            else if (remarks == "答辩成绩")
                            {
                                defenceScore = Convert.ToDouble(ds.Tables[0].Rows[i]["score"].ToString());
                            }
                        }
                        score = guideScore * 0.4 + crossScore * 0.3 + defenceScore * 0.3;
                    }
                }
            }
        }
    }
}
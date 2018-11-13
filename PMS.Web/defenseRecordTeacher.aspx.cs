using PMS.BLL;
using PMS.DBHelper;
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
    using Result = Enums.OpResult;
    public partial class defenseRecordTeacher : System.Web.UI.Page
    {
        public string stuAccount, titleRecordId;
        public DataSet getData;
        public string titleName,stuName,account,proName,finishYear,teaName,recordContent;
        public string now = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        DefenceBll defenceBll = new DefenceBll();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request["op"];
            try
            {
                if (op == "submit")
                {
                    titleRecordId = Request["titleRecordId"];
                    stuAccount = Request["stuAccount"];
                    getData = defenceBll.getModel(titleRecordId);
                    DefenceRecord defenceRecord = new DefenceRecord();
                    TitleRecord titleRecord = new TitleRecord();
                    titleRecord.TitleRecordId = Convert.ToInt32(getData.Tables[0].Rows[0]["titleRecordId"]);
                    defenceRecord.titleRecord = titleRecord;
                    defenceRecord.recordContent = Request["content"];
                    defenceRecord.dateTime = Convert.ToDateTime(now);

                    Result result = defenceBll.UpdateRecord(defenceRecord);
                    if (result == Result.添加成功)
                    {
                        LogHelper.Info(this.GetType(), titleRecord.DefeseTeamId+"-提交-"+ titleRecord.student.StuAccount+ titleRecord.student.RealName+"的答辩记录");
                        Response.Write("添加成功");
                        Response.End();
                    }
                    else
                    {
                        Response.Write("添加失败");
                        Response.End();
                    }
                }
                else
                {
                    reportData();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this.GetType(), ex);
            }
        }
        private void reportData()
        {
            stuAccount = Request.QueryString["stuAccount"];
            titleRecordId = Request.QueryString["titleRecordId"];
            getData = defenceBll.getModel(titleRecordId);
            int i = getData.Tables[0].Rows.Count - 1;
            titleName = getData.Tables[0].Rows[i]["title"].ToString();
            stuName = getData.Tables[0].Rows[i]["realName"].ToString();
            account = getData.Tables[0].Rows[i]["stuAccount"].ToString();
            proName = getData.Tables[0].Rows[i]["proName"].ToString();
            finishYear = Convert.ToDateTime(getData.Tables[0].Rows[i]["finishYear"]).ToString("yyyy-MM-dd");
            teaName = getData.Tables[0].Rows[i]["teaName"].ToString();
            recordContent = getData.Tables[0].Rows[i]["recordContent"].ToString();
        }
    }
}
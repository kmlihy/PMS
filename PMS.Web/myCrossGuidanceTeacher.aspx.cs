﻿using PMS.Model;
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
        public string name, sex, phone, email;
        protected void Page_Load(object sender, EventArgs e)
        {
            Student student = (Student)Session["loginuser"];
            string stuAccount = student.StuAccount;
            TitleRecordBll trecordBll = new TitleRecordBll();
            DataSet ds =trecordBll.GetByAccount(stuAccount);
            int i = ds.Tables[0].Rows.Count;
            name = ds.Tables[0].Rows[i]["teaName"].ToString();
            sex = ds.Tables[0].Rows[i]["teaSex"].ToString();
            phone = ds.Tables[0].Rows[i]["teaPhone"].ToString();
            email = ds.Tables[0].Rows[i]["teaEmail"].ToString();
        }
    }
}
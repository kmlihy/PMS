﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PMS.Web
{
	public partial class CommonPage : System.Web.UI.Page
	{
        public CommonPage()
        {
            //  
            // TODO: 在此处添加构造函数逻辑  
            //  
        }
        override protected void OnInit(EventArgs e)
        {
            //会话超时
            if (base.Session["state"] == null || base.Session["state"].ToString().Equals(""))
            {
                Response.Redirect("~/error.aspx");
            }
            else
            {
                Hashtable hOnline = (Hashtable)Application["Online"];
                if (hOnline != null)
                {
                    IDictionaryEnumerator idE = hOnline.GetEnumerator();
                    while (idE.MoveNext())
                    {
                        if (idE.Key != null && idE.Key.ToString().Equals(Session.SessionID))
                        {
                            if (idE.Value != null && "XXXXXX".Equals(idE.Value.ToString()))
                            {
                                hOnline.Remove(Session.SessionID);
                                Application.Lock();
                                Application["Online"] = hOnline;
                                Application.UnLock();
                                string js = "<script language=javascript>alert('{0}');parent.location.href='{1}';</script>";
                                Response.Write(string.Format(js, "帐号已在别处登录 ，你将被强迫下线（若非本人登录，请注意保护密码安全）！", "../login.aspx"));
                                Session.Abandon();

                                //Response.Write("<script>document.getElementById('iframe').src='login.aspx';</script>");
                                return;
                            }
                            break;
                        }
                    }
                }
            }
            
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
		{

		}
	}
}
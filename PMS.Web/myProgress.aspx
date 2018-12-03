<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myProgress.aspx.cs" Inherits="PMS.Web.myGrogress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文进度</title>
    <link rel="stylesheet" href="css/timeAxis.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="demo">
        <div class="history">
            <div class="history-date">
                <ul>
                    <h2 id="myproh2">
                        <a href="#nogo">选题开始</a>
                    </h2>
                    <li class="green">
                        <% DateTime time = new DateTime();
                            time = DateTime.Now;
                        %>
                        <h3><%=string.Format("{0:MM-dd}",time) %><span><%=string.Format("{0:yyyy}",time) %></span></h3>
                        <dl>
                            <dt>选题时间
                                <span>开始时间：<%=string.Format("{0:yyyy-MM-dd}",startTime) %></span>
                                <span>结束时间：<%=string.Format("{0:yyyy-MM-dd}",endTime) %></span>
                            </dt>
                        </dl>
                    </li>
                    <li class="green">
                        <h3><%=string.Format("{0:MM-dd}",time) %><span><%=string.Format("{0:yyyy}",time) %></span></h3>
                        <%if (DateTime.Compare(time, startTime) < 0)
                            { %>
                        <dl>
                            <dt>选题时间没有到，你还不能选题</dt>
                        </dl>
                        <%}
                            else if (DateTime.Compare(time, startTime) > 0 && DateTime.Compare(time, endTime) < 0)
                            {
                        %>
                        <dl>
                            <dt>现在在选题时间内，你可以进行选题了</dt>
                        </dl>
                        <%}
                            else
                            { %>
                        <dl>
                            <dt>选题时间已经结束，你不能再进行选题</dt>
                        </dl>
                        <%} %>
                    </li>
                    <li class="green">
                        <%
                            DateTime nowTime = new DateTime();
                            nowTime = DateTime.Now;
                            if (title != "" && title != null)
                            {%>
                        <h3>
                            <%=string.Format("{0:MM-dd}", selectTime) %>
                            <span><%=string.Format("{0:yyyy}", selectTime) %></span>
                            <span>选定题目时间</span>
                        </h3>
                        <dl>
                            <dt>我的题目<span><%=title %></span></dt>
                        </dl>
                        <% }
                            else
                            { %>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>你还没有选题，点击<a href="paperList.aspx">进行选题</a></dt>
                        </dl>
                        <%} %>
                    </li>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">提交开题报告</a></h2>
                    <%
                        string opT = "0001-01-01";
                        DateTime opt2 = Convert.ToDateTime(opT);
                        if (DateTime.Compare(opt2, opTime) == 0)
                        {
                    %>
                    <li class="green">
                        <h3><%=string.Format("{0:MM-dd}", DateTime.Now) %><span><%=string.Format("{0:yyyy}", DateTime.Now) %></span></h3>
                        <dl>
                            <dt>
                                <%
                                    if (title != "" && title != null)
                                    {%>
                                你还未提交开题报告
                                <% }
                                    else
                                    {%>
                                你还未选题
                                <%} %>
                            </dt>
                        </dl>
                    </li>
                    <%}
                        else
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", opTime) %><span><%=string.Format("{0:yyyy}", opTime) %></span></h3>
                        <dl>
                            <dt>你已提交开题报告，请等待教师审核</dt>
                        </dl>
                    </li>
                    <%if (teacherOpenning == null || teacherOpenning == "")
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>教师评阅开题报告<span>请耐心等待</span></dt>
                        </dl>
                    </li>
                    <%
                        }
                        else
                        {%>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>教师评阅开题报告<span><%=teacherOpenning %></span></dt>
                        </dl>
                    </li>
                    <% }
                        } %>
                </ul>
            </div>
            <div class="history-date">
                <%if (title == "" || title == null)
                    { %>
                <ul>
                    <h2 class="date02"><a href="#nogo">论文指导阶段</a></h2>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}",nowTime) %><span><%=string.Format("{0:yyyy}",nowTime) %></span></h3>
                        <dl>
                            <dt>你还没有选题</dt>
                        </dl>
                    </li>
                </ul>
                <%}
                    else
                    { %>
                <ul>
                    <h2 class="date02"><a href="#nogo">论文指导阶段</a></h2>
                    <%if (pathRe == PMS.BLL.Enums.OpResult.记录存在)
                        {
                    %>
                    <li>
                        <h3><%= string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>进入论文指导阶段</dt>
                        </dl>
                    </li>
                    <%for (int i = 0; i < pathds.Tables[0].Rows.Count; i++)
                        {%>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}",pathds.Tables[0].Rows[i]["dateTime"]) %><span><%=string.Format("{0:yyyy}", pathds.Tables[0].Rows[i]["dateTime"]) %></span></h3>
                        <dl>
                            <dt><%=pathds.Tables[0].Rows[i]["pathTitle"] %></dt>
                        </dl>
                    </li>
                    <%}%>
                    <%if (mq != null)
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", mq.dateTime) %><span><%=string.Format("{0:yyyy}", mq.dateTime) %></span></h3>
                        <dl>
                            <%if (mq.teacherOpinion == null || mq.teacherOpinion == "")
                                { %>
                            <dt>中期质量检查报告提交<span>你已经提交报告，请耐心等待教师回复</span></dt>
                            <%}
                                else
                                {%>
                            <dt>中期质量检查报告提交<span><%=mq.teacherOpinion %></span></dt>
                            <%} %>
                        </dl>
                    </li>
                    <%}
                        else
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>中期质量检查报告提交<span>你还没有提交中期质量报告</span></dt>
                        </dl>
                    </li>
                    <%} %>
                    <%if (checkReport.Tables[0].Rows.Count > 0)
                        {%>
                    <li>
                        <h3>
                            <%=string.Format("{0:MM-dd}",checkReport.Tables[0].Rows[0]["dateTime"]) %>
                            <span><%=string.Format("{0:yyyy}", checkReport.Tables[0].Rows[0]["dateTime"]) %></span>
                        </h3>
                        <dl>
                            <dt>查重报告<span>
                                <%=checkReport.Tables[0].Rows[0]["pathTitle"] %>
                            </span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>
                            <%=string.Format("{0:MM-dd}",checkReport.Tables[0].Rows[0]["dateTime"]) %>
                            <span><%=string.Format("{0:yyyy}", checkReport.Tables[0].Rows[0]["dateTime"]) %></span>
                        </h3>
                        <dl>
                            <dt>论文指导阶段结束<span>你的论文成绩为：
                                <%if (scoreDs.Tables[0].Rows.Count > 0)
                                    {%>
                                <%=scoreDs.Tables[0].Rows[0]["guideScore"] %>
                                <%}
                                    else
                                    { %>
                                你还没有成绩
                                <%} %>
                            </span></dt>
                        </dl>
                    </li>
                    <%} %>
                </ul>
                <%
                    }
                    else
                    { %>
                <ul>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>你还未提交过论文</dt>
                        </dl>
                    </li>
                </ul>
                <%} %>
                <%} %>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">交叉指导阶段</a></h2>
                    <%if (corssDs != null)
                        {
                            if (crossGuideDs.Tables[0].Rows.Count > 0)
                            {
                    %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", crossGuideDs.Tables[0].Rows[0]["createTime"]) %><span><%=string.Format("{0:yyyy}", crossGuideDs.Tables[0].Rows[0]["createTime"]) %></span></h3>
                        <dl>
                            <dt>进入论文交叉指导阶段<span>我的交叉指导教师：<%=crossGuideDs.Tables[0].Rows[0]["teaName"] %></span></dt>
                        </dl>
                    </li>
                    <%if (scoreDs.Tables[0].Rows[0]["crossScore"] != null && scoreDs.Tables[0].Rows[0]["crossScore"].ToString() != "")
                        { %>
                    <li>
                        <h3>11.16<span>2018</span></h3>
                        <dl>
                            <dt>交叉指导阶段结束<span>你的交叉指导成绩：<%=scoreDs.Tables[0].Rows[0]["crossScore"] %></span></dt>
                        </dl>
                    </li>
                    <%} %>
                    <%
                            }
                        }
                        else
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}",nowTime) %><span><%=string.Format("{0:yyyy}",nowTime) %></span></h3>
                        <dl>
                            <dt>未分配交叉指导教师</dt>
                        </dl>
                    </li>
                    <%} %>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">论文答辩阶段</a></h2>
                    <%if (defenceDs != null)
                        {
                            if (defenceDs.Tables[0].Rows.Count > 0)
                            { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", defenceDs.Tables[0].Rows[0]["finishYear"]) %><span><%=string.Format("{0:yyyy}", defenceDs.Tables[0].Rows[0]["finishYear"]) %></span></h3>
                        <dl>
                            <dt>答辩小组指派
                                <span>组长：<%= defenceDs.Tables[0].Rows[0]["leaderName"]%></span>
                                <span>组员：<%= defenceDs.Tables[0].Rows[0]["memberName"]%></span>
                                <span>秘书：<%= defenceDs.Tables[0].Rows[0]["recordName"]%></span>
                            </dt>
                        </dl>
                    </li>
                    <%if (defenceDs.Tables[0].Rows[0]["recordContent"] != null && defenceDs.Tables[0].Rows[0]["recordContent"].ToString() != "")
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>完成论文答辩
                                <%if (scoreDs.Tables[0].Rows[0]["defenceScore"] != null && scoreDs.Tables[0].Rows[0]["defenceScore"].ToString() != "")
                                    { %>
                                <span><%=scoreDs.Tables[0].Rows[0]["defenceScore"] %></span>
                                <%} %>
                            </dt>
                        </dl>
                    </li>
                    <%
                        }
                        else
                        {%>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>请耐心等待</dt>
                        </dl>
                    </li>
                    <% }
                    %>
                    <% }
                        }
                        else
                        { %>
                    <li>
                        <h3><%=string.Format("{0:MM-dd}", nowTime) %><span><%=string.Format("{0:yyyy}", nowTime) %></span></h3>
                        <dl>
                            <dt>未分配答辩小组</dt>
                        </dl>
                    </li>
                    <%} %>
                </ul>
            </div>
            <div id="myproEnddiv">
                <h2 id="myproEndh2">结束</h2>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/myProgress.js"></script>
</body>
</html>

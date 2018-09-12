<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reviewOpeningReport.aspx.cs" Inherits="PMS.Web.reviewOpeningReport" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>评阅开题报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <span class="h2 ">评阅开题报告</span>
            <button class="btn btn-primary navbar-btn" onclick="javascript:window.history.back(-1)" id="back">返回</button>
        </div>
        <% if (or == null)
            { %>
        <h3>该学生暂未提交开题报告，请耐心等待。</h3>
        <% }
            else
            { %>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="9"><b><%=title %></b></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">学生姓名</td>
                        <td class="col-sm-1"><b><%= stuName%></b></td>
                        <td class="col-md-1">学号</td>
                        <td class="col-sm-1" id="stuAccount"><b><%= stuAccount%></b></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"><b><%= proName%></b></td>
                        <%--<td class="col-md-1">班级</td>
                        <td class="col-sm-1"><b></b></td>--%>
                        <td class="col-md-1">指导教师</td>
                        <td class="col-sm-1"><b><%= teaName%></b></td>
                    </tr>
                    <%if (or.state == 2 || or.state == 3)
                        { %>
                    <tr>
                        <td class="openReportmain" colspan="2">选题目的、价值和意义：</td>
                        <td class="openReportmain" colspan="8" id="meaning">
                            <textarea class="openReportText" readonly="readonly"><%=or.meaning %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">本课题在国内外的研究状况及发展趋势：</td>
                        <td class="openReportmain" colspan="8" id="trend">
                            <textarea class="openReportText" readonly="readonly"><%=or.trend %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">主要研究内容：</td>
                        <td class="openReportmain" colspan="8" id="content">
                            <textarea class="openReportText" readonly="readonly"><%=or.content %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">实验设计计划（内容简介）：</td>
                        <td class="openReportmain" colspan="8" id="plan">
                            <textarea class="openReportText" readonly="readonly"><%=or.plan %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">完成设计（论文）的条件、方法及措施：</td>
                        <td class="openReportmain" colspan="8" id="method">
                            <textarea class="openReportText" readonly="readonly"><%=or.method %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">设计（论文）拟定提纲：</td>
                        <td class="openReportmain" colspan="8" id="outline">
                            <textarea class="openReportText" readonly="readonly"><%=or.outline %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">主要参考文献（研究综述：作者、题目、杂志、卷号、页码）：</td>
                        <td class="openReportmain" colspan="8" id="reference">
                            <textarea class="openReportText" readonly="readonly"><%=or.reference %></textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">指导教师意见及建议：</td>
                        <td class="openReportmain" colspan="8">
                            <textarea class="openReportText adviceTextArea" id="guideTeacher"></textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="2">分院院长意见：</td>
                        <td class="openReportmain" colspan="8">
                            <textarea class="openReportText adviceTextArea" id="dean"></textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                    <%if(or.state == 3){ %>
                    <h3 class="error">该学生已完成开题报告</h3>
                    <%}}
                    else
                    {%>
                    <h3 class="error">学生暂未修改提交</h3>
                    <%}%>
                </tbody>
            </table>
        </div>
        <div class="container text-center panel-footer panleFooter">
            <%if (or.state == 2)
                { %>
            <div>此表由学生本人填写后交指导教师签署意见，经各分院（教研室）院长签字同意后方可开题，否则不得开题。此表作为评定成绩的依据之一。</div>
            <button class="btn btn-info agreebtn" type="button" id="btnReviewSubmit">同意</button>
            <button type="button" class="btn btn-info agreebtn" id="btnOpinion">不同意</button>
            <%} %>
        </div>
        <%} %>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/openingReport.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="defenseRecordTeacher.aspx.cs" Inherits="PMS.Web.defenseRecordTeacher" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>本科生毕业设计（论文）答辩记录</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>

<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>本科生毕业设计（论文）答辩记录</h2>
        </div>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="4"><%=titleName %></td>
                    </tr>
                    <tr class="table_head">
                        <td>姓名</td>
                        <td>学号</td>
                        <td>专业</td>
                        <td>毕业年份</td>
                        <td>指导教师</td>
                    </tr>
                    <tr class="table_head">
                        <td><%=stuName %></td>
                        <td id="stuAccount"><%=account %></td>
                        <td><%=proName %></td>
                        <td><%=finishYear %></td>
                        <td><%=teaName %></td>
                    </tr>
                    <tr class="table_head">
                        <td colspan="5">说明：本栏目填写学生论文答辩情况，答辩小组成员提问、学生回答等答辩过程及论文综合评价情况。每个学生记录一份。</td>
                    </tr>
                    <tr>
                        <td class="record-td">
                            <div class="textmain-record">答 &nbsp&nbsp&nbsp&nbsp 辩 &nbsp&nbsp&nbsp&nbsp 记 &nbsp&nbsp&nbsp&nbsp 录</div>
                        </td>
                        <td class="record-td" colspan="4">
                            <textarea class="openReportText" id="content"><%=recordContent %></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td colspan="2">答辩日期</td>
                        <td><%=now%></td>
                        <td>答辩成绩</td>
                        <td><a href="replyPanelsOpinion.aspx?stuAccount=<%=stuAccount%>">
                            <button class="btn btn-default btn-sm btn-success btnSearch">
                                给定成绩
                            </button>
                        </a></td>
                    </tr>
                    <tr class="table_head">
                        <td colspan="2">答辩小组成员签字</td>
                        <td colspan="3">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td colspan="2">答辩小组组长签字</td>
                        <td>
                            <textarea class="openReportText"></textarea></td>
                        <td>记录人</td>
                        <td>
                            <textarea class="openReportText"></textarea></td>
                    </tr>
                </tbody>
            </table>
            <input type="hidden" id="titleRecordId" value="<%=titleRecordId %>" />
        </div>
        <div class="container text-right panel-footer panleFooter">
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/defenseRecordTeacher.js"></script>
</html>

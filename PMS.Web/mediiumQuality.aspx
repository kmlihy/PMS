<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mediiumQuality.aspx.cs" Inherits="PMS.Web.mediiumQuality" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>中期质量检查</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="panel">
            <div class="panel-heading">
                <h1 class="text-center">本科生毕业设计（论文）中期质量检查</h1>
            </div>
            <% if(mq == null && state == 1){ %>
                <h3>该学生还未提交中期质量检查报告，请耐心等待。</h3>
            <% }else{ %>
            <div class="panel-body">
                <table class="table" id="mediumQuality_table">
                    <tr>
                        <td class="col-xs-2">分院</td>
                        <td class="col-xs-4"><%=college %></td>
                        <td class="col-xs-2">专业</td>
                        <td class="col-xs-4"><%=profession %></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">毕业设计（论文）题目</td>
                        <td class="col-xs-4" colspan="8"><%=title %></td>
                        <%--<td colspan="4" class="text-left">
                            <div class="input-group" style="width:100%">
                                <span class="input-group-addon" style="background-color:white; font-size:24px; border:none;">毕业设计（论文）题目：<%=title %></span>
                            </div>
                        </td>--%>
                    </tr>
                    <tr>
                        <td class="col-xs-2">学生姓名</td>
                        <td class="col-xs-4"><%=stuName %></td>
                        <td class="col-xs-2">学号</td>
                        <td class="col-xs-4"><%=stuAccount %></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">指导教师</td>
                        <td class="col-xs-4"><%=teaName %></td>
                        <td class="col-xs-2">专业职务技术</td>
                        <td class="col-xs-4"></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">期中按计划完成情况</td>
                        <td colspan="10" style="padding:0 0;">
                            <%if(state == 3){ %>
                            <textarea rows="5" class="textArea" id="stuSet"></textarea>
                            <%}else if(state == 1){ %>
                            <textarea rows="5" class="textArea" id="stuShow" readonly="readonly"><%=mq.planFinishSituation %></textarea>
                            <%} %>
                            <div class="text-right" style="width:100%">
                                <span>学生签字：</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>年</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>月</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>日</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">指导教师意见</td>
                        <td colspan="4" style="padding:0 0;">
                            <%if(state == 1){ %>
                            <textarea rows="5" class="textArea" id="teaSet"></textarea>
                            <%}else if(state == 3){ %>
                            <textarea rows="5" class="textArea" id="teaShow" readonly="readonly">提交后请等待指导教师回复</textarea>
                            <%} %>
                            <div class="text-right" style="width:100%">
                                <span>指导教师签字：</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>年</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>月</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>日</span>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">毕业设计（论文）指导小组意见</td>
                        <td colspan="4" style="padding:0 0;">
                            <%if(state == 1){ %>
                            <textarea rows="5" class="textArea" id="groupSet"></textarea>
                            <%}else if(state == 3){ %>
                            <textarea rows="5" class="textArea" id="groupShow" readonly="readonly">提交后请等待毕业设计（论文）指导小组回复</textarea>
                            <%} %>
                            <div class="text-right" style="width:100%">
                                <span>指导小组签字：</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>年</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>月</span>
                                <span contenteditable="true" class="label_Time">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                <span>日</span>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="container-fluid text-right">
                <button class="btn btn-info btn-lg" value="提交" id="btnSubmit">提交</button>
            </div>
            <%} %>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/mediiumQuality.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

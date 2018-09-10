<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mediiumQuality.aspx.cs" Inherits="PMS.Web.mediiumQuality" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>中期质量检查</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>
<body>
    <%if (content == "学生未提交中期质量检查")
        { %>
    <h3><%=content %></h3>
    <%}
        else if (content == "暂未选题")
        {%>
    <h3><%=content %></h3>
    <%}
        else if (content == "暂未提交论文")
        { %>
    <h3><%=content %></h3>
    <%}
        else
        {%>
    <div class="container-fluid">
        <div class="panel">
            <div class="panel-heading">
                <h1 class="text-center">本科生毕业设计（论文）中期质量检查</h1>
                <%if (mstate == 2 && state == 3)
                    { %>
                <h4>请等待教师处理</h4>
                <%}
                    else if (mstate == 3)
                    {%>
                <h4>中期质量检查已通过</h4>
                <%} %>
            </div>
            <div class="panel-body">
                <table class="table" id="mediumQuality_table">
                    <tr>
                        <td class="col-xs-2">分院</td>
                        <td class="col-xs-4"><%=collegeName %></td>
                        <td class="col-xs-2">专业</td>
                        <td class="col-xs-4"><%=proName %></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">毕业设计（论文）题目</td>
                        <td class="col-xs-4" colspan="8"><%=title %></td>
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
                        <td colspan="10" style="padding: 0 0;">
                            <%if (mstate == 0 || mstate == 1)
                                { %>
                            <textarea rows="5" class="textArea" id="stuSet"></textarea>
                            <%}
                                else if (mstate == 2 || mstate == 3)
                                { %>
                            <textarea rows="5" class="textArea" id="stuShow" readonly="readonly"><%=planFinishSituation %></textarea>
                            <%} %>
                            <div class="text-right" style="width: 100%">
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
                        <td colspan="4" style="padding: 0 0;">
                            <%if (state == 1)
                            {
                                if (mstate != 3)
                                {%>
                                    <textarea rows="5" class="textArea" id="teaSet"></textarea>
                                <%}else{%>
                                    <textarea rows="5" class="textArea" id="teaSet" readonly="readonly"><%=teacherOpinion %></textarea>
                                <%}
                            }else if (state == 3)
                            {
                                if (mstate != 3)
                                {%>
                            <textarea rows="5" class="textArea" id="teaShow" readonly="readonly">提交后请等待指导教师回复</textarea>
                            <%}
                            else
                            { %>
                            <textarea rows="5" class="textArea" id="teaShow" readonly="readonly"><%=teacherOpinion %></textarea>
                            <%  }
                            } %>
                            <div class="text-right" style="width: 100%">
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
                        <td colspan="4" style="padding: 0 0;">
                            <%if (state == 1)
                                { %>
                            <textarea rows="5" class="textArea" id="groupSet"></textarea>
                            <%}
                                else if (state == 3)
                                { %>
                            <textarea rows="5" class="textArea" id="groupShow" readonly="readonly">提交后请等待毕业设计（论文）指导小组回复</textarea>
                            <%} %>
                            <div class="text-right" style="width: 100%">
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
        </div>
    </div>
    <%} %>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/mediiumQuality.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

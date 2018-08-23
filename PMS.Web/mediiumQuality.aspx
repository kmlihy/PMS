<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mediiumQuality.aspx.cs" Inherits="PMS.Web.mediiumQuality" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>中期质量检查</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="panel">
            <div class="panel-heading">
                <h1 class="text-center">本科生毕业设计（论文）中期质量检查</h1>
            </div>
            <div class="panel-body">
                <table class="table" id="mediumQuality_table">
                    <tr>
                        <td class="col-xs-2">分院</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                        <td class="col-xs-2">专业</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" class="text-left">
                            <div class="input-group" style="width:100%">
                                <span class="input-group-addon" style="background-color:white; font-size:24px; border:none;">毕业设计（论文）题目：</span>
                                <input type="text" class="textInput" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">学生姓名</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                        <td class="col-xs-2">学号</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">指导教师</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                        <td class="col-xs-2">专业职务技术</td>
                        <td class="col-xs-4">
                            <input type="text" class="textInput" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="padding:0 0;">
                            <textarea rows="7" class="textArea">期中按计划完成情况:</textarea>
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
                        <td colspan="4" style="padding:0 0;">
                            <textarea rows="7" class="textArea">指导教师意见:</textarea>
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
                        <td colspan="4" style="padding:0 0;">
                            <textarea rows="7" class="textArea">毕业设计（论文）指导小组意见:</textarea>
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
                <button class="btn btn-info btn-lg" value="提交">提交</button>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

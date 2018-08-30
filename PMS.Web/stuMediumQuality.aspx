<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuMediumQuality.aspx.cs" Inherits="PMS.Web.stuMediumQuality" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看学生中期质量报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <style>
        body{
            font-size:24px;
        }
    </style>
</head>
<body>
    <div class="container-fluid">
        <div class="panel">
            <div class="panel-heading">
                <h1 class="text-center">XX学生毕业设计（论文）中期质量检查</h1>
            </div>
            <div class="panel-body">
                <table class="table" id="mediumQuality_table">
                    <tr>
                        <td class="col-xs-2">分院</td>
                        <td class="col-xs-4"></td>
                        <td class="col-xs-2">专业</td>
                        <td class="col-xs-4"></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">毕业设计（论文）题目</td>
                        <td class="col-xs-4" colspan="3"></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">学生姓名</td>
                        <td class="col-xs-4"></td>
                        <td class="col-xs-2">学号</td>
                        <td class="col-xs-4"></td>
                    </tr>
                    <tr>
                        <td class="col-xs-2">期中按计划完成情况</td>
                        <td colspan="10" style="padding: 0 0;">
                            <textarea rows="5" class="textArea" id="stuSet"></textarea>
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
                            <textarea rows="5" class="textArea" id="teaSet"></textarea>
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
                            <textarea rows="5" class="textArea" id="groupSet"></textarea>
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
                <button class="btn btn-defualt btn-lg" value="提交" id="btnSubmit">提交</button>
                <button class="btn btn-default btn-lg" value="返回" onclick="javascript:history.back()">返回</button>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/mediiumQuality.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

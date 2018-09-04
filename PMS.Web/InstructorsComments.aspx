﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorsComments.aspx.cs" Inherits="PMS.Web.InstructorsComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>指导教师评语</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>

<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>指导教师评语级成绩评定等级</h2>
        </div>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="9"></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">学生姓名</td>
                        <td class="col-sm-1"></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-sm-1">项目</td>
                        <td colspan="9">评价</td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">调查论证</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">实践能力</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">分析、解决问题能力</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">工作态度</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">质量</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">创新</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea">评价：</textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">指导教师签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="container text-center panel-footer panleFooter">
            <button class="btn btn-primary col-xs-1" type="submit" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
</html>

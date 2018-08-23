<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="openingReport.aspx.cs" Inherits="PMS.Web.openingReport" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交论文开题报告</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>

<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>本科生毕业设计（论文）开题报告</h2>
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
                        <td class="col-md-1">学号</td>
                        <td class="col-sm-1"></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"></td>
                        <td class="col-md-1">班级</td>
                        <td class="col-sm-1"></td>
                        <td class="col-md-1">指导教师</td>
                        <td class="col-sm-1"></td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">选题目的、价值和意义</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">本课题在国内外的研究状况及发展趋势</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">主要研究内容</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">实验设计计划（内容简介）</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">完成设计（论文）的条件、方法及措施</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">设计（论文）拟定提纲</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText">主要参考文献（研究综述：作者、题目、杂志、卷号、页码）</textarea>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea">指导教师意见及建议</textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                    <tr>
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea">分院院长意见</textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="container text-center panel-footer panleFooter">
            <div>此表由学生本人填写后交指导教师签署意见，经各分院（教研室）院长签字同意后方可开题，否则不得开题。此表作为评定成绩的依据之一。</div>
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
</html>

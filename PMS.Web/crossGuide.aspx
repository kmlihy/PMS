<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crossGuide.aspx.cs" Inherits="PMS.Web.crossGuide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>提交交叉评阅评语</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>

<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>交叉评阅人评语及成绩评定等级</h2>
        </div>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="9"><%=title %></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">学生姓名</td>
                        <td class="col-sm-1"><%=stuName %></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"><%=proName %></td>
                        <%--<td class="col-md-1">论文字数</td>
                        <td class="col-sm-1"></td>--%>
                    </tr>
                    <tr class="table_head">
                        <td class="col-sm-1">项目</td>
                        <td colspan="9">评价</td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1" id="data">翻译资料综述材料</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="tdata"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1" id="quality">论文（设计）质量</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="tquality"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1" id="workload">工作量及难度</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="tworkload"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1" id="innovate">创新</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="tinnovate"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">成绩</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="score"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea" id="evaluate">评价：</textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">交叉评阅人签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <button class="btn btn-primary col-xs-1" type="submit" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/crossGuide.js"></script>
<script src="js/xcConfirm.js"></script>
</html>


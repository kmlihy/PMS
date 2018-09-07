<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="replyPanelsOpinion.aspx.cs" Inherits="PMS.Web.replyPanelsOpinion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>答辩小组评语</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>答辩小组意见及成绩评定等级</h2>
        </div>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered text-center table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="9"><%=ds.Tables[0].Rows[0]["title"].ToString()%></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">学生姓名</td>
                        <td class="col-sm-1"><%=ds.Tables[0].Rows[0]["realName"].ToString()%></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"><%=ds.Tables[0].Rows[0]["proName"].ToString()%></td>
                        <td class="col-md-1">成绩</td>
                        <td class="col-sm-1 text-center">
                            <input type="text" maxlength="3" id="defensescore" oninput="value = value.replace(/[^\d]/g, '')" style="outline:none;border:none;width:100%;" />
                            <button onclick="rescore()" id="scoretips" style="width: 100%; height: 100%; background-color: white; border: none;">
                            </button>
                            <%--<textarea class="openReportText" id=""></textarea>--%>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-sm-1">项目</td>
                        <td colspan="9">评价</td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">报告内容</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="txtAreReportContent"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">报告时间</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="txtAreReportTime"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">答辩</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="txtAreDefence"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">创新</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="textAreInnovate"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea" id="txtAreEvaluate">评价：</textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">指导教师签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="container text-right panel-footer panleFooter">
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/replyPanelsOpinion.js"></script>
</html>

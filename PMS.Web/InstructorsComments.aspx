﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorsComments.aspx.cs" Inherits="PMS.Web.InstructorsComments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>指导教师评语</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="css/bootstrap-select.css" />
</head>

<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>指导教师评语级成绩评定等级</h2>
            <button class="btn btn-primary navbar-btn" onclick="javascript:window.history.back(-1)" id="back">返回</button>
        </div>
        <div class="panel-body">
            <table id="openingReportmaindiv" class="table table-bordered table_mian">
                <tbody>
                    <tr class="table_head">
                        <td class="col-sm-1">论文题目</td>
                        <td colspan="9"><%=getData.Tables[0].Rows[0]["title"].ToString() %></td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">学生姓名</td>
                        <td class="col-sm-1"><%=getData.Tables[0].Rows[0]["realName"].ToString() %></td>
                        <td class="col-md-1">专业</td>
                        <td class="col-sm-1"><%=getData.Tables[0].Rows[0]["proName"].ToString() %></td>
                        <td class="col-md-1">成绩</td>
                        <td class="col-sm-1">
                            <input type="text" maxlength="3" id="defensescore" oninput="value = value.replace(/[^\d]/g, '')" style="outline: none; border: none; width: 100%;" />
                            <button onclick="rescore()" id="scoretips" style="width: 100%; height: 100%; background-color: white; border: none;">
                            </button>
                            <%-- <input type="number" id="score" min="0" max="100" />--%></td>
                    </tr>
                    <%if (midState != 3)
                        { %>
                    <tr class="table_head">
                        <td colspan="10">
                            <h3>中期质量未提交或未通过</h3>
                        </td>
                    </tr>
                    <%}
                        else if (checkState != 3)
                        { %>
                    <tr class="table_head">
                        <td colspan="10">
                            <h3>查重质量未提交或未通过</h3>
                        </td>
                    </tr>
                    <%}else if (paperState == 0 || paperState == 1)
                        { %>
                    <tr class="table_head">
                        <td colspan="10">
                            <h3>学生未提交论文</h3>
                        </td>
                    </tr>
                    <%}else if (paperState == 3)
                        { %>
                    <tr class="table_head">
                        <td colspan="10">
                            <h3>已给定学生成绩</h3>
                        </td>
                    </tr>
                    <%}else
                        { %>
                    <tr class="table_head">
                        <td class="col-sm-1">项目</td>
                        <td colspan="9">评价</td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">调查论证</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="investigation"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">实践能力</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="practice"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">分析、解决问题能力</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="solveProblem"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">工作态度</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="workAttitude"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">质量</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="quality"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="col-md-1">创新</td>
                        <td class="openReportmain" colspan="7">
                            <textarea class="openReportText" id="innovate"></textarea>
                        </td>
                    </tr>
                    <tr class="table_head">
                        <td class="openReportmain" colspan="10">
                            <textarea class="openReportText adviceTextArea" placeholder="请输入评价" id="evaluate"></textarea>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 日</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 月</label>
                            <label class="lableTime" contenteditable="true">&nbsp &nbsp 年</label>
                            <label class="lableTime" contenteditable="true">指导教师签字：&nbsp &nbsp</label>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
        <%if (midState == 3 && checkState == 3 && paperState == 2)
            {%>
        <div class="container text-center panel-footer panleFooter">
            <button class="btn btn-info agreebtn" type="button" id="btnReviewSubmit" data-toggle="modal" data-target="#myModa2">提交</button>
        </div>
        <%} %>
        <%-- 同意通过指定交叉指导教师--%>
        <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModal2">指定交叉指导教师
                        </h4>
                    </div>
                    <div class="modal-body text-center">
                        <select class="selectpicker" id="crossTea">
                            <option value="0">请选择交叉指导教师</option>
                            <%if (dsTitle != null)
                                {
                                    for (int i = 0; i < dsTitle.Tables[0].Rows.Count; i++)
                                    { %>
                            <option value="<%=dsTitle.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=dsTitle.Tables[0].Rows[i]["teaName"].ToString()%></option>
                            <%}
                                } %>
                        </select>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-primary" type="submit" id="scorebtnSubmit">提交</button>
                        <button type="button" class="btn btn-default " data-dismiss="modal">关闭</button>
                    </div>
                </div>
            </div>
        </div>
        <%-- 驳回意见填写--%>
        <div class="modal fade" id="myModa1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModal1">驳回意见
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid table-bordered img-rounded modal_comment">
                            <textarea rows="8" style="margin-top: 15px; width: 100%;" class="opinion"></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-default " id="submit">提交</button>
                        <button type="button" class="btn btn-default " data-dismiss="modal">关闭</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/instructorsComments.js"></script>
</html>


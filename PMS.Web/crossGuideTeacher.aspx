﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="crossGuideTeacher.aspx.cs" Inherits="PMS.Web.crossGuideTeacher" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>我的教师信息</h2>
        </div>
        <div class="panel-body">
            <table class="table table-bordered table-responsive">
                <tr>
                    <td colspan="8" style="vertical-align: middle">
                        <span class="sap">我的指导老师</span>
                        <button type="button" class="btn btn-default btn_searchComment btn-info btn-sm" data-toggle="modal" data-target="#myModa1">
                            <span class="glyphicon glyphicon-search"></span>
                            查看指导意见
                        </button>
                    </td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td>刘备刘备</td>
                    <td class="text_type">性别</td>
                    <td>男</td>
                    <td class="text_type">联系方式</td>
                    <td>12345679801</td>
                    <td class="text_type">电子邮件</td>
                    <td>123121312@qq.com</td>
                </tr>
                <tr>
                    <td colspan="8"></td>
                </tr>
                <tr>
                    <td colspan="8" style="vertical-align: middle">
                        <span class="sap">我的交叉指导老师</span>
                        <button type="button" class="btn btn-default btn_searchComment btn-info btn-sm" data-toggle="modal" data-target="#myModa2">
                            <span class="glyphicon glyphicon-search"></span>
                            查看交叉指导意见
                        </button>
                    </td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td>刘备刘备</td>
                    <td class="text_type">性别</td>
                    <td>男</td>
                    <td class="text_type">联系方式</td>
                    <td>12345679801</td>
                    <td class="text_type">电子邮件</td>
                    <td>123121312@qq.com</td>
                </tr>

<%--                <tr>
                    <td colspan="8">
                        <span class="sap">我的答辩小组</span>
                        <button type="button" class="btn btn-default btn_searchComment btn-info btn-sm" data-toggle="modal" data-target="#myModa3">
                            <span class="glyphicon glyphicon-search"></span>
                            查看答辩小组意见
                        </button>
                    </td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td>刘备刘备</td>
                    <td class="text_type">负责职务</td>
                    <td>秘书</td>
                    <td class="text_type">联系方式</td>
                    <td>12345679801</td>
                    <td class="text_type">电子邮件</td>
                    <td>123121312@qq.com</td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td>刘备</td>
                    <td class="text_type">负责职务</td>
                    <td>组长</td>
                    <td class="text_type">联系方式</td>
                    <td>12345679801</td>
                    <td class="text_type">电子邮件</td>
                    <td>123121312@qq.com</td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td>刘备</td>
                    <td class="text_type">负责职务</td>
                    <td>组员</td>
                    <td class="text_type">联系方式</td>
                    <td>12345679801</td>
                    <td class="text_type">电子邮件</td>
                    <td>123121312@qq.com</td>
                </tr>--%>
            </table>
        </div>
    </div>

    <%--查看指导意见--%>
    <div class="modal fade" id="myModa1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal1">指导意见
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid table-bordered img-rounded modal_comment">
                        是顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶顶
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn_close" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>

    <%--查看交叉指导意见--%>
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal2">交叉指导意见
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid table-bordered img-rounded modal_comment"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn_close" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>

    <%--查看答辩小组意见--%>
<%--    <div class="modal fade" id="myModa3" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal3">查看答辩小组意见
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid table-bordered img-rounded modal_comment"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn_close" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>--%>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

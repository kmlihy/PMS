<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="PMS.Web.admin.addNews" %>

<%= "" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>发布公告</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>

<body id="addNewsBody">
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>发布公告</h2>
        </div>
        <div class="panel-body">
            <div class="container-fluid">

                <div class="container-fluid tablediv">
                    <form runat="server" action="addNews.aspx" method="post">
                        <table class="table titleTable" id="titleTable">
                            <tbody>
                                <tr>
                                    <td>
                                        <div class="container-fluid text-right">
                                            <span class="label title">标题</span>
                                        </div>
                                    </td>
                                    <td>
                                        <div class="col-xs-5 col-sm-4 col-md-3 col-lg-3 inputdiv">
                                            <input type="text" class="form-control" id="newsTitle" name="newsTitle" placeholder="请输入标题" />
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="container-fluid text-right col-xs-10 col-sm-10 col-md-8 col-lg-7">
                                            <span class="label title">内容</span>
                                        </div>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <textarea name="content" class="titlemain" id="content"></textarea>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <button class="btn btn-primary btn-title" type="button" id="release">
                                            发布公告
                                        </button>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </form>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../kindeditor/kindeditor-all.js"></script>
<script src="../kindeditor/asp.net/lang/zh-CN.js"></script>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/addNews.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

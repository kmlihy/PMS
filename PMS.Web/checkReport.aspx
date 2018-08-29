<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkReport.aspx.cs" Inherits="PMS.Web.checkReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交查重报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/zwh.css" />
</head>
<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>提交查重报告</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <form id="form1" runat="server">
                <h4><a href="http://www.bylwjc.com/" class="web">前往第三方网站>></a></h4>
                <h3><small>请使用第三方网站完成查重报告，可使用官方提供网址，也可自行查找；</small></h3>
                    <h4>上传查重报告：
                    <a href="javascript:;" id="file">
                        <input type="file" name="upload" id="upload" />
                        <label class="showFileName"></label>
                        <label class="fileerrorTip"></label>
                    </a>
                        <button type="button" class="btn btn-primary" id="btnupload">上传</button>
                    </h4>
            </form>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/ajaxfileupload.js"></script>
<script src="js/checkReport.js"></script>
</html>

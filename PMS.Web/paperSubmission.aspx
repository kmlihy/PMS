<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperSubmission.aspx.cs" Inherits="PMS.Web.paperSubmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>论文提交页面</h2>
        </div>
        <div class="panel-body">
            <input type="file" value="选择文件" />
        </div>
        <div class="container text-center panel-footer panleFooter">
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
</html>

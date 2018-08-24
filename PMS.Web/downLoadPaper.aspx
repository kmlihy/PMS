<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downLoadPaper.aspx.cs" Inherits="PMS.Web.downLoadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>下载学生论文并评阅</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data" action="~/downLoadPaper.aspx">
        <button type="button" class="btn btn-primary"></button>
    </form>
</body>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
</html>

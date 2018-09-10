<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="openAchievement.aspx.cs" Inherits="PMS.Web.admin.openAchievement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>开放成绩</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>
<body>
    <div class="panel-heading text-center">
        <h2>开放成绩</h2>
    </div>
    <div class="panel-body text-center">
        <button class="btn btn-info" id="openBtn">开放成绩</button>
    </div>
</body>
<script type="text/javascript" src="../js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="../js/xcConfirm.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#openBtn").click(function () {
            window.wxc.xcConfirm("确定开放成绩么？", window.wxc.xcConfirm.typeEnum.confirm, {
                onOk: function (v) {
                   
                }
            });
        })
    })
</script>
</html>

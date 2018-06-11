<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PMS.Web.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:solid 1px #ccc;width:200px;float:left;height:400px;">
            <input type="button" value="sina" id="btn" />
        </div>
        <div id="content" style="border:solid 1px #ccc;width:200px;float:left;height:400px;"></div>
    </form>
</body>
    <script>
        $(document).ready(function () {
            $("#btn").click(function () {
                $("#content").load("login.aspx");
            });
        });
    </script>
</html>

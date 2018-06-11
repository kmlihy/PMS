<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="PMS.Web.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-3.3.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <input type="text" id="user" />
        <input type="button" value="set" onclick="setValue();" />
    </div>
    </form>
</body>
    <script>
        function setValue() {
            $("#user").val("hello");
        }
    </script>
</html>

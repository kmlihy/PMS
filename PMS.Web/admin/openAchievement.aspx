<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="openAchievement.aspx.cs" Inherits="PMS.Web.admin.openAchievement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>开放成绩</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lc_switch.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>
<body>
    <div class="panel-heading text-center">
        <h2>开放成绩</h2>
    </div>
    <div class="panel-body text-center">
        <div id="second_div">
            <p>
                <input type="checkbox" name="check-1" value="4" class="lcs_check" <%if (status == 1)
                    {%>checked="on"<%}
                    else
                    {%>checked="off"<%} %>  />
            </p>
        </div>
    </div>
</body>
<script type="text/javascript" src="../js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="../js/lc_switch.min.js"></script>
<script type="text/javascript" src="../js/xcConfirm.js"></script>
<script type="text/javascript" src="../js/openAchievement.js"></script>
</html>

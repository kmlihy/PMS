<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thesisSubmit.aspx.cs" Inherits="PMS.Web.thesisSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/lgd.css" />
 </head>
<body>
    <p id="upload-p">选择文件<input type="file" id="file1" name="file"/></p>
    <input type="button" value="上传" id="btnupload" class="btn btn-info" />
</body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="js/ajaxfileupload.js"></script>
    <script type="text/javascript" src="js/thesisSubmit.js"></script>
</html>

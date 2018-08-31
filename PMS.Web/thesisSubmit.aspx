<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thesisSubmit.aspx.cs" Inherits="PMS.Web.thesisSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文提交页面</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="container">
        <div class="panel-head text-center">
            <h2>论文提交页面</h2>
        </div>
        <div class="panel-body text-center thesis-panelbody">
            <p id="upload-p">选择文件<input onchange="showname()" type="file" id="file1" name="file" /></p>
            <div class="container text-center">
                <p id="tips"></p>
                <table class="table table-bordered" id="thesisTable">
                    <thead>
                        <tr>
                            <th class="text-center">文件名称</th>
                            <th class="text-center">文件大小</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td id="thesisFileName" class="file-Info"></td>
                            <td id="thseisFileSize" class="file-Info"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="container panel-footer text-right panelFooter">
            <input type="button" value="上传" id="btnupload" class="btn btn-info" />
        </div>
    </div>

</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="js/ajaxfileupload.js"></script>
<script type="text/javascript" src="js/thesisSubmit.js"></script>
</html>

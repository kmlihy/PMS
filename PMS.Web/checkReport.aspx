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
    <div class="panel panel-default text-center" id="panel">
        <div class="panel-head">
            <h2>提交查重报告</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <h4><a href="http://www.bylwjc.com/" class="web">前往第三方网站>></a></h4>
            <h3><small>请使用第三方网站完成查重报告，可使用官方提供网址，也可自行查找；</small></h3>
            <div>
                <table class="table">
                    <tr>
                        <td>
                            <p>上传查重报告文件:</p>
                        </td>
                        <td><a href="javascript:;" id="a_filereport">选择文件
                        <input type="file" name="upload" id="upload" onchange="showname()" />
                        </a></td>
                    </tr>
                </table>
                <table class="table table-bordered" id="thesisTable" style="display: none">
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
        <div class="panel panel-footer text-right">
            <button type="button" class="btn btn-primary" id="btnupload">上传</button>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/ajaxfileupload.js"></script>
<script src="js/checkReport.js"></script>
<script>
    


</script>
</html>

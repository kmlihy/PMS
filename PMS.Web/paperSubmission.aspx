<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperSubmission.aspx.cs" Inherits="PMS.Web.paperSubmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文提交页面</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/lgd.css" />

</head>
<body>
    <div class="panel">
        <div class="panel-head text-center">
            <h2>论文提交页面</h2>
        </div>
        <div class="panel-body text-center">
            <div class="fileBox text-center">
                <p class="fileInputP vm">
                    <i>选择文件</i>
                    <input type="file" multiple="multiple" id="fileInput" />

                </p>
                <span id="fileSpan" class="vm">或者将文件拖到此处</span>
                <div class="mask"></div>
            </div>
            <div class="container text-center">
                <table class="fileList_parent table table-bordered">
                    <thead>
                        <tr>
                            <th>文件名称</th>
                            <th>文件类型</th>
                            <th>文件大小</th>
                            <th>上传进度</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody class="fileList"></tbody>
                </table>
            </div>
        </div>
        <div class="container panel-footer text-center panelFooter">
            <input type="button" value="上传" id="fileBtn" class="btn btn-info" />
        </div>
    </div>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script type="text/javascript" src="js/paperSubmission.js"></script>
</body>
</html>

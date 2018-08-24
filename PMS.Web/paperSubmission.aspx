<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperSubmission.aspx.cs" Inherits="PMS.Web.paperSubmission" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/base.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>论文提交页面</h2>
        </div>
        <div class="panel-body">
            <div class="fileBox">
                <p class="fileInputP vm">
                    <i>选择文件</i>
                    <input type="file" multiple="multiple" id="fileInput" />
                </p>
                <span id="fileSpan" class="vm">或者将文件拖到此处</span>
                <div class="mask"></div>
            </div>

            <table width="50%" border="1" class="fileList_parent">
                <thead>
                    <tr>
                        <th>文件名称</th>
                        <th>类型</th>
                        <th>大小</th>
                        <th>进度</th>
                        <th>操作</th>
                    </tr>
                </thead>

                <tbody class="fileList">
                </tbody>

            </table>

            <input type="button" value="上传" id="fileBtn" class="btn btn-info" />
        </div>
        <div class="container text-center panel-footer panleFooter">
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>

</html>

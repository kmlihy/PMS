<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkReport.aspx.cs" Inherits="PMS.Web.checkReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>提交查重报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/zwh.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body class="oraldefense-student">
    <%if (state == 0)
        { %>
    <h3 class="text-primary">暂未提交论文</h3>
    <%}
        else if (state == 3)
        { %>
    <h3 class="text-primary">暂未选题</h3>
    <%}
        else
        { %>
    <div class="panel panel-default text-center" id="panel">
        <div class="panel-head">
            <h2>提交查重报告</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <h4><a href="http://www.bylwjc.com/" target="_blank" class="web">前往第三方网站>></a></h4>
            <h3><small>请使用第三方网站完成查重报告，可使用官方提供网址，也可自行查找；</small></h3>
            <div>
                <%if (pstate == 0 || pstate == 1)
                    { %>
                <table class="table">
                    <tr>
                        <td class="text-right file-Info">
                            <p class="p-report">上传查重报告文件:</p>
                        </td>
                        <td class="text-left file-Info">
                            <p id="upload-p">选择文件<input onchange="showname()" type="file" name="upload" id="upload" /></p>
                        </td>
                    </tr>
                </table>
                <%} %>
                <div id="myAlert" class="alert alert-success">
                    <%if (pstate == 2)
                        { %>
                    <h3>等待教师处理</h3>
                    <%}
                        else if (pstate == 3)
                        {%>
                    <h3>查重报告已通过审核</h3>
                    <%}
                        else if (pstate == 1)
                        {%>
                    <h3 class="error">查重报告暂未通过审核</h3>
                    <%}
                        else
                        {%>
                    <strong>提示！</strong>只允许上传.doc或.docx格式的文件，谢谢！<p>
                        文件命名规范：学号+姓名
                        <br />
                        例如：10002金木研
                    </p>
                    <%} %>
                </div>
                <table class="table table-bordered" id="thesisTable">
                    <thead>
                        <tr>
                            <th class="text-center"><nobr>文件名称</nobr></th>
                            <th class="text-center"><nobr>文件大小</nobr></th>
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
        <% if (pstate == 0 || pstate == 1)
            {%>
        <div class="panel panel-footer text-right">
            <button type="button" class="btn btn-primary" id="btnupload">上传</button>
        </div>
        <%} %>
    </div>
    <%} %>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/ajaxfileupload.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/checkReport.js"></script>
<script>
</script>
</html>

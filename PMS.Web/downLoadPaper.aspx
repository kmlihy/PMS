<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downLoadPaper.aspx.cs" Inherits="PMS.Web.downLoadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>下载学生论文并评阅</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>下载并评阅论文</h1>
        </div>
        <div class="panel-body">
            <%--<form id="form1" runat="server" method="post" enctype="multipart/form-data" action="~/downLoadPaper.aspx">
                <button type="button" class="btn btn-primary" id="downLoadFile">下载论文</button>
            </form>--%>
            <table class="table">
                <thead>
                    <tr>
                        <th>序号</th>
                        <th>姓名</th>
                        <th>论文</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1</td>
                        <td>
                            <a href="upload/题目信息导入Excel文件存储/admin/20180716132754-题目信息表.xls" download="论文.xls">点击下载论文</a>
                        </td>
                        <td>
                             学生姓名
                        </td>
                        <td>
                            <a href="#">查看更多》</a>   
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script>
        <%--$("#downLoadFile").click(function () {
            var downForm = $("<form method='get'><form>");
            downForm.attr("action", "upload/信息模板下载/教师批量导入模板.xlsx");
            $(document.body).append(downForm);
            downForm.submit();
        })--%>
    </script>
</html>

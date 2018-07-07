<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperDetail.aspx.cs" Inherits="PMS.Web.paperDetail" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>论文详细信息</title>
    </head>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/ml.css">
    <link rel="stylesheet" href="css/style.css">

    <body>
        <div class="container-fluid col-lg-10 col-lg-offset-1">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div class="navbar-header">
                        <a class="navbar-brand" href="#">题目信息</a>
                    </div>
                    <div style="float: right">
                        <button type="button" class="btn btn-primary navbar-btn">
                            <a href="PaperDtailStu.aspx?titleid=<%=titleid %>" >选定题目</a>
                        </button>
                    </div>
                </div>
            </nav>
            <div class="panel">
                <div class="panel-heading text-center">
                    <label for="title"><%=titleId.title %></label>
                </div>
                <div class="panel-body">
                    <span><%=titleId.TitleContent %></span>
                </div>
                <div class="panel-footer">
                    <label for="text">选题人数上限：<%=titleId.Limit %></label>
                    <label for="text" style="float: right">已选人数：<%=titleId.Selected %></label>
                </div>
            </div>
        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    </html>
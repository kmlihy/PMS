<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addPaper.aspx.cs" Inherits="PMS.Web.admin.addPaper" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加论文信息</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/zwh.css" />
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>

<body id="addPaperBody">
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>添加论文信息</h2>
        </div>
        <div class="panel-body">
            <div class="addPaper">
                <div class="container-fluid">
                <div id="box" class="col-xs-10 col-xs-10 col-md-10 col-lg-10 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                    <span class="lable">标题：</span>
                    <input maxlength="100" type="text" name="title" class="TextBox form-control" placeholder="请输入标题" />
                </div>

                <div id="box" class="col-xs-10 col-sm-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                    <span class="lable">专业：</span>
                    <select name="profession" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control selPro" required="required">
                        <option value="" id="getPro">————请选择专业————</option>
                        <%
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {%>
                        <option>
                            <%=ds.Tables[0].Rows[i]["proName"].ToString() %>
                        </option>
                        <% 
                            }
                        %>
                    </select>
                </div>
                <div id="box" class="col-xs-10 col-sm-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-2 col-md-push-2 col-lg-push-2">
                    <span class="lable">批次：</span>
                    <select name="batch" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control selBat" required="required">
                        <option value="">————请选择批次————</option>
                        <%
                            for (int i = 0; i < pbds.Tables[0].Rows.Count; i++)
                            {%>
                        <option>
                            <%=pbds.Tables[0].Rows[i]["planName"].ToString() %>
                        </option>
                        <%
                            }
                        %>
                    </select>
                </div>
                <div id="box" class="number col-xs-10 col-sm-10 col-md-2 col-lg-2">
                    <span class="lable1">人数上限：</span>
                    <input type="number" min="0" max="200" class="numMax" />
                </div>

                <div id="box" class="col-xs-11 col-sm-11 col-md-11 col-lg-11 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                    <span class="lable1">内容：</span>
                    <textarea name="content" class="content"></textarea>
                </div>
                <div>
                    <button id="btnOK" type="submit" class="btn btn-primary col-xs-3 col-sm-3 col-md-2 col-lg-2 col-xs-push-8 col-sm-push-8 col-md-push-9 col-lg-push-9">提交论文</button>
                </div>
            </div></div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../kindeditor/kindeditor-all.js"></script>
<script src="../js/zwh.js"></script>
<script src="../js/addPaper.js"></script>
<script src="../js/xcConfirm.js"></script>

</html>

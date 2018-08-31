<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oralDefenseStudent.aspx.cs" Inherits="PMS.Web.oralDefenseStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文答辩</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body class="oraldefense-student">
    <%if (RTId == "" || RTId == null)
        { %>
    <h3>暂未选题</h3>
    <%}
    else if (RTId=="noGroup")
    { %>
     <h3>未指定答辩小组</h3>
        <% }
    else
    {%>
    <div class="container oraldefense-div">
        <div class="panel panel-heading text-center">
            <h2>我的答辩小组</h2>
        </div>
        <div class="panel panel-body text-center">
            <table class="table table-bordered oraldefense-table">
                <thead>
                    <tr>
                        <td>姓名</td>
                        <td>负责职务</td>
                        <td>联系方式</td>
                        <td>电子邮箱</td>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td><%=leaderName %> </td>
                        <td>组长</td>
                        <td><%=leaderTel %></td>
                        <td><%=leaderMail %></td>
                    </tr>
                    <tr>
                        <td><%=memberName %></td>
                        <td>副组长</td>
                        <td><%=memberTel %></td>
                        <td><%=memberMail %></td>
                    </tr>
                    <tr>
                        <td><%=recorderName %></td>
                        <td>秘书</td>
                        <td><%=recorderTel %></td>
                        <td><%=recorderMail %></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="panel panel-footer text-right">
            <button class="btn btn-success" data-toggle="modal" data-target="#myModal">查看答辩记录</button>
        </div>
    </div>
    <!--查看答辩记录模态框 -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">查看答辩记录
                    </h4>
                </div>
                <div class="modal-body">
                    <div>
                        <pre id="oraldefenseHistory">
                            老师还未录入答辩记录
                        </pre>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
    <%} %>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaperDtailStu.aspx.cs" Inherits="PMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的题目信息</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/zwh.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>

<body>
    <div class="container-fluid col-lg-10 col-lg-offset-1" id="box" onload="disp_confirm()">
        <div class="navbar navbar-default allNews_pageHead" role="navigation">
            <span class="h2 text-info" id="allNews_info">我的题目信息</span>
        </div>
        <div class="panel">
            <div class="panel-heading text-center">

                <% if (showTitle == null)
                    {
                        showTitle = "";
                    }%>
                <span class="h3">
                    <%=showTitle %>
                </span>
            </div>
            <div class="panel-body">
                <% if (showTitleContent == null)
                    {
                        showTitleContent = "";
                    }%>
                <span>
                    <%=showTitleContent %>
                </span>
            </div>
            <div class="panel-footer">
                <label>
                    <% if (showTeaName == null)
                        {
                            showTeaName = "";
                        }%>
                    <span>我的指导老师：<a href="#" data-toggle="modal" data-target="#myModal"><%=showTeaName %></a>
                    </span>
                </label>
                <span>|</span>
                <label>交叉指导老师：XX</label>
            </div>
        </div>
    </div>
    <!--查看指导教师弹窗-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="ModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="ModalLabel">查询指导教师
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-bordered" id="selecttab">
                        <tbody class="tablebody">
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">工号:</label></td>
                                <td>
                                    <p class="text-span"><%=teaAccount %></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">姓名:</label></td>
                                <td>
                                    <p class="text-span"><%=teaName %></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别:</label></td>
                                <td>
                                    <p class="text-span"><%=sex %></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">学院:</label></td>
                                <td>
                                    <p class="text-span"><%=college %></p>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话:</label></td>
                                <td>
                                    <p class="text-span"><%=phone %></p>
                                </td>
                                <td class="teaLable">
                                    <label class="text-span">邮箱:</label></td>
                                <td>
                                    <p class="text-span"><%=email %></p>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script>
     <%if (showTitle == "")
    {%>
    $(document).ready(function () {
        document.write('<a href="http://localhost:33192/PaperList.aspx">你还没有选题，请点击跳转到选题界面  </a>');
    })
    <% }%>
</script>
</html>

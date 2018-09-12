<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myCrossGuidanceTeacher.aspx.cs" Inherits="PMS.Web.myCrossGuidanceTeacher" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>我的交叉指导老师</h2>
        </div>
        <div class="panel-body">
            <table class="table table-bordered table-responsive">
                <%--<tr>
                    <td colspan="8" style="vertical-align: middle">
                        <span class="sap">我的交叉指导老师</span>
                        <button type="button" class="btn btn-default btn_searchComment btn-info btn-sm" data-toggle="modal" data-target="#myModa2">
                            <span class="glyphicon glyphicon-search"></span>
                            查看历史指导意见
                        </button>
                    </td>
                </tr>--%>
                <tr>
                    <td class="text_type">姓名</td>
                    <td class="text-info"><%=name %></td>
                    <td class="text_type">性别</td>
                    <td class="text-info"><%=sex %></td>
                    <td class="text_type">联系方式</td>
                    <td class="text-info"><%=phone %></td>
                    <td class="text_type">电子邮件</td>
                    <td class="text-info"><%=email %></td>
                </tr>
            </table>
            <div class="container-fluid table-bordered img-rounded modal_comment"><%=opninion %></div>
        </div>
    </div>

    <%--查看交叉指导意见模态框--%>
    <%--<div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal2">交叉指导意见
                    </h4>
                </div>
                <div class="modal-body">
                    <%if (dsCross != null && dsCross.Tables[0].Rows.Count - 2 >= 0)
                    {
                        for (int k = dsCross.Tables[0].Rows.Count - 2; k >= 0; k--)
                        { %>
                            <%=dsCross.Tables[0].Rows[k]["dateTime"].ToString() %>
                            <script type="text/html" id="code">
                                <%=dsCross.Tables[0].Rows[k]["guideOpinion"].ToString() %>
                            </script>
                            <br />
                        <%}
                    }else
                    { %>
                    <h3 class="text-primary">暂无历史指导意见</h3>
                    <%} %>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn_close" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>--%>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>

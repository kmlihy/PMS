<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myGuideTeacher.aspx.cs" Inherits="PMS.Web.myGuideTeacher" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h2>我的教师信息</h2>
        </div>
        <div class="panel-body">
            <%if (ds == null)
                { %>
            <h4>暂未换题,<a href="paperList.aspx">请前往选题页面选题</a></h4>
            <%}
            else
            { %>
            <table class="table table-bordered table-responsive">
                <tr>
                    <td colspan="8" style="vertical-align: middle">
                        <span class="sap">我的指导老师</span>
                        <button type="button" class="btn btn-default btn_searchComment btn-info btn-sm" data-toggle="modal" data-target="#myModa1">
                            <span class="glyphicon glyphicon-search"></span>
                            查看历史指导意见
                        </button>
                    </td>
                </tr>
                <tr>
                    <td class="text_type">姓名</td>
                    <td><%=name %></td>
                    <td class="text_type">性别</td>
                    <td><%=sex %></td>
                    <td class="text_type">联系方式</td>
                    <td><%=phone %></td>
                    <td class="text_type">电子邮件</td>
                    <td><%=email %></td>
                </tr>
            </table>
            <div class="container-fluid table-bordered img-rounded modal_comment"><%=opinion %></div>
            <%} %>
        </div>
    </div>

    <%--查看历史指导意见--%>
    <div class="modal fade" id="myModa1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal1">指导意见
                    </h4>
                </div>
                <div class="modal-body">
                    <%if (dsGuide != null && dsGuide.Tables[0].Rows.Count - 2 >= 0)
                    {
                        for (int k = dsGuide.Tables[0].Rows.Count - 2; k >= 0; k--)
                        { %>
                            <%=dsGuide.Tables[0].Rows[k]["dateTime"].ToString() %>
                            <script type="text/html" id="code">
                                <%=dsGuide.Tables[0].Rows[k]["opinion"].ToString() %>
                            </script>
                            <br />
                        <%}
                    }
                    else
                    { %>
                    <h2>暂无历史指导意见</h2>
                    <%} %>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default btn_close" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="PMS.Web.news" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>公告查看</title>
        <link rel="stylesheet" href="css/bootstrap.min.css"/>
        <link rel="stylesheet" href="css/ml.css"/>
        <link rel="stylesheet" href="css/style.css"/>
    </head>
    <body>
        <div class="container-fluid col-lg-6 col-lg-offset-3" id="contentBox">
            <div class="panel table-bordered" id="panelBox">
                 <div class="panel-heading">
                    <span class="h3 text-info">通知公告</span>
                    <span class="glyphicon glyphicon-volume-up btn-lg"></span>
                    <hr id="underline" />
                </div>
                <div class="panel-body container-fluid" id="panelBody">
                    <div class="container col-lg-12">
                        <table class="table">
                            <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            { %>
                            <thead>
                                <th colspan="2" class="text-center">
                                    <label for="title" class="h4"><%=ds.Tables[0].Rows[i]["newsTitle"].ToString() %></label>
                                </th>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="text-right">
                                        <span class="table">
                                            发布时间:<%=ds.Tables[0].Rows[i]["createTime"].ToString() %>
                                            <label id="time"></label>
                                        </span>
                                    </td>
                                    <td class="text-left">
                                        <span class="table">
                                            发布人：<%=ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="">
                                        <label for="text">
                                            <%=ds.Tables[0].Rows[i]["newsContent"].ToString() %>
                                        </label>
                                    </td>
                                </tr>
                            </tbody>
                            <%} %>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    </html>
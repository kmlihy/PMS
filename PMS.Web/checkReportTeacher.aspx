<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkReportTeacher.aspx.cs" Inherits="PMS.Web.checkReportTeacher" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>下载学生查重报告</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>下载学生查重报告</h1>
        </div>
        <div class="panel-body">
            <div class="panel panel-default">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <input type="text" class="form-control inputsearch" placeholder="请输入搜索条件" id="inputsearch" value="<%=secSearch %>" />
                        <span class="input-group-btn">
                            <button class="btn btn-info" type="button" id="btn-search">
                                <span class="glyphicon glyphicon-search">查询</span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <div class="panel-body text-center" id="panelbody">
                <table class="table table-bordered text-center">
                    <thead>
                        <tr>
                            <th class="text-center"><nobr>序号</nobr></th>
                            <th class="text-center"><nobr>学号</nobr></th>
                            <th class="text-center"><nobr>姓名</nobr></th>
                            <th class="text-center"><nobr>论文题目</nobr></th>
                            <th class="text-center"><nobr>上传时间</nobr></th>
                            <th class="text-center"><nobr>下载</nobr></th>
                            <th class="text-center"><nobr>审核</nobr></th>
                        </tr>
                    </thead>
                    <tbody>
                        <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            { %>
                        <tr>
                            <td><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                            <td id="stuAccount"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                            <td><%=ds.Tables[0].Rows[i]["dateTime"].ToString() %></td>
                            <td>
                                <a href="<%=ds.Tables[0].Rows[i]["path"].ToString() %>">
                                    <button type="button" class="btn btn-success">
                                        <span class="glyphicon glyphicon-download-alt"></span>
                                    </button>
                                </a>
                            </td>
                            <td>
                                <%if (ds.Tables[0].Rows[i]["state"].ToString() == "3")
                                    { %>
                                <span class="btn-success" id="ok">审核通过</span>
                                <%} else if (ds.Tables[0].Rows[i]["state"].ToString() == "1") { %>
                                <span class="btn-danger" id="no">审核不通过</span>
                                <%} else{ %>
                                <button type="submit" class="btn btn-success submit">同意</button>
                                <button type="submit" class="btn btn-danger submitNo">不同意</button>
                                <%} %>
                            </td>
                        </tr>
                        <%} %>
                    </tbody>
                </table>
            </div>
            <div class="text-right" id="paging">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="first">首页</a>
                    </li>
                    <li>
                        <a href="#" class="jump" id="prev">
                            <span class="iconfont icon-back"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=getCurrentPage %></a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump">
                            <%=count %>
                        </a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump">
                            <span class="iconfont icon-more"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump" id="last">尾页</a>
                    </li>
                </ul>
            </div>

        </div>
        <%-- 意见填写--%>
       <%-- <div class="modal" id="myModa1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModal1">意见
                        </h4>
                    </div>
                    <div class="modal-body">
                        <div class="container-fluid table-bordered img-rounded modal_comment">
                            <textarea rows="8" style="margin-top: 15px; width: 100%;" class="opinion"></textarea>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="submit" class="btn btn-default " id="submit">同意</button>
                        <button type="submit" class="btn btn-default ">不同意</button>
                        <button type="button" class="btn btn-default " data-dismiss="modal">关闭</button>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/checkReportTeacher.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="downLoadPaper.aspx.cs" Inherits="PMS.Web.downLoadPaper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>我的学生论文</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <style>
        #body {
            height: 500px;
        }
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>我的学生论文</h1>
        </div>
        <div class="panel-body" id="body">
            <div class="panel panel-default" id="propanelbox">
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
            <table class="table text-center table-bordered">
                <thead>
                    <tr>
                        <th class="text-center"><nobr>序号</nobr></th>
                        <th class="text-center"><nobr>论文</nobr></th>
                        <th class="text-center"><nobr>学号</nobr></th>
                        <th class="text-center"><nobr>姓名</nobr></th>
                        <th class="text-center"><nobr>驳回意见</nobr></th>
                        <th class="text-center"><nobr>评定</nobr></th>
                        <th class="text-center"><nobr>查看历史提交</nobr></th>
                    </tr>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td style="vertical-align: middle" class="col-sm-1"><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                        <td style="vertical-align: middle" class="col-sm-3"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                        <td style="vertical-align: middle" class="col-sm-1 stuAccount"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %></td>
                        <td style="vertical-align: middle" class="col-sm-1"><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                        <td style="vertical-align: middle" class="col-sm-1">
                            <button type="button" class="btn btn-info btnOpinion" data-toggle="modal">
                                <span class="glyphicon glyphicon-list-alt"></span>
                                点击评价
                            </button>
                        </td>
                        <td style="vertical-align: middle" class="col-sm-1">
                            <a href="InstructorsComments.aspx?stuAccount=<%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %>&titleRecordId=<%=ds.Tables[0].Rows[i]["titleRecordId"].ToString() %>">
                                <%if (ds.Tables[0].Rows[i]["state"].ToString() == "0")
                                    { %>
                                <span class="glyphicon glyphicon-hand-right"></span>
                                评定及成绩
                                <%}
                                else
                                { %>
                                已评定
                                <%} %>
                            </a>
                        </td>
                        <td style="vertical-align: middle" class="col-sm-1">
                            <a href="stuHistoryPaper.aspx?stuAccount=<%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %>">
                                <span class="glyphicon glyphicon-hand-right"></span>
                                点击查看
                            </a>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
        </div>
    </div>
    <%--分页--%>
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
                <a href="#" class="jump">
                    <%=getCurrentPage %>
                </a>
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

    <%--添加指导意见--%>
    <div class="modal fade" id="myModa1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal1">指导评价意见
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="container-fluid table-bordered img-rounded modal_comment">
                        <textarea rows="8" style="margin-top: 15px; width: 100%;" class="opinion"></textarea>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-default " id="submit">提交</button>
                    <button type="button" class="btn btn-default " data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/downloadPaper.js"></script>
</html>

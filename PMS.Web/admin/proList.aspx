<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proList.aspx.cs" Inherits="PMS.Web.admin.proList" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
</head>
<body>
    <div class="container-fluid big-box">
        <div class="panel panel-default" id="propanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search">查询</span>
                        </button>
                    </span>
                    <span class="input-group-btn">
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                            <span class="glyphicon glyphicon-plus-sign">新增</span>
                        </button>
                    </span>
                    <button class="btn btn-primary" type="button" id="btn-Adds" data-toggle="modal" data-target="#addsModal">
                        <span class="glyphicon glyphicon-plus-sign"></span>
                        批量导入
                    </button>
                    <button class="btn btn-danger" type="button" id="btn-Del">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量删除
                    </button>
                </div>
            </div>
        </div>
        <div class="" id="protab">
            <table class="table table-bordered table-hover" id="proTable">
                <thead>
                    <th class="text-center">
                        <input type="checkbox" class="js-checkbox-all" />
                    </th>
                    <th class="text-center">编号</th>
                    <th class="text-center">专业名称</th>
                    <th class="text-center">所属分院</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center td-check">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center" id="tdproId">
                            <%=ds.Tables[0].Rows[i]["proId"].ToString() %>
                        </td>
                        <td class="text-center" id="tdproName"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                        <td class="text-center" id="tdcollegeName"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning changebtn" data-toggle="modal" data-target="#myModa2">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger btnDel" id="del">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <div class="container-fluid text-right">
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
        </div>
    </div>
    <!-- 批量导入弹框 -->
    <div class="modal fade" id="addsModal" tabindex="-1" role="dialog" aria-labelledby="addsModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="addsModalLabel">批量导入学院信息
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">上传</button>
                                </td>
                                <td>
                                    <button type="button" class="btn btn-primary" data-dismiss="modal" aria-hidden="true">下载模板</button>
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
    <!--添加专业弹窗-->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加专业
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center">
                                        <label class="text-span">所属院系:</label></td>
                                    <td>
                                        <select class="selectpicker changeSearch" data-width="auto" id="selectcol">
                                            <option value="-1">-请选择院系-</option>
                                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                                {%>
                                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                            <%} %>
                                        </select></td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">专业名称:</label></td>
                                    <td>
                                        <input class="form-control teaAddinput" type="text" id="proName" />
                                        <span id="validata"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="submit" class="btn btn-primary" id="btnAdd" onclick="add()">提交</button>
                </div>
            </div>
        </div>
    </div>
    <!--编辑弹窗-->
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" data-backdrop="static" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                    </button>
                    <h4 class="modal-title" id="">专业信息修改
                    </h4>
                </div>
                <div class="modal-body">
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="teaLable text-center">
                                        <label class="text-span">所属院系:</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="collegeSelect">
                                            <option value="-1">-请选择院系-</option>
                                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                                {%>
                                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                            <%} %>
                                        </select>
                                        <input class="form-control col-sm-3" data-width="auto" type="text" id="colname" readonly="true" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">专业名称:</label></td>
                                    <td>
                                        <input class="form-control col-sm-3" data-width="auto" type="text" id="p_proName" readonly="true" />
                                        <span id="validate"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default chID" data-dismiss="modal" id="closeModel">关闭</button>
                    <button type="button" class="btn btn-default" id="btnch">编辑</button>
                    <button type="button" class="btn btn-primary" id="btnSave">保存修改</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/lgd.js"></script>
<script src="../js/proList.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

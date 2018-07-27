<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teaList.aspx.cs" Inherits="PMS.Web.admin.teaList" %>

<%=""%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>教师信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
</head>
<body>
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>教师信息管理列表</h2>
        </div>
        <div class="panel-body" id="panelbody">
            <div class="container-fluid big-box">
                <div class="panel panel-default" id="propanelbox">
                    <div class="pane input-group" id="panel-head">
                        <div class="input-group" id="inputgroups">
                            <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=showmsg %>" />
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
                <div class="">
                    <table class="table table-bordered table-hover">
                        <thead>
                            <th class="text-center">
                                <input type="checkbox" class="js-checkbox-all" />
                            </th>
                            <th class="text-center">工号</th>
                            <th class="text-center">姓名</th>
                            <th class="text-center">性别</th>
                            <th class="text-center">院系</th>
                            <th class="text-center">联系电话</th>
                            <th class="text-center">邮箱</th>
                            <th class="text-center">教师类型</th>
                            <th class="text-center">操作</th>
                        </thead>
                        <tbody>
                            <%
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                            %>
                            <tr>
                                <td class="text-center td-check">
                                    <input type="checkbox" />
                                </td>
                                <td class="text-center" id="tdteaAccount">
                                    <%=ds.Tables[0].Rows[i]["teaAccount"].ToString() %>
                                </td>
                                <td class="text-center" id="tdteaName">
                                    <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                                </td>
                                <td class="text-center" id="tdteaSex">
                                    <%=ds.Tables[0].Rows[i]["sex"].ToString() %>
                                </td>
                                <td class="text-center" id="tdteacoll">
                                    <%=ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                </td>
                                <td class="text-center" id="tdteaTel">
                                    <%=ds.Tables[0].Rows[i]["phone"].ToString() %>
                                </td>
                                <td class="text-center" id="tdteaEmail">
                                    <%=ds.Tables[0].Rows[i]["Email"].ToString() %>
                                </td>
                                <!--<td class="text-center cstdteaPwd" id="tdteaPwd">
                                    <%=ds.Tables[0].Rows[i]["teaPwd"].ToString() %>
                                </td>-->
                                <td class="text-center" id="tdteatype">
                                    <%=((ds.Tables[0].Rows[i]["teaType"].ToString()=="1")?"教师":"分院管理员")%>
                                </td>
                                <td class="text-center">
                                    <button class="btn btn-default btn-sm btn-warning changebtn" data-toggle="modal" data-target="#myModa2">
                                        <span class="glyphicon glyphicon-pencil"></span>
                                    </button>
                                    <button class="btn btn-default btn-sm btn-danger btnDel">
                                        <span class="glyphicon glyphicon-trash"></span>
                                    </button>
                                </td>
                            </tr>
                            <%
                                }
                            %>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
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
        <!-- 批量导入弹框 -->
        <div class="modal fade" id="addsModal" tabindex="-1" role="dialog" aria-labelledby="addsModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="addsModalLabel">批量导入教师信息
                        </h4>
                    </div>
                    <form id="form2" runat="server" method="post" enctype="multipart/form-data" action="branchList.aspx?op=upload">
                        <div class="modal-body">
                            <table class="table">
                                <tbody>
                                    <tr>
                                        <td class="text-center">
                                            <div>
                                                <a href="javascript:;" class="file">列表导入
                                                <input type="file" name="upload" id="upload" />
                                                    <label class="showFileName"></label>
                                                    <label class="fileerrorTip"></label>
                                                </a>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="text-center">
                                            <button type="button" class="btn btn-primary" id="downfile">下载模板</button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="modal-footer">
                            <button type="submit" class="btn btn-success" id="btnupload">上传</button>
                            <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        <!-- 添加教师弹框（Modal） -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close addclose" data-dismiss="modal" aria-hidden="true">
                            &times;
                        </button>
                        <h4 class="modal-title" id="myModalLabel">添加教师
                        </h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <%--                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">所属院系</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="addselectcol">
                                            <option value="">-请选择院系-</option>
                                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                                { %>
                                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                            <%} %>
                                        </select>
                                    </td>
                                </tr>--%>
                                <%--                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">教师类型</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="addteaType">
                                            <option value="1">教师</option>
                                            <option value="2">管理员</option>
                                        </select>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">工号</label></td>
                                    <td>
                                        <input class="form-control" type="text" id="teaAccount" />
                                        <span id="validateAccount"></span>
                                    </td>
                                </tr>
                                <!--<tr>
                                    <td class="teaLable">
                                        <label class="text-span">密码</label></td>
                                    <td>
                                        <input class="form-control" type="password" id="pwd" /></td>
                                </tr>-->
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">姓名</label></td>
                                    <td>
                                        <input class="form-control" type="text" id="teaName" />
                                        <span id="validateName"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">性别</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="sex">
                                            <option value="">男</option>
                                            <option value="">女</option>
                                        </select>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">邮箱</label></td>
                                    <td>
                                        <input class="form-control" type="text" id="email" />
                                        <span id="validateEmal"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">联系电话</label></td>
                                    <td>
                                        <input class="form-control" type="text" id="tel" />
                                        <span id="validateTel"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default addclose" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary" id="btnAdd">添加</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- 编辑教师弹框（Modal） -->
        <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title" id="myModal2">教师信息修改
                        </h4>
                    </div>
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <%--                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">所属院系:</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="chselectcol">
                                            <option value="-1">-请选择院系-</option>
                                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                                { %>
                                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                            <%} %>
                                        </select>
                                        <p class="text-span" id="p-collegeName"></p>
                                    </td>
                                </tr>--%>
                                <%if (state == 0)
                                { %>
                                <tr id="type">
                                    <td class="teaLable">
                                        <label class="text-span">类型:</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="chteaType">
                                            <option value="1">教师</option>
                                            <option value="2">管理员</option>
                                        </select>
                                        <p class="text-span" id="p-chteaType"></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">工号:</label></td>
                                    <td>
                                        <input class="form-control chteaAccount" type="text" id="chteaAccount" />
                                        <span id="chValitateAccount"></span>
                                    </td>
                                </tr>
                                <%}
                                else
                                { %>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">工号:</label></td>
                                    <td>
                                        <input class="form-control chteaAccount" type="text" readonly="true" id="chteaAccount" />
                                        <span id="chValitateAccount"></span>
                                    </td>
                                </tr>
                                <%} %>
                                <!--<tr id="tr-pwd">
                                    <td class="teaLable">
                                        <label class="text-span">密码:</label></td>
                                    <td>
                                        <input class="form-control chpwd" type="password" id="chpwd" /></td>
                                </tr>-->
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">姓名:</label></td>
                                    <td>
                                        <input class="form-control chteaName" type="text" id="chteaName" />
                                        <span id="chValitateteaName"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">性别:</label></td>
                                    <td>
                                        <select class="selectpicker" data-width="auto" id="chsex">
                                            <option value="">男</option>
                                            <option value="">女</option>
                                        </select>
                                        <p class="text-span" id="p-chsex"></p>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">邮箱:</label></td>
                                    <td>
                                        <input class="form-control chemail" type="text" id="chemail" />
                                        <span id="chValitateteaemail"></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="teaLable">
                                        <label class="text-span">联系电话:</label></td>
                                    <td>
                                        <input class="form-control chtel" type="text" id="chtel" />
                                        <span id="chValitateteatel"></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default chID" data-dismiss="modal" id="closeModel">关闭</button>
                        <button type="button" class="btn btn-default btnch">编辑</button>
                        <button type="button" class="btn btn-primary" id="chbtn">保存更改</button>
                    </div>
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
<script src="../js/ml.js"></script>
<script src="../js/teaList.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

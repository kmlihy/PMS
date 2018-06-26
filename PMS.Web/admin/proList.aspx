<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="proList.aspx.cs" Inherits="PMS.Web.admin.proList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<link rel="stylesheet" href="../css/bootstrap.min.css" />
<link rel="stylesheet" href="../css/ml.css" />
<link rel="stylesheet" href="../css/style.css" />
<link rel="stylesheet" href="../square/_all.css" />

<body>
    <div class="container-fluid big-box">
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <div>
                    <ul class="nav navbar-nav">
                            <li class="active">
                                <div class="form-group checkbox-stu">
                                    <select class="form-control">
                                        <option value="">-请选择分院-</option>
                                        <%for (int i = 0; i < bads.Tables[0].Rows.Count; i++)
                                            {%>
                                            <option value=""><%=bads.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </li>
                            <li class="active">
                                <div class="form-group checkbox-stu">
                                    <select class="form-control">
                                        <option value="">-请选择专业-</option>
                                            <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                            {%>
                                            <option value=""><%=prods.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%} %>
                                    </select>
                                </div>
                            </li>
                            <li class="active col-sm-4 checkbox-stu">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="请输入查询条件"/>
                                    <span class="input-group-btn">
                                        <button class="btn btn-info" type="button">
                                            <span class="glyphicon glyphicon-search"></span>
                                            查询
                                        </button>
                                    </span>
                                </div>
                            </li>
                            <li class="active">
                                <button class="btn btn-success checkbox-stu" id="btn-Add">
                                    <span class="glyphicon glyphicon-plus-sign"></span>
                                    新增
                                </button>
                            </li>
                            <li class="active">
                                <button class="btn btn-danger checkbox-stu" id="btn-Del">
                                    <span class="glyphicon glyphicon-trash"></span>
                                    批量删除
                                </button>
                            </li>
                            
                        </ul>
                </div>
            </div>
        </nav>
        <div class="">
            <table class="table table-bordered table-hover">
                <thead>
                    <th class="text-center">
                        <input type="checkbox" class="js-checkbox-all" />
                    </th>
                    <th class="text-center">序号</th>
                    <th class="text-center">专业名称</th>
                    <th class="text-center">所属分院</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proId"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger">
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
                        <a href="">
                            <span class="glyphicon glyphicon-chevron-left"></span>
                        </a>
                    </li>
                    <li>
                        <a href="">1</a>
                    </li>
                    <li>
                        <a href="">2</a>
                    </li>
                    <li>
                        <a href="">3</a>
                    </li>
                    <li>
                        <a href="">...</a>
                    </li>
                    <li>
                        <a href="">
                            <span class="glyphicon glyphicon-chevron-right"></span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectTopicList.aspx.cs" Inherits="PMS.Web.admin.selectTopicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选题管理列表</title>

    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/ml.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>

<body>
    <div class="container-fluid big-box">
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <div>
                    <ul class="nav navbar-nav">
                        <li class="active">
                            <div class="form-group checkbox-stu">
                                <select class="selectpicker" data-width="auto">
                                    <option value="">-请选择分院-</option>
                                    <%for (int i = 0; i < bads.Tables[0].Rows.Count; i++)
                                        {%>
                                    <option value=""><%=bads.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                    <%} %>
                                </select>
                            </div>
                        </li>
                        <li class="active">
                            <div class="form-group col-sm-3 checkbox-stu">
                                <select class="selectpicker" data-width="auto">
                                     <option value="">-请选择专业-</option>
                                    <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                        {%>
                                    <option value=""><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                                    <%} %>
                                </select>
                            </div>
                        </li>
                        <li class="active col-sm-4 checkbox-stu">
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="请输入查询条件" />
                                <span class="input-group-btn">
                                    <button class="btn btn-info" type="button">
                                        <span class="glyphicon glyphicon-search"></span>
                                        查询
                                    </button>
                                </span>
                            </div>
                        </li>
                        <li class="active">
                            <button class="btn btn-success checkbox-stu" data-toggle="modal" data-target="#myModal" id="btn-Add">
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
                    <th class="text-center">题目</th>
                    <th class="text-center">出题教师</th>
                    <th class="text-center">选题学生</th>
                    <th class="text-center">所属批次</th>
                    <th class="text-center">所属专业</th>
                    <th class="text-center">已选人数</th>
                    <th class="text-center">人数上限</th>
                    <th class="text-center">选题时间</th>
                    <th class="text-center">所属分院</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <tr>
                        <%for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {%>
                        <td class="text-center">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["titleRecordId"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["teaName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["realName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["planName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["selected"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["limit"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["title"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-success">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
                        <%} %>
                    </tr>
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
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加教师
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <td class="teaLable">工号</td>
                                <td>
                                    <input type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">姓名</td>
                                <td>
                                    <input type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">性别</td>
                                <td>
                                    <select type="text">
                                        <option>男</option>
                                        <option>女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">院系</td>
                                <td>
                                    <select type="text">
                                        <option>信息工程学院</option>
                                        <option>人文学院</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">职称</td>
                                <td>
                                    <select type="text">
                                        <option>教授</option>
                                        <option>副教授</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">邮箱</td>
                                <td>
                                    <input type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">联系电话</td>
                                <td>
                                    <input type="text" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="submit" class="btn btn-primary">提交更改</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/bootstrap-select.js"></script>

</html>

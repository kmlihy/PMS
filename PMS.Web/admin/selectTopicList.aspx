<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectTopicList.aspx.cs" Inherits="PMS.Web.admin.selectTopicList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>选题管理列表</title>

    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>

<body>
    <div class="container-fluid big-box">
        <div class="panel panel-default" id="selectToppanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <select class="selectpicker" data-width="auto">
                        <option value="">-请选择专业-</option>
                        <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                            {%>
                        <option value=""><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                        <%} %>
                    </select>
                    <input type="text" class="form-control inputsearch" placeholder="请输入查询条件" id="inputsearch" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search">查询</span>
                        </button>
                    </span>
                    <button class="btn btn-danger" type="button" id="btn-Del">
                        <span class="glyphicon glyphicon-trash"></span>
                        批量删除
                    </button>
                </div>
            </div>
        </div>

        <div id="selectToptab">
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
            <div class="text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="prev">上一页
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump">1</a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump">下一页
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
<script src="../js/bootstrap-select.js"></script>
<script>
    function change() {
        //获取选中的值
        var college = $("#select").find("option:selected").text();
        //alert(college);
        sessionStorage.setItem["collegeselect", college];
        var storage = window.localStorage;
        var data = {
            currentPage: storage.collegeselect
        }
        $.ajax({
            type: "Post",
            url: "selectTopicList.aspx",
            data: data
        });
    }
    $(document).ready(function () {
        $(".jump").click(function () {
            switch ($.trim($(this).html())) {
                case ("上一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())-1%>);
                    break;
                case ("下一页"):
                    jump(<%=int.Parse( ViewState["page"].ToString())+1%>);
                    break;
                case ("1"):
                    jump(1);
                    break;
                case ("<%=count %>"):
                    jump(<%=count %>);
                    break;
            }
        });
        function jump(cur) {
            window.location.href = "selectTopicList.aspx?currentPage=" + cur;
        }
    })
</script>
</html>

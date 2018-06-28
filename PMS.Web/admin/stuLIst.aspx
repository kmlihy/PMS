<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuLIst.aspx.cs" Inherits="PMS.Web.admin.stuLIst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/ml.css">
    <link rel="stylesheet" href="../css/lgd.css">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../square/_all.css">
    <link rel="stylesheet" href="../css/bootstrap-select.css">
</head>

<body>
    <div class="container-fluid ">
        <div class="panel panel-default" id="teapanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <select class="selectpicker">
                        <option>请选择专业</option>
                        <% for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                            { %>
                        <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>">
                            <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                        </option>
                        <%} %>
                    </select>
                    <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                    <span class="input-group-btn">
                        <button class="btn btn-info" type="button" id="btn-search">
                            <span class="glyphicon glyphicon-search" id="search">查询</span>
                        </button>
                    </span>
                    <span class="input-group-btn">
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModal" id="btn-Add">
                            <span class="glyphicon glyphicon-plus-sign">新增</span>
                        </button>
                    </span>
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
                    <th class="text-center">学号</th>
                    <th class="text-center">姓名</th>
                    <th class="text-center">性别</th>
                    <th class="text-center">专业</th>
                    <th class="text-center">院系</th>
                    <th class="text-center">联系电话</th>
                    <th class="text-center">邮箱</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <% for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        { %>
                    <tr>
                        <td class="text-center">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["stuAccount"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["realName"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["proName"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                        </td>
                        <td class="text-center">
                            <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                        </td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-success">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-warning">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump" id="prev">
                            上一页
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
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump" onclick="pagingMsg()">
                            下一页
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- 添加学生弹框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">添加学生
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">学号</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option value="">请选择性别</option>
                                        <option value="">男</option>
                                        <option value="">女</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option value="">请选择院系</option>
                                        <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=prods.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                            <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </option>
                                        <% } %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto">
                                        <option>请选择专业</option>
                                        <% for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>">
                                            <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                                        </option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary">提交更改</button>
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
<script>
    sessionStorage.setItem("page", <%=getCurrentPage %>);
    sessionStorage.setItem("countPage",<%=count %>);
    $(document).ready(function () {
        $(".jump").click(function () {
            switch ($.trim($(this).html())) {
                case ("上一页"):
                    if (parseInt(sessionStorage.getItem("page")) > 1) {
                        jump(parseInt(sessionStorage.getItem("page")) - 1);
                        //sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                        break;
                    }
                    else {
                        jump(1);
                        break;
                    }
                case ("下一页"):
                    if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                        jump(parseInt(sessionStorage.getItem("page")) + 1);
                        //sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                        break;
                    }
                    else {
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case ("1"):
                    jump(1);
                    break;
                case (sessionStorage.getItem("countPage")):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        });

        $("#search").click(function () {
            var strWhere = $("#inputsearch").val();
            sessionStorage.setItem("strWhere",strWhere);
            jump(1);
        });

        function jump(cur) {
            if (sessionStorage.getItem("strWhere") == null) {
                window.location.href = "stuLIst.aspx?currentPage=" + cur
            }
            else {
                window.location.href = "stuLIst.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
            }          
        }
    })

    //分页的首页和尾页显示
    function pagingMsg() {
        var my_toast_plug_name = "mytoast";
        $[my_toast_plug_name] = function (options) {
            var content;
            if (parseInt(sessionStorage.getItem("page")) <= 1) {
                content = "前无古人！";
            } else if (parseInt(sessionStorage.getItem("page")) >= parseInt(sessionStorage.getItem("countPage"))) {
                content = "后无来者！";
            } else {
                return;
            }
            var jq_toast = $("<div class='my-toast'><div class='my-toast-text'></div></div>");
            var jq_text = jq_toast.find(".my-toast-text");
            jq_text.html(content);
            jq_toast.appendTo($("body")).stop().fadeIn(500).delay(3000).fadeOut(500);
            var w = jq_toast.width() - 10;
            jq_text.width(w);
            var l = -jq_toast.outerWidth() / 2;
            var t = -jq_toast.outerHeight() / 2;
            jq_toast.css({
                "margin-left": l + "px",
                "margin-top": t - 50 + "px"
            });
            var _jq_toast = jq_toast;
            setTimeout(function () {
                _jq_toast.remove();
            }, 3 * 1000);
        };
        $.mytoast({
            type: "notice"
        });
    }
</script>
</html>

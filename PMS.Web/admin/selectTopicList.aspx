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
                        <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString()%>"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
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
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["recordCreateTime"].ToString() %></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"].ToString() %></td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-success" data-toggle="modal" data-target="#myModal">
                                <span class="glyphicon glyphicon-search"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger">
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
                        <a href="#" class="jump" id="fristPage"><%=getCurrentPage %></a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump" id="lastPage"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump">下一页
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- 查看选题记录弹框（Modal） -->
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModalLabel">详细信息
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">所属院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="selectcol">
                                        <option value="">请选择院系</option>
                                        <option value="1">信息工程学院</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">类型</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="teaType">
                                        <option value="1">教师</option>
                                        <option value="2">管理员</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">工号</label></td>
                                <td>
                                    <input class="form-control" type="text" id="teaAccount" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">密码</label></td>
                                <td>
                                    <input class="form-control" type="password" id="pwd" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control" type="text" id="teaName" /></td>
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
                                    <input class="form-control" type="text" id="email" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control" type="text" id="tel" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="btnAdd">添加</button>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/lgd.js"></script>
<script>
    //当前页数
    sessionStorage.setItem("Page",<%=getCurrentPage%>);
    //总页
    sessionStorage.setItem("countPage",<%=count%>);
    $(document).ready(function () {
        $(".jump").click(function(){
            switch($.trim($(this).html())){
                case("上一页"):
                    if(parseInt(sessionStorage.getItem("Page"))>1){
                        jump(parseInt(sessionStorage.getItem("Page"))-1);
                        break;
                    }
                    else{
                        jump(1);
                        break;
                    }
                    
                case("下一页"):
                    if(parseInt(sessionStorage.getItem("Page"))<parseInt(sessionStorage.getItem("countPage"))){
                        jump(parseInt(sessionStorage.getItem("Page"))+1);
                        break;
                    }
                    else{
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case("1"):
                    break;
                case(sessionStorage.getItem("countPage")):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        });
        $("#btn-search").click(function(){
            var strWhere =$("#inputsearch").val();
            sessionStorage.setItem("strWhere",strWhere);
            jump(1);
        });
        function jump(cur) {
            if(sessionStorage.getItem("strWhere")==null){
                window.location.href = "selectTopicList.aspx?currentPage=" + cur;
            }else{
                window.location.href ="selectTopicList.aspx?currentPage="+cur+"&search="+sessionStorage.getItem("strWhere");
            }
        };
    });
    $(document).ready(function () {
        $("#next").click(function () {
            $('<div>').appendTo('body').addClass('alert alert-success').html('操作成功').show().delay(1500).fadeOut();
        })
    }) 
</script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stuLIst.aspx.cs" Inherits="PMS.Web.admin.stuLIst" %>
<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/ml.css"/>
    <link rel="stylesheet" href="../css/lgd.css"/>
    <link rel="stylesheet" href="../css/style.css"/>
    <link rel="stylesheet" href="../square/_all.css"/>
    <link rel="stylesheet" href="../css/bootstrap-select.css"/>
    <link rel="stylesheet" href="../css/iconfont.css" />
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
                    <button class="btn btn-danger" type="button" id="btn-Del" onclick="pagingMsg()">
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
                        <td class="text-center stuNO">
                            <%= ds.Tables[0].Rows[i]["stuAccount"].ToString() %>
                        </td>
                        <td class="text-center stuName">
                            <%= ds.Tables[0].Rows[i]["realName"].ToString() %>
                        </td>
                        <td class="text-center stuSex">
                            <%= ds.Tables[0].Rows[i]["sex"].ToString() %>
                        </td>
                        <td class="text-center stuPro" id="<%= ds.Tables[0].Rows[i]["proId"].ToString() %>">
                            <%= ds.Tables[0].Rows[i]["proName"].ToString() %>
                        </td>
                        <td class="text-center stuCollege" id="<%= ds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                            <%= ds.Tables[0].Rows[i]["collegeName"].ToString() %>
                        </td>
                        <td class="text-center stuPhone">
                            <%= ds.Tables[0].Rows[i]["phone"].ToString() %>
                        </td>
                        <td class="text-center stuEmail">
                            <%= ds.Tables[0].Rows[i]["Email"].ToString() %>
                        </td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning Editor" data-toggle="modal" data-target="#myEditor">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger" id="Delete">
                                <span class="glyphicon glyphicon-trash"></span>
                            </button>
                        </td>
                    </tr>
                    <% } %>
                </tbody>
            </table>
            <div class="container-fluid text-right">
                <ul class="pagination pagination-lg">
                    <li>
                        <a href="#" class="jump">首页</a>
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
                        <a href="#" class="jump"><%=count %></a>
                    </li>
                    <li>
                        <a href="#" id="next" class="jump" onclick="Alert('houwulaizhe')">
                            <span class="iconfont icon-more"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump">尾页</a>
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
                                    <label class="text-span">学号</label>
                                </td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="stuAccount" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">初始密码</label>
                                </td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="pwd" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="realName" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="sex">
                                        <option value="">请选择性别</option>
                                        <option value="男">男</option>
                                        <option value="女">女</option>
                                    </select>
                                </td>
                            </tr>
<%--                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="college">
                                        <option value="">请选择院系</option>
                                        <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>">
                                            <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </option>
                                        <% } %>
                                    </select>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="pro">
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
                                    <input class="form-control teaAddinput" type="text" id="email" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput" type="text" id="phone" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="saveSutdent">提交更改</button>
                </div>
            </div>
        </div>
    </div>
    <!--编辑按钮弹框-->
    <div class="modal fade" id="myEditor" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myEditorLabel">
                        编辑学生
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="teaLable text-center">
                                    <label class="text-span">学号</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuNO" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuName" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorStuSex" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">院系</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorCollege" type="text" />
<%--                                    <select class="selectpicker " data-width="auto" id="editorCollege">
                                        <option value="">请选择院系</option>
                                        <% for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>">
                                            <%=colds.Tables[0].Rows[i]["collegeName"].ToString() %>
                                        </option>
                                        <% } %>
                                    </select>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">专业</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorPro" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorEmail" type="text" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control teaAddinput editorPhone" type="text" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <span class="stuCollegeId"></span>
                    <span class="stuProId"></span>
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="saveChange">提交更改</button>
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
<script src="../js/jquery.validate.min.js"></script>
<script>
    //编辑框获取学生数据
    $(document).ready(function(){
        $(".Editor").click(function(){
            var stuNO = $(this).parent().parent().find(".stuNO").text().trim(),
                stuName = $(this).parent().parent().find(".stuName").text().trim(),
                stuSex = $(this).parent().parent().find(".stuSex").text().trim(),
                stuPro = $(this).parent().parent().find(".stuPro").text().trim(),
                stuProId = $(this).parent().parent().children("td").get(4).id,//专业Id
                stuCollege = $(this).parent().parent().find(".stuCollege").text().trim(),
                stuColId = $(this).parent().parent().children("td").get(5).id;//学院ID
                stuPhone = $(this).parent().parent().find(".stuPhone").text().trim(),
                stuEmail = $(this).parent().parent().find(".stuEmail").text().trim();
            $(".editorStuNO").val(stuNO);
            $(".editorStuName").val(stuName);
            $(".editorStuSex").val(stuSex);
            $(".editorCollege").val(stuCollege);
            $(".editorPro").val(stuPro);
            $(".editorEmail").val(stuEmail);
            $(".editorPhone").val(stuPhone);
            $(".stuCollegeId").text(stuColId);
            $(".stuProId").text(stuProId);
        });
        $(".stuCollegeId").hide();
        $(".stuProId").hide();
        $("#saveChange").click(function(){
            var stuNO = $(".editorStuNO").val(),
                stuName = $(".editorStuName").val(),
                stuSex = $(".editorStuSex").val(),
                stuCollege = $(".stuCollegeId").text(),
                stuPro = $(".stuProId").text(),
                stuEmail = $(".editorEmail").val(),
                stuPhone = $(".editorPhone").val();
            //alert(stuNO+stuPro+stuEmail);
            alert("ajax");
            $.ajax({
                type:'Post',
                url:'stuLIst.aspx',
                data:{
                    stuNO:stuNO,
                    stuName:stuName,
                    stuSex:stuSex,
                    stuCollege:stuCollege,
                    stuPro:stuPro,
                    stuEmail:stuEmail,
                    stuPhone:stuPhone,
                    editorOp:"editor"
                },
                dataType:'text',
                success:function(succ){
                    alert(succ);
                    jump(1);
                }
            })
        })
    })
    //分页及查询
    sessionStorage.setItem("page", <%=getCurrentPage %>);
    sessionStorage.setItem("countPage",<%=count %>);
    $(document).ready(function () {
        //分页
        $(".jump").click(function () {
            switch ($.trim($(this).html())) {
                case ('<span class="iconfont icon-back"></span>'):
                    if (parseInt(sessionStorage.getItem("page")) > 1) {
                        jump(parseInt(sessionStorage.getItem("page")) - 1);
                        //sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                        break;
                    }
                    else {
                        jump(1);
                        break;
                    }
                case ('<span class="iconfont icon-more"></span>"></span>'):
                    if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                        jump(parseInt(sessionStorage.getItem("page")) + 1);
                        //sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                        break;
                    }
                    else {
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case ("首页"):
                    jump(1);
                    break;
                case (sessionStorage.getItem("countPage")):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                case ("尾页"):
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
            }
        });
        //查询
        $("#search").click(function () {
            var strWhere = $("#inputsearch").val();
            sessionStorage.setItem("strWhere",strWhere);
            jump(1);
        });
        //地址栏显示信息
        function jump(cur) {
            if (sessionStorage.getItem("strWhere") == null) {
                window.location.href = "stuLIst.aspx?currentPage=" + cur
            }
            else {
                window.location.href = "stuLIst.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
            }          
        }
        //添加学生
        $("#saveSutdent").click(function(){
            var stuAccount = $("#stuAccount").val(),
                pwd = $("#pwd").val(),
                realName = $("#realName").val(),
                sex = $("#sex").find("option:selected").val(),
                pro = $("#pro").find("option:selected").val(),
                phone = $("#phone").val(),
                email = $("#email").val();
            if(stuAccount==""||pwd==""||realName==""||sex==""||pro==""||phone==""||email==""){
                alert("不能出现未填项！");
            }
            else{
                alert("ajax");
                $.ajax({
                    type:'Post',
                    url:'stuLIst.aspx',
                    data:{
                        stuAccount:stuAccount,
                        pwd:pwd,
                        realName:realName,
                        sex:sex,
                        pro:pro,
                        phone:phone,
                        email:email,
                        op:"add"
                    },
                    dateType:'text',
                    success:function(succ){
                        alert(succ);
                        jump(1);
                    }
                })
            }
        })
    })
</script>
</html>

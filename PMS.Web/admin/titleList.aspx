<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="titleList.aspx.cs" Inherits="PMS.Web.admin.titleList" %>

<%=" " %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>题目信息表</title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
</head>
<body>
    <div class="container-fluid big-box">
        <div class="panel panel-default" id="propanelbox">
            <div class="pane input-group" id="panel-head">
                <div class="input-group" id="inputgroups">
                    <select class="selectpicker selectdrop" data-width="auto" id="chooseStuPro">
                        <option value="0">-显示所有专业-</option>
                        <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                            {
                                if(prods.Tables[0].Rows[i]["proId"].ToString() == dropstrWherepro)
                                {%>
                                     <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected">
                                         <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                                     </option>
                                <% }
                                else
                                {%>
                                    <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>">
                                        <%=prods.Tables[0].Rows[i]["proName"].ToString() %>
                                    </option>
                                <%}%>
                        <%} %>
                    </select>
                    &nbsp
                    <select class="selectpicker selectdrop" data-width="auto" id="choosePlan">
                        <option value="0">--显示所有批次--</option>
                        <%for (int i = 0; i < plads.Tables[0].Rows.Count; i++)
                            {
                                if (plads.Tables[0].Rows[i]["planId"].ToString() == dropstrWhereplan)
                                {%>
                                    <option value="<%=plads.Tables[0].Rows[i]["planId"].ToString() %>" selected="selected">
                                        <%=plads.Tables[0].Rows[i]["planName"].ToString() %>
                                    </option>
                                 <%}
                                else
                                { %>
                                    <option value="<%=plads.Tables[0].Rows[i]["planId"].ToString() %>">
                                        <%=plads.Tables[0].Rows[i]["planName"].ToString() %>
                                    </option>
                                <%} %>
                        <%} %>
                    </select>
                    <%if (showinput == null) {
                            showinput = "请输入搜索条件";
                        } %>
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
        <div class="">
            <table class="table table-bordered table-hover">
                <thead>
                    <th class="text-center">
                        <input type="checkbox" class="js-checkbox-all" />
                    </th>
                    <th class="text-center">标题编号</th>
                    <th class="text-center">标题</th>
                    <th class="text-center">批次</th>
                    <th class="text-center">专业</th>
                    <th class="text-center">发布人</th>
                    <th class="text-center">已选人数/人数上限</th>
                    <th class="text-center">创建时间</th>
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
                            <input type="hidden" value="<%=ds.Tables[0].Rows[i]["titleContent"].ToString() %>" id="titleContent" />
                            <input type="hidden" value="<%=ds.Tables[0].Rows[i]["selected"].ToString() %>" id="selected" />
                        </td>
                        <td class="text-center" id="titleId">
                            <%=ds.Tables[0].Rows[i]["titleId"].ToString() %>
                        </td>
                        <td class="text-center" id="title">
                            <%=ds.Tables[0].Rows[i]["title"].ToString() %>
                        </td>
                        <td class="text-center" id="plaName">
                            <%=ds.Tables[0].Rows[i]["planName"].ToString() %>
                        </td>
                        <td class="text-center" id="proName">
                            <%=ds.Tables[0].Rows[i]["proName"].ToString() %>
                        </td>
                        <td class="text-center" id="teaName">
                            <%=ds.Tables[0].Rows[i]["teaName"].ToString() %>
                        </td>
                        <td class="text-center" id="titleNumber">
                            <span><%=ds.Tables[0].Rows[i]["selected"].ToString() %></span>
                            /<span id="limit"><%=ds.Tables[0].Rows[i]["limit"].ToString()%></span>
                        </td>
                        <td class="text-center" id="createTime">
                            <%=ds.Tables[0].Rows[i]["createTime"].ToString() %>
                        </td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning btnEdit" data-toggle="modal" data-target="#myModa2">
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
                        <a href="#" class="jump">第<%=getCurrentPage %>页
                        </a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <% if (count == 0) { count = 1; } %>
                        <a href="#" class="jump">共<%=count %>页
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
                <form id="form1" runat="server" method="post" enctype="multipart/form-data" action="branchList.aspx?op=upload">
                    <div class="modal-body">
                        <table class="table">
                            <tbody>
                                <tr>
                                    <td class="text-center">
                                        <div>
                                            <a href="javascript:;" class="file">选择文件
                                                <input type="file" name="upload" id="upload" />
                                                <label class="showFileName"></label>
                                                <label class="fileerrorTip"></label>
                                            </a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="text-center" id="download" >
                                        <a href="~/upload/信息模板下载/学院信息表.xls" download="学院信息表.xls"><button type="button" class="btn btn-primary">下载模板</button></a>
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
    <!-- 编辑信息弹框（Modal） -->
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModal2">题目信息修改
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table">
                        <tbody>
                            <tr>
                                <td class="titleId text-right">
                                    <label class="text-span">题目编号:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTitleId" />
                                    <span id="titleIdValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="title text-right">
                                    <label class="text-span">题目:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTitle" />
                                    <span id="titleValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="plan text-right">
                                    <label class="text-span">批次:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediPlan" />
                                    <span id="planValidate"></span>
                                </td>
                            </tr>
                            <tr id="prof">
                                <td class="teaLable text-right">
                                    <label class="text-span">专业:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediProf" />
                                    <span id="profValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaName text-right">
                                    <label class="text-span">发布人:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediTeaName" />
                                    <span id="teaNameValidate"></span>
                                </td>
                            </tr>
                            <tr>
                                <td class="limit text-right">
                                    <label class="text-span">人数上限:</label>
                                </td>
                                <td>
                                    <input class="form-control" type="text" id="ediLimit" />
                                    <span id="limitValidate"></span>
                                </td>
                            </tr>

                            <tr>
                                <td class="createTime text-right">
                                    <label class="text-span">创建时间:</label>
                                </td>
                                <td>
                                    <input class="form-control chemail" type="text" id="ediCreateTime" />
                                    <span id="createTimeValidate"></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default chID" data-dismiss="modal" id="btnClose">关闭</button>
                    <button type="button" class="btn btn-primary" id="btnSave">保存更改</button>
                </div>
            </div>
        </div>
    </div>
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />

    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>
    <script src="../js/bootstrap-select.js"></script>
    <script src="../js/ml.js"></script>
    <script src="../js/xcConfirm.js"></script>
    <script>
        //存储当前页数
        var page = $("#page").val();
        sessionStorage.setItem("Page", page);
        //存储总页数
        var countPage = $("#countPage").val();
        sessionStorage.setItem("countPage", countPage);       

        //专业下拉框查询
        $("#chooseStuPro").change(function () {
            sessionStorage.removeItem("strWhere");
            //获取用户选中的专业下拉框的Id值
            var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();   
            if (dropstrWherepro != "0") {
                //把值存储到sessionStorage中并传到后台
                sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                //获取用户选中批次的id值
                var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
                //判断批次下拉框有没有值
                if (dropstrWhereplan != "0") {
                    //存储批次下拉框的条件           
                    sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "alldrop");
                    jump(1);
                }
                else {
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "prodrop");
                    jump(1);
                }            
            }  
            else {
                sessionStorage.removeItem("dropstrWherepro");
                var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
                //判断批次下拉框有没有值
                if (dropstrWhereplan != "0") {
                    //存储批次下拉框的条件           
                    sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "plandrop");
                    jump(1);
                }
                else {
                    sessionStorage.removeItem("dropstrWhereplan");
                    sessionStorage.removeItem("type");
                    jump(1);
                }            
            }            
        });

        //批次下拉框查询
        $("#choosePlan").change(function () {      
            sessionStorage.removeItem("strWhere");
            //存储批次下拉框的条件
            var dropstrWhereplan = $("#choosePlan").find("option:selected").val();
            if (dropstrWhereplan != "0") {
                sessionStorage.setItem("dropstrWhereplan", dropstrWhereplan);
                var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();          
                //判断专业是否被选中
                if (dropstrWherepro != "0") {
                    //存储专业下拉框的条件
                    sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "alldrop");
                    jump(1);
                }
                else {
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "plandrop");
                    jump(1);
                }
            }
            else {
                sessionStorage.removeItem("dropstrWhereplan");
                var dropstrWherepro = $("#chooseStuPro").find("option:selected").val();          
                //判断专业是否被选中
                if (dropstrWherepro != "0") {
                    //存储专业下拉框的条件
                    sessionStorage.setItem("dropstrWherepro", dropstrWherepro);
                    sessionStorage.removeItem("type");
                    sessionStorage.setItem("type", "prodrop");
                    jump(1);
                }
                else {
                    sessionStorage.removeItem("dropstrWherepro");
                    sessionStorage.removeItem("type");
                    jump(1);
                }
            }            
        });

        function jump(cur) {

            if (sessionStorage.getItem("strWhere") == null && sessionStorage.getItem("dropstrWherepro") == null && sessionStorage.getItem("dropstrWhereplan") == null) {
                window.location.href = "titleList.aspx?currentPage=" + cur;
            }
            if (sessionStorage.getItem("strWhere") != null) {
                window.location.href = "titleList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere") + "&type=" + sessionStorage.getItem("type");
            }
            if (sessionStorage.getItem("dropstrWhereplan") != null && sessionStorage.getItem("dropstrWherepro") == null) {
                window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
            }
            if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") == null) {
                window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro") + "&type=" + sessionStorage.getItem("type");
            }
            if (sessionStorage.getItem("dropstrWherepro") != null && sessionStorage.getItem("dropstrWhereplan") != null) {
                window.location.href = "titleList.aspx?currentPage=" + cur + "&dropstrWherepro=" + sessionStorage.getItem("dropstrWherepro")+ "&dropstrWhereplan=" + sessionStorage.getItem("dropstrWhereplan") + "&type=" + sessionStorage.getItem("type");
            }
        };        

        //查询按钮点击事件
        $("#btn-search").click(function () {
            var strWhere = $("#inputsearch").val();
            sessionStorage.setItem("strWhere", strWhere);
            sessionStorage.setItem("type", "textSelect");
            sessionStorage.removeItem("dropstrWhereplan");
            sessionStorage.removeItem("dropstrWherepro")
            jump(1);
        });

        $(document).ready(function () {
            //分页参数传递
            $(".jump").click(function () {
                switch ($.trim($(this).html())) {
                    case ('<span class="iconfont icon-back"></span>'):
                        if (parseInt(sessionStorage.getItem("Page")) > 1) {                            
                            sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                            sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                            jump(parseInt(sessionStorage.getItem("Page")) - 1);
                            break;
                        }
                        else {
                            sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                            sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                            jump(1);
                            break;
                        }

                    case ('<span class="iconfont icon-more"></span>'):
                        if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                            sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                            sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                            jump(parseInt(sessionStorage.getItem("Page")) + 1);
                            break;
                        }
                        else {
                            sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                            sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                            jump(parseInt(sessionStorage.getItem("countPage")));
                            break;
                        }
                    case ("首页"):
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(1);
                        break;
                    case ("尾页"):
                        sessionStorage.setItem("dropstrWhereplan", $("#choosePlan").find("option:selected").val());
                        sessionStorage.setItem("dropstrWherepro", $("#chooseStuPro").find("option:selected").val());
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                }
            });

            //自动隐藏导航栏首页尾页
            if (sessionStorage.getItem("countPage") == "1") {
                $("#first").hide();
                $("#last").hide();
            }

            //添加标题
            $("#btn-Add").click(function () {
                window.location.href = "addPaper.aspx";
            });

            //点击编辑按钮，编辑弹框绑定数据
            $(".btnEdit").click(function () {
                var ediTitleId = $(this).parent().parent().find("#titleId").text().trim();
                $("#ediTitleId").val(ediTitleId);
                var ediTitle = $(this).parent().parent().find("#title").text().trim();
                $("#ediTitle").val(ediTitle);
                var ediPlan = $(this).parent().parent().find("#plaName").text().trim();
                $("#ediPlan").val(ediPlan);
                var ediProf = $(this).parent().parent().find("#proName").text().trim();
                $("#ediProf").val(ediProf);
                var ediTeaName = $(this).parent().parent().find("#teaName").text().trim();
                $("#ediTeaName").val(ediTeaName);
                var ediLimit = $(this).parent().parent().find("#limit").text().trim();
                $("#ediLimit").val(ediLimit);
                var ediCreateTime = $(this).parent().parent().find("#createTime").text().trim();
                $("#ediCreateTime").val(ediCreateTime);
            });

            //点击关闭按钮，清除验证提示信息
            $("#btnClose").click(function () {
                $("#titleIdValidate").html("");
                $("#titleValidate").html("");
                $("#planValidate").html("");
                $("#profValidate").html("");
                $("#teaNameValidate").html("");
                $("#limitValidate").html("");
                $("#createTimeValidate").html("");
            });
            //验证是否提交更改
            $("#btnSave").click(function () {
                var saveTitleId = $("#ediTitleId").val(),
                    saveTitle = $("#ediTitle").val(),
                    savePlan = $("#ediPlan").val(),
                    saveProf = $("#ediProf").val(),
                    saveTeaName = $("#ediTeaName").val(),
                    saveLimit = $("#ediLimit").val(),
                    saveCreateTime = $("#ediCreateTime").val(),
                    saveContent = $("#titleContent").val(),
                    saveSelected = $("#selected").val();

                //验证用户输入不能为空
                if (saveTitleId == "") {
                    $("#titleIdValidate").html("题目编号不能为空！").css("color", "red");
                }
                else if (saveTitle == "") {
                    $("#titleValidate").html("题目不能为空，请重新输入！").css("color", "red");
                }
                else if (savePlan == "") {
                    $("#planValidate").html("批次不能为空，请重新输入！").css("color", "red");
                }
                else if (saveProf == "") {
                    $("#profValidate").html("学院不能为空，请重新输入！").css("color", "red");
                }
                else if (saveTeaName == "") {
                    $("#teaNameValidate").html("发布人不能为空，请重新输入！").css("color", "red");
                }
                else if (saveLimit == "") {
                    $("#limitValidate").html("人数上限不能为空，请重新输入！").css("color", "red");
                }
                else if (saveCreateTime == "") {
                    $("#createTimeValidate").html("创建时间不能为空，请重新输入！").css("color", "red");
                }
                else {
                    $.ajax({
                        type: 'Post',
                        url: 'titleList.aspx',
                        data: {
                            saveTitleId: saveTitleId,
                            saveTitle: saveTitle,
                            savePlan: savePlan,
                            saveProf: saveProf,
                            saveTeaName: saveTeaName,
                            saveLimit: saveLimit,
                            saveCreateTime: saveCreateTime,
                            saveContent: saveContent,
                            saveSelected: saveSelected,
                            op: "edit"
                        },
                        dataType: 'text',
                        success: function (succ) {
                            if (succ == "更新成功") {
                                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                    onOk: function (v) {
                                        jump(1);
                                        alert("更新成功");
                                    }
                                });
                            } else {
                                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                                    onOk: function (v) {
                                        jump(1);
                                    }
                                });
                            }
                        }
                    });
                }
            });

            //表单不能被用户编辑
            $("#ediTitleId").attr("disabled", "disabled");
            $("#ediPlan").attr("disabled", "disabled");
            $("#ediProf").attr("disabled", "disabled");
            $("#ediCreateTime").attr("disabled", "disabled");

            //删除标题信息
            $(".btnDel").click(function () {
                var deleteTitleId = $(this).parent().parent().find("#titleId").text().trim();
                alert(deleteTitleId);
                //var result = confirm("您确定删除吗？如果该条记录没有关联其他表，将会直接删除！");
                //if (result == true) {
                //    $.ajax({
                //        type: 'Post',
                //        url: 'titleList.aspx',
                //        data: {
                //            deleteTitleId: deleteTitleId,
                //            op: "del"
                //        },
                //        dataType: 'text',
                //        success: function (succ) {
                //            alert(succ);
                //            jump(parseInt(sessionStorage.getItem("Page")));
                //        }
                //    })
                //}
                //Confirm弹窗
                var txt = "确定要删除吗？";
                var option = {
                    title: "删除警告",
                    btn: parseInt("0011", 2),
                    onOk: function () {
                        $.ajax({
                            type: 'Post',
                            url: 'titleList.aspx',
                            data: {
                                deleteTitleId: deleteTitleId,
                                op: "del"
                            },
                            dataType: 'text',
                            success: function (succ) {
                                if (succ == "删除成功") {
                                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                        onOk: function (v) {
                                            jump(parseInt(sessionStorage.getItem("Page")));
                                        }
                                    });
                                } else {
                                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                                        onOk: function (v) {
                                            jump(parseInt(sessionStorage.getItem("Page")));
                                        }
                                    });
                                }
                            }
                        });
                    }
                }
                window.wxc.xcConfirm(txt, "warning", option);
            })
        });
    </script>
</body>
</html>

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
                    <th class="text-center">教师类型</th>
                    <th class="text-center">联系电话</th>
                    <th class="text-center">邮箱</th>
                    <th class="text-center">操作</th>
                </thead>
                <tbody>
                    <%
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                    %>
                    <tr>
                        <td class="text-center">
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
                        <td class="text-center" id="tdteatype">
                            <%=ds.Tables[0].Rows[i]["teaType"].ToString() %>
                        </td>
                        <td class="text-center" id="tdteaTel">
                            <%=ds.Tables[0].Rows[i]["phone"].ToString() %>
                        </td>
                        <td class="text-center" id="tdteaEmail">
                            <%=ds.Tables[0].Rows[i]["Email"].ToString() %>
                        </td>
                        <td class="text-center">
                            <button class="btn btn-default btn-sm btn-warning changebtn" data-toggle="modal" data-target="#myModa2">
                                <span class="glyphicon glyphicon-pencil"></span>
                            </button>
                            <button class="btn btn-default btn-sm btn-danger isdelete">
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
                            <span class="glyphicon glyphicon-chevron-left"></span>
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
                            <span class="glyphicon glyphicon-chevron-right"></span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="jump" id="last">尾页</a>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- 添加教师弹框（Modal） -->
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
                                <td class="teaLable">
                                    <label class="text-span">所属院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="selectcol">
                                        <option value="">-请选择院系-</option>
                                        <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%} %>
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
    <!-- 编辑教师弹框（Modal） -->
    <div class="modal fade" id="myModa2" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;
                    </button>
                    <h4 class="modal-title" id="myModal2">添加教师
                    </h4>
                </div>
                <div class="modal-body">
                    <table class="table table-hover">
                        <tbody>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">所属院系</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="chselectcol">
                                        <option value="">-请选择院系-</option>
                                        <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                            { %>
                                        <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%} %>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">类型</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="chteaType">
                                        <option value="1">教师</option>
                                        <option value="2">管理员</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">工号</label></td>
                                <td>
                                    <input class="form-control" type="text" id="chteaAccount" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">密码</label></td>
                                <td>
                                    <input class="form-control" type="password" id="chpwd" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">姓名</label></td>
                                <td>
                                    <input class="form-control" type="text" id="chteaName" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">性别</label></td>
                                <td>
                                    <select class="selectpicker" data-width="auto" id="chsex">
                                        <option value="">男</option>
                                        <option value="">女</option>
                                    </select>
                                </td>
                            </tr>

                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">邮箱</label></td>
                                <td>
                                    <input class="form-control" type="text" id="chemail" /></td>
                            </tr>
                            <tr>
                                <td class="teaLable">
                                    <label class="text-span">联系电话</label></td>
                                <td>
                                    <input class="form-control" type="text" id="chtel" /></td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" id="chbtn">保存更改</button>
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
    //当前页数
    sessionStorage.setItem("Page",<%=getCurrentPage%>);
    //总页
    sessionStorage.setItem("countPage",<%=count%>);
    $(document).ready(function () {
        $(".jump").click(function(){
            switch($.trim($(this).html())){
                case('<span class="glyphicon glyphicon-chevron-left"></span>'):
                    if(parseInt(sessionStorage.getItem("Page"))>1){
                        jump(parseInt(sessionStorage.getItem("Page"))-1);
                        break;
                    }
                    else{
                        jump(1);
                        break;
                    }
                    
                case('<span class="glyphicon glyphicon-chevron-right"></span>'):
                    if(parseInt(sessionStorage.getItem("Page"))<parseInt(sessionStorage.getItem("countPage"))){
                        jump(parseInt(sessionStorage.getItem("Page"))+1);
                        break;
                    }
                    else{
                        jump(parseInt(sessionStorage.getItem("countPage")));
                        break;
                    }
                case("首页"):
                    jump(1);
                    break;
                case("尾页"):
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
                window.location.href = "teaList.aspx?currentPage=" + cur;
            }else{
                window.location.href ="teaList.aspx?currentPage="+cur+"&search="+sessionStorage.getItem("strWhere");
            }
        };
        if (sessionStorage.getItem("countPage") == "1") {
            $("#first").hide();
            $("#last").hide();
        }
        $("#btnAdd").click(function(){
            var collegeId=$("#selectcol").find("option:selected").val(),
                teaType=$("#teaType").find("option:selected").val(),
                teaAccount=$("#teaAccount").val(),
                pwd=$("#pwd").val(),
                teaName=$("#teaName").val(),
                sex=$("#sex").find("option:selected").text(),
                email=$("#email").val(),
                tel=$("#tel").val();
            if(collegeId==""){
                alert("不能为空")
            }
            else{
                alert("ajax");
                $.ajax({
                    type:'Post',
                    url:'teaList.aspx',
                    data:{
                        CollegeId:collegeId,
                        TeaType:teaType,
                        TeaAccount:teaAccount,
                        Pwd:pwd,
                        TeaName:teaName,
                        Sex:sex,
                        Email:email,
                        Tel:tel,
                        op:"add"
                    },
                    dataType:'text',
                    success:function(succ){
                        alert(succ);
                        jump(1);
                    }
                });
            }
        })
        $(".changebtn").click(function (){
            $("#chteaAccount").val( $(this).parent().parent().find("#tdteaAccount").text().trim());
            $("#chpwd").val("");
            $("#chteaName").val($(this).parent().parent().find("#tdteaName").text().trim());
            $("#chemail").val($(this).parent().parent().find("#tdteaEmail").text().trim());
            $("#chtel").val($(this).parent().parent().find("#tdteaTel").text().trim())
            
            //$(this).parent().parent().find("#sex").text();
            //$(this).parent().parent().find("#collegeName").text();
            //$(this).parent().parent().find("#teaType").text();
            $("#chbtn").click(function(){
                
                var teaAccount= $("#chteaAccount").val(),
                    teaName= $("#chteaAccount").val(),
                    teaEmail= $("#chteaAccount").val(),
                    teaPhone= $("#chteaAccount").val(),
                    pwd=$("#chpwd").val(),
                    collegeId=$("#chselectcol").find("option:selected").val(),
                    sex=$("#chsex").find("option:selected").text(),
                    teaType=$("#chteaType").find("option:selected").val();
                   
                if(teaAccount ==""){
                    alert("不能为空");
                }
                else{
                    alert("ajax");
                    $.ajax({
                        type:'Post',
                        url:'teaList.aspx',
                        data:{
                            TeaAccount:teaAccount,
                            TeaName:teaName,
                            TeaEmail:teaEmail,
                            TeaPhone:teaPhone,
                            Pwd:pwd,
                            CollegeId:collegeId,
                            Sex:sex,
                            TeaType:teaType,
                            op:"change"
                        },
                        dataType:'text',
                        success:function(succ){
                            alert(succ);
                            jump(1);
                        }
                    });
                }
            })
        });
        $(".isdelete").click(function(){
        
        });

    });
</script>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reg.aspx.cs" Inherits="PMS.Web.reg" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>学生注册</title>
    <link rel="stylesheet" type="text/css" href="css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="css/zwh.css" />
    <link rel="stylesheet" type="text/css" href="css/xcConfirm.css" />
</head>

<body id="regBody">
    <div class="container col-xs-8 col-sm-8 col-md-6 col-lg-4 col-xs-push-2 col-sm-push-2 col-md-push-3 col-lg-push-4" id="bigbox">
        <div class="container-fluid" id="regmain">
            <div class="container-style">
                <form class="form-horizontal" role="form" id="regform" method="post" action="login.aspx">

                    <table class="table table-hover">
                        <thead>
                            <h1 class="col-xs-10 col-sm-10 col-md-6 col-lg-6 col-xs-push-4 col-sm-push-4 col-md-push-4 col-lg-push-4">账号注册</h1>
                        </thead>
                        <tbody>
                            <tr>
                                <td id="regLable">
                                    <label for="" class="control-label">学院:</label>
                                </td>
                                <td>
                                    <select class="form-control input-sm select-drop" id="college">
                                        <option value="">--请选择学院--</option>
                                        <%for (int i = 0; i < dsColl.Tables[0].Rows.Count; i++)
                                            {
                                                if (collid == dsColl.Tables[0].Rows[i]["collegeId"].ToString())
                                                {%>
                                        <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>" selected="selected"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%}
                                        else
                                        { %>
                                        <option value="<%=dsColl.Tables[0].Rows[i]["collegeId"].ToString() %>"><%=dsColl.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                                        <%}
                                        } %>
                                    </select>
                                    <span id="validateColl"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">专业:</label>
                                </td>
                                <td>
                                    <select class="form-control input-sm select-drop" id="profession">
                                        <option value="">--请选择专业--</option>
                                        <%
                                            if (dsPro != null)
                                            {
                                                for (int i = 0; i < dsPro.Tables[0].Rows.Count; i++)
                                                { %>
                                        <option value="<%=dsPro.Tables[0].Rows[i]["proId"].ToString() %>"><%=dsPro.Tables[0].Rows[i]["proName"].ToString() %></option>
                                        <% }
                                            } %>
                                    </select>
                                    <span id="validatePro"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">账号:</label>
                                </td>
                                <td>
                                    <input type="text" class="form-control input-sm input" id="account" name="usercount" placeholder="账号" />
                                    <span id="validateAccount"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">姓名:</label>
                                </td>
                                <td>
                                    <input type="text" class="form-control input-sm input" id="name" name="username" placeholder="请输入姓名" />
                                    <span id="validateName"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">性别:</label>
                                </td>
                                <td>
                                    <label>
                                        <input type="radio" name="sex" value="男" checked="checked" />
                                        男
                                    </label>
                                    <label>
                                        <input type="radio" name="sex" value="女" checked="checked" />
                                        女
                                    </label>
                                    <span id="validateSex"></span>
                                </td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">密码:</label>
                                </td>
                                <td>
                                    <input type="password" class="form-control input-sm input" id="regPwd" name="regPwd" placeholder="请输入密码" />
                                    <span id="validatePwd"></span></td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">确认密码:</label></td>
                                <td>
                                    <input type="password" class="form-control input-sm input" id="confirmPwd" name="confirmPwd" placeholder="请再次输入密码" />
                                    <span id="validateConfirmPwd"></span></td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">邮箱:</label></td>
                                <td>
                                    <input type="text" class="form-control input-sm input" id="email" name="userEmail" placeholder="请输入邮箱" />
                                    <span id="validateEmail"></span></td>
                            </tr>
                            <tr>
                                <td id="regLable">
                                    <label class="control-label">电话:</label></td>
                                <td>
                                    <input type="text" class="form-control input-sm input" id="telNum" name="usertel" placeholder="请输入电话号码" />
                                    <span id="validateTelNum"></span></td>
                            </tr>
                            <!--<tr>
                                <td id="regLable">
                                    <label class="control-label">验证码:</label></td>
                                <td>
                                    <input type="text" class="input-sm" id="regCode" name="telverify" placeholder="请输入验证码" />
                                    <button class="btn-primary btn-sm" type="button" id="getCode">获取验证码</button>
                                    <span id="validateCode"></span></td>
                            </tr>-->
                        </tbody>
                    </table>
                    <div class="form-group">
                        <div class="col-sm-offset-2">
                            <button type="button" class="btn btn-info col-xs-9 col-sm-9 col-md-10 col-lg-10 col-xs-push-2 col-sm-push-1 col-md-push-1" id="btnAdd" onclick="cmdEncrypt();">立即注册</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/additional-methods.js"></script>
<script src="js/messages_zh.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="js/reg.js"></script>
<script src="js/jsencrypt.min.js"></script>
</html>

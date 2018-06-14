<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePwd.aspx.cs" Inherits="PMS.Web.admin.changePwd" %>
    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title></title>
        <link rel="stylesheet" href="../css/bootstrap.min.css">
        <link rel="stylesheet" href="../css/lgd.css">

    </head>

    <body>
        <div class="container-fluid">
            <div class="container">
                <h1 class="text-center">密码修改
                </h1>
            </div>
            <div class="container-fluid changepwdmain">
                <form action="" class="cmxform" id="changePwdForm" method="POST">
                    <table class="table changePwdtable">
                        <tbody>
                            <tr>
                                <td>
                                    <div class="container-fluid text-right changnum ">
                                        <label class="col-xm-2 control-label">当前账户:</label>
                                    </div>
                                </td>
                                <td>
                                    <div class="container-fluid col-xm-8 col-sm-5 col-md-5 col-lg-5 ">
                                        <input type="text" class="form-control input-sm" placeholder="用户账户" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="container-fluid  text-right changnum">
                                        <label class="col-xm-2 control-label">当前密码:</label>
                                    </div>
                                </td>
                                <td>
                                    <div class="container-fluid col-xm-8 col-sm-6 col-md-5 col-lg-5 ">
                                        <input type="password" id="oldpwd" name="oldpwd" class="form-control input-sm" placeholder="请入当前密码">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="container-fluid text-right changnum ">
                                        <label class="col-xm-2 control-label">输入新密码:</label>
                                    </div>
                                </td>
                                <td>
                                    <div class="container-fluid col-xm-8 col-sm-5 col-md-5 col-lg-5 ">
                                        <input type="password " id="newpwd" name="newpwd " class="form-control input-sm " placeholder="新密码不能和当前密码相同 ">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="container-fluid text-right changnum ">
                                        <label class="col-xm-2 control-label ">确认新密码:</label>
                                    </div>
                                </td>
                                <td>
                                    <div class="container-fluid col-xm-8 col-sm-6 col-md-5 col-lg-5 ">
                                        <input type="password " class="form-control input-sm " placeholder="请再次输入新密码 " id="confirmPwd " name="confirmPwd ">
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                </td>
                                <td>
                                    <div class="container-fluid col-xm-8 col-sm-5 col-md-5 col-lg-5 ">
                                        <button type="button " class="btn btn-primary ">提交</button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <div class="span12 ">
                        <div class="alert alert-info text-center ">
                            <h4>
                                友情提示：
                            </h4>
                            新密码长度为6~16位，至少包含数字、字母、特殊符号中的两类，字母区分大小写。 请妥善保管密码，如遇忘记或者丢失，请及时与系统管理员联系！
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js "></script>
    <script src="../js/bootstrap.min.js "></script>
    <script src="../js/jquery.validate.min.js "></script>
    <script src="../js/messages_zh.min.js "></script>
    <script>
        $().ready(function() {
            $("#changePwdForm ").validate({
                rules: {
                    oldpwd: {

                    },
                    newpwd: {

                    }
                }
            })
        })
    </script>

    </html>
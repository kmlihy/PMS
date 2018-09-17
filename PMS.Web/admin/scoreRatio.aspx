<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="scoreRatio.aspx.cs" Inherits="PMS.Web.admin.scoreRatio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
</head>
<body>
    <div class="panel">
        <div class="panel-head text-center">
            <h2>各阶段分数占比</h2>
        </div>
        <div class="panel-body">
            <div>
                <table class="table table-bordered text-center" style="width: 60%;margin:auto">
                    <thead>
                        <tr>
                            <th class="text-center">指导阶段</th>
                            <th class="text-center">交叉指导阶段</th>
                            <th class="text-center">答辩阶段</th>
                            <th class="text-center">优秀论文成绩下限</th>
                            <th class="text-center">总分</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <input id="guide" type="text" maxlength="1" class="ratioScore" oninput="value = value.replace(/[^\d]/g, '')" /></td>
                            <td>
                                <input id="cross" type="text" maxlength="1" class="ratioScore" oninput="value = value.replace(/[^\d]/g, '')" /></td>
                            <td>
                                <input id="defence" type="text" maxlength="1" class="ratioScore" oninput="value = value.replace(/[^\d]/g, '')" /></td>
                            <td>
                                <input id="excellent" type="text" maxlength="2" class="ratioScore" oninput="value = value.replace(/[^\d]/g, '')" /></td>
                            <td>
                                10</td>
                        </tr>
                    </tbody>
                </table>
                <div id="myAlert" class="alert alert-success text-center" style="width: 60%;margin:auto">
                    <strong>提示！</strong>各科占比总和为10<p>优秀论文成绩下限总分为100
                    </p>
                </div>
            </div>
        </div>
        <div class="container text-center panel-footer panleFooter">
            <button class="btn btn-info col-xs-1" type="button" id="btnSubmit">提交</button>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/xcConfirm.js"></script>
<script src="../js/scoreRatio.js"></script>
</html>

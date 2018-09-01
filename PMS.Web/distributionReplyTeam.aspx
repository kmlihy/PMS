<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distributionReplyTeam.aspx.cs" Inherits="PMS.Web.distributionReplyTeam" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>分配答辩小组</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/ml.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
</head>
<body>
    <div class="panel">
        <div class=" panel-heading">
            <h2>分配答辩小组</h2>
        </div>
        <div class="panel-body">
            <table class="table" style="width: 80%; margin: 0 auto;">
                <thead>
                    <tr>
                        <th>所属批次</th>
                        <th>组长</th>
                        <th>副助长</th>
                        <th>秘书</th>
                        <th>操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="col-sm-3">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1  usertype" multiple="multiple" data-live-search="true" data-max-options="1">
                                <option value="0">云南工商学院2019批次</option>
                                <option value="1">信息工程学院2018批次</option>
                                <option value="2">交通机电学院2018批次</option>
                                <option value="3">建筑工程学院2018批次</option>
                                <option value="4">信息工程学院2017批次</option>
                                <option value="5">信息工程学院2019批次</option>
                                <option value="6">交通机电学院2017批次</option>
                                <option value="7">建筑工程学院2019批次</option>
                                <option value="8">建筑工程学院2017批次</option>
                                <option value="9">国际学院2018批次</option>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" multiple="multiple" data-live-search="true" data-max-options="1">
                                <option value="0">张三</option>
                                <option value="1">李四</option>
                                <option value="2">王五</option>
                                <option value="3">赵六</option>
                                <option value="4">横七</option>
                                <option value="5">竖八</option>
                                <option value="6">小王</option>
                                <option value="7">刘备</option>
                                <option value="8">曹操</option>
                                <option value="9">孙权</option>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" multiple="multiple" data-max-options="1" data-live-search="true">
                                <option value="0">张三</option>
                                <option value="1">李四</option>
                                <option value="2">王五</option>
                                <option value="3">赵六</option>
                                <option value="4">横七</option>
                                <option value="5">竖八</option>
                                <option value="6">小王</option>
                                <option value="7">刘备</option>
                                <option value="8">曹操</option>
                                <option value="9">孙权</option>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" multiple="multiple" data-max-options="1" data-live-search="true">
                                <option value="0">张三</option>
                                <option value="1">李四</option>
                                <option value="2">王五</option>
                                <option value="3">赵六</option>
                                <option value="4">横七</option>
                                <option value="5">竖八</option>
                                <option value="6">小王</option>
                                <option value="7">刘备</option>
                                <option value="8">曹操</option>
                                <option value="9">孙权</option>
                            </select>
                        </td>
                        <td class="">
                            <button type="button" class="btn btn-info">
                                <span class="glyphicon glyphicon-ok"></span>
                                确定人选
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <table class="table table-bordered text-center">
                <thead>
                    <tr>
                        <th colspan="6">
                            <div class="panel panel-default" id="propanelbox">
                                <div class="pane input-group" id="panel-head">
                                    <div class="input-group" id="inputgroups">
                                        <select class="selectpicker selectcollegeId" data-width="auto" id="selectcollegeId">
                                            <option>请选择查询学院 </option>
                                            <option value="0">信息工程学院</option>
                                            <option value="1">交通机电学院</option>
                                            <option value="2">建筑工程学院</option>
                                            <option value="3">会计学院</option>
                                            <option value="4">设计学院</option>
                                        </select>
                                        <select class="selectpicker" data-width="auto" id="chooseStuPro">
                                            <option value="0">请选择查询批次</option>
                                            <option value="0">云南工商学院2019批次</option>
                                            <option value="1">信息工程学院2018批次</option>
                                            <option value="2">交通机电学院2018批次</option>
                                            <option value="3">建筑工程学院2018批次</option>
                                            <option value="4">信息工程学院2017批次</option>
                                            <option value="5">信息工程学院2019批次</option>
                                            <option value="6">交通机电学院2017批次</option>
                                            <option value="7">建筑工程学院2019批次</option>
                                            <option value="8">建筑工程学院2017批次</option>
                                            <option value="9">国际学院2018批次</option>
                                        </select>
                                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" />
                                        <span class="input-group-btn">
                                            <button class="btn btn-info" type="button" id="btn-search">
                                                <span class="glyphicon glyphicon-search" id="search">查询</span>
                                            </button>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </th>
                    </tr>
                    <tr>
                        <th class="text-center">所属学院</th>
                        <th class="text-center">所属批次</th>
                        <th class="text-center">组长</th>
                        <th class="text-center">副组长</th>
                        <th class="text-center">秘书</th>
                        <th class="text-center">操作</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="col-sm-2">d</td>
                        <td class="col-sm-2">d</td>
                        <td class="col-sm-2">d</td>
                        <td class="col-sm-2">d</td>
                        <td class="col-sm-2">d</td>
                        <td class="col-sm-2">
                            <button type="button" class="btn btn-info" onclick="window.location.href='distributionReplyStudent.aspx'">分配答辩学生</button>
                            <button type="button" class="btn btn-info" onclick="window.location.href='myReplyStudent.aspx'">查看答辩学生</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/xcConfirm.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script type="text/javascript">
    $(function () {
        $(".selectpicker").selectpicker({
            noneSelectedText: '请选择',
            countSelectedText: function () { }
        });
    });
    function selectValue() {
        //获取选择的值
        alert($('.usertype').selectpicker('val'));
    }
</script>

</html>

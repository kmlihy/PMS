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
            <% if (state == 2)
                { %>
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
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1  usertype" id="plan" data-live-search="true" data-max-options="1">
                                <option value="">请选择批次</option>
                                <%for (int i = 0; i < getPlan.Tables[0].Rows.Count; i++)
                                    {
                                        if (_planId == getPlan.Tables[0].Rows[i]["planId"].ToString())
                                        {%>
                                <option value="<%=getPlan.Tables[0].Rows[i]["planId"].ToString()%>" selected="selected"><%=getPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%}else{ %>
                                <option value="<%=getPlan.Tables[0].Rows[i]["planId"].ToString()%>"><%=getPlan.Tables[0].Rows[i]["planName"].ToString() %></option>
                                <%}
    } %>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="leader" data-live-search="true" data-max-options="1">
                                <option value="">请选择组长</option>
                                <%for (int i = 0; i < getLeader.Tables[0].Rows.Count; i++)
                                    {
                                        if (leader == getLeader.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getLeader.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getLeader.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    else
                                    { %>
                                <option value="<%=getLeader.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getLeader.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    }%>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="member" data-max-options="1" data-live-search="true">
                                <option value="">请选择副组长</option>
                                <%for (int i = 0; i < getMember.Tables[0].Rows.Count; i++)
                                    {
                                        if (member == getMember.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getMember.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getMember.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                else
                                { %>
                                <option value="<%=getMember.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getMember.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                    } %>
                            </select>
                        </td>
                        <td class="col-sm-2">
                            <select name="usertype" class="selectpicker show-tick form-control col-sm-1 usertype" id="record" data-max-options="1" data-live-search="true">
                                <option value="">请选择秘书</option>
                                <%for (int i = 0; i < getRecord.Tables[0].Rows.Count; i++)
                                    {
                                        if (record == getRecord.Tables[0].Rows[i]["teaAccount"].ToString())
                                        {%>
                                <option value="<%=getRecord.Tables[0].Rows[i]["teaAccount"].ToString()%>" selected="selected"><%=getRecord.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                else
                                { %>
                                <option value="<%=getRecord.Tables[0].Rows[i]["teaAccount"].ToString()%>"><%=getRecord.Tables[0].Rows[i]["teaName"].ToString() %></option>
                                <%}
                                } %>
                            </select>
                        </td>
                        <td class="">
                            <button type="button" class="btn btn-info" id="confirm">
                                <span class="glyphicon glyphicon-ok"></span>
                                确定人选
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%} %>
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
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/distributionReplyTeam.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

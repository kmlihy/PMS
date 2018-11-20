<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distributionReplyStudent.aspx.cs" Inherits="PMS.Web.distributionReplyStudent" %>

<%="" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="square/_all.css" />
    <link rel="stylesheet" href="css/bootstrap-select.css" />
    <link rel="stylesheet" href="css/iconfont.css" />
    <link rel="stylesheet" href="css/xcConfirm.css" />
    <style>
        .check_box {
            width: 50px;
        }

        .Serial_number {
            width: 60px;
        }

        #body {
            height: 500px;
        }

        #btn_backForReplyStu {
            position: absolute;
            margin-top: 20px;
        }

        /*.sure_box{
            margin-top:250px;
        }*/
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>分配答辩学生</h1>
        </div>
        <div class="panel-body" id="body">
            <!--查询区域-->
            <div class="panel panel-default" id="propanelbox">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <%if (userType == "0")
                            {%>
                        <select class="selectpicker" data-width="auto" id="selectcollegeId">
                            <option value="0">请选择查询学院 </option>
                            <%for (int i = 0; i < colds.Tables[0].Rows.Count; i++)
                                {
                                    if (colds.Tables[0].Rows[i]["collegeId"].ToString() == showcollegedrop)
                                    {%>
                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>" selected="selected"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                            <%}%>
                            <%else
                                {%>
                            <option value="<%=colds.Tables[0].Rows[i]["collegeId"].ToString()%>"><%=colds.Tables[0].Rows[i]["collegeName"].ToString() %></option>
                            <%}
                                } %>
                        </select>
                        <%}%>
                        <select class="selectpicker" data-width="auto" id="chooseStuPro">
                            <%if (showstr == "0")
                                {%>
                            <option value="0" selected="selected">-查询全部专业-</option>
                            <%}
                                else
                                {%>
                            <%if (prods == null)
                                {%>
                            <option value="0">-查询全部专业-</option>
                            <%}
                                       else
                                       {
                            %><option value="0">-查询全部专业-</option>
                            <%for (int i = 0; i < prods.Tables[0].Rows.Count; i++)
                                {
                                    if (prods.Tables[0].Rows[i]["proId"].ToString() == showstr)
                                    {%>
                            <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>" selected="selected"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                            <% }
                                else
                                {%>
                            <option value="<%=prods.Tables[0].Rows[i]["proId"].ToString() %>"><%=prods.Tables[0].Rows[i]["proName"].ToString() %></option>
                            <%}
                                        }
                                    }
                                } %>
                        </select>
                        <input type="text" class="form-control" placeholder="请输入查询条件" id="inputsearch" value="<%=showmsg %>" />
                        <span class="input-group-btn">
                            <button class="btn btn-info" type="button" id="btn-search">
                                <span class="glyphicon glyphicon-search" id="search">查询</span>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
            <!--数据展示区-->
            <table class="table table-bordered table-responsive text-center">
                <thead>
                    <tr>
                        <th class="text-center">
                            <input type="checkbox" name="checkboxAll" class="js-checkbox-all" />
                        </th>
                        <th class="text-center Serial_number">序号</th>
                        <th class="text-center">学院</th>
                        <th class="text-center">专业</th>
                        <th class="text-center">学号</th>
                        <th class="text-center">姓名</th>
                    </tr>
                </thead>
                <tbody>
                    <% if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {%>
                    <tr>
                        <td class="text-center check_box">
                            <input type="checkbox" name="checkbox" class="check" value="<%=ds.Tables[0].Rows[i]["stuAccount"].ToString() %>" />
                        </td>
                        <td class="text-center"><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["collegeName"].ToString()%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["proName"].ToString()%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["stuAccount"].ToString()%></td>
                        <td class="text-center"><%=ds.Tables[0].Rows[i]["realName"].ToString()%></td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="panel-footer" id="footer">
            <div class="container-fluid sure_box text-right" id="selectStudent">
                <button class="btn btn-info" id="btnSubmit" style="margin-top: 0px;">确定选择</button>
                <%--<button class="btn btn-info" onclick="window.location.href='myReplyStudent.aspx?titleRecordId=<%=ds.Tables[0].Rows[i]["titleRecordId"].ToString()%>'">查看答辩学生</button>--%>
            </div>
            <%}
                }%>
            <button class="btn btn-info" type="button" id="btn_backForReplyStu" onclick="javascript:history.back(-1);">
                <span class="glyphicon glyphicon-arrow-left"></span>
                返回
            </button>
            <%--分页--%>
            <div class="text-right" id="paging">
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
    <input type="hidden" value="<%=getCurrentPage %>" id="page" />
    <input type="hidden" value="<%=count %>" id="countPage" />
    <input type="hidden" value="<%=userType %>" id="userType" />
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/distributionReplyStudent.js"></script>
<script src="js/icheck.min.js"></script>
<script src="js/bootstrap-select.js"></script>
<script src="js/ml.js"></script>
<script src="js/xcConfirm.js"></script>
</html>

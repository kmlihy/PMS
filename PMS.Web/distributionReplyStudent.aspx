<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="distributionReplyStudent.aspx.cs" Inherits="PMS.Web.distributionReplyStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/lgd.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../square/_all.css" />
    <link rel="stylesheet" href="../css/bootstrap-select.css" />
    <link rel="stylesheet" href="../css/xcConfirm.css" />
    <link rel="stylesheet" href="../css/iconfont.css" />
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

        .sure_box{
            margin-top:250px;
        }
    </style>
</head>
<body>
    <div class="panel">
        <div class="panel-heading text-center">
            <h1>分配答辩学生</h1>
        </div>
        <div class="panel-body" id="body">
            <%--查询框--%>
            <div class="panel panel-default" id="propanelbox">
                <div class="pane input-group" id="panel-head">
                    <div class="input-group" id="inputgroups">
                        <select class="selectpicker" data-width="auto" id="selectcollegeId">
                            <option>请选择查询学院 </option>
                            <option value="0">信息工程学院</option>
                            <option value="1">交通机电学院</option>
                            <option value="2">建筑工程学院</option>
                            <option value="3">会计学院</option>
                            <option value="4">设计学院</option>
                        </select>
                        <select class="selectpicker" data-width="auto" id="chooseStuPro">
                            <option value="0">请选择查询专业</option>
                            <option value="0">软件工程</option>
                            <option value="1">网络技术</option>
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
            <table class="table table-bordered table-responsive text-center">
                <thead>
                    <tr>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all check_box" />
                        </th>
                        <th class="text-center Serial_number">序号</th>
                        <th class="text-center">学院</th>
                        <th class="text-center">专业</th>
                        <th class="text-center">学号</th>
                        <th class="text-center">姓名</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td class="text-center check_box">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center"><%=i + 1 + ((getCurrentPage - 1) * pagesize)%></td>
                        <td class="text-center">信息工程学院2018批次</td>
                        <td class="text-center">移动互联技术</td>
                        <td class="text-center">2231231</td>
                        <td class="text-center">gouride</td>
                    </tr>
                    <tr>
                        <td class="text-center">
                            <input type="checkbox" />
                        </td>
                        <td class="text-center Serial_number"></td>
                        <td class="text-center"></td>
                        <td class="text-center"></td>
                        <td class="text-center"></td>
                        <td class="text-center"></td>
                    </tr>
                </tbody>
            </table>
            <div class="container-fluid sure_box text-right">
                <span>当前选择人数为：</span>
                <input type="text" />
                <button class="btn btn-info">确定选择</button>
                <button class="btn btn-info" onclick="window.location.href='myReplyStudent.aspx'">查看答辩学生</button>
            </div>
        </div>
        <div class="panel-footer" id="footer">
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
                        <a href="#" class="jump">1
                        </a>
                    </li>
                    <li>
                        <a href="#">/</a>
                    </li>
                    <li>
                        <a href="#" class="jump">4
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
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../js/icheck.min.js"></script>
<script src="../js/bootstrap-select.js"></script>
<script src="../js/ml.js"></script>
<script src="../js/xcConfirm.js"></script>
</html>

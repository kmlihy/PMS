<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectTopicList.aspx.cs" Inherits="PMS.Web.admin.selectTopicList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>选题管理列表</title>
    </head>
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/ml.css">
    <link rel="stylesheet" href="../css/style.css">
    <link rel="stylesheet" href="../square/_all.css">

    <body>
        <div class="container-fluid big-box">
            <nav class="navbar navbar-default" role="navigation">
                <div class="container-fluid">
                    <div>
                        <ul class="nav navbar-nav">
                            <li class="active col-sm-4  ">
                                <div class="input-group" style="margin-top: 7px">
                                    <input type="text" class="form-control" placeholder="请输入查询条件">
                                    <span class="input-group-btn">
                                        <button class="btn btn-info" type="button">
                                            <span class="glyphicon glyphicon-search"></span>
                                            查询
                                        </button>
                                    </span>
                                </div>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    所属专业
                                    <b class="caret"></b>
                                </a>
                                <ul class="dropdown-menu">
                                    <li>
                                        <a href="#">XXXX</a>
                                    </li>
                                    <li>
                                        <a href="#">XXXXX</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    所属批次
                                    <b class="caret"></b>
                                </a>
                                <ul class="dropdown-menu">
                                    <li>
                                        <a href="#">XXXX</a>
                                    </li>
                                    <li>
                                        <a href="#">XXXXX</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="active">
                                <button class="btn btn-success" id="btn-Add">
                                    <span class="glyphicon glyphicon-plus-sign"></span>
                                    新增
                                </button>
                            </li>
                            <li class="active">
                                <button class="btn btn-danger" id="btn-Add">
                                    <span class="glyphicon glyphicon-trash"></span>
                                    批量删除
                                </button>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
            <div class="">
                <table class="table table-bordered table-hover">
                    <thead>
                        <th class="text-center">
                            <input type="checkbox" class="js-checkbox-all">
                        </th>
                        <th class="text-center">题目</th>
                        <th class="text-center">出题教师</th>
                        <th class="text-center">选题学生学号</th>
                        <th class="text-center">选题学生姓名</th>
                        <th class="text-center">选题时间</th>
                        <th class="text-center">所属专业</th>
                        <th class="text-center">所属批次</th>
                        <th class="text-center">操作</th>
                    </thead>
                    <tbody>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox">
                            </td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-success">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-warning">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox">
                            </td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-success">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-warning">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                        </tr>
                        <tr>
                            <td class="text-center">
                                <input type="checkbox">
                            </td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center"></td>
                            <td class="text-center">
                                <button class="btn btn-default btn-sm btn-success">
                                    <span class="glyphicon glyphicon-search"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-danger">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                </button>
                                <button class="btn btn-default btn-sm btn-warning">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </button>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div class="container-fluid text-right">
                    <ul class="pagination pagination-lg">
                        <li>
                            <a href="">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                            </a>
                        </li>
                        <li>
                            <a href="">1</a>
                        </li>
                        <li>
                            <a href="">2</a>
                        </li>
                        <li>
                            <a href="">3</a>
                        </li>
                        <li>
                            <a href="">...</a>
                        </li>
                        <li>
                            <a href="">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/icheck.min.js"></script>

    <script>
        var $checkboxAll = $(".js-checkbox-all"),
            $checkbox = $("tbody").find("[type='checkbox']"),
            length = $checkbox.length,
            i = 0;

        //启动icheck
        $(("[type='checkbox']")).iCheck({
            checkboxClass: 'icheckbox_square-orange',
        });

        //全选checkbox
        $checkboxAll.on("ifClicked", function (event) {
            if (event.target.checked) {
                $checkbox.iCheck('uncheck');
                i = 1;
            } else {
                $checkbox.iCheck('check');
                i = length;
            }
        });

        //监听计数
        $checkbox.on('ifClicked', function (event) {
            event.target.checked ? i-- : i++;
            if (i == length + 1) {
                $checkboxAll.iCheck('check');
            } else {
                $checkboxAll.iCheck('uncheck');
            }
        });
    </script>

    </html>
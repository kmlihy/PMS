<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="paperList.aspx.cs" Inherits="PMS.Web.paperList" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>论文列表</title>
        <link rel="stylesheet" href="css/bootstrap.min.css">
        <link rel="stylesheet" href="css/lgd.css">
    </head>

    <body>
        <div class="container-fluid paperlistbox">
            <div class="container">
                <h1 class="col-sm-3  col-sm-offset-5">选题列表
                </h1>
            </div>
            <table class="table table-striped paperlisttable">
                <thead>
                    <tr>
                        <th>
                            论文题目
                        </th>
                        <th>
                            已选人数/人数上限
                        </th>
                        <th>
                            状态
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <a href="http://www.baidu.com">
                                QAQ图书馆管理系统
                            </a>
                        </td>

                        <td>
                            10/20
                        </td>
                        <td>
                            <button class="btn btn-primary" type="button">选题</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            网吧计费管理系统
                        </td>
                        <td>
                            10/20
                        </td>
                        <td>
                            <button class="btn btn-primary" type="button">选题</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            校园二手管理系统
                        </td>
                        <td>
                            9/20
                        </td>
                        <td>
                            <button class="btn btn-primary" type="button">选题</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            课程选题系统
                        </td>
                        <td>
                            10/20
                        </td>
                        <td>
                            <button class="btn btn-primary" type="button">选题</button>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            酒店管理系统
                        </td>
                        <td>
                            10/20
                        </td>
                        <td>
                            <button class="btn btn-primary" type="button">选题</button>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="container text-right paperpagination-div ">
                <ul class="pagination pagination-lg">
                    <li><a href="#">&laquo;</a></li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">4</a></li>
                    <li><a href="#">...</a></li>
                    <li><a href="#">&raquo;</a></li>
                </ul>
            </div>


        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

    </html>
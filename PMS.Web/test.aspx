<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PMS.Web.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <script src="js/jquery-3.3.1.min.js"></script>
</head>
<body>
   <select id="select" name="select" onchange="gradeChange()">
       <option value="1">1</option>
       <option value="2">2</option>
       <option value="3">3</option>
       <option value="4">4</option>
   </select>
    <div>
        <ul class="pagination pagination-lg">
            <li>
                <a href="#" onclick="previousPage()">
                    <span class="glyphicon glyphicon-chevron-left"></span>
                </a>
            </li>
            <li>
                <a href="#">1</a>
            </li>
            <li>
                <a href="#">/</a>
            </li>
            <li>
                <a href="#">10</a>
            </li>
            <li>
                <a href="#" onclick="nextPage()">
                    <span class="glyphicon glyphicon-chevron-right"></span>
                </a>
            </li>
        </ul>
    </div>
</body>
    <script>
        $(document).ready(function () {
            if (window.localStorage) {
                alert("浏览器不支持localstorage");
                return false;
            }
            else {
                alert("OK");
                var storage = window.localStorage;
                storage.clear();
                //存总页数
                sessionStorage.setItem("countPage", 10);
                //storage["countPage"] = 10;
                //存入当前页
                sessionStorage.setItem("currenPage", 1);
                //storage["currentPage"] = 1;
            }
        });
        function previousPage() {
          
            var data = {
                currentPage: sessionStorage.getItem("currentPage"),
                op:1
            }
            if (sessionStorage.getItem("currentPage") != 1) {

                $.ajax({
                    type: "Post",
                    url: "test.aspx",
                    data:data
                });
                var x = parseInt(sessionStorage.getItem("currentPage")) - 1;
                sessionStorage.setItem("currentPage", x);
            }
        }
        function nextPage() {
            var data = {
                currentPage: sessionStorage.getItem("currentPage"),
                op: 2
            }
            if (sessionStorage.getItem("currentPage") != 1) {
                $.ajax({
                    type: "Post",
                    url: "test.aspx",
                    data: data
                });
                var x = parseInt(sessionStorage.getItem("currentPage")) + 1;
                sessionStorage.setItem("currentPage", x);
            }
        }
        function gradeChange() {

            var userName = $("#select").val();
            var storage = window.localStorage;
            var data={
                name: userName,
                currentPage:storage.currentPage
            }
            $.ajax({
                type: "Post",
                url: "test.aspx",
                data:data
            });
         }
    </script>
</html>

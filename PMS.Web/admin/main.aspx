<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="PMS.Web.admin.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>论文管理系统</title>
    <link rel="stylesheet" href="../css/style.css"/>
    <link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/iconfont.css"/>
</head>
<body>
    <div class="box">
        <!-- 页面头部 -->
        <header class="page-top" id="top">
            <nav class="navbar">
                <div class="navbar-inner">
                    <div class="container-fluid">
                        <button class="btn btn-primary navbar-toggle" data-toggle="collapse" data-target="#nav-menu">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>

                        <a class="brand pull-left" href="#">
                            <img src="../images/logo.png" alt="云南工商学院" class="hidden-xs col-sm-7"/>
                            <span class="col-sm-5">论文管理系统</span>
                        </a>
                        <div class="dropdown pull-right">
                            <button class="btn btn-primary dropdown-toggle" id="dropdownMenu1" data-toggle="dropdown">
                                <b>bootstrap</b>
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">
                                        <b class="iconfont icon-smile"></b>
                                        <span>个人中心</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">
                                        <b class="iconfont icon-remind1"></b>
                                        <span>我的消息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">
                                        <b class="iconfont icon-password"></b>
                                        <span>修改密码</span>
                                    </a>
                                </li>
                                <li role="presentation" class="divider"></li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="#">
                                        <i class="glyphicon glyphicon-off"></i>
                                        <span>退出登录</span>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </nav>
        </header>

        <!-- 中间区域 -->
        <div class="moddle" id="moddle">
            <!-- 左侧导航栏 -->
            <aside class="page-left-nav col-xs-12 col-sm-2 col-md-2 col-lg-1 collapse in" id="nav-menu">
                <nav role="navigation" class="row">
                    <ul class="nav nav-list nav-stacked">
                        <li role="presentation">
                            <a href="#">
                                <div></div>
                                <i class="iconfont icon-remind"></i>
                                <span>公告管理</span>
                            </a>
                        </li>
                        <li role="presentation" onclick="rotate()">
                            <a href="#datasetting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-jifen"></i>
                                <span>数据管理</span>
                                <i class="iconfont icon-more" id="trans"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="datasetting">
                                <li role="presentation">
                                    <a href="#">
                                        <span>数据库备份</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#">
                                        <span>文档设置</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li role="presentation">
                            <a href="#">
                                <i class="iconfont icon-set"></i>
                                <span>网站配置</span>
                            </a>
                        </li>
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>分院管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="setting">
                                <li role="presentation">
                                    <a href="#">
                                        <span>分院设置</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="#">
                                        <span>分院管理员设置</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li role="presentation">
                            <a href="#">
                                <i class="iconfont icon-edit"></i>
                                <span>批次管理</span>
                            </a>
                        </li>
                    </ul>
                </nav>

            </aside>

            <!-- 右侧内容区 -->
            <main class="page-right-content col-xs-12 col-sm-10 col-md-10 col-lg-11">
                <article class="">
                    <header class="">
                        <p>这是内容区</p>
                    </header>

                </article>
            </main>
        </div>

        <!-- 页面尾部 -->
        <footer class="page-bottom">
        </footer>
    </div>

    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script>
        autodivheight();

        //获取页面高度
        function autodivheight() {
            //函数：获取尺寸
            //获取浏览器窗口高度
            var winHeight = 0;
            if (window.innerHeight) {
                winHeight = window.innerHeight;
            } else if ((document.body) && (document.body.clientHeight)) {
                winHeight = document.body.clientHeight;
            }
            //通过深入Document内部对body进行检测，获取浏览器窗口高度
            if (document.documentElement && document.documentElement.clientHeight) {
                winHeight = document.documentElement.clientHeight;
            }
            //DIV高度为浏览器窗口的高度
            //document.getElementById("test").style.height= winHeight +"px";
            //DIV高度为浏览器窗口高度的一半
            //alert(winHeight);
            //alert(document.getElementById("top").offsetHeight);
            var topheight = document.getElementById("top").offsetHeight;
            document.getElementById("nav-menu").style.height = winHeight - topheight + "px";
            var moddleheight = document.getElementById("top").offsetHeight;
            document.getElementById("moddle").style.height = winHeight - moddleheight + "px";
        }
        window.onresize = autodivheight; //浏览器窗口发生变化时同时变化DIV高度//

        //TODO 只有第一个>符号可以旋转，另一个未完成
        function rotate(){
            x = document.getElementById("trans");
            if(x.style.transform == ""){
                x.style.transform = "rotate(90deg)";
            }
            else{
                x.style.transform = "";
            }
        }
    </script>
</body>
</html>

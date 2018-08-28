<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="PMS.Web.admin.main" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>论文管理系统</title>
    <link rel="stylesheet" href="../css/zgz.css">
    <link rel="stylesheet" href="../css/bootstrap.min.css">
    <link rel="stylesheet" href="../css/iconfont.css">
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
                            <img src="../images/logo.png" alt="云南工商学院" class="hidden-xs col-sm-7">
                            <span class="col-sm-5">论文管理系统</span>
                        </a>
                        <div class="dropdown pull-right">
                            <button class="btn btn-primary dropdown-toggle" id="dropdownMenu1" data-toggle="dropdown">
                                <b>你好，<%=realName %>&nbsp</b>
                                <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                <!--<li role="presentation">
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
                                </li>-->
                                <li role="presentation" id="myCenter">
                                    <a role="menuitem" tabindex="-1" class="sidebarclick" href="<%=url %>">
                                        <b class="iconfont icon-smile"></b>
                                        <span>个人中心</span>
                                    </a>
                                </li>
                                <li role="presentation" class="divider"></li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" class="sidebarclick" href="changePwd.aspx">
                                        <b class="iconfont icon-password"></b>
                                        <span>修改密码</span>
                                    </a>
                                </li>
                                <li role="presentation" class="divider"></li>
                                <li role="presentation">
                                    <a role="menuitem" tabindex="-1" href="javascript:logout();">
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
            <div class="page-left-nav col-sm-2 col-md-2 col-lg-1 collapse in" id="nav-menu">
                <nav role="navigation" class="row">
                    <ul class="nav nav-list nav-stacked">
                        <%
                            if (State == 3)
                            { %>
                        <!-- 学生 -->
                        <li role="presentation">
                            <a href="#ccccc"  class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-remind"></i>
                                <span>公告管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list sidebarclick" id="ccccc">
                                <li role="presentation">
                                    <a href="../newsList.aspx" class="sidebarclick" >
                                        <span>公告信息</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>选题信息</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="setting">
                                <li role="presentation" id="selectTitle">
                                    <a href="../paperList.aspx" class="sidebarclick" >
                                        <span>我要选题</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="myTitle">
                                    <a href="../PaperDtailStu.aspx" class="sidebarclick" >
                                        <span>我的选题</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        
                        <li role="presentation">
                            <a href="#reportStu" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>论文管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="reportStu">
                                <li role="presentation" id="openReport">
                                    <a href="../openingReport.aspx" class="sidebarclick" >
                                        <span>开题报告</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="submitReport">
                                    <a href="../thesisSubmit.aspx" class="sidebarclick" >
                                        <span>提交论文</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="checkReport">
                                    <a href="../checkReport.aspx" class="sidebarclick" >
                                        <span>查重报告</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="crossGuide">
                                    <a href="../crossGuide.aspx" class="sidebarclick" >
                                        <span>交叉评阅</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="defence">
                                    <a href="#" class="sidebarclick" >
                                        <span>论文答辩</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <!--<li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>开题报告</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>提交论文</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>查重报告</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>交叉评阅</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>
                        <li role="presentation">
                            <a href="#setting" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>论文答辩</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>-->
                        <li role="presentation">
                            <a href="#" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>查看成绩</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                        </li>

                        <%}
                            else if (State == 1)
                            {%>
                        <!-- 教师 -->
                        <li role="presentation">
                            <a href="#teagonggao"  class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-remind"></i>
                                <span>公告管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list sidebarclick" id="teagonggao">
                                <li role="presentation">
                                    <a href="../newsList.aspx" class="sidebarclick" >
                                        <span>公告信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="addNews.aspx" class="sidebarclick" >
                                        <span>发布公告</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        
                        <li role="presentation">
                            <a href="#timuguanli" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>题目管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="timuguanli"> 
                                <li role="presentation">
                                    <a href="addPaper.aspx?article=new" class="sidebarclick" >
                                        <span>我要出题</span>
                                    </a>
                                </li>                           
                                <li role="presentation">
                                    <a href="titleList.aspx" class="sidebarclick" >
                                        <span>我的题目</span>
                                    </a>
                                </li>
                                 <li role="presentation">
                                    <a href="titleReadList.aspx?search=null" class="sidebarclick" >
                                        <span>题目信息</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        
                        <li role="presentation">
                            <a href="#reportTea" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>论文管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="reportTea">
                                <li role="presentation" id="openReportTea">
                                    <a href="../reviewOpeningReport.aspx" class="sidebarclick" >
                                        <span>开题报告</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="submitReportTea">
                                    <a href="#" class="sidebarclick" >
                                        <span>论文评阅</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="checkReportTea">
                                    <a href="#" class="sidebarclick" >
                                        <span>查重报告</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="crossGuideTea">
                                    <a href="../crossGuide.aspx" class="sidebarclick" >
                                        <span>交叉评阅</span>
                                    </a>
                                </li>
                                 <li role="presentation" id="defenceTea">
                                    <a href="#" class="sidebarclick" >
                                        <span>查看答辩</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <li role="presentation">
                            <a href="#question" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>学生选题</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="question">
                                <li role="presentation">
                                    <a href="../myStudents.aspx" class="sidebarclick" >
                                        <span>我的学生</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <%}
                            else if (State == 0)
                            { %>
                        <!-- 超级管理员 -->
                        <li role="presentation">
                            <a href="#glygonggao" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>公告管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="glygonggao">
                                <li role="presentation">
                                    <a href="../newsList.aspx" class="sidebarclick" >
                                        <span>公告列表</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="addNews.aspx" class="sidebarclick" >
                                        <span>发布公告</span>
                                    </a>
                                </li>
                            </ul>
                        </li>

                        <li role="presentation">
                            <a href="#role" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>基本信息管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="role">
                                <li role="presentation">
                                    <a href="branchList.aspx" class="sidebarclick" >
                                        <span>学院信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="proList.aspx" class="sidebarclick" >
                                        <span>专业信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="adminList.aspx" class="sidebarclick" >
                                        <span>管理员信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="teaList.aspx" class="sidebarclick" >
                                        <span>教师信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="stuLIst.aspx" class="sidebarclick" >
                                        <span>学生信息</span>
                                    </a>
                                </li>
                                
                            </ul>
                        </li>

                        <li role="presentation">
                            <a href="#xuanti" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>选题管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="xuanti">
                                <li role="presentation">
                                    <a href="titleReadList.aspx" class="sidebarclick" >
                                        <span>题目信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="batchList.aspx" class="sidebarclick" >
                                        <span>批次信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="selectTopicList.aspx" class="sidebarclick" >
                                        <span>选题记录</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <%-- 
                        <li role="presentation">
                            <a href="#achievement" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>成绩管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="achievement">
                                <li role="presentation">
                                    <a href="adminList.aspx" class="sidebarclick" >
                                        <span>成绩信息</span>
                                    </a>
                                </li>
                            </ul>
                        </li><li role="presentation">
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
                        <li role="presentation" id="focus">
                            <a href="#">
                                <i class="iconfont icon-set"></i>
                                <span>网站配置</span>
                            </a>
                        </li>--%>
                        <%}
                            else if (State == 2)
                            { %>
                        <!-- 管理员 -->
                        <li role="presentation">
                            <a href="#glygonggao" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>公告管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="glygonggao">
                                <li role="presentation">
                                    <a href="../newsList.aspx" class="sidebarclick" >
                                        <span>公告列表</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="addNews.aspx" class="sidebarclick" >
                                        <span>发布公告</span>
                                    </a>
                                </li>
                            </ul>
                        </li>

                        <li role="presentation">
                            <a href="#role" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>基本信息管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="role">
                                <li role="presentation">
                                    <a href="proList.aspx" class="sidebarclick" >
                                        <span>专业信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="teaList.aspx" class="sidebarclick" >
                                        <span>教师信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="stuLIst.aspx" class="sidebarclick" >
                                        <span>学生信息</span>
                                    </a>
                                </li>
                                
                            </ul>
                        </li>

                        <li role="presentation">
                            <a href="#xuanti" class="collapsed" data-toggle="collapse">
                                <i class="iconfont icon-survey1"></i>
                                <span>选题管理</span>
                                <i class="iconfont icon-more"></i>
                            </a>
                            <ul class="collapse nav nav-list" id="xuanti">
                                <li role="presentation">
                                    <a href="titleReadList.aspx" class="sidebarclick" >
                                        <span>题目信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="batchList.aspx" class="sidebarclick" >
                                        <span>批次信息</span>
                                    </a>
                                </li>
                                <li role="presentation">
                                    <a href="selectTopicList.aspx" class="sidebarclick" >
                                        <span>选题记录</span>
                                    </a>
                                </li>
                            </ul>
                        </li>
                        <%} %>
                    </ul>
                </nav>
            </div>

            <!-- 右侧内容区 -->
            <div class="page-right-content col-sm-10 col-md-10 col-lg-11" id="content">
                <article class="">
                   <iframe id="iframe" style="margin-top:20px;" frameborder="0" scrolling="auto" src="../newsList.aspx" width="100%"></iframe>
                </article>
            </div>
        </div>

        <!-- 页面尾部 -->
        <footer class="page-bottom">
        </footer>
    </div>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/main.js"></script>
<%--    <script>
        

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
        function xuanz() {
            x = document.getElementById("trans");
            if (x.style.transform == "") {
                x.style.transform = "rotate(90deg)";
            }
            else {
                x.style.transform = "";
            }
        }

        function gethref(val) {
            document.getElementById("iframe").src = val;
        }
        var h = document.documentElement.clientHeight - 110;
        x = document.getElementById("iframe");
        x.height = h

        window.onresize = function () {
            var h = document.documentElement.clientHeight -110;
            x = document.getElementById("iframe");
            x.height = h
        }

        $(".sidebarclick").click(function () {
            gethref($(this).attr("href"));
            return false
        });

        function logout() {
            //alert("退出登录");
            $.ajax({
                type: 'get',
                url: 'main.aspx?op=logout',
                datatype: 'text',
                data: {},
                success: function (data) {
                    window.location.href = "../login.aspx";
                }
            });
        }
    </script>--%>
</body>

</html>

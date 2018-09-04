<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myGrogress.aspx.cs" Inherits="PMS.Web.myGrogress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文进度</title>
    <link rel="stylesheet" href="css/timeAxis.css" />

</head>
<body>
    <div class="demo">
        <div class="history">
            <div class="history-date">
                <ul>
                    <h2><a href="#nogo">选题开始</a>
                    </h2>
                    <li class="green">
                        <h3>10.08<span>2018</span></h3>
                        <dl>
                            <dt>10-8 开始选题<span>选了校园图书管理系统题目</span></dt>
                        </dl>
                    </li>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">提交开题报告</a></h2>
                    <li class="green">
                        <h3>10.12<span>2018</span></h3>
                        <dl>
                            <dt>提交开题报告<span>提交开题报告</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>10.13<span>2018</span></h3>
                        <dl>
                            <dt>教师评阅开题报告<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">论文指导阶段</a></h2>
                    <li>
                        <h3>10.14<span>2018</span></h3>
                        <dl>
                            <dt>进入论文指导阶段<span>提升浏览器速度、增强安全性</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>10.20<span>2018</span></h3>
                        <dl>
                            <dt>第一次论文提交<span>提升浏览器速度、增强安全性</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>10.25<span>2018</span></h3>
                        <dl>
                            <dt>第二次论文提交<span>新增360帐户，同步网络收藏夹</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>10.30<span>2018</span></h3>
                        <dl>
                            <dt>第三次论文提交<span>新增360帐户，同步网络收藏夹</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>11.02<span>2018</span></h3>
                        <dl>
                            <dt>最终提交论文<span>新增360帐户，同步网络收藏夹</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>11.05<span>2018</span></h3>
                        <dl>
                            <dt>中期质量检查报告提交<span>新增360帐户，同步网络收藏夹</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>11.10<span>2018</span></h3>
                        <dl>
                            <dt>论文指导阶段结束<span>首个包含沙箱</span></dt>
                        </dl>
                    </li>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">交叉指导阶段</a></h2>
                    <li>
                        <h3>11.12<span>2018</span></h3>
                        <dl>
                            <dt>进入论文交叉指导阶段<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>11.16<span>2018</span></h3>
                        <dl>
                            <dt>交叉指导阶段结束<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                </ul>
            </div>
            <div class="history-date">
                <ul>
                    <h2 class="date02"><a href="#nogo">论文答辩阶段</a></h2>
                    <li>
                        <h3>11.20<span>2018</span></h3>
                        <dl>
                            <dt>答辩小组指派<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>12.01<span>2018</span></h3>
                        <dl>
                            <dt>进行论文答辩<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                    <li>
                        <h3>12.01<span>2018</span></h3>
                        <dl>
                            <dt>完成论文答辩<span>新增对360网购保镖支持，保护网上交易安全</span></dt>
                        </dl>
                    </li>
                </ul>
            </div>
            <div style="margin-left: 162px; background: white; height: 100px;">
                <h2 style="font-weight: normal; font-size: 25px; line-height: 25px; padding-top: 10px; color: #003a59">结束</h2>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
    <script>
        $(function () {
            systole();
        });

        function systole() {
            if (!$(".history").length) {
                return;
            }
            var $warpEle = $(".history-date"),
                $targetA = $warpEle.find("h2 a,ul li dl dt a"),
                parentH,
                eleTop = [];

            parentH = $warpEle.parent().height();
            $warpEle.parent().css({ "height": 59 });

            setTimeout(function () {

                $warpEle.find("ul").children(":not('h2:first')").each(function (idx) {
                    eleTop.push($(this).position().top);
                    $(this).css({ "margin-top": -eleTop[idx] }).children().hide();
                }).animate({ "margin-top": 0 }, 1600).children().fadeIn();

                $warpEle.parent().animate({ "height": parentH }, 2600);

                $warpEle.find("ul").children(":not('h2:first')").addClass("bounceInDown").css({ "-webkit-animation-duration": "2s", "-webkit-animation-delay": "0", "-webkit-animation-timing-function": "ease", "-webkit-animation-fill-mode": "both" }).end().children("h2").css({ "position": "relative" });

            }, 600);

            $targetA.click(function () {
                $(this).parent().css({ "position": "relative" });
                $(this).parent().siblings().slideToggle();
                $warpEle.parent().removeAttr("style");
                return false;
            });
        };
    </script>
</body>
</html>

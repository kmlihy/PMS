//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
$(document).ready(function () {
    //点击翻页按钮
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            //点击上一页按钮时
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("page")) - 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) - 1);
                    break;
                } else {
                    jump(1);
                    break;
                }
            //点击下一页按钮时
            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("page")) + 1);
                    sessionStorage.setItem("page", parseInt(sessionStorage.getItem("page")) + 1);
                    break;
                } else {
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
            //点击首页按钮时
            case ("首页"):
                jump(1);
                break;
            //点击尾页按钮时
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //点击查询按钮时
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    //翻页时获取当前页码
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") === null) {
            window.location.href = "branchList.aspx?currentPage=" + cur
        } else {
            window.location.href = "branchList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
            //sessionStorage.setItem("strWhere", null);
        }
    }
    //当总页数为1时，首页与尾页按钮隐藏
    if (sessionStorage.getItem("countPage") === "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //添加分院对象
    $("#saveCollege").click(function () {
        var collegeName = $("#insertColl").val();
        if (collegeName === "") {
            alert("请输入分院名称");
        } else {
            $.ajax({
                type: 'Post',
                url: 'branchList.aspx',
                data: {
                    collegeName: collegeName,
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(parseInt(sessionStorage.getItem("page")));
                }
            });
        }
    })
    //编辑分院弹框绑定分院信息
    $(".btnEdit").click(function () {
        var collegeId = $(this).parent().parent().find(".collegeId").text().trim();
        var collegeName = $(this).parent().parent().find(".collegeName").text().trim();
        sessionStorage.setItem("collegeId", collegeId);
        $("#editColl").val(collegeName);
    })
    //编辑分院信息
    $("#saveEdit").click(function () {
        var name = $("#editColl").val();
        var id = sessionStorage.getItem("collegeId");
        if (name === "") {
            alert("请输入分院名称");
        } else {
            $.ajax({
                type: 'Post',
                url: 'branchList.aspx',
                data: {
                    id: id,
                    name: name,
                    op: "edit"
                },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(parseInt(sessionStorage.getItem("page")));
                }
            });
        }
    })
    //删除分院信息
    $(".btnDlete").click(function () {
        //alert("删除")
        var collegeId = $(this).parent().parent().find(".collegeId").text().trim();
        //alert(collegeId);
        $.ajax({
            type: 'Post',
            url: 'branchList.aspx',
            data: {
                collegeid: collegeId,
                op: "dele"
            },
            dataType: 'text',
            success: function (succ) {
                alert(succ);
                jump(parseInt(sessionStorage.getItem("page")));
            }
        });
    })
})
//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
    //翻页实现
    $(".jump").click(function () {
        switch ($.trim($(this).html())) {
            case ('<span class="iconfont icon-back"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) > 1) {
                    jump(parseInt(sessionStorage.getItem("Page")) - 1);
                    break;
                }
                else {
                    jump(1);
                    break;
                }

            case ('<span class="iconfont icon-more"></span>'):
                if (parseInt(sessionStorage.getItem("Page")) < parseInt(sessionStorage.getItem("countPage"))) {
                    jump(parseInt(sessionStorage.getItem("Page")) + 1);
                    break;
                }
                else {
                    jump(parseInt(sessionStorage.getItem("countPage")));
                    break;
                }
            case ("首页"):
                jump(1);
                break;
            case ("尾页"):
                jump(parseInt(sessionStorage.getItem("countPage")));
                break;
        }
    });
    //查询按钮点击事件
    $("#btn-search").click(function () {
        var strWhere = $("#inputsearch").val();
        sessionStorage.setItem("strWhere", strWhere);
        jump(1);
    });
    function jump(cur) {
        if (sessionStorage.getItem("strWhere") == null) {
            window.location.href = "proList.aspx?currentPage=" + cur;
        } else {
            window.location.href = "proList.aspx?currentPage=" + cur + "&search=" + sessionStorage.getItem("strWhere");
        }
    };
    if (sessionStorage.getItem("countPage") == "1") {
        $("#first").hide();
        $("#last").hide();
    }
    //添加按钮

    $("#btnAdd").click(function () {
        var collegeId = $("#selectcol").find("option:selected").val(),
            proName = $("#proName").val();
        if (proName == "") {
            alert("不能为空")
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'proList.aspx',
                data: { collegeId: collegeId, proName: proName, op: "add" },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(1);
                }
            });
        }
    })

    //专业信息查看
    $(".changebtn").click(function () {
        $("#btnSave").hide();
        $("#btnch").show();
        var proId = $(this).parent().parent().find("#tdproId").text();
        $(".bootstrap-select").hide();
        $("#colname").val($(this).parent().parent().find("#tdcollegeName").text());
        $("#colname").css("max-width", "140px");
        $("#p_proName").val($(this).parent().parent().find("#tdproName").text());
        $("#p_proName").css("max-width", "140px");
        //点击关闭清除ID
        $(".chID").click(function () {
            proId = "";
            $("#colname").show();
            $(".bootstrap-select").hide();
            $("#p_proName").attr("readonly", true);
        })
        //编辑按钮点击事件
        $("#btnch").click(function () {
            $(".bootstrap-select").show();
            $("#colname").hide();
            $("#p_proName").attr("readonly", false);
            $("#btnch").hide();
            $("#btnSave").show();
        })
        //保存更改事件
        $("#btnSave").click(function () {
            var proName = $("#p_proName").val(),
              collegeId = $("#collegeSelect").find("option:selected").val();
            if (proName == "" || collegeId == "") {
                alert("不能含有空项");
            }
            else {
                $.ajax({
                    type: 'Post',
                    url: 'proList.aspx',
                    data: { ProId: proId, ProName: proName, CollegeId: collegeId, op: "change" },
                    dataType: 'text',
                    success: function (succ) {
                        alert(succ);
                        jump(1);
                    }
                });
            }
        })
    })
    //删除事件
    $(".btnDel").click(function () {
        var result = confirm("您确定删除吗？如果该条记录没有关联其他表，将会直接删除！");
        if (result == true) {
            var delproId = $(this).parent().parent().find("#tdproId").text().trim();
            $.ajax({
                type: 'Post',
                url: 'proList.aspx',
                data: {
                    DelProId: delproId,
                    op: "del"
                },
                dataType: 'text',
                success: function (succ) {
                    alert(succ);
                    jump(parseInt(sessionStorage.getItem("Page")))
                }
            })
        } else {

        }
    })
});
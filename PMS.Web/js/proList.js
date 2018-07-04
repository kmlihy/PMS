//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("Page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);

$(document).ready(function () {
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
    $("#btnAdd").click(function () {
        var collegeId = $("#selectcol").find("option:selected").val(),
            proName = $("#proName").val();
        if (proName == "") {
            alert("不能为空")
        }
        else {
            alert("ajax");
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
    $(".changebtn").click(function () {
        var btnState = 1;
        $("#closeModel").click(function () {
           
            $("#btnSave").text("编辑");
        });
        $("#collegeName").show();
        $(".bootstrap-select").hide();
        $("#collegeName").text($(this).parent().parent().find("#tdcollegeName").text())

        var proId = $(this).parent().parent().find("#tdproId").text();
        $("#p_proName").text($(this).parent().parent().find("#tdproName").text());
        $("#btnSave").click(function () {
            switch (btnState) {
                case (0):
                    var proName = $("#p_proName").text(),
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
                    btnState = 1;
                    break;
                case (1):
                    $("#collegeName").hide();
                    $(".bootstrap-select").show();
                    $(this).text("保存");
                    btnState = 0;
                    break;
            }
        })
    })
});
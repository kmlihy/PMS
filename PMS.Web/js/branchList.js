//存储当前页数
var page = $("#page").val();
sessionStorage.setItem("page", page);
//存储总页数
var countPage = $("#countPage").val();
sessionStorage.setItem("countPage", countPage);
$(document).ready(function () {
    //防止当前页数大于总页数
    var page = parseInt(sessionStorage.getItem("page"));
    var countPage = parseInt(sessionStorage.getItem("countPage"));
    if (page > countPage) {
        sessionStorage.setItem("page", countPage);
        jump(parseInt(sessionStorage.getItem("page")));
    }
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
        var pattern_chin = /[\u4e00-\u9fa5]/g; //汉字的正则表达式
        if (collegeName === "") {
            $("#validate").html("学院名不能为空").css("color", "red");
        }
        else if (!pattern_chin.test(collegeName)) {
            $("#validate").html("学院名必须为汉字").css("color", "red");
        } 
        else {
            $.ajax({
                type: 'Post',
                url: 'branchList.aspx',
                data: {
                    collegeName: collegeName,
                    op: "add"
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ === "添加成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    }
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
    //每一次打开编辑弹窗时
    $(".btnEdit").click(function () {
        $("#select").hide();
        $("#input").show();
        $("#btnEditColl").show();
        sessionStorage.setItem("flag", "false");
    })
    //提交编辑分院信息
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
                    if (succ === "更新成功") {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    } else {
                        window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                                jump(1);
                            }
                        });
                    }
                }
            });
        }
    })
    //批量导入
    $(".file").on("change", "input[type='file']", function () {
        var filePath = $(this).val();
        if (filePath.indexOf("xls") !== -1 || filePath.indexOf("xlsx") !== -1) {
            $(".fileerrorTip").html("").hide();
            var arr = filePath.split('\\');
            var fileName = arr[arr.length - 1];
            $(".showFileName").html(fileName);
        } else {
            $(".showFileName").html("");
            $(".fileerrorTip").html("您未上传文件，或者您上传文件类型有误！").show();
            return false
        }
    })
    //删除分院信息
    $(".btnDlete").click(function () {
        var collegeId = $(this).parent().parent().find(".collegeId").text().trim();
        var txt = "确定要删除吗？";
        var option = {
            title: "删除警告",
            btn: parseInt("0011", 2),
            onOk: function () {
                $.ajax({
                    type: 'Post',
                    url: 'branchList.aspx',
                    data: {
                        collegeid: collegeId,
                        op: "dele"
                    },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ === "删除成功") {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                                onOk: function (v) {
                                    jump(parseInt(sessionStorage.getItem("page")));
                                }
                            });
                        } else {
                            window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                                onOk: function (v) {
                                    jump(parseInt(sessionStorage.getItem("page")));
                                }
                            });
                        }
                    }
                });
            }
        }
        window.wxc.xcConfirm(txt, "warning", option);
    })
    //批量删除
    $("#btn-Del").click(function () {
        var obj = document.getElementsByName('checkbox'); //选择所有name="checkbox"的对象，返回数组 
        //取到对象数组后，循环检测它是不是被选中 
        var collId = '';
        for (var i = 0; i < obj.length; i++) {
            if (obj[i].checked) collId += obj[i].value + '?'; //如果选中，将value添加到变量s中 
        }
        //那么现在来检测s的值就知道选中的复选框的值了 
        //alert(collId === '' ? '请至少选择一项！' : collId);
        $.ajax({
            type: 'Post',
            url: 'branchList.aspx',
            data: {
                collId: collId,
                op: "batchDel"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ === "删除成功") {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            jump(parseInt(sessionStorage.getItem("page")));
                        }
                    });
                } else {
                    window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                            jump(parseInt(sessionStorage.getItem("page")));
                        }
                    });
                }
            }
        });
    })
})
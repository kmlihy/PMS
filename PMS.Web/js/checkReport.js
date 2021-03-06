﻿var oFileInfo = document.getElementById("#tbody_reportFileInfo");//tbody

function showname() {
    var files = document.getElementById("upload").files;
    var FileName = files[0].name;
    //文件大小转换为M
    var FileSize = (files[0].size) / 1024;
    //取小数点后两位
    var Size = FileSize.toFixed(2);
    $("#myAlert").hide();
    $("#thesisTable").show();
    $("#thesisFileName").text(FileName);
    $("#thseisFileSize").text(Size + "KB");
}
$(function () {
    $("#btnupload").click(function () {
        var size = $("#upload")[0].files[0].size;
        if ((size / 1024 / 1024) > 1) {
            $("#thesisTable").hide();
            $("#upload").replaceWith('<input onchange="showname()" type="file" name="upload" id="upload" />');
            $("#myAlert").show();
            $("#myAlert").html("<h3>文件大小超过限制</h3>");
        }
        else {
            var location = $("input[name='upload']").val();
            var point = location.lastIndexOf(".");
            var type = location.substr(point).toLowerCase();
            var uploadFiles = document.getElementById("upload").files;
            if (uploadFiles.length == 0) {
                window.wxc.xcConfirm("请选择要上传的文件", window.wxc.xcConfirm.typeEnum.warning);
            }
            else if (type == ".doc" || type == ".docx") {
                ajaxFileUpload();

            }
            else {
                $("#thesisTable").hide();
                $("#upload").replaceWith('<input onchange="showname()" type="file" name="upload" id="upload" />');
                $("#myAlert").show();
                $("#myAlert").html("<h3>只允许上传.doc或者.docx格式的文件</h3>");
            }
        }
    });
});

function ajaxFileUpload() {
    $.ajaxFileUpload(
        {
            url: '/uploadCheckReport.aspx',
            secureuri: false,
            fileElementId: 'upload', //文件上传域的ID
            dataType: 'json',
            success: function (data, status) {
                console.log(data.msg);
                if (typeof (data.error) != 'undefined') {
                    if (data.error != '') {
                        window.wxc.xcConfirm(data.error, window.wxc.xcConfirm.typeEnum.warning);
                        $('#upload').val("");
                    }
                    else if (data.msg =="文件大小超过限制") {
                        window.wxc.xcConfirm(data.msg, window.wxc.xcConfirm.typeEnum.warning);
                    }
                    else {
                        window.wxc.xcConfirm(data.msg, window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                window.location.reload(true);
                            }
                        });
                        $('#upload').val("");
                    }
                }
            },
            error: function (data, status, e) {
                window.wxc.xcConfirm(e, window.wxc.xcConfirm.typeEnum.warning);
                $('#upload').val("");
            }
        }
    );
    return false;
}
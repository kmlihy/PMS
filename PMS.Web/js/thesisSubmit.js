$(document).ready(function () {
    $("#thesisTable").hide();
    $("#tips").hide();
})
function showname() {
    var files = document.getElementById("file1").files;
    var FileName = files[0].name;
    //文件大小转换为M
    var FileSize = (files[0].size) / 1024;
    //取小数点后两位
    var Size = FileSize.toFixed(2);
    $("#tips").hide();
    $("#thesisTable").show();
    $("#thesisFileName").text(FileName);
    $("#thseisFileSize").text(Size + "KB");
}
$(function () {
    $("#btnupload").click(function () {
        var location = $("input[name='file']").val();
        var point = location.lastIndexOf(".");
        var type = location.substr(point).toLowerCase();
        var uploadFiles = document.getElementById("file1").files;
        if (uploadFiles.length == 0) {
            alert("请选择要上传的文件");
        }
        else if (type == ".zip" || type == ".rar") {
            ajaxFileUpload();
        }
        else {
            $("#thesisTable").hide();
            $("#file1").replaceWith('<input onchange="showname()" type="file" id="file1" name="file" />');
            $("#tips").show();
            $("#tips").text("只允许上传.zip或者.rar格式的文件");
        }
    });
});

function ajaxFileUpload() {
    $.ajaxFileUpload(
        {
            url: '/thesisUpload.aspx',
            secureuri: false,
            fileElementId: 'file1', //文件上传域的ID
            dataType: 'json',
            success: function (data, status) {
                console.log(data.msg);
                if (typeof (data.error) != 'undefined') {
                    if (data.error != '') {
                        alert(data.error);
                        $("#thesisTable").hide();
                        $("#tips").show();
                        $("#tips").text("论文上传失败，请重新上传！");
                        $('#file1').val("");
                    } else {
                        alert(data.msg);
                        $("#thesisTable").hide();
                        $("#tips").show();
                        $("#tips").text("论文上传成功，请等待老评阅！");
                        $('#file1').val("");
                    }
                }
            },
            error: function (data, status, e) {
                alert(e);
                $("#thesisTable").hide();
                $("#tips").show();
                $("#tips").text("论文上传失败，请重新上传！");
                $('#file1').val("");
            }
        }
    );
    return false;
}
//教师还未下载论文评阅 0；
//下载评阅给出意见 1；
//学生论文最终通过 2 可进如下一步
var state = 0;

function showname() {
    var files = document.getElementById("file1").files;
    var FileName = files[0].name;
    //文件大小转换为M
    var FileSize = (files[0].size) / 1024;
    //取小数点后两位
    var Size = FileSize.toFixed(2);
    $("#thesisTable").show();
    $("#thesisFileName").text(FileName);
    $("#thseisFileSize").text(Size + "KB");
    $("#myAlert").hide();
}
$(function () {
    $("#btnupload").click(function () {
        var size = $("#file1")[0].files[0].size;
        if ((size / 1024 / 1024) > 1) {
            $("#thesisTable").hide();
            $("#file1").replaceWith('<input onchange="showname()" type="file" id="file1" name="file" />');
            $("#myAlert").show();
            $("#myAlert").html("<h3>文件大小超过限制</h3>");
        }
        else {
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
                $("#myAlert").show();
                $("#myAlert").html("<h3>只允许上传.zip或者.rar格式的文件</h3>");
            }
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
                        //alert(data.error);
                        $("#thesisTable").hide();
                        $("#myAlert").show();
                        $("#myAlert").text("文件上传失败，请重新上传！");
                        $('#file1').val("");
                    }
                    else if (data.msg =="文件大小超过限制") {
                        $("#thesisTable").hide();
                        $("#myAlert").show();
                        $("#myAlert").text("文件大小超过限制");
                        $('#file1').val("");
                    }
                    else {
                        //alert(data.msg);
                        $("#thesisTable").hide();
                        $("#myAlert").show();
                        $("#myAlert").text("论文上传成功，请等待老师评阅");
                        $('#file1').val("");
                    }
                }
            },
            error: function (data, status, e) {
               // alert(e);
                $("#thesisTable").hide();
                $("#myAlert").show();
                $("#myAlert").text("论文上传失败，请重新上传！");
                $('#file1').val("");
            }
        }
    );
    return false;
}
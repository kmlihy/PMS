$(function () {
    $("#btnupload").click(function () {
        var location = $("input[name='upload']").val();
        var point = location.lastIndexOf(".");
        var type = location.substr(point).toLowerCase();
        var uploadFiles = document.getElementById("upload").files;
        if (uploadFiles.length == 0) {
            alert("请选择要上传的文件");
        }
        else if (type == ".doc" || type == ".docx") {
            ajaxFileUpload();
           
        }
        else {
            alert("只允许上传.doc或者.docx格式的文件");
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
                        alert(data.error);
                        $('#upload').val("");
                    } else {
                        alert(data.msg);
                        $('#upload').val("");
                    }
                }
            },
            error: function (data, status, e) {
                alert(e);
                $('#upload').val("");
            }
        }
    );
    return false;
}
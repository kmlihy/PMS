$(function () {
    $(":button").click(function () {
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
            alert("只允许上传.zip或者.rar格式的文件");
        }
    });
});

function ajaxFileUpload() {
    $.ajaxFileUpload(
        {
            url: '/upload.aspx', 
            secureuri: false,
            fileElementId: 'file1', //文件上传域的ID
            dataType: 'json', 
            success: function (data, status)  
            {
                console.log(data.msg);
                if (typeof (data.error) != 'undefined') {
                    if (data.error != '') {
                        alert(data.error);
                    } else {
                        alert(data.msg);
                    }
                }
            },
            error: function (data, status, e)
            {
                alert(e);
            }
        }
    );
    return false;
}
//编辑器脚本
var editor;
KindEditor.ready(function (K) {
    editor = K.create('textarea[name="content"]', {
        afterCreate: function () {
            this.sync();
        },
        afterBlur: function () {
            this.sync();
        },
        width: '75%',
        items: [
            'source', '|', 'undo', 'redo', '|', 'fontname', 'fontsize', 'formatblock',
            'forecolor', 'hilitecolor', 'bold', 'italic', 'underline', '|', 'justifyleft',
            'justifycenter', 'justifyright', 'justifyfull', '|', 'selectall', 'cut',
            'copy', 'paste', 'plainpaste', 'wordpaste', 'strikethrough', 'lineheight',
            'removeformat', 'insertorderedlist', 'insertunorderedlist',
            'outdent', '|', 'preview', 'print', 'code', '|',
            'clearhtml', 'quickformat',
            'fullscreen', 'image', 'multiimage',
            'media', 'insertfile', 'table', 'hr',
            'baidumap', 'pagebreak', 'anchor', 'link',
            'unlink', 'about'
        ]
    });
});

//提交发布信息脚本
$("#release").click(function () {
    var newsTitle = $("#newsTitle").val();
    //var content = System.Web.HttpUtility.HtmlEncode($("#content").val());
    var content = escape($("#content").val());
    // alert(content);
    if (newsTitle == "") {
        window.wxc.xcConfirm("标题不能为空", window.wxc.xcConfirm.typeEnum.warning);
    }
    else if (content == "") {
        window.wxc.xcConfirm("内容不能为空", window.wxc.xcConfirm.typeEnum.warning);
    }
    else {
        $.ajax({
            type: 'Post',
            url: 'addNews.aspx',
            data: {
                newsTitle: newsTitle,
                content: content,
                op: "add"
            },
            dataType: 'text',
            success: function (succ) {
                if (succ == "添加成功") {
                    window.wxc.xcConfirm("发布成功", window.wxc.xcConfirm.typeEnum.success, {
                        onOk: function (v) {
                            window.location.href = "../newsList.aspx";
                        }
                    });
                }
                else {
                    window.wxc.xcConfirm("发布失败", window.wxc.xcConfirm.typeEnum.error, {
                        onOk: function (v) {
                            window.location.href = "../admin/addNew.aspx";
                        }
                    });
                }
            }
        });
    }
});
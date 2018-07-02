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
    var content = $("#content").val();
    // alert(content);
    if (newsTitle == "") {
        alert("标题不能为空");
    }
    else if (content == "") {
        alert("内容不能为空");
    }
    else {
        $.ajax({
            type: 'Post',
            url: 'addNews.aspx',
            data: { newsTitle: newsTitle, content: content, op: "add" },
            dataType: 'text',
            success: function (succ) {
                if (succ == "添加成功") {
                    alert("发布成功!");
                    window.location.href = "../newsList.aspx";
                }
                else {
                    alert("发布失败!");
                }
            }
        });
    }
});
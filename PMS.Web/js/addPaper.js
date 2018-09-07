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
$(document).ready(function () {
    //$(".selPro").change(function () {
    //    var college = $(".selPro").val();
    //    alert(college);
    //});
    var article = $("#article").val();
    $("#btnOK").click(function () {
        var paperTitle = $(".TextBox").val(),//获取标题文本值
            profession = $("#pro").val(),//获取专业文本值
            plan = $("#plan").val(),//获取批次文本值
            paperContent = escape($(".content").val());//获取内容文本值
        numMax = $(".numMax").val();//获取人数上限值
        if (paperTitle == "") {
            alert("论文标题不能为空");
        }
        else if (profession == "") {
            alert("专业不能为空");
        }
        else if (plan == "") {
            alert("批次不能为空");
        }
        else if (numMax == "") {
            alert("人数上限不能为空");
        }
        else if (paperContent == "") {
            alert("论文内容不能为空");
        }
        else {
            $.ajax({
                type: 'Post',
                url: 'addPaper.aspx',
                data: {
                    paperTitle: paperTitle,
                    profession: profession,
                    plan: plan,
                    paperContent: paperContent,
                    numMax: numMax,
                    op: article
                },
                dataType: 'text',
                success: function (succ) {
                    if (succ == "添加成功") {
                        window.wxc.xcConfirm("发布成功!", window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                window.location.href = "titleList.aspx";
                            }
                        });
                    }
                    else if (succ == "更新成功") {
                        window.wxc.xcConfirm("修改成功!", window.wxc.xcConfirm.typeEnum.success, {
                            onOk: function (v) {
                                window.location.href = "titleList.aspx";
                            }
                        });
                    }
                    else {
                        window.wxc.xcConfirm("发布失败!", window.wxc.xcConfirm.typeEnum.error, {
                            onOk: function (v) {
                            }
                        });
                    }
                }
            });
        }
    })
})
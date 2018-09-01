$("#btnSubmit").click(function () {
    var submit = "submit";
    var content = $("#content").val();
    var stuAccount = $("#stuAccount").text();
    var titleRecordId = $("#titleRecordId").val();
    $.ajax({
        type: 'Post',
        url: 'defenseRecordTeacher.aspx',
        data: {
            stuAccount: stuAccount,
            titleRecordId: titleRecordId,
            content: content,
            op: submit
        },
        dataType: 'text',
        success: function (succ) {
            if (succ === "添加成功") {
                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.success, {
                    onOk: function (v) {
                        alert("添加成功");
                    }
                });
            } else {
                window.wxc.xcConfirm(succ, window.wxc.xcConfirm.typeEnum.error, {
                    onOk: function (v) {
                        alert("添加失败");
                    }
                });
            }
        }
    })
})
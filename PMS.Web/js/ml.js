var $checkboxAll = $(".js-checkbox-all"),
    $checkbox = $("tbody").find("[type='checkbox']"),
    length = $checkbox.length,
    i = 0;

//启动icheck
$(("[type='checkbox']")).iCheck({
    checkboxClass: 'icheckbox_square-orange',
});

//全选checkbox
$checkboxAll.on("ifClicked", function (event) {
    if (event.target.checked) {
        $checkbox.iCheck('uncheck');
        i = 1;
    } else {
        $checkbox.iCheck('check');
        i = length;
    }
});

//监听计数
$checkbox.on('ifClicked', function (event) {
    event.target.checked ? i-- : i++;
    if (i == length + 1) {
        $checkboxAll.iCheck('check');
    } else {
        $checkboxAll.iCheck('uncheck');
    }
});

//批次添加框输入框验证
//$(document).ready(function () {
//    $("#myEditor").validate({
//        onfocusout: function (element) { $(element).valid(); },
//        errorPlacement: function (error, element) {
//            error.appendTo(element.parent().parent());
//        },
//        rules: {
//            planName: {
//                required: true,
//            },
//            startTime: {
//                required: true,
//                dateISO: true,
//            },
//            endTime: {
//                required: true,
//                dateISO:tru,
//            },
//            state: {
//                required:true,
//            },
//            collegeId: {
//                reqiured:true,
//            },
//        },
//        messages: {
//            planName: {
//                required:"*"
//            },
//            startTime: {
//                required: "*",
//                dateISO:"请输入正确的日期格式！",
//            },
//            endTime: {
//                required: "*",
//                dateISO: "请输入正确的日期格式！",
//            },
//            state: {
//                required: "*"
//            },
//            collegeId: {
//                required: "*"
//            },
//        }
//    })
//})

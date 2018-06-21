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
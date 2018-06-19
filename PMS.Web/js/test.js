// validate signup form on keyup and submit  
$("#accountForm").validate({
    rules: {
        /* input name 有 . 时加上引号 */
        personalId: {
            required: true
        },
        password: {
            required: true,
            minlength: 6
        },
        card_number: {
            required: true,
            remote: {
                url: "account!checkAvailbleVoucher.action",
                data: {
                    property: function() {
                        return "card_number";
                    },
                    type: function() {
                        return 2;
                    }
                }
            }
        },
        voucher_number: {
            required: true,
            remote: {
                url: "account!checkAvailbleVoucher.action",
                data: {
                    property: function() {
                        return "voucher_number";
                    },
                    type: function() {
                        return 1;
                    }
                }
            }
        }
    },
    messages: {
        password: {
            required: "请设定密码！",
            minlength: "密码至少为6位！"
        },
        card_number: {
            remote: "卡号输入错误！"
        },
        voucher_number: {
            remote: "凭证号输入错误！"
        }
    },
    /* 重写错误显示消息方法,以alert方式弹出错误消息 */
    showErrors: function(errorMap, errorList) {
        var msg = "";
        $.each(errorList, function(i, v) {
            msg += (v.message + "\r\n");
        });
        if (msg != "")
            alert(msg);
    },
    /* 失去焦点时不验证 */
    onfocusout: false
});

var mizhu = new function() {

    this.toast = function(message, time) {
        var html = '<div class="win"><div class="window-panel"><iframe class="title-panel" frameborder="0" marginheight="0" marginwidth="0" scrolling="no"></iframe><div class="body-panel toast-panel"><p class="content toast-content"></p></div></div></div>';
        messageBox(html, "", message, "toast");
        setTimeout(function() {
            mizhu.close();
        }, time || 3000);
    }
};

function valempty(str) {
    if (str == "null" || str == null || str == "" || str == "undefined" || str == undefined || str == 0) {
        return true;
    } else {
        return false;
    }
}
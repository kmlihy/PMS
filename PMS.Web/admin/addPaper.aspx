<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addPaper.aspx.cs" Inherits="PMS.Web.admin.addPaper" %>

    <!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>添加论文信息</title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/zwh.css" />
        <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
    </head>
    <body>
        <div class="container-fluid">
            <div class="container">
                <h3 class="text-center">添加论文信息</h3>
            </div>
            <div class="container-fluid">
                <div id="box" class="col-xs-9 col-xs-9 col-md-8 col-lg-8 col-xs-push-1 col-sm-push-1 col-md-push-2 col-lg-push-2">
                    <span class="lable">标题：</span>
                    <input maxlength="100" type="text" name="title" class="TextBox form-control" placeholder="请输入标题" />
                </div>
                <div id="box" class="col-xs-12 col-sm-12 col-md-10 col-lg-10 col-xs-push-1 col-sm-push-1 col-md-push-2 col-lg-push-2">
                    <span class="lable1">内容：</span>
                    <textarea name="content" class="content">KindEditor</textarea>
                </div>
                <div id="box" class="col-xs-4 col-xs-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-1 col-md-push-2 col-lg-push-2">
                    <span class="lable">专业：</span>
                    <select name="profession" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control" required="required">
                    <option value="">————请选择专业————</option>
                </select>
                </div>
                <div id="box" class="col-xs-4 col-xs-4 col-md-3 col-lg-3 col-xs-push-2 col-sm-push-2 col-md-push-4 col-lg-push-4">
                    <span class="lable">批次：</span>
                    <select name="batch" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control" required="required">
                    <option value="">————请选择批次————</option>
                </select>
                </div>
                <div>
                    <span class="lable"></span>
                    <button id="btnOK" type="submit" class="btn btn-primary col-xs-3 col-sm-3 col-md-2 col-lg-2 col-xs-pull-6 col-sm-pull-6 col-md-push-2 col-lg-push-2">提交</button>
                </div>
            </div>
        </div>
    </body>
    <script src="../js/jquery-3.3.1.min.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../kindeditor/kindeditor-all.js"></script>
    <script src="../kindeditor/lang/zh-CN.js"></script>
    <script>
        /* 文本编辑器图标*/
        var editor;
        KindEditor.ready(function(K) {
            editor = K.create('textarea[name="content"]', {
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
        /* 批次下拉项*/
        window.onload = function() {
            //设置年份的选择 
            var myDate = new Date();
            var startYear = myDate.getFullYear() - 50; //起始年份 
            var endYear = myDate.getFullYear(); //结束年份 
            var obj = document.getElementById('batch')
            for (var i = startYear; i <= endYear; i++) {
                obj.options.add(new Option(i, i));
            }
            obj.options[obj.options.length - 51].selected = 1;
        }
    </script>

    </html>
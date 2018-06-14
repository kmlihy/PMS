<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNews.aspx.cs" Inherits="PMS.Web.admin.addNews" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>发布公告</title>
        <link rel="stylesheet" href="../css/bootstrap.min.css" />
        <link rel="stylesheet" href="../css/style.css" />
        <link rel="stylesheet" href="../css/lgd.css" />
        <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
        <script src="../kindeditor/kindeditor-all.js"></script>
        <script src="../kindeditor/lang/zh-CN.js"></script>
    </head>

    <body>
        <div class="container-fluid">
            <div class="container">
                <h1 class="text-center">发布公告
                </h1>
            </div>

            <div class="container-fluid tablediv">
                <table class="table titleTable" id="titleTable">
                    <tbody>
                        <tr>
                            <td>
                                <div class="container-fluid text-right">
                                    <span class="label title">标题</span>
                                </div>
                            </td>
                            <td>
                                <div class="col-xs-3 col-sm-3 col-md-3 inputdiv">
                                    <input type="text" class="form-control" id="InputAmount" placeholder="请输入标题" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="container-fluid text-right">
                                    <span class="label title">内容</span>
                                </div>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <textarea name="content" class="titlemain">KindEditor</textarea>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <button class="btn btn-primary btn-title" type="submit">发布公告</button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </body>
    <script>
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
    </script>


    </html>
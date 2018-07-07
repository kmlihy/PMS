<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PMS.Web.test" %>

<!DOCTYPE html>

<html lang="ch">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
        <title>Krajee JQuery Plugins - &copy; Kartik</title>
        <link href="css/bootstrap.min.css" rel="stylesheet">
        <script type="text/javascript" src="js/jquery-3.3.1.min.js"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
        <style>
		       .file {
                position: relative;
                display: inline-block;
                background: #D0EEFF;
                border: 1px solid #99D3F5;
                border-radius: 4px;
                padding: 4px 12px;
                overflow: hidden;
                color: #1E88C7;
                text-decoration: none;
                text-indent: 0;
                line-height: 20px;
               }
                .file input {
                    position: absolute;
                    font-size: 100px;
                    right: 0;
                    top: 0;
                    opacity: 0;
                }
                .file:hover {
                    background: #AADFFD;
                    border-color: #78C3F3;
                    color: #004974;
                    text-decoration: none;
                }
        </style>
    </head>
    <body>
        <div class="container kv-main">
            <form id="form1" runat="server" method="post" enctype="multipart/form-data" action="test.aspx?op=upload">
                <div>
                    <a href="javascript:;" class="file">选择文件
                     <input type="file" name="upload" id="upload">
                     <label class="showFileName"></label>
                     <label class="fileerrorTip"></label>
                    </a>
                </div>
                <button type="submit" class="btn btn-success" id="btnupload">上传</button>
            </form>
        </div>
    </body>
    <script>
        $(".file").on("change","input[type='file']",function(){
            var filePath=$(this).val();
            if(filePath.indexOf("xls")!=-1 || filePath.indexOf("xlsx")!=-1){
                $(".fileerrorTip").html("").hide();
                var arr=filePath.split('\\');
                var fileName=arr[arr.length-1];
                $(".showFileName").html(fileName);
            }else{
                $(".showFileName").html("");
                $(".fileerrorTip").html("您未上传文件，或者您上传文件类型有误！").show();
                return false 
            }
        })
    </script>
</html>

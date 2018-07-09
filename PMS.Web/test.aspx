<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="PMS.Web.test" %>

<!DOCTYPE html>

<html lang="ch">
    <head>
        <meta charset="UTF-8"/>
        <title>Krajee JQuery Plugins - &copy; Kartik</title>
        <link href="css/bootstrap.min.css" rel="stylesheet">
        <script src="js/jquery-3.3.1.min.js"></script>
        <script src="js/ajaxfileupload.js"></script>
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
    </head>
    <body>
        <div class="container kv-main">
            <form enctype="multipart/form-data">
               <button type="button" class="btn btn-success" id="btnupload">上传</button>
           	    <!-- 隐藏file标签 -->  
		        <input id="fileToUpload" style="display:none" type="file" name="upfile" />        
            </form>
        </div>
    </body>
	<script type="text/javascript">  
	$(function(){
		$("input") //将html控件实现jqury对象化  
		$("#btnupload").click(function(){ 
			$("#fileToUpload").click();
		});
	    //选择文件之后执行上传  
        $("#fileToUpload").change(function () {
            var path = $("#fileToUpload").val();
            $.ajax({
                type: "post",
                url: "test.aspx?op=upload",
                data: {
                    Path: path,
                },
                datatype: 'text',
                success: function (data) {
                    alert(data);
                },
                error: function () {

                }
            })
	    });  
	      
	});  
	</script>

</html>

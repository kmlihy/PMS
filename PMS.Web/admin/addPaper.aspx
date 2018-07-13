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

<body id="addPaperBody">
    <div class="panel panel-default" id="panel">
        <div class="panel-head">
            <h2>添加论文信息</h2>
        </div>
        <div class="panel-body">
            <div class="addPaper container-fluid">
                <div class="container-fluid">
                    <div id="box" class="col-xs-10 col-xs-10 col-md-10 col-lg-10 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                        <span class="lable">标题：</span>
                        <input maxlength="100" type="text" name="title" class="TextBox form-control title" placeholder="请输入标题" />
                    </div>

                    <div id="box" class="col-xs-10 col-sm-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                        <span class="lable">专业：</span>
                        <select name="profession" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control selPro" required="required">
                            <option value="" id="getPro">————请选择专业————</option>
                            <%
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {%>
                            <option>
                                <%=ds.Tables[0].Rows[i]["proName"].ToString() %>
                            </option>
                            <% 
                                }
                            %>
                        </select>
                    </div>
                    <div id="box" class="col-xs-10 col-sm-4 col-md-3 col-lg-3 col-xs-push-1 col-sm-push-2 col-md-push-2 col-lg-push-2">
                        <span class="lable">批次：</span>
                        <select name="batch" id="input${1/(\w+)/\u\1/g}" class="TextBox form-control selBat" required="required">
                            <option value="">————请选择批次————</option>
                            <%
                                for (int i = 0; i < pbds.Tables[0].Rows.Count; i++)
                                {%>
                            <option>
                                <%=pbds.Tables[0].Rows[i]["planName"].ToString() %>
                            </option>
                            <%
                                }
                            %>
                        </select>
                    </div>
                    <div id="box" class="number col-xs-10 col-sm-10 col-md-2 col-lg-2">
                        <span class="lable1">人数上限：</span>
                        <input type="number" min="0" max="200" class="numMax" />
                    </div>

                    <div id="box" class="col-xs-11 col-sm-11 col-md-11 col-lg-11 col-xs-push-1 col-sm-push-1 col-md-push-1 col-lg-push-1">
                        <span class="lable1">内容：</span>
                        <textarea name="content" class="content">KindEditor</textarea>
                    </div>
                    <div>
                        <button id="btnOK" type="submit" class="btn btn-primary col-xs-3 col-sm-3 col-md-2 col-lg-2 col-xs-push-8 col-sm-push-8 col-md-push-9 col-lg-push-9">提交</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<script src="../js/jquery-3.3.1.min.js"></script>
<script src="../js/bootstrap.min.js"></script>
<script src="../kindeditor/kindeditor-all.js"></script>
<script src="../kindeditor/lang/zh-CN.js"></script>
<script src="../js/zwh.js"></script>
<script>
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
        $("#btnOK").click(function () {
            var paperTitle = $(".TextBox").val(),//获取标题文本值
                profession = $(".selPro").val(),//获取专业文本值
                plan = $(".selBat").val(),//获取批次文本值
                paperContent = $(".content").val();//获取内容文本值
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
                    data: { paperTitle: paperTitle, profession: profession, plan: plan, paperContent: paperContent, numMax: numMax, op: "add" },
                    dataType: 'text',
                    success: function (succ) {
                        if (succ == "添加成功") {
                            alert("发布成功!");
                            window.location.href = "../paperList.aspx";
                        }
                        else {
                            alert("发布失败!");
                        }
                    }
                });
            }

        })

    })
</script>

</html>

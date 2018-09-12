<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="thesisSubmit.aspx.cs" Inherits="PMS.Web.thesisSubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>论文提交页面</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/lgd.css" />
</head>
<body>
    <%if (openState != 3)
        { %>
    <h3 class="text-primary">开题报告暂未通过</h3>
    <%}
        else
        {%>
    <div class="container">
        <div class="panel-head text-center">
            <h2>论文提交页面</h2>
        </div>
        <div class="panel-body text-center thesis-panelbody">
            <%if (state==0||state == 1)
                { %>
            <table class="table">
                <tr>
                    <td class="file-Info"><span id="tips">上传论文:</span></td>
                    <td class="file-Info">
                        <p id="upload-p">选择文件<input onchange="showname()" type="file" id="file1" name="file" /></p>
                    </td>
                </tr>
            </table>
            <%}%>

            <div id="myAlert" class="alert alert-success">
                <%if (state==0||state == 1)
                    { %>
                <span class="text-primary"><strong>提示！</strong>只允许上传.zip或者.rar格式的文件，请把论文压缩成.zip或者.rar格式的文件,谢谢！<p>文件命名规范：学号+姓名 <br/>例如：10001漩涡鸣人</p></span><%}
    else if (state == 2)
    { %>
                <h4 class="text-primary">上传成功，请前往<a href="/myGuideTeacher.aspx">教师信息</a>查看回复</h4>
                <%}
    else
    {%>
                <h4 class="text-success">论文已通过，请前往<a href="/myCrossGuidanceTeacher.aspx">交叉评阅</a>进行下一阶段</h4>
                <%} %>
            </div>
            <div class="container text-center">
                <%--<p id="tips"></p>--%>
                <table class="table table-bordered" id="thesisTable">
                    <thead>
                        <tr>
                            <th class="text-center">文件名称</th>
                            <th class="text-center">文件大小</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td id="thesisFileName" class="file-Info"></td>
                            <td id="thseisFileSize" class="file-Info"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="container panel-footer text-right panelFooter">
            <%if (state==0||state == 1)
                { %>
            <input type="button" value="上传" id="btnupload" class="btn btn-primary" />
            <%} %>
        </div>
    </div>
    <%} %>
</body>
<script src="js/jquery-3.3.1.min.js"></script>
<script type="text/javascript" src="js/ajaxfileupload.js"></script>
<script type="text/javascript" src="js/thesisSubmit.js"></script>
</html>

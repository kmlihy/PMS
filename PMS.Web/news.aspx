<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="PMS.Web.admin.news" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>公告查看</title>
    </head>
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/ml.css">
    <link rel="stylesheet" href="css/style.css">

    <body>
        <div class="container-fluid col-lg-6 col-lg-offset-3" id="contentBox">
            <div class="panel table-bordered" id="panelBox">
                 <div class="panel-heading">
                    <span class="h3 text-info">通知公告</span>
                    <span class="glyphicon glyphicon-volume-up btn-lg"></span>
                    <hr id="underline">
                </div>
                <div class="panel-body container-fluid" id="panelBody">
                    <div class="container col-lg-12">
                        <table class="table">
                            <thead>
                                <th colspan="2" class="text-center">
                                    <label for="title" class="h4">公告标题（数据绑定）</label>
                                </th>
                            </thead>
                            <tbody>
                                <tr>
                                    <td class="text-right">
                                        <span class="table">
                                            发布时间:
                                            <label id="time"></label>
                                        </span>
                                    </td>
                                    <td class="text-left">
                                        <span class="table">
                                            发布人：XXXXX
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="">
                                        <label for="text">
                                            为推动高等学校依法自主办学负面清单管理改革，教育部拟对高校办学过程中涉及的政府管理事项进行全面清理。请各单位细致梳理需要政府及其有关部门审批、备案、年审、年检、数量指标控制、限制性规定等事项，并注明其法律或文件依据、设立部门，填写《高等学校负面清单管理摸底核查表》（附件通过OA通知公告栏转发）    
                                            为推动高等学校依法自主办学负面清单管理改革，教育部拟对高校办学过程中涉及的政府管理事项进行全面清理。请各单位细致梳理需要政府及其有关部门审批、备案、年审、年检、数量指标控制、限制性规定等事项，并注明其法律或文件依据、设立部门，填写《高等学校负面清单管理摸底核查表》（附件通过OA通知公告栏转发）    
                                            为推动高等学校依法自主办学负面清单管理改革，教育部拟对高校办学过程中涉及的政府管理事项进行全面清理。请各单位细致梳理需要政府及其有关部门审批、备案、年审、年检、数量指标控制、限制性规定等事项，并注明其法律或文件依据、设立部门，填写《高等学校负面清单管理摸底核查表》（附件通过OA通知公告栏转发）
                                        </label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </body>
    <script src="js/jquery-3.3.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    </html>
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="SLHotSpot.Web.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>热点展示页面</title>
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/icon.css" />
    <%--    <link type="text/css" href="Scripts/JQueryUI/css/smoothness/jquery-ui-1.8.19.custom.css"
        rel="stylesheet" />--%>
    <script type="text/javascript" src="Scripts/JQuery/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Scripts/EasyUI/jquery.easyui.min.js"></script>
    <%--    <script type="text/javascript" src="Scripts/JQueryUI/js/jquery-ui-1.8.19.custom.min.js"></script>--%>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }


        var slCtl = null;
        function pluginLoaded(sender, args) {
            slCtl = sender.getHost();
            slCtl.Content.SLControl.ItemOpenedHandle = itemOpened;
        }


        function showShop(value, rowData, rowIndex) {
            return "<a href='#' title='提示信息'>" + value + "</a>";
        }


        function itemOpened(sender, args) {
            window.open('http://localhost:12031/Shop_ShopDetail.aspx?CSN=' + sender, 'newwindow', 'resizable=1,width=860,height=645,scrollbars=1');

        }


        $(function () {





            $("#slider").slider({
                onChange: function (newValue) {
                    slCtl.Content.SLControl.SetZoom(newValue);
                }
            });


            $('#tt').datagrid({
                onSelect: function (rowIndex, rowData) {
                    slCtl.Content.SLControl.SetHotSpotSelected(rowData.ShopNO, true);
                },
                onUnselect: function (rowIndex, rowData) {
                    slCtl.Content.SLControl.SetHotSpotSelected(rowData.ShopNO, false);
                },
                onSelectAll: function (rows) {
                    for (var i = 0; i < rows.length; i++) {
                        slCtl.Content.SLControl.SetHotSpotSelected(rows[i].ShopNO, true);
                    }
                },
                onUnselectAll: function (rows) {
                    for (var i = 0; i < rows.length; i++) {
                        slCtl.Content.SLControl.SetHotSpotSelected(rows[i].ShopNO, false);
                    }
                }

            });


        });

    </script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    </form>
    <div id="content" region="center" title="电脑城平面图" iconcls="icon-map" style="padding: 5px;">
        <div id="silverlightControlHost" style="height: 100%; text-align: center;">
            <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                width="100%" height="100%">
                <param name="source" value="ClientBin/SLHotSpot.xap" />
                <param name="onError" value="onSilverlightError" />
                <param name="onLoad" value="pluginLoaded" />
                <param name="background" value="white" />
                <param name="minRuntimeVersion" value="5.0.61118.0" />
                <param name="autoUpgrade" value="true" />
                <param name="enableHtmlAccess" value="true" />
                <param name="initParams" value="WebServiceUrl=http://localhost:64141/HotSpotWebService.asmx,RootUrl=http://localhost:64141/,HotSpotBgImage=http://localhost:64141/Images/M001001_F1_0-3.png,Mode=View,DataID=M001001_F1_0" />
                <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=5.0.61118.0" style="text-decoration: none">
                    <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight"
                        style="border-style: none" />
                </a>
            </object>
            <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                border: 0px"></iframe>
        </div>
    </div>
    <div region="east" split="true" title="设置" style="width: 200px;">
        <div class="easyui-layout" fit="true">
            <div region="north" title="缩放" split="false" style="overflow: hidden; height: 60px;
                padding: 10px">
                <div id="slider" class="easyui-slider" min="1" max="6" step="1" fit="true">
                </div>
            </div>
            <div region="center" title="商铺" style="background: #fafafa; overflow: hidden" tools="#tol">
                <table id="tt" title="商铺列表" class="easyui-datagrid" border="false" fit="true" fitcolumns="true"
                    idfield="itemid" pagination="false" url="Handler1.ashx?223232" iconcls="icon-save">
                    <thead>
                        <tr>
                            <th field="ck" checkbox="true">
                            </th>
                            <th field="ShopNO" width="130" formatter="showShop">
                                商铺位
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
    <div id="tol">
        显示店铺：
        <a href="#" class="icon-edit"
            onclick="javascript:alert('edit')"></a>
    </div>
</body>
</html>

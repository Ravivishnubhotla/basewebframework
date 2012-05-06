<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotSpotView.aspx.cs" Inherits="SLHotSpot.Web.HotSpotView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>热点展示页面</title>
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/icon.css" />
 
    <script type="text/javascript" src="Scripts/JQuery/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Scripts/EasyUI/jquery.easyui.min.js"></script>
 
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

            loaddata();
        }


        function showShop(value, rowData, rowIndex) {

            return "<a href='#' title='" + rowData.ShopName + "'>" + rowData.ShopName + "</a>";
        }


        function itemOpened(sender, args) {
            window.open('http://localhost:12031/Shop_ShopDetail.aspx?CSN=' + sender, 'newwindow', 'resizable=1,width=860,height=645,scrollbars=1');
        }


        $(function () {



            $('#tt').datagrid({
                onSelect: function (rowIndex, rowData) {
                    slCtl.Content.SLControl.SetHotSpotSelected(rowData.SeatNO, true);
                },
                onUnselect: function (rowIndex, rowData) {
                    slCtl.Content.SLControl.SetHotSpotSelected(rowData.SeatNO, false);
                },
                onSelectAll: function (rows) {
                    for (var i = 0; i < rows.length; i++) {
                        slCtl.Content.SLControl.SetHotSpotSelected(rows[i].SeatNO, true);
                    }
                },
                onUnselectAll: function (rows) {
                    for (var i = 0; i < rows.length; i++) {
                        slCtl.Content.SLControl.SetHotSpotSelected(rows[i].SeatNO, false);
                    }
                }

            });

            
 

        });


        function loaddata() {

            $('#tt').datagrid('load', {
                showAllBrandInf: ($('#chkShowAllBrandInfo').attr("checked") == 'checked')
            });

            $.ajax({
                url: 'Handler1.ashx?data=true&showAllBrandInf=' + ($('#chkShowAllBrandInfo').attr("checked") == 'checked'),
                success: function (data) {
                    slCtl.Content.SLControl.LoadData(data);

                }
            });


 
        }
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
                <param name="initParams" value="ShopMallNo=M001001,FloorNo=F1_0,WebServiceUrl=http://localhost:12686/HotSpotWebService.asmx,RootUrl=http://localhost:12686/,HotSpotBgImage=http://localhost:12686/Images/M001001_F1_0-3.png,Mode=View,DataID=M001001_F1_0" />
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
            <div region="north" title="设置" split="false" style="overflow: hidden; height: 60px;
                padding: 10px"><label for="chkShowAllBrandInfo">显示所有的品牌：</label> 
                 <input id="chkShowAllBrandInfo" type="checkbox" onclick="loaddata();" />
            </div>
            <div region="center" title="商铺" style="background: #fafafa; overflow: hidden" >
                <table id="tt" title="商铺列表" class="easyui-datagrid" border="false" fit="true" fitcolumns="true"
                    idfield="itemid" url="Handler1.ashx" pagination="false" iconcls="icon-save">
                    <thead>
                        <tr>
                            <th field="ck" checkbox="true">
                            </th>
                            <th field="SeatNO" width="130" formatter="showShop">
                                商铺位
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
 
</body>
</html>

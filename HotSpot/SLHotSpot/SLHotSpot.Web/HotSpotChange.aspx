<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotSpotChange.aspx.cs" Inherits="SLHotSpot.Web.HotSpotChange" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>品牌竞争力分析</title>
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
            slCtl.Content.SLControl.ItemChangedBrandHandle = itemChangedBrand;
            loaddata();
        }


 

        function showValue(value, rowData, rowIndex) {

            return value.toFixed(2);
        }


        function itemOpened(sender, args) {
            window.open('http://localhost:12031/Shop_ShopDetail.aspx?CSN=' + sender, 'newwindow', 'resizable=1,width=860,height=645,scrollbars=1');
        }

        function itemChangedBrand(sender, args) {

            document.getElementById('hidshopbrandinfo').value = slCtl.Content.SLControl.GetAllShopBrandInfo();

            $('#tt').datagrid('load', {
                shopbrandinfo: document.getElementById('hidshopbrandinfo').value
            });
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
                shopbrandinfo: document.getElementById('hidshopbrandinfo').value
            });

            $.ajax({
                url: 'Handler1.ashx?data=true&showAllBrandInf=true',
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
                <param name="initParams" value="ShopMallNo=M001001,FloorNo=F1_0,WebServiceUrl=http://localhost:12686/HotSpotWebService.asmx,Mode=Change" />
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
            <div region="center" title="竞争力分析" style="background: #fafafa; overflow: hidden" >
                <table id="tt" title="品牌竞争力" class="easyui-datagrid" border="false" fit="true" fitcolumns="true"
                    idfield="itemid" url="Handler2.ashx" pagination="false" iconcls="icon-save">
                    <thead>
                        <tr>
                            <th field="BrandName" width="80">
                                品牌
                            </th>
                            <th field="OldCompetitionScore" width="80"  formatter="showValue">
                                原竞争力
                            </th>
                            <th field="NewCompetitionScore" width="80" formatter="showValue">
                                现竞争力
                            </th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
 <input type="hidden" id="hidshopbrandinfo"/>
</body>
</html>

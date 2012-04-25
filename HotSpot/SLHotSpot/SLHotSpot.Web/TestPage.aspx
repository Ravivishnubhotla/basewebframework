<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestPage.aspx.cs" Inherits="SLHotSpot.Web.TestPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>热点展示页面</title>
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/gray/easyui.css" />
    <link rel="stylesheet" type="text/css" href="Scripts/EasyUI/themes/icon.css" />
    <link type="text/css" href="Scripts/JQueryUI/css/smoothness/jquery-ui-1.8.19.custom.css"
        rel="stylesheet" />
    <script type="text/javascript" src="Scripts/JQuery/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="Scripts/EasyUI/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="Scripts/JQueryUI/js/jquery-ui-1.8.19.custom.min.js"></script>
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




        $(function () {

            $("#slider").slider();

//            var data = { total: 9, rows:  [
//                { itemid: '01' },
//                { itemid: '02' },
//                { itemid: '03' },
//                { itemid: '04' },
//                { itemid: '05' },
//                { itemid: '06' },
//                { itemid: '07' },
//                { itemid: '08' },
//                { itemid: '09' }
//            ] };

//            try {
//                $('#dg').datagrid('load', data);
//            }
//            catch (err) {
//                alert(err.description);
//            }




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
                <param name="background" value="white" />
                <param name="minRuntimeVersion" value="5.0.61118.0" />
                <param name="autoUpgrade" value="true" />
                <param name="enableHtmlAccess" value="true" />
                <param name="initParams" value="WebServiceUrl=http://localhost:64141/HotSpotWebService.asmx,RootUrl=http://localhost:64141/,HotSpotBgImage=http://localhost:64141/Images/M001001_F1_0-3.png,Mode=Change,DataID=M001001_F1_0" />
                <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=5.0.61118.0" style="text-decoration: none">
                    <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight"
                        style="border-style: none" />
                </a>
            </object>
            <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                border: 0px"></iframe>
        </div>
    </div>
    <div region="east" split="true" title="商铺信息" style="width: 200px;">
        <div style="padding: 5px; margin: 0;">
            图像缩放:</div>
        <div style="padding: 5px; margin: 0;">
            <div id="slider">
            </div>
        </div>
        <table id="tt" title="Checkbox Select" class="easyui-datagrid" style="width: 190px;
            height: 300px;" idfield="itemid" pagination="true"            url="http://www.jeasyui.com/tutorial/datagrid/data/datagrid_data.json"
            iconcls="icon-save">
            <thead>
                <tr>
                    <th field="ck" checkbox="true">
                    </th>
                    <th field="itemid" width="150">
                        商铺位
                    </th>
                </tr>
            </thead>
        </table>
    </div>
</body>
</html>

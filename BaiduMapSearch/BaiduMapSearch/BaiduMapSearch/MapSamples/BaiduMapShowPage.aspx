<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaiduMapShowPage.aspx.cs"
    Inherits="BaiduMapSearch.MapSamples.BaiduMapShowPage" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>
    <style type="text/css">
        html
        {
            height: 100%;
        }
        body
        {
            height: 100%;
            margin: 0px;
            padding: 0px;
        }
        #map
        {
            height: 100%;
        }
    </style>
</head>
<body>
    <div id="map">
    </div>
</body>
</html>
<script type="text/javascript">
    var map = new BMap.Map("map");            // 创建Map实例
    var point = new BMap.Point(113.146196, 29.378007);    // 创建点坐标
    map.centerAndZoom(point, 14);                     // 初始化地图,设置中心点坐标和地图级别。
    map.addControl(new BMap.MapTypeControl());          //添加地图类型控件
    var opts = { type: BMAP_NAVIGATION_CONTROL_LARGE }
    map.addControl(new BMap.NavigationControl(opts));
    map.enableScrollWheelZoom();
    map.enableKeyboard();     
</script>

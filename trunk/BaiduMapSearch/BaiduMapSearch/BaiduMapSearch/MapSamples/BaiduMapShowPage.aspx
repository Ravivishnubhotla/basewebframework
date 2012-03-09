<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaiduMapShowPage.aspx.cs"
    Inherits="BaiduMapSearch.MapSamples.BaiduMapShowPage" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title></title>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2&services=true"></script>
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
    var opts = { type: BMAP_NAVIGATION_CONTROL_LARGE };
    map.addControl(new BMap.NavigationControl(opts));
    map.enableScrollWheelZoom();
    map.enableKeyboard();



    var geolocation = new BMap.Geolocation();
    geolocation.getCurrentPosition(function (r) {
        //alert(this.getStatus());
        if (this.getStatus() == BMAP_STATUS_SUCCESS) {


            var marker = new BMap.Marker(r.point);
            var opts = {
                width: 250,     // 信息窗口宽度
                height: 100,     // 信息窗口高度
                title: "您的位置"  // 信息窗口标题
            };

 

            var infoWindow = new BMap.InfoWindow('坐标：' + r.point.lng + ',' + r.point.lat, opts);  // 创建信息窗口对象

            marker.addEventListener("click", function () {
                this.openInfoWindow(infoWindow);
            });


            map.addOverlay(marker);

            marker.setAnimation(BMAP_ANIMATION_DROP); 
            map.panTo(r.point);
        }
    });

    // 添加标注
    function addMarker(point, index) {
        var myIcon = new BMap.Icon("http://api.map.baidu.com/img/markers.png", new BMap.Size(23, 25), {
            offset: new BMap.Size(10, 25),
            imageOffset: new BMap.Size(0, 0 - index * 25)
        });
        var marker = new BMap.Marker(point, { icon: myIcon });
        map.addOverlay(marker);
        return marker;
    }

    function MoveTo(point) {
        map.panTo(point);
    }
    function MoveToPoint(x,y) {
        var point = new BMap.Point(x,y);
        //alert(point);
        map.panTo(point);
    }



    map.addEventListener("tilesloaded", function () {
        //map.panTo(point);
        var center = map.getCenter();


        if (typeof (parent.map_tilesloaded) == "function") {
            parent.map_tilesloaded(center);
        }

    });

    //显示地图中心地点的坐标
    map.addEventListener("dragend", function () {
        //map.panTo(point);
        var center = map.getCenter();
 

        if (typeof (parent.map_dragend) == "function") {
            parent.map_dragend(center);
        }

    });


    function Search(keyword, searchResult) {

        var options = { onSearchComplete: searchResult };

        var local = new BMap.LocalSearch(map, options);

        local.search(keyword);

        //local.getResults();

        //local.setSearchCompleteCallback(searchResult);    
    }





</script>

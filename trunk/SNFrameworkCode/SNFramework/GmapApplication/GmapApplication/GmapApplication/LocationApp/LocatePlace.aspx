<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LocatePlace.aspx.cs" Inherits="GmapApplication.LocationApp.LocatePlace" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
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
        #map_canvas
        {
            height: 100%;
        }
    </style>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var geocodingService = new google.maps.Geocoder();
        var map;
        var marker;
        var globalResult;

        function InitMap() {
            var latlng = new google.maps.LatLng(39.47, -86.08);
            var myMapOptions = {
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                center: latlng
            };
            map = new google.maps.Map(document.getElementById("map_canvas"), myMapOptions);
        }

        function ChooseOne(rowIndex) {
            marker.setPosition(globalResult[rowIndex].geometry.location);
            map.panTo(globalResult[rowIndex].geometry.location);
        }


        function CheckAddress(addr) {
            var myGeoOptions = {
                address: addr,
                region: 'us'
            };
            geocodingService.geocode(myGeoOptions, function (result, status) {
                if (marker != null) {
                    marker.setMap(null);
                }

                parent.ClearStore();

                if (status != google.maps.GeocoderStatus.OK) {
                    return;
                }

                globalResult = result;

                // Display location list

                for (var i = 0; i < result.length; i++) {
                    //debugger;
                    parent.StoreAddDirection(result[i].formatted_address, result[i].geometry.location.lng(), result[i].geometry.location.lat());
                }



                // Add marker
                marker = new google.maps.Marker({
                    position: result[0].geometry.location,
                    map: map,
                    title: result[0].geometry.location.toString(),
                    draggable: true
                });
                map.panTo(result[0].geometry.location);
                // Add event for dragging marker
                google.maps.event.addListener(marker, 'drag', function (mouse) {
                    //document.getElementById("divLocationList").innerHTML = mouse.latLng.toString();
                    //debugger;
                    parent.ShowlatLng(mouse.latLng.toString(), mouse.latLng.lng(), mouse.latLng.lat())
                    //marker.setTitle(mouse.latLng.toString());
                });
            });
        }
 
    </script>
</head>
<body onload="InitMap();">
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
</body>
</html>
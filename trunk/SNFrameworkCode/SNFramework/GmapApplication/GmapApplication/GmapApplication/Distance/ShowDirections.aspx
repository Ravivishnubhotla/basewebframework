<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowDirections.aspx.cs"
    Inherits="GmapApplication.Distance.ShowDirections" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Calculate distance between origins and destinations</title>
    <script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        var directionDisplay;
        var directionsService = new google.maps.DirectionsService();
        var map;

        function initialize() {
            directionsDisplay = new google.maps.DirectionsRenderer();
            var latlng = new google.maps.LatLng(39.47, -86.08);
            var myOptions = {
                zoom: 7,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                center: latlng
            };
            map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
            directionsDisplay.setMap(map);
        }

        function showRoute(start, end) {
            var request = {
                origin: start,
                destination: end,
                travelMode: google.maps.TravelMode.DRIVING,
                provideRouteAlternatives: true
            };

            directionsService.route(request, function (result, status) {

                parent.ClearStore();

                if (status == google.maps.DirectionsStatus.OK) {
                    directionsDisplay.setDirections(result);

                    for (var i = 0; i < result.routes.length; i++) {
                        for (var j = 0; j < result.routes[i].legs.length; j++) {
                            parent.StoreAddDirection(result.routes[i].legs[j].distance.text, result.routes[i].legs[j].duration.text);
                        }
                    }

                    parent.selectRowIndex(0);
                }
                else {
                }
            });
        }


        function setRoute(rowIndex) {
            directionsDisplay.setRouteIndex(parseInt(rowIndex));
        }
    </script>
</head>
<body onload="initialize()">
    <form id="form1" runat="server">
    <div id="map_canvas" style="width: 100%; height: 100%">
    </div>
    </form>
</body>
</html>

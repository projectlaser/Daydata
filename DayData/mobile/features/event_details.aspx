<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="event_details.aspx.cs" Inherits="DayData.mobile.features.event_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<meta name="viewport" content="width=device-width, initial-scale=1" />
              <link rel="Stylesheet" type="text/css" href="../../required/css/TJHS.min.css" />
                  <link rel="Stylesheet" type="text/css" href="../../required/css/jquery.mobile.structure-1.1.1.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../../required/js/mobilejquery.js"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script type="text/javascript">
        $('document').ready(function () {
            initialize();
        });

        var geocoder;
        var map;
        var markersArray = [];

        function initialize() {
            geocoder = new google.maps.Geocoder();
            var latlng;
            var locTxt = $("#loc").val();
            if (locTxt == "") {
                latlng = new google.maps.LatLng(41.29055, -95.91807);
            }
            else {
                codeAddress();
            }
            var myOptions = {
                zoom: 9,
                center: latlng,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }
            map = new google.maps.Map(document.getElementById("map"), myOptions);
        }

        function addMarker(location) {
            marker = new google.maps.Marker({
                position: location,
                map: map
            });
            markersArray.push(marker);
        }
        function codeAddress() {
            var address = document.getElementById("loc").value;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    clearOverlays();
                    addMarker(results[0].geometry.location);
                    map.setZoom(16);
                    return results[0].geometry.location;
                } else {
                    alert("Geocode was not successful for the following reason: " + status);
                }
            });
        }
        function clearOverlays() {
            if (markersArray) {
                for (i in markersArray) {
                    markersArray[i].setMap(null);
                }
            }
        }
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxLinksEnabled(false);
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input runat="server" id="loc" />
    <div data-role="page" data-theme="a">
    
    <div data-role="header">
    <h1><asp:Label ID="header" runat="server"></asp:Label></h1>
    <a href="events.aspx" data-iconpos="notext" data-icon="back"></a>
    </div>

    <div data-role="content">
        <ul data-role="listview" data-inset="true">
        <li data-role="list-divider"><asp:Label ID="title" runat="server"></asp:Label></li>
        <li>Time: <asp:Label ID="time" runat="server"></asp:Label></li>
        <li>Description: <asp:Label ID="desc" runat="server"></asp:Label></li>
        <li><div id="map" style="height: 250px; width: 100%"></div></li>
        </ul>
    </div>

    </div>

    </form>
</body>
</html>

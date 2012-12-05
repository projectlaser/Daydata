<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events_more.aspx.cs" Inherits="DayData.desktop.features.events_more" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="Stylesheet" href="../../required/css/metrotiles.css" />
    <link rel="Stylesheet" href="../../required/css/desktop_view.css" />
    <link rel="Stylesheet" href="../../required/js/tiles.js" />
    <link rel="stylesheet" href="../../required/css/reset.css" />
    <link rel="stylesheet" href="../../required/css/icons.css" />
    <link rel="stylesheet" href="../../required/css/formalize.css" />
    <link rel="stylesheet" href="../../required/css/checkboxes.css" />
    <link rel="stylesheet" href="../../required/css/sourcerer.css" />
    <link rel="stylesheet" href="../../required/css/jqueryui.css" />
    <link rel="stylesheet" href="../../required/css/tipsy.css" />
    <link rel="stylesheet" href="../../required/css/calendar.css" />
    <link rel="stylesheet" href="../../required/css/fonts.css" />
    <link rel="Stylesheet" href="../../required/css/960.css" />
    <link rel="stylesheet" href="../../required/css/main.css" />
    <link rel="icon" type="image/png" href="../../required/images/favicon.png" />
    <script src="../../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../required/js/jquery.tipsy.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="../../required/images/favicon.png" type="image/png" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
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
            map = new google.maps.Map(document.getElementById("mappreview"), myOptions);
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
    </script>
    <style type="text/css">
    .table
    {
-moz-border-radius: 15px;
border-radius: 15px;
    }
    .center
    {
        margin: 0px auto;
        width: 70%;
        text-align:center;
    }
    .event_short
    {
        width: 60%;
        display: inline;
    }
    .centerBox
    {
        margin: 0px auto;
        width: 70%;
    }
    .linkStyle
    {
        color: #666;
display: block;
line-height: 32px;
text-decoration: none;
    }
    .spanStyle
    {
        display: inline-block;
font-size: 18px;
font-weight: bold;
margin-right: 10px;
text-align: right;
width: 70px;
zoom: 1;
margin: 0px auto;
    }
    </style>
</head>
<body>
<script type="text/javascript">
    $(function () {
        $('body').hide().fadeIn('fast');
        $('a').click(function () {
            var link = $(this).attr('href');
            $('body').fadeOut('fast', function () {
                window.location.href = link;
            });
            return false;
        });

    });
</script>
    <form id="form1" runat="server">
    <input type="hidden" runat="server" id="loc" name="loc" />
     <div id="top_nav" class="topbar fixedbar">
     <div class="topbar-inside topbar-inner">
     <div class="container" style="height: 45px">
     <a href="../default.aspx" class="left">
     <asp:Image runat="server" ID="top_image" />
     </a>
     <a href="../default.aspx" class="title"><asp:Label ID="name_label" runat="server"></asp:Label></a>
     </div>
     </div>
     </div>
     <div class="tiles">
     <div class="section">
     <a style="float:left" class="nav_back" href="events.aspx"></a>
          <div class="box centerBox">
     <div class="box-header"><span class="glyph calendar"></span><h1><asp:Label ID="title_header" runat="server"></asp:Label></h1></div>
    <ul class="statistics">
    <li>
    <a><span style="width: 107px;">Title</span> <asp:PlaceHolder ID="titleLabel2" runat="server"></asp:PlaceHolder></a>
    </li>
        <li>
    <a><span style="width: 107px;">Description</span> <asp:PlaceHolder ID="desc" runat="server"></asp:PlaceHolder></a>
    </li>
        <li>
    <a><span style="width: 107px;">Time</span> <asp:PlaceHolder ID="time" runat="server"></asp:PlaceHolder></a>
    </li>
    <li>
    <div class="linkStyle"><span class="spanStyle" style="width: 107px;">Location</span> <div id="mappreview" 
            class="google_map" style="width: 99%; height: 157px;"></div></div>
    </li>
    </ul>
     </div>
     </div>
     </div>
    </form>
</body>
</html>

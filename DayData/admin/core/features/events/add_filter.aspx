<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_filter.aspx.cs" Inherits="DayData.admin.core.features.events.WebForm1" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../../../required/css/reset.css" />
    <link rel="stylesheet" href="../../../../required/css/icons.css" />
    <link rel="stylesheet" href="../../../../required/css/formalize.css" />
    <link rel="stylesheet" href="../../../../required/css/checkboxes.css" />
    <link rel="stylesheet" href="../../../../required/css/sourcerer.css" />
    <link rel="stylesheet" href="../../../../required/css/jqueryui.css" />
    <link rel="stylesheet" href="../../../../required/css/tipsy.css" />
    <link rel="stylesheet" href="../../../../required/css/calendar.css" />
    <link rel="stylesheet" href="../../../../required/css/tags.css" />
    <link rel="stylesheet" href="../../../../required/css/fonts.css" />
    <link rel="Stylesheet" href="../../../../required/css/960.css" />
    <link rel="Stylesheet" href="../../../../required/css/selectboxes.css" />
    <link rel="stylesheet" href="../../../../required/css/main.css" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <script src="../../../../required/js/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $('document').load(function () {
            alert('activated');
            initialize();
            $('#location').focusout(function () {
                if ($("#location").val().length > 3) {
                    var t = codeAddress();
                }
            });
        });

        var geocoder;
        var map;
        var markersArray = [];

        function initialize() {
            geocoder = new google.maps.Geocoder();
            var latlng;
            var locTxt = $("#location").val();
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
            map = new google.maps.Map(document.getElementById("google_map"), myOptions);
        }

        function addMarker(location) {
            marker = new google.maps.Marker({
                position: location,
                map: map
            });
            markersArray.push(marker);
        }

        function codeAddress() {
            var address = document.getElementById("location").value;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    map.setCenter(results[0].geometry.location);
                    clearOverlays();
                    addMarker(results[0].geometry.location);
                    map.setZoom(16);
                    return results[0].geometry.location;
                } else {
                    alert("Geocode was not successful for the following reason: " + status + ". Please enter a better location");
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
</head>
<body onload="initialize();">
    <form id="form1" runat="server">
    <p>
    <input type="text" id="title" placeholder="Filter Title (Location Name)" name="title" class="{validate:{required:true, minlength:3}}" />
    </p>
    <p>
    <input type="text" id="location" placeholder="Location Address" name="location" class="{validate:{required:true, minlength:3}}" />
    <span>Please enter the most accurate location name (including city and state)</span>
    </p>
    <div id="google_map" class="google_map" style="width: 100px; height: 100px"></div>
    <p>
    <asp:Button ID="add" runat="server" Text="Add Filter" CssClass="button blue" />
    </p>
    </form>
</body>
</html>

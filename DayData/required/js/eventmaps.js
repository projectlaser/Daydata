$('document').ready(function () {
    initialize();
    $('#loc').focusout(function () {
        if ($("#loc").val().length > 3) {
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
function setLongLatHidden(text) {
    $('#long_lat').val(text);
  //  alert(text);
}
function codeAddress() {
    var address = document.getElementById("loc").value;
    geocoder.geocode({ 'address': address }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            map.setCenter(results[0].geometry.location);
            clearOverlays();
            addMarker(results[0].geometry.location);
            map.setZoom(16);
            setLongLatHidden(results[0].geometry.location);
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
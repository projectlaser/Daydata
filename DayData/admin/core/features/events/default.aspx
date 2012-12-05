<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin.core.features.events._default" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 thansitional//EN" "http://www.w3.org/th/xhtml1/DTD/xhtml1-thansitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=1024px, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>DayData</title>
    <!-- Stylesheets -->
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
    <link rel="Stylesheet" href="../../../../required/css/jquery.alerts.css" />
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <script src="../../../../required/js/jquery.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
        <script src="../../../../required/js/jquery.alerts.js"></script>
       <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <!--[if lt IE 9]>
    <script src="../../../../required/js/html5shiv.js"></script>
    <![endif]-->
    <meta charset="UTF-8">
    <script type="text/javascript">
        $(document).bind('mapsReady', function () {
            $('#event_popup').hide();
            $('.minimap').each(function (index) {
                var lat = $(this).attr("lat");
                var long = $(this).attr("long");
                var latlng = new google.maps.LatLng(lat, long);
                var myOptions = {
                    zoom: 15,
                    center: latlng,
                    disableDefaultUI: true,
                    scrollwheel: false,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                }
                map = new google.maps.Map(this, myOptions);
            });
        });
        function popItUp() {
            modalPopup("center", 100, 500, 10, "#666666", 40, "#FFFFFF", "#333333", 2, 5, 300, "add_filter.aspx", "../../../../required/images/loading.gif")
        }
        </script>
</head>
<body>
    <nav id="primary">
      <ul>
        <li>
          <a href="../../../default.aspx">
            <span class="glyph dashboard"></span>
            Dashboard
          </a>
        </li>
        <li class="active">
          <a href="../default.aspx">
            <span class="glyph windows"></span>
            Features
          </a>
        </li>
        <li >
          <a href="../../settings/default.aspx">
            <span class="glyph cog"></span>
            Settings
          </a>
        </li>
        <li class="bottom">
          <a href="../../../login/default.aspx?set=logout">
            <span class="glyph quit"></span>
            Log out
          </a>
        </li>
      </ul>
    </nav>
    <nav id="secondary">
      <ul>
      <li ><a href="../default.aspx">Feature Dashboard</a></li>
  <li><a href="../announcements/default.aspx">Announcements</a></li>
  <li><a href="../lunchmenu/default.aspx">Lunch Menu</a></li>
  <li><a href="#">Pages</a></li>
  <li class="active"><a href="default.aspx">Events</a></li>
  <li><a href="../grades/default.aspx">Grades</a></li>  
</ul>
      
      <div id="notifications">
        <ul>
        </ul>
      </div>
    </nav>
    <section id="maincontainer">
      <div id="main" class="container_12">
      <div class="quick-actions">
  <a href="new_event.aspx">
    <span class="glyph new"></span>
    Add Event
  </a>
  
  <a onclick="popItUp();" style="cursor: pointer">
    <span class="glyph new"></span>
    Add Filter
  </a>
</div>
        <div class="box">
  <div class="box-header">
    <h1>Events</h1>
    
    <ul>
      <li class="active"><a href="#one">Today&#39;s Events</a></li>
      <li><a href="#updater">Updater</a></li>
      <li><a href="#two">calendar</a></li>
      <li><a href="#three">Settings</a></li>
    </ul>
  </div>
  
  <div class="box-content">
    <div class="tab-content" id="one">
      
      
        <table class="datatable">
        <thead>
        <tr><th>ID</th><th>Title</th><th>Time</th><th>Description</th><th>Added By</th><th>Location</th><th></th><th></th></tr>
        </thead>
        <tbody>
        <asp:Panel ID="tablePanel" runat="server"></asp:Panel>
        </tbody>
        </table>

        <div class="clear"></div>
        
        
    </div>
    
    <div class="tab-content" id="two">
    <br />
    <br />
    <br />

       <div id="calendar">
  </div>
    </div>
    
    <div class="tab-content" id="three">
      <p>settings go here</p>
    </div>
    <div class="tab-content" id="updater">
    
    </div>
  </div>
</div>
<div id="event_popup">
<h1 id="eventitle">Event Title</h1>
<p id="eventdesc">
aidoeainfdoewqandoindndqwndiwqioesfneiwoasdfnwqndwq
</p>
<div id="mappopup" style="width: 80px; height: 180px;"></div>
</div>
<form runat="server" id="mainform">
      <div class="box grid_6">
                  <div class="box-header">
                     <h1>Event Filters</h1>
                  </div>
                  <table class="datatable">
                     <thead>
                        <tr>
                           <th>Filter</th>
                           <th>Location</th>
                           <th>Map</th>
                        </tr>
                     </thead>
                     <tbody>
                        <asp:Panel ID="filters_table" runat="server"></asp:Panel>
                        <script type="text/javascript">$(document).trigger('mapsReady');</script>
                     </tbody>
                  </table>
                  <div class="action_bar">
                      <asp:DropDownList id="filter_selections" runat="server" Height="173px" 
                          Width="237px" AutoPostBack="True"></asp:DropDownList>
                      <asp:Button ID="Button1" runat="server" CssClass="button plain" 
                          onclick="Button1_Click" Text="Edit" />
                      <asp:Button ID="Button2" runat="server" CssClass="button danger" 
                          onclick="Button2_Click" Text="Delete" />
                      
                  </div>
               </div>
               <div class="box grid_6">
                  <div class="box-header">
                     <h1>Scoreboard</h1>
                  </div>
                 
               </div>
               </form>
    </section>
    <script src="../../../../required/js/jqueryui.min.js"></script>
    <script src="../../../../required/js/jquery.cookies.js"></script>
    <script src="../../../../required/js/jquery.pjax.js"></script>
    <script src="../../../../required/js/formalize.min.js"></script>
    <script src="../../../../required/js/jquery.metadata.js"></script>
    <script src="../../../../required/js/jquery.validate.js"></script>
    <script src="../../../../required/js/jquery.checkboxes.js"></script>
    <script src="../../../../required/js/jquery.selectskin.js"></script>
    <script src="../../../../required/js/jquery.fileinput.js"></script>
    <script src="../../../../required/js/jquery.datatables.js"></script>
    <script src="../../../../required/js/jquery.sourcerer.js"></script>
    <script src="../../../../required/js/jquery.tipsy.js"></script>
    <script src="../../../../required/js/jquery.calendar.js"></script>
    <script src="../../../../required/js/jquery.inputtags.min.js"></script>
    <script src="../../../../required/js/jquery.wymeditor.js"></script>
    <script src="../../../../required/js/jquery.livequery.js"></script>
    <script src="../../../../required/js/jquery.highcharts.js"></script>
    <script src="../../../../required/js/jquery.chosen.js"></script>
    <script src="../../../../required/js/application.js"></script>
    <script src="../../../../required/js/modal.popup.js"></script>
    <GAnalytics:Analytics ID="analytics" runat="server" />
</body>
</html>

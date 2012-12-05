<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_event.aspx.cs" Inherits="DayData.admin.core.features.events.new_event" %>
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
    <link rel="stylesheet" href="../../../../required/css/main.css" />
    <link rel="Stylesheet" href="../../../../required/css/timePicker.css" />
    <link rel="Stylesheet" href="../../../../required/css/selectboxes.css" />
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <!--[if lt IE 9]>
    <script src="../../../../required/js/html5shiv.js"></script>
    <![endif]-->
    <meta charset="UTF-8">
    <script>
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
          <a href="/forms/forms">
            <span class="glyph cog"></span>
            Settings
          </a>
        </li>
        <li class="bottom">
          <a href="/login">
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
  <li class="active"><a href="#">Events</a></li>
  <li><a href="../grades/default.aspx">Grades</a><asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
          </li>  
</ul>
      
      <div id="notifications">
        <ul>
        </ul>
      </div>
    </nav>
    <section id="maincontainer">
      <div id="main" class="container_12">
        <div class="box">
        <div class="box-header"><h1><a href="default.aspx">Event System</a> -> Add an Event</h1></div>
        <div class="box-content">
        <form id="addanevent" runat="server">
        <input type="hidden" id="long_lat" name="long_lat" runat="server" />
        <div class="column-left">
        <p>
        
            <asp:TextBox ID="title" placeholder="Event Title" runat="server"></asp:TextBox>
        
        </p>
                 <p>
                     <asp:TextBox ID="date" placeholder="Event Date" class="datepicker {validate:{required:true}}" 
                         runat="server"></asp:TextBox>
           
            <span class="icon calendar"></span>
            <small>Please use the format MM/DD/YEAR</small>
          </p>
          <p>
          <asp:TextBox ID="starttime" placeholder="Event Time Start" runat="server" class="{validate: {required:true}}"></asp:TextBox>
          <span class="icon clock"></span>
          <span><asp:CheckBox runat="server" Text="No Event End Time" Checked="true" 
                  ID="checkbox" AutoPostBack="True" oncheckedchanged="checkbox_CheckedChanged" /></span>
          </p>
          <asp:PlaceHolder ID="placeholder" Visible="false" runat="server">
          
          <p>
          <asp:TextBox ID="endtime" placeholder="Event Time End" runat="server"></asp:TextBox>
          <span class="icon clock"></span>
          </p>
          
          
          </asp:PlaceHolder>
        <p>
        <asp:TextBox ID="desc" runat="server" TextMode="MultiLine" placeholder="Event Description..."></asp:TextBox>
        </p>
        </div>
        <div class="column-right">
        <div class="combined">
        <p class="large">
        <asp:TextBox ID="loc" runat="server" placeholder="Location..."></asp:TextBox>
        <small>Please enter the most accurate location name (including city and state)</small>
        </p>
        <p class="small last-child">
        <asp:TextBox ID="room" Enabled="false" runat="server" placeholder="Room #"></asp:TextBox>
        </p>
        </div>
        <p>
                                              <asp:DropDownList ID="filters" runat="server" 
                                      onselectedindexchanged="filters_SelectedIndexChanged" AutoPostBack="True">
                                  <asp:ListItem>Defined Above</asp:ListItem>
                                  </asp:DropDownList></p>
        <p>
        <div style="height: 250px" id="mappreview"></div>
        </p>
        </div>
        <div class="clear"></div>
        <div class="action_bar">
            <asp:Button ID="Button1" runat="server" CssClass="blue button" 
                Text="Add Event" onclick="Button1_Click" />
        </div>
        </form>
        </div>
        </div>
      </div>
    </section>
    <script src="../../../../required/js/jquery.min.js"></script>
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
    <script src="../../../../required/js/jquery.timePicker.min.js"></script>
    <script src="../../../../required/js/eventmaps.js"></script>
    <script src="../../../../required/js/eventTime.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    <script src="../../../../required/js/application.js"></script>
    <GAnalytics:Analytics ID="analytics" runat="server" />
</body>
</html>

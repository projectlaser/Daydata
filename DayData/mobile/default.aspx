<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.mobile._default" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>
<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <link rel="Stylesheet" type="text/css" href="../required/css/TJHS.min.css" />
    <link rel="Stylesheet" type="text/css" href="../required/css/jquery.mobile.structure-1.1.1.min.css" />
        <script type="text/javascript" src="../required/js/mobilejquery.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div data-role="page" data-theme="a">
    
    <div data-role="header">
    <h1 id="headerText" runat="server"></h1>
    </div>

    <div data-role="content">
    		<ul data-role="listview" data-inset="true">
			<li><a href="features/announcements.aspx"><img src="../required/images/small_announcement.png" alt="Announcements" class="ui-li-icon ui-corner-none" />View Announcements</a></li>
			<li><a href="features/lunchmenu.aspx"><img src="../required/images/small_food.png" alt="Lunch Menu" class="ui-li-icon" />View Lunch Menu</a></li>
			<li><a href="features/events.aspx"><img src="../required/images/events.png" alt="Daily Events" class="ui-li-icon" />View Daily Events</a></li>
		    <li><a href="http://project-laser.com/tjhs/desktop/default.aspx"><img src="../required/images/redirect.png" alt="View Desktop Version" class="ui-li-icon" />View Desktop Version</a></li>
        </ul>
    
    </div>
    </div>
    <GAnalytics:Analytics ID="anayltics" runat="server" />
    </form>
</body>
</html>

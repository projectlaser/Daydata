<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin.core.features.lunchmenu._default" %>
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
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <!--[if lt IE 9]>
    <script src="../../../../required/js/html5shiv.js"></script>
    <![endif]-->
    <meta charset="UTF-8">
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
  <li class="active"><a href="#">Lunch Menu</a></li>
  <li><a href="#">Pages</a></li>
  <li><a href="../events/default.aspx">Events</a></li>
  <li><a href="../grades/default.aspx">Grades</a></li>  
</ul>
      
      <div id="notifications">
        <ul>
        </ul>
      </div>
    </nav>

    <section id="maincontainer">
        <form id="form1" runat="server">
      <div id="main" class="container_12">

        <div class="box">
  <div class="box-header">
    <h1>Lunch menu</h1>
    
    <ul>
      <li class="active"><a href="#one">LUNCH Status</a></li>
      <li><a href="#settings">Settings</a></li>
    </ul>
  </div>
  
  <div class="box-content">
    <div class="tab-content" id="one">
<p>Currently, there is not too many features we can put here. However we have many ideas planned as soon as they become available from Nutritional Services.</p>

        <div class="clear"></div>
        
        
    </div>
    
    <div class="tab-content" id="settings">
    <p>Beehive : Enabled</p>
    </div>
    
  </div>
</div>

<div class="box column-left">
<div class="box-header"><h1>Today's Lunch Menu</h1></div>
<table>
        <tbody>
        <tr><td>
        Today
        </td><td>
                <asp:Label ID="TodayLabel" runat="server" Text="Label"></asp:Label>
            </td></tr>
        <asp:Panel ID="lunchTodayPanel" runat="server"></asp:Panel>
        </tbody>
        <asp:Button ID="Button1" runat="server" CssClass="button plain" Text="Edit" 
            Visible="False" onclick="Button1_Click" />
        </table></div>

        <div class="box column-right">
<div class="box-header"><h1>Tomorrow's Lunch Menu</h1></div>
<table>
        <tbody>
        <tr><td>
        Tomorrow
        </td><td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td></tr>
        <asp:Panel ID="lunchTomorrowPanel" runat="server"></asp:Panel>
        </tbody>
        <asp:Button ID="Button2" runat="server" CssClass="button plain" Text="Edit" 
            Visible="False" onclick="Button1_Click" />
        </table></div>


      </div>
          <GAnalytics:Analytics ID="analytics" runat="server" />
          </form>
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
    <script src="../../../../required/js/application.js"></script>
</body>
</html>
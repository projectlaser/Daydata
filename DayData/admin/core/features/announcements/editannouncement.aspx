<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editannouncement.aspx.cs"
    Inherits="DayData.admin.core.features.announcements.editannouncement" %>

<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics"
    TagPrefix="GAnalytics" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 thansitional//EN" "http://www.w3.org/th/xhtml1/DTD/xhtml1-thansitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=1024px, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>DayData</title>
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
    <link rel="Stylesheet" href="../../../../required/css/jquery.ibutton.min.css" />
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <script src="../../../../required/js/jquery.min.js"></script>
    <!--[if lt IE 9]>
      <script src="../../../../required/js/html5shiv.js"></script>
      <![endif]-->
    <meta charset="UTF-8" />
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
               <a href="#">
               <span class="glyph windows"></span>
               Features
               </a>
            </li>
            <li>
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
            <li><a href="../default.aspx">Feature Dashboard</a></li>
            <li class="active"><a href="#">Announcements</a></li>
            <li><a href="#">Lunch Menu</a></li>
            <li><a href="#">Pages</a></li>
            <li><a href="../events/default.aspx">Events</a></li>
            <li><a href="#">Viewers</a></li>
            <li><a href="#">Grades</a></li>
         </ul>
         <div id="notifications">
            <ul>
            </ul>
         </div>
      </nav>
    <form runat="server" id="editAnnouncement">
    <input type="hidden" runat="server" id="idOfAnnouncement" />
    <section id="maincontainer" />
    <div id="main" class="container_12">
        <div class="box">
            <div class="box-header">
                <h1>
                    <a href="default.aspx">Announcement System</a> -> Edit Announcement</h1>
                <ul>
                    <li class="active"><a href="#one">Announcement</a></li>
                </ul>
            </div>
            <div class="box-content">
                <div class="tab-content" id="one">
                    <div class="column-left">
                        <p>
                            <asp:TextBox ID="announcemenTitle" TextMode="SingleLine" runat="server" MaxLength="25"></asp:TextBox>
                        </p>
                        <p>
                            <asp:TextBox ID="announcementText" TextMode="MultiLine" runat="server" MaxLength="200"></asp:TextBox>
                        </p>
                        <p>
                            <asp:CheckBox ID="announcementLocked" runat="server" Text="Announcement Locked" />
                        </p>
                        <p style="text-align: center">
                            <asp:Button ID="editButton" runat="server" Text="Edit" CssClass="button blue" OnClick="editButton_Click" />
                        </p>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
            <div class="action_bar">
            </div>
        </div>
        <div class="tab-content" id="three">
        </div>
    </div>
    </section>
    <GAnalytics:Analytics ID="analytics" runat="server" />
    </form>
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
    <script src="../../../../required/js/jquery.ibutton.min.js"></script>
    <script src="../../../../required/js/jquery.easing.1.3.js"></script>
    <script src="../../../../required/js/application.js"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin.pub.pages.features._default" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=1024px, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>DayData</title>
    <link rel="stylesheet" href="../../../required/css/reset.css" />
    <link rel="stylesheet" href="../../../required/css/icons.css" />
    <link rel="stylesheet" href="../../../required/css/formalize.css" />
    <link rel="stylesheet" href="../../../required/css/checkboxes.css" />
    <link rel="stylesheet" href="../../../required/css/sourcerer.css" />
    <link rel="stylesheet" href="../../../required/css/jqueryui.css" />
    <link rel="stylesheet" href="../../../required/css/tipsy.css" />
    <link rel="stylesheet" href="../../../required/css/calendar.css" />
    <link rel="stylesheet" href="../../../required/css/tags.css" />
    <link rel="stylesheet" href="../../../required/css/fonts.css" />
    <link rel="Stylesheet" href="../../../required/css/960.css" />
    <link rel="stylesheet" href="../../../required/css/main.css" />
    <link rel="stylesheet" media="all and (orientation:portrait)" href="../../../required/css/portrait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="shortcut icon" href="../../../required/images/favicon.png" type="image/png" />
    <!--[if lt IE 9]>
    <script src="../../../required/js/html5shiv.js"></script>
    <![endif]-->
    <meta charset="UTF-8">
</head>
<body>
    <form id="form1" runat="server">
    <nav id="primary">
      <ul>
        <li>
          <a href="../../default.aspx">
            <span class="glyph dashboard"></span>
            Dashboard
          </a>
        </li>
        <li class="active">
          <a href="default.aspx">
            <span class="glyph windows"></span>
            Features
          </a>
        </li>
        <li >
          <a href="../settings/default.aspx">
            <span class="glyph cog"></span>
            Settings
          </a>
        </li>
        <li class="bottom">
          <a href="../../login/default.aspx?set=logout">
            <span class="glyph quit"></span>
            Log out
          </a>
        </li>
      </ul>
    </nav>
    <!-- Secondary navigation -->
    <nav id="secondary">
      <ul>
      <li class="active"><a href="#">Feature Dashboard</a></li>
  <li><a href="announcements/default.aspx">Announcements</a></li>
  <li><a href="lunchmenu/default.aspx">Lunch Menu</a></li>
  <li><a href="#">Pages</a></li>
  <li><a href="events/default.aspx">Events</a></li>
  <li><a href="grades/default.aspx">Grades</a></li>  
</ul>
      
      <div id="notifications">
        <ul>
        </ul>
      </div>
    </nav>
    <section id="maincontainer">
      <div id="main" class="container_12">

<div class="box">    
  <div class="box-header">
  <span class="glyph chart"></span>
    <h1>Features</h1>
  </div>

  <table>
    <tbody>
      <tr>
      
      <td>
      <asp:Label ID="featureName" runat="server" Text="FeatureName"></asp:Label>
      </td>
      <td>
      <asp:Label ID="SchoolName" runat="server" Text="Label"></asp:Label>
      </td>
      <td>
      <asp:Label ID="Status" runat="server" Text="Status"></asp:Label>
      </td>
      </tr>
      

    </tbody>
  </table>
</div>
      
      </div>
    </section>
    <script src="../../../required/js/jquery.min.js"></script>
    <script src="../../../required/js/jqueryui.min.js"></script>
    <script src="../../../required/js/jquery.cookies.js"></script>
    <script src="../../../required/js/jquery.pjax.js"></script>
    <script src="../../../required/js/formalize.min.js"></script>
    <script src="../../../required/js/jquery.metadata.js"></script>
    <script src="../../../required/js/jquery.validate.js"></script>
    <script src="../../../required/js/jquery.checkboxes.js"></script>
    <script src="../../../required/js/jquery.selectskin.js"></script>
    <script src="../../../required/js/jquery.fileinput.js"></script>
    <script src="../../../required/js/jquery.datatables.js"></script>
    <script src="../../../required/js/jquery.sourcerer.js"></script>
    <script src="../../../required/js/jquery.tipsy.js"></script>
    <script src="../../../required/js/jquery.calendar.js"></script>
    <script src="../../../required/js/jquery.inputtags.min.js"></script>
    <script src="../../../required/js/jquery.wymeditor.js"></script>
    <script src="../../../required/js/jquery.livequery.js"></script>
    <script src="../../../required/js/jquery.highcharts.js"></script>
    <script src="../../../required/js/jquery.chosen.js"></script>
    <script src="../../../required/js/application.js"></script>
    <GAnalytics:Analytics ID="analytics" runat="server" />
    </form>
</body>
</html>
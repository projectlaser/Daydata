<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin._default" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=1024px, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>DayData</title>
    <link rel="stylesheet" href="../required/css/reset.css" />
    <link rel="stylesheet" href="../required/css/icons.css" />
    <link rel="stylesheet" href="../required/css/formalize.css" />
    <link rel="stylesheet" href="../required/css/checkboxes.css" />
    <link rel="stylesheet" href="../required/css/sourcerer.css" />
    <link rel="stylesheet" href="../required/css/jqueryui.css" />
    <link rel="stylesheet" href="../required/css/tipsy.css" />
    <link rel="stylesheet" href="../required/css/calendar.css" />
    <link rel="stylesheet" href="../required/css/tags.css" />
    <link rel="stylesheet" href="../required/css/fonts.css" />
    <link rel="Stylesheet" href="../required/css/960.css" />
    <link rel="stylesheet" href="../required/css/main.css" />
    <link rel="stylesheet" media="all and (orientation:portrait)" href="../required/css/portrait.css" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="../apple-touch-icon-ipad3.png" />
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="../apple-touch-icon-iphone.png" />
    <link rel="apple-touch-icon-precomposed" href="../apple-touch-icon-iphone4.png" />
    <link rel="apple-touch-icon-precomposed" href="../apple-touch-icon-precomposed.png" />
    <link rel="shortcut icon" href="../required/images/favicon.png" type="image/png" />
    <script type="text/javascript" src="../required/js/jquery.min.js"></script>
    <!--[if lt IE 9]>
    <script src="../required/js/html5shiv.js"></script>
    <![endif]-->
</head>
<body>
<script type="text/javascript">
function updateNow(d)
{
    editfield.value = "updateNow("+d+")";
    __doPostBack('', '');
}
function deleteNow(d)
{
    editfield.value = "deleteNow(" + d + ")";
    __doPostBack('', '');
}
function emergencyShutoff() {
    editfield.value = "shutoff";
    __doPostBack('', '');
}
</script>
    <nav id="primary">
      <ul>
        <li class="active">
          <a href="default.aspx">
            <span class="glyph dashboard"></span>
            Dashboard
          </a>
        </li>
        <li >
          <a href="core/features/default.aspx">
            <span class="glyph windows"></span>
            Features
          </a>
        </li>
        <li >
          <a href="core/settings/default.aspx">
            <span class="glyph cog"></span>
            Settings
          </a>
        </li>
        <li class="bottom">
          <a href="login/default.aspx?set=logout">
            <span class="glyph quit"></span>
            Log out
          </a>
        </li>
      </ul>
    </nav>
    <nav id="secondary">
      <ul>
  <li class="active"><a href="default.aspx">Dashboard</a></li>
  <li><a href="logs.aspx">System logs</a></li>  
</ul>
    </nav>
    <form id="form" runat="server">
    <section id="maincontainer">
      <div id="main" class="container_12">
      
      <div class="quick-actions">
  <a style="cursor: pointer" onclick="emergencyShutoff();">
    <span class="glyph switch"></span>
    Emergency Shut Off
  </a>
</div>
<input type="hidden" id="editfield" name="editfield" />
<div class="box">    
  <div class="box-header">
    <h1>DayData information</h1>
  </div>

  <table>
    <tbody>
      <tr><td>School Name</td><td>
          <asp:Label ID="SchoolName" runat="server" Text="Label"></asp:Label>
          </td></tr>
      <tr><td>District Name</td><td>
          <asp:Label ID="DistrictName" runat="server" Text="Label"></asp:Label>
          </td></tr>
      <tr><td>School ID</td><td>
          <asp:Label ID="schoolID" runat="server" Text="SID"></asp:Label>
          </td></tr>
      <tr><td>District ID</td><td>
          <asp:Label ID="DistrictID" runat="server" Text="Label"></asp:Label>
          </td></tr>
      <tr><td>Color</td><td>
          <asp:Label ID="ColorLabel" runat="server" Text="Label"></asp:Label>
          </td></tr>
          <tr><td>Second Color</td><td>
          <asp:Label ID="SecondColorLabel" runat="server" Text="Label"></asp:Label>
          </td></tr>
    </tbody>
  </table>
</div>
    <div class="box grid_4 column-right">
<div class="box-header"><h1>DayData Status</h1></div>
<div class="box-content">
<div class="logo"></div>
<ul class="statistics">
<li>
<a><span><asp:Label ID="version" runat="server" Text="0.0.0.0"></asp:Label></span>DayData Version</a>
<a><span class="check"><img alt="DayData by Project Laser" src="../required/img/58.png" /></span>DayData System</a>
</li>
</ul>
        </div>
</div>
<div class="box grid_8 left">
<div class="box-header"><h1>Updaters</h1></div>

    <table class="datatable">
    <thead>
    <tr>
    <th>Type</th>
    <th>Using</th>
    <th>At Time</th>
    <th>Next Fire</th>
    </tr>
    </thead>
    <tbody>
    <asp:Panel ID="panelUpdaters" runat="server"></asp:Panel>
    </tbody>
    </table></div>
      
      </div>
    </section>
        <GAnalytics:Analytics ID="analytics" runat="server" />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    </form>
    <script src="../required/js/jqueryui.min.js" type="text/javascript"></script>
    <script src="../required/js/jquery.cookies.js" type="text/javascript"></script>
    <script src="../required/js/jquery.pjax.js" type="text/javascript"></script>
    <script src="../required/js/formalize.min.js" type="text/javascript"></script>
    <script src="../required/js/jquery.metadata.js" type="text/javascript"></script>
    <script src="../required/js/jquery.validate.js" type="text/javascript"></script>
    <script src="../required/js/jquery.checkboxes.js" type="text/javascript"></script>
    <script src="../required/js/jquery.selectskin.js" type="text/javascript"></script>
    <script src="../required/js/jquery.fileinput.js" type="text/javascript"></script>
    <script src="../required/js/jquery.datatables.js" type="text/javascript"></script>
    <script src="../required/js/jquery.sourcerer.js" type="text/javascript"></script>
    <script src="../required/js/jquery.tipsy.js" type="text/javascript"></script>
    <script src="../required/js/jquery.calendar.js" type="text/javascript"></script>
    <script src="../required/js/jquery.inputtags.min.js" type="text/javascript"></script>
    <script src="../required/js/jquery.wymeditor.js" type="text/javascript"></script>
    <script src="../required/js/jquery.livequery.js" type="text/javascript"></script>
    <script src="../required/js/jquery.highcharts.js" type="text/javascript"></script>
    <script src="../required/js/jquery.chosen.js" type="text/javascript"></script>
    <script src="../required/js/application.js" type="text/javascript"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin.login._default" %>
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
    <link rel="stylesheet" href="../../../../required/css/main.css" />
    <link rel="shortcut icon" href="../../required/images/favicon.png" type="image/png" />
</head>
<body id="login">

  
    <div id="login_container">
    <img alt="DayData by project laser" src="../../required/img/logo.png" />
    <asp:Panel ID="panel" runat="server"></asp:Panel>
  <div id="login_form">
  <form id="form2" runat="server">
  <p>
  <input runat="server" type="text" id="username" name="username" placeholder="Username" class="{validate: {required: true}}" />
  </p>
        <p>
        <input runat="server" type="password" id="password" name="password" placeholder="Password" class="{validate: {required: true}}" />
      </p>
      <asp:Button ID="submit" runat="server" CssClass="button blue" OnClick="Button1_Click" />
          <GAnalytics:Analytics ID="analytics" runat="server" />
  </form>
  </div>
  </div>
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
</body>
</html>

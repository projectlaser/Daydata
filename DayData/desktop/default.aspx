<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.desktop._default" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
    <link rel="Stylesheet" href="../required/css/metrotiles.css" />
    <link rel="Stylesheet" href="../required/css/desktop.css" />
    <link rel="Stylesheet" href="../required/js/tiles.js" />
    <script src="../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../required/js/jquery.simpleWeather.min.js" type="text/javascript"></script>
    <script src="../required/js/desktop.js?V=1" type="text/javascript"></script>
    <link rel="icon" type="image/png" href="../required/images/favicon.png" />
</head>
<body>
<script type="text/javascript">
    $(function () {
        $('body').hide().fadeIn('fast');
        $('a').click(function () {
            var link = $(this).attr('href');
            $('body').fadeOut('fast', function () {
                window.location.href = link;
            });
            return false;
        });

    });
</script>
    <form id="form1" runat="server">
     <div id="top_nav" class="topbar fixedbar">
     <div class="topbar-inside topbar-inner">
     <div class="container" style="height: 45px">
     <a href="default.aspx" class="left">
     <asp:Image runat="server" ID="top_image" />
     </a>
     <a href="default.aspx" class="title"><asp:Label ID="name_label" runat="server"></asp:Label></a>
     </div>
     </div>

     </div>
     <div class="tiles">
     <div class="section">
        <center><b style="color: #FB5C61; font-size: 16px;">Check out the new Grade Checker!</b></center>
     <asp:Panel ID="tilePanel" runat="server"></asp:Panel>
     </div>
     </div>
     <div class="copyright">
     <asp:Label ID="namelabel2" runat="server"></asp:Label> powered by DayData from Project Laser Copyright 2012
    
</div>
     <div class="copyright" style="opacity: 1.0; bottom: 14px;">
    <asp:HyperLink NavigateUrl="~/desktop/about.aspx" runat="server" Text="About DayData" ID="about"></asp:HyperLink>
    
    | <asp:HyperLink NavigateUrl="mailto:anthony@project-laser.com;area735@cbcsd.org?subject=Feedback" runat="server" Text="Contact / Feedback" ID="HyperLink1"></asp:HyperLink>
</div>


     <GAnalytics:Analytics ID="analytics" runat="server" />
    </form>
</body>
</html>

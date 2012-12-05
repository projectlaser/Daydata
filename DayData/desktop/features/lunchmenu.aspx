<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lunchmenu.aspx.cs" Inherits="DayData.desktop.features.lunchmenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<link rel="Stylesheet" href="../../required/css/metrotiles.css" />
    <link rel="Stylesheet" href="../../required/css/desktop_view.css" />
    <link rel="Stylesheet" href="../../required/js/tiles.js" />
    <link rel="stylesheet" href="../../required/css/reset.css" />
    <link rel="stylesheet" href="../../required/css/icons.css" />
    <link rel="stylesheet" href="../../required/css/formalize.css" />
    <link rel="stylesheet" href="../../required/css/checkboxes.css" />
    <link rel="stylesheet" href="../../required/css/sourcerer.css" />
    <link rel="stylesheet" href="../../required/css/jqueryui.css" />
    <link rel="stylesheet" href="../../required/css/tipsy.css" />
    <link rel="stylesheet" href="../../required/css/calendar.css" />
    <link rel="stylesheet" href="../../required/css/tags.css" />
    <link rel="stylesheet" href="../../required/css/fonts.css" />
    <link rel="Stylesheet" href="../../required/css/960.css" />
    <link rel="stylesheet" href="../../required/css/main.css" />
    <link rel="Stylesheet" href="../../required/css/selectboxes.css" />
    <link rel="icon" type="image/png" href="../../required/images/favicon.png" />
    <script src="../../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../required/js/jquery.tipsy.js" type="text/javascript"></script>
    <script src="../../required/js/jquery.chosen.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="../../required/images/favicon.png" type="image/png" />
    <style type="text/css">
    .table
    {
-moz-border-radius: 15px;
border-radius: 15px;
    }
            .center
    {
        margin: 0px auto;
        width: 35%;
        text-align:center;
        box-shadow: 0 1px 3px rgba(0, 0, 0, .2);
    }
    
    .bottom_normal
    {
        background-image: url('../../required/images/normal.png');
        width: 37px;
        height: 100%;
    }
    .bottom_normal:hover
    {
        background-image: url('../../required/images/hover.png');
        width: 37px;
        height: 100%;
    }
    .bottom_today
    {
                background-image: url('../../required/images/selected.png');
        width: 37px;
        height: 100%;
        color:White;
    }
    </style>
</head>
<body>
<script type="text/javascript">
    $(function () {
        $('select').parent().each(function (index) {
            $(this).css('position', 'relative');
            $(this).css('z-index', 99 - index);
        });
        $('select').chosen();

        $('.bottom_normal').hover(function () {
            $(this).css('background-image', 'url(../../required/images/hover.png)');
        });
        $('.bottom_normal').mouseleave(function () {
            $(this).css('background-image', 'url(../../required/images/normal.png)');
        });
        $('td').click(function () {
            $(this).css('backgroundColor', '#000');
        });
        $('.bottom_normal').click(function () {
            alert('selected');
            $(this).css('background-image', 'url(../../required/images/selected.png)');

        });
        $('.bottom_normal').mousedown(function () {
            var text = $(this).text;
            alert(text);
        });
    });
    function activated() {
            var p = $('#combo').val();
            window.location = "lunchmenu.aspx?date=" + p;
    }
</script>
    <form id="form1" runat="server">
     <div id="top_nav" class="topbar fixedbar">
     <div class="topbar-inside topbar-inner">
     <div class="container" style="height: 45px">
     <a href="../../default.aspx" class="left">
     <asp:Image runat="server" ID="top_image" />
     </a>
     <a href="../../default.aspx" class="title"><asp:Label ID="name_label" runat="server"></asp:Label></a>
         <br />
         <br />
         <br />
     </div>
     </div>

     </div>
     <div class="tiles">
     <div class="section">
     <div><a class="nav_back" style="float:left;" href="../default.aspx"></a></div>
     <div class="box center">
     <div class="box-header">
     <h1><asp:Label ID="Date" runat="server" Text="Friday, November 16th"></asp:Label></h1>
     </div>
     <div class="box-content">
          <table>
     <tbody>
       <asp:Panel id="panel" runat="server"></asp:Panel>
     </tbody>
     </table>
     </div>
     </div>
     <br />
     <br />
     <div class="box center" style="width: 30%">
     <div class="box-header"><h1>Select a date</h1></div>
     <div class="box-content">
     <select onchange="activated();" runat="server" id="combo" style="width: 100%"></select>
     </div>
     </div>

    

    
     </div></div>    </form>
</body>
</html>

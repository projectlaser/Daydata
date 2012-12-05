<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="announcements.aspx.cs" Inherits="DayData.desktop.features.announcements" %>

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
    <link rel="stylesheet" href="../../required/css/fonts.css" />
    <link rel="Stylesheet" href="../../required/css/960.css" />
    <link rel="stylesheet" href="../../required/css/main.css" />
    <link rel="icon" type="image/png" href="../../required/images/favicon.png" />
    <script src="../../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../required/js/desktop.js?V=1" type="text/javascript"></script>
    <script src="../../required/js/jquery.tipsy.js" type="text/javascript"></script>
    <link rel="shortcut icon" href="../../required/images/favicon.png" type="image/png" />
    <style type="text/css">
        .table {
            -moz-border-radius: 15px;
            border-radius: 15px;
        }

        .center {
            margin: 0px auto;
            width: 70%;
            text-align: center;
        }
    </style>
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
                    <a href="../default.aspx" class="left">
                        <asp:Image runat="server" ID="top_image" />
                    </a>
                    <a href="../default.aspx" class="title">
                        <asp:Label ID="name_label" runat="server"></asp:Label></a>
                </div>
            </div>

        </div>
        <div class="tiles">
            <div class="section">
                <div><a style="float: left" class="nav_back" href="../default.aspx"></a></div>
                <div class="box center">
                    <div class="box-header"><span class="glyph calendar"></span>
                        <h1>Announcements for
                            <asp:Label runat="server" ID="dateLabel"></asp:Label></h1>
                    </div>
                    <table class="table">
                        <tbody>
                            <asp:Panel ID="tablePanel" runat="server"></asp:Panel>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="grades.aspx.cs" Inherits="DayData.desktop.features.grades" %>

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
    <link rel="Stylesheet" href="../../required/css/main.css" />
    <link rel="icon" type="image/png" href="../../required/images/favicon.png" />
    <script src="../../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../required/js/desktop.js?V=1" type="text/javascript"></script>
    <script src="../../required/js/jquery.tipsy.js" type="text/javascript"></script>
    <script src="../../required/js/jquery.datatables.js" type="text/javascript"></script>
    <script src="../../required/js/application.js" type="text/javascript"></script>
    <style type="text/css">
        .table
        {
            -moz-border-radius: 15px;
            border-radius: 15px;
        }

        .center
        {
            margin: 0px auto;
            width: 20%;
            text-align: center;
        }

        .event_short
        {
            width: 60%;
            display: inline;
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
                <a style="float: left" class="nav_back" href="../default.aspx" runat="server" id="backbutton"></a>
                <div class="box center" runat="server" id="login_box">
                    <div class="box-header">
                        <h1>Grade Checker</h1>
                    </div>
                    <div class="box-content">
                       <asp:PlaceHolder ID="error_messages" runat="server" />
                        <p>
                            <asp:TextBox ID="usernameBox" runat="server" MaxLength="25" placeholder="Username"></asp:TextBox>
                        </p>
                        <p>
                            <asp:TextBox ID="passwordBox" runat="server" TextMode="Password" MaxLength="25" placeholder="Password"></asp:TextBox>
                        </p>
                    </div>

                    <div class="action_bar">
                        

                        <asp:Button ID="Button1" runat="server" CssClass="button blue" OnClick="Button1_Click" Text="Login" />
                        

                    </div>
                </div>
                <div class="box" style="width: 10%; float: right; display: none;"  runat="server" id="logout_box">
                    <div class="box-header"><h1>Logout</h1></div>
                    <div class="box-content" style="text-align: center"><asp:Button CssClass="button blue" ID="logout_button" runat="server"  Text="Logout" OnClick="logout_button_Click"/></div>
                    </div>
                <asp:PlaceHolder ID="gradeShower" runat="server"></asp:PlaceHolder>
                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>

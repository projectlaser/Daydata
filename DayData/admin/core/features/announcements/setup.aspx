<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="setup.aspx.cs" Inherits="DayData.admin.core.features.announcements.setup" %>
<%@ Register Src="~/admin/core/controls/GoogleAnalytics.ascx" TagName="Analytics" TagPrefix="GAnalytics" %>
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
    <link rel="Stylesheet" href="../../../../required/css/selectboxes.css" />
    <link rel="Stylesheet" href="../../../../required/css/jquery.alerts.css" />
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
   <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <script src="../../../../required/js/jquery.min.js"></script>
    <!--[if lt IE 9]>
    <script src="../../../../required/js/html5shiv.js"></script>
    <![endif]-->
    <meta charset="UTF-8">
</head>
<body>
    <input runat="server" id="alreadySetup" type="hidden" />
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
          <a href="/login">
            <span class="glyph quit"></span>
            Log out
          </a>
        </li>
      </ul>
    </nav>
    <nav id="secondary">
      <ul>
      <li ><a href="../default.aspx">Feature Dashboard</a></li>
  <li class="active"><a href="#">Announcements</a></li>
  <li><a href="#">Lunch Menu</a></li>
  <li><a href="#">Pages</a></li>
  <li><a href="#">Events</a></li>
  <li><a href="#">Viewers</a></li>
  <li><a href="#">Grades</a>
          </li>  
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
            <h1>Setup Autoupdating for Announcements</h1>
            </div>
            <div class="box-content">
            <form id="updater" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>
            <div class="column-right"><p></p><p>
            ID: <asp:TextBox ID="idBox" runat="server" 
                    Enabled="false" CssClass="{validate: {required:true}}"></asp:TextBox>
            </p>            </div>
            <div class="column-left">

            <p>
            How would you like to update the announcements?
            
            <asp:DropDownList ID="how" placeholder="How would you like to update the announcements?" AutoPostBack="true" runat="server">
            <asp:ListItem>Google Docs</asp:ListItem>
            </asp:DropDownList>
            </p>
            <p>
                Share link to the Doc:
            <asp:TextBox ID="link" runat="server" 
                    placeholder="https://docs.google.com/document/d/1pUrfXo6rMjPWn8dMeBVMmqkaw3TAZpOvjgBLqnTftBg/" 
                    AutoPostBack="True" ontextchanged="link_TextChanged" CssClass="{validate: {required:true}}"></asp:TextBox>
            </p>
            <p>
            How often would you like us to update the announcements:<asp:DropDownList 
                    ID="DropDownList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem>Every hour</asp:ListItem>
                    <asp:ListItem>Every 5 hours</asp:ListItem>
                    <asp:ListItem Value="Every 24 hours">Every 24 hours</asp:ListItem>
                </asp:DropDownList>
                <asp:PlaceHolder ID="holder" runat="server" visible="false"><br />
                At: <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="false">
                    <asp:ListItem Value="6">6:00 AM</asp:ListItem>
                    <asp:ListItem Value="7">7:00 AM</asp:ListItem>
                    <asp:ListItem Value="8">8:00 AM</asp:ListItem>
                    <asp:ListItem Value="9">9:00 AM</asp:ListItem>
                    <asp:ListItem Value="10">10:00 AM</asp:ListItem>
                </asp:DropDownList>
                </asp:PlaceHolder>
            </p>
            </div>
            <div class="clear"></div>
            <div class="action_bar">
            <asp:Button ID="Button1" runat="server" CssClass="button blue" onclick="Button1_Click" 
                    Text="Submit Settings" />
            </div>
            </form>
            </div>
            </div>
            <div class="box">
            <div class="box-header"><h1>Example</h1></div>
            <div class="box-content">
            <table><tbody><asp:Panel ID="Panel1" runat="server"></asp:Panel></tbody></table>
            </div>
            </div>
            </form>
      </div>
      
    </section>
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
    <script src="../../../../required/js/jquery.alerts.js"></script>
    <GAnalytics:Analytics ID="analytics" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () { if ($('#alreadySetup').val() == 'true') { jAlert('Warning: An auto announcement updater is already setup, if you setup one again, you will lose all the settings that were previously set', 'Warning: Already setup'); } });
        
    </script>
</body>
</html>

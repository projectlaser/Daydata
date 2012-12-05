<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DayData.admin.core.features.announcements._default" %>
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
    <link rel="Stylesheet" href="../../../../required/css/jquery.ibutton.min.css" />
    <link rel="stylesheet" media="all and (orientation:porthait)" href="../../../../required/css/porthait.css" />
        <link rel="apple-touch-icon-precomposed" sizes="144x144" href="../apple-touch-icon-ipad.png" />
    <link rel="shortcut icon" href="../../../../required/images/favicon.png" type="image/png" />
    <script src="../../../../required/js/jquery.min.js" type="text/javascript"></script>
    <script src="../../../../required/js/modal.popup.js" type="text/javascript"></script>
    <!--[if lt IE 9]>
      <script src="../../../../required/js/html5shiv.js"></script>
      <![endif]-->
    <meta charset="UTF-8" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#edit_announcement").hide();
            $("#desktopCheck").iButton({ change: function ($input) {
                checked("desktop", $input.is(":checked"));
            }
            });
        });
        function editButtonClick(id) {
            editButton.value = "TRUE" + id;
            $("#edit_announcement").show();
            $("#TextBox3").removeAttr("disabled");
            __doPostBack('', '');
        }
        function checked(type, checked) {
            checkedBoxStatus.value = "CHECKED(" + type + "):" + checked;
            __doPostBack('', '');
        }
        function popItUp(id) {
            modalPopup("center", 100, 500, 10, "#666666", 40, "#FFFFFF", "#333333", 4, 5, 300, "delete_page.aspx?id="+id, "../../../../required/images/loading.gif")
        }

        $(document).ready(function () {
            $(document).keyup(function (a) {
                27 == a.keyCode && closePopup(300)
            })
        });
    </script>
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
               <a href="../../settings/default.aspx">
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
            <li><a href="../default.aspx">Feature Dashboard</a></li>
            <li class="active"><a href="#">Announcements</a></li>
            <li><a href="../lunchmenu/default.aspx">Lunch Menu</a></li>
            <li><a href="#">Pages</a></li>
            <li><a href="../events/default.aspx">Events</a></li>
            <li><a href="../grades/default.aspx">Grades</a></li>
         </ul>
         <div id="notifications">
            <ul>
            </ul>
         </div>
      </nav>
   
            <section id="maincontainer" />
            <div id="main" class="container_12" />
            <form runat="server" id="addannouncement">
    <input type="hidden" id="editButton" name="editButton" />
    <input type="hidden" id="checkedBoxStatus" name="checkedBoxStatus" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="notifcation_panel">
            </asp:Panel>
            <div class="box">
                <div class="box-header">
                    <h1>
                        Announcements</h1>
                    <ul>
                        <li class="active"><a href="#one">Updater</a></li>
                        <li><a href="#settings">Settings</a></li>
                    </ul>
                </div>
                <div class="box-content">
                    <div class="tab-content" id="one">
                        <asp:Panel ID="updater_status" runat="server">
                        </asp:Panel>
                        <div class="clear">
                        </div>
                    </div>
                    <div class="tab-content" id="settings">
                    </div>
                </div>
            </div>
            <div class="box">
                <div class="box-header">
                    <h1>
                        Today's Announcements</h1>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button plain" OnClick="LinkButton1_Click"
                        Visible="false"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button plain" OnClick="LinkButton2_Click"
                        Visible="False"></asp:LinkButton>
                </div>
                <table class="datatable">
                    <thead>
                        <tr>
                            <th>
                            </th>
                            <th>
                                Title
                            </th>
                            <th>
                                Content
                            </th>
                            <th class="options">
                                Options
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Panel ID="announcements" runat="server">
                        </asp:Panel>
                    </tbody>
                </table>
                <div class="clear">
                </div>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <div class="box grid_4">
                <div class="box-header">
                    <h1>
                        Quick Add Announcement</h1>
                </div>
                <div class="box-content">
                    <p>
                        <asp:TextBox MaxLength="25" placeholder="Title (You may leave this blank)" ID="TextBox1"
                            runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:TextBox MaxLength="200" TextMode="MultiLine" placeholder="Content" ID="TextBox2"
                            runat="server" CssClass="{validate: {required:true}}"></asp:TextBox>
                    </p>
                    <p>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="Lock this announcement" />
                    </p>
                </div>
                <div class="action_bar">
                    <asp:Button ID="Button1" runat="server" CssClass="button blue" OnClick="Button1_Click"
                        Text="Add Announcement" />
                </div>
                <div class="clear">
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
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
    <script src="../../../../required/js/fix.js"></script>
    <script src="../../../../required/js/jquery.msgbox.min.js"></script>
    <GAnalytics:Analytics ID="analytics" runat="server" />
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (args.get_error() == undefined) {
                fix();
            }
        }
    </script>
</body>
</html>

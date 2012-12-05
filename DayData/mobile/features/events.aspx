<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="events.aspx.cs" Inherits="DayData.mobile.features.events" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title></title>
      <meta name="viewport" content="width=device-width, initial-scale=1" />
              <link rel="Stylesheet" type="text/css" href="../../required/css/TJHS.min.css" />
                  <link rel="Stylesheet" type="text/css" href="../../required/css/jquery.mobile.structure-1.1.1.min.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="../../required/js/helper.js"></script>
    <script type="text/javascript" src="../../required/js/mobilejquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div data-role="page" data-theme="a">
    
    <div data-role="header">
    <h1><asp:Label ID="header" runat="server"></asp:Label></h1>
    <a href="../default.aspx" data-iconpos="notext" data-icon="home"></a>
    </div>

    <div data-role="content">
        <asp:Panel ID="contentPanel" runat="server"></asp:Panel>
    </div>

    </div>

    </form>
</body>
</html>

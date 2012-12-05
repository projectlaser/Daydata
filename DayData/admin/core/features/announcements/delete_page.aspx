<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="delete_page.aspx.cs" Inherits="DayData.admin.core.features.announcements.delete_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Are you sure?</h1>
        <p>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Confirm Delete" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </p>
    </div>
    </form>
</body>
</html>

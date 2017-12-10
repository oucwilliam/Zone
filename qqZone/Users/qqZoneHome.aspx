<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qqZoneHome.aspx.cs" Inherits="qqZoneHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             欢迎：<br />
            <asp:Button ID="BtnUserSubmit" runat="server" Text="注册" OnClick="BtnUserSubmit_Click" />
            <asp:Button ID="BtnUserLogin" runat="server" Text="登录" OnClick="BtnUserLogin_Click" />
        </div>
    </form>
</body>
</html>

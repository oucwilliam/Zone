<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogsInfo.aspx.cs" Inherits="qqZoneHome_LogsInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            日志详情：<br />
            标题：<asp:Label ID="LabTitle" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="LabContents" runat="server" Text=""></asp:Label><br />
            <asp:Button ID ="BtnPreserve" runat="server" Text="编辑" OnClick="BtnPreserve_Click" />
            <asp:Button ID ="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>

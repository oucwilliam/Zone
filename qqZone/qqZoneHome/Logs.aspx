<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logs.aspx.cs" Inherits="qqZoneHome_Logs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>日志：<br />
            <asp:Button ID="BtnWrite" runat="server" Text="写日志" OnClick="BtnWrite_Click" /><br />
            日志列表：<br />
            <asp:Repeater ID="RptLogs" runat="server" OnItemCommand="RptLogs_ItemCommand">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>标题</th>
                    <th>日期</th>
                    <th>详情</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                   <td><%# Eval("Title") %></td> 
                   <td><%# Eval("Date","{0:yyyy年MM月dd日}") %></td>
                     <td><asp:LinkButton runat="server" ID="BtnInfo" CommandName="Info" Text="详情" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                </tr>
                        </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
            <asp:Button ID="btnDown" runat="server" Text="下一页"  OnClick="btnDown_Click"/>
            <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
            <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
            页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
            /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>
            转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="16px"></asp:TextBox>
            <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/><br />
        </div>
    </form>
</body>
</html>

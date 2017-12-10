<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Friends.aspx.cs" Inherits="qqZoneHome_Friends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>好友：<br />
            <asp:Button ID="BtnSure" runat="server" Text="查看好友请求" OnClick="BtnSure_Click" /><br />
            <asp:TextBox ID="TxtAdd" runat="server" Text=""></asp:TextBox>
            <asp:Button ID="BtnAdd" runat="server" Text="添加好友" OnClick="BtnAdd_Click" /><br />
            好友列表：<br />
            <asp:Repeater ID="RptFriends" runat="server" OnItemCommand="RptFriends_ItemCommand">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>好友</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                   <td><%# Eval("Friends") %></td> 
                     <td><asp:LinkButton runat="server" ID="BtnInfo" CommandName="Info" Text="进入他的空间" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                        <td><asp:LinkButton runat="server" ID="BtnDelete" CommandName="Delete" Text="删除好友" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要删除该好友吗？')"></asp:LinkButton></td>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sure.aspx.cs" Inherits="qqZoneHome_Sure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand" >
             <HeaderTemplate>
            <table>
                <tr>
                    <th>用户名</th>
                </tr>
             </HeaderTemplate>
        <ItemTemplate>
                <tr>
                    <td><%# Eval("Friends") %></td>
                    <td><asp:LinkButton runat="server" ID="BtnAgree" CommandName="Agree" Text="同意" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要同意吗？')"></asp:LinkButton></td>
                    <td><asp:LinkButton runat="server" ID="BtnDisagree" CommandName="Disagree" Text="拒绝" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('确定要拒绝吗？')"></asp:LinkButton></td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater><br />
            <asp:Button ID="BtnBack" runat="server" Text="返回" OnClick="BtnBack_Click" />
        </div>
    </form>
</body>
</html>

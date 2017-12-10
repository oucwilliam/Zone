<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Message.aspx.cs" Inherits="qqZoneHome_Message" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>留言板：<br />
            <asp:TextBox ID="TxtMessage" runat="server" Text=""></asp:TextBox>
            <asp:Button ID="BtnAdd" runat="server" Text="留言" OnClick="BtnAdd_Click" /><br />
            <asp:Repeater ID="RptCategory" runat="server" OnItemDataBound="RptCategory_ItemDataBound">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>用户名</th>
                    <th>留言</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                 <td><%#Eval("Friends")%></td>:
                   <td><%#Eval("Contents")%></td> 
                     <td><asp:LinkButton runat="server" ID="btnComment" CommandName="Comment" Text="评论" CommandArgument='<%# Eval("id") %>'></asp:LinkButton></td>
                     <td> <asp:TextBox ID ="TxtNewComment2" runat="server" Text=""  Visible ="false"></asp:TextBox></td>
                    <td><asp:Button ID="BtnSave2" runat="server" Text="评论" OnClick="BtnSave2_Click" Visible="false" /><br /></td>
            <asp:Repeater ID="RptMessage" runat="server"  Visible="true">
                <HeaderTemplate>
                 <table>
                <tr>
                    <th>用户名</th>
                    <th>留言</th>
                </tr>
                 </HeaderTemplate>
                <ItemTemplate>
                  <tr>
                   <td><%# Eval("Friends") %></td>
                   <td><%# Eval("Contents") %></td>
                      
                </tr>
                     
                        </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater>
            <%--嵌套Repeater结束--%>
                   
            <br />
        </ItemTemplate>
    </asp:Repeater>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Me.aspx.cs" Inherits="qqZoneHome_Me" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>个人档：<br />
            真实姓名：<asp:Label ID="LabName" runat="server" Text=""></asp:Label><br />
            生日：<asp:TextBox ID="TxtBirthday" runat="server" Text=""></asp:TextBox><br />
            性别：
            <asp:RadioButton ID="RBtnMan" runat="server" Text="男" GroupName="Sex" />
            <asp:RadioButton ID="RBtnWoman" runat="server" Text="女" GroupName="Sex" /><br />
            年龄：<asp:TextBox ID="TxtAge" runat="server" Text=""></asp:TextBox><br />
            血型：<asp:DropDownList ID="DdlBlood" runat="server">
                  <asp:ListItem >其它</asp:ListItem>
                <asp:ListItem >A</asp:ListItem>
                <asp:ListItem>B</asp:ListItem>
                <asp:ListItem>AB</asp:ListItem>
                <asp:ListItem>O</asp:ListItem>
               </asp:DropDownList> <br />
            星座：<asp:TextBox ID="TxtConstellation" runat="server" Text=""></asp:TextBox><br />
            职业：<asp:TextBox ID="TxtOccupation" runat="server" Text=""></asp:TextBox><br />
            <asp:Button ID="BtnSave" runat="server" Text="保存修改" OnClick="BtnSave_Click" />
        </div>
    </form>
</body>
</html>

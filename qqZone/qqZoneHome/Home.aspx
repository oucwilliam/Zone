<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="qqZoneHome_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div><asp:Label ID="LabName" runat="server" Text=""></asp:Label>的个人空间<br />
            <asp:Button ID="BtnChangePassword" runat="server" Text="修改密码" OnClick="BtnChangePassword_Click" /><br />
            <asp:Button ID="BtnCancel" runat="server" Text="注销" OnClick="BtnCancel_Click" /><br />
            <div id="right">
            <div id="right-2">
            	<ul>
                    <li><p><a href="Logs.aspx" target="mainframe">日志</a></p></li>
                    <li><p><a href="Friends.aspx" target="mainframe">好友</a></p></li>
                    <li><p><a href="Photo.aspx" target="mainframe">相册</a></p></li>
                    <li><p><a href="Me.aspx" target="mainframe">个人档</a></p></li>
                     <li><p><a href="Message.aspx" target="mainframe">留言板</a></p></li>
                </ul>
            </div>
            <div id="right-3"></div>
            </div>
        </div>
        <div id="mp1">
            </div>
            <div id="mp2"><iframe id="mainframe" name="mainframe" style="width: 1000px; height: 500px;" src="Logs.aspx" ></iframe></div>
            <div id="mp3">
                <div id="mp3_1"></div>
            </div>
        
    </form>
</body>
</html>

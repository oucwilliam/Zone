<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Photo.aspx.cs" Inherits="qqZoneHome_Photo" %>
<%@ Register Src="PhotoAlbum.ascx" TagName="PhotoAlbum" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>相册：<br />
           <uc1:PhotoAlbum ID="PhotoAlbum1" runat="server" />
        </div>
    </form>
</body>
</html>

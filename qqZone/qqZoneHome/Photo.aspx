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
            <asp:Button ID="BtnUL" runat="server" Text="上传" OnClick="BtnUL_Click" />
        </div>
         <uc1:PhotoAlbum ID="PhotoAlbum1" runat="server" />
    <div id="UL"  runat="server" visible ="false">
        <label for="text" >上传图片</label> 
            <input id="FileName" type="file" name="files"  runat="server" /><span style="color:#ff6666;"></span><br />
            <asp:Button ID="BtnUpload" runat="server" Text="上传" OnClick="BtnUpload_Click" />
        </div>
    </form>
</body>
</html>

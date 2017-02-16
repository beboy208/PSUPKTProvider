<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PSUUserInfo.aspx.cs" Inherits="TestProvider.PSUUserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            var psuuserInfo1 = new PSUPKTProvider.Model.PSUUserInfo("nontapon.r");
            var psuuserInfo2 = new PSUPKTProvider.Model.PSUUserInfo("nontapon.r");
            
            Response.Write("Hello");
             %>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testtesttesttesttest.aspx.cs" Inherits="TestProvider.testtesttesttesttest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
        PSUPKTProvider.PSUPKTDBProfileProvider pom = new PSUPKTProvider.PSUPKTDBProfileProvider();
        var campuses = pom.GetProfile("iesorn.c");
        Response.Write(campuses + "<br />");
        //foreach (var item in campuses)
        //{
        //    Response.Write(item.NameTH + "<br />");
        //}
        
         %>


    </div>
    </form>
</body>
</html>

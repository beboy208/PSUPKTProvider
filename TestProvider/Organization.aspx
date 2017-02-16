<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organization.aspx.cs" Inherits="TestProvider.Organization" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
            var op = new PSUPKTProvider.PSUOrganizationProvider();
            var campus = op.GetCampus("03");
            if (campus != null)
                Response.Write("Campus = " + campus.NameTH);


            var dep = op.GetDepartment("335");
            if (dep != null)
                Response.Write("Department = " + dep.NameTH);
                
             %>
    </div>
    </form>
</body>
</html>

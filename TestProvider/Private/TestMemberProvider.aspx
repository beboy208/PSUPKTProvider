<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMemberProvider.aspx.cs" Inherits="TestProvider.Private.TestMemberProvider" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>MemberShip Provider: Identity</h1>
            <%
                HttpContext.Current.Response.Write("Name = " + User.Identity.Name + Environment.NewLine);
                HttpContext.Current.Response.Write("GetUserId()=" + User.Identity.GetUserId() + Environment.NewLine);
                HttpContext.Current.Response.Write("GetUserName() = " + User.Identity.GetUserName() + Environment.NewLine);
                HttpContext.Current.Response.Write("AuthenticationType=" + User.Identity.AuthenticationType.ToString() + Environment.NewLine);
                HttpContext.Current.Response.Write("IsAuthenticated=" + User.Identity.IsAuthenticated.ToString() + Environment.NewLine);
                //HttpContext.Current.Response.Write("Cookie =" + ((RolePrincipal)User).CookiePath);
                //HttpContext.Current.Response.Write("ProviderName =" + ((RolePrincipal)User).ProviderName);
            %>
            <br />
            <h1>MemberShip Provider</h1>
            <%
                HttpContext.Current.Response.Write(Membership.ApplicationName);
            %><br />
            <h1>Profile Provider</h1>
            <%
                HttpContext.Current.Response.Write(HttpContext.Current.Profile.ToString() + "<br />");
                //HttpContext.Current.Response.Write(TestProvider.Global.Profile.ToString() + "<br />");
                HttpContext.Current.Response.Write(Profile.UserName + "<br />");
                HttpContext.Current.Response.Write("Is Admin = " + User.IsInRole("Admin").ToString() + "<br />");
                HttpContext.Current.Response.Write("Is Nurse = " + User.IsInRole("Nurse").ToString() + "<br />");
            %><br />
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Faculty.aspx.cs" Inherits="TestProvider.Faculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Code" HeaderText="Code" ReadOnly="True" SortExpression="Code" />
                    <asp:BoundField DataField="NameTH" HeaderText="NameTH" ReadOnly="True" SortExpression="NameTH" />
                    <asp:BoundField DataField="NameEN" HeaderText="NameEN" ReadOnly="True" SortExpression="NameEN" />
                    <asp:BoundField DataField="ParentCode" HeaderText="ParentCode" ReadOnly="True" SortExpression="ParentCode" />
                    <asp:BoundField DataField="CurrentLevel" HeaderText="CurrentLevel" ReadOnly="True" SortExpression="CurrentLevel" />
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getFaculties" TypeName="PSUPKTProvider.PSUOrganizationProvider"></asp:ObjectDataSource>
        </div>
    </form>

    <%
        PSUPKTProvider.PSUOrganizationProvider provider = new PSUPKTProvider.PSUOrganizationProvider();

        var start = DateTime.Now.Ticks;
        //var faculties = provider.getFaculties("03");
        List<PSUPKTProvider.Model.PSUFaculty> faculties = new List<PSUPKTProvider.Model.PSUFaculty>();
        
        faculties.Add(provider.GetFaculty("99"));
        var end = DateTime.Now.Ticks;
        Response.Write("Time: " + (end - start).ToString("N0") + "<br />");
        foreach (var faculty in faculties)
        {
            Response.Write(string.Format("{0} - {1} {2} (LV: {3})<br />",
                faculty.Code, faculty.NameTH, faculty.NameEN, faculty.CurrentLevel));
        }
    %>

    <hr />

    <%
        faculties.Clear();
        start = DateTime.Now.Ticks;
        faculties.AddRange(provider.GetFaculties("03"));
        end = DateTime.Now.Ticks;
        Response.Write("Time: " + (end - start).ToString("N0") + "<br />");
        foreach (var faculty in faculties)
        {
            Response.Write(string.Format("{0} - {1} {2} (LV: {3})<br />",
                faculty.Code, faculty.NameTH, faculty.NameEN, faculty.CurrentLevel));
        }
         %>
</body>
</html>

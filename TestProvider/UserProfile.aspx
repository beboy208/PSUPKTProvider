<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="TestProvider.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataSourceID="odsSearchProfileFromDB">
        <Fields>
            <asp:CheckBoxField DataField="IsValidOrganizationInfo" HeaderText="IsValidOrganizationInfo" ReadOnly="True" SortExpression="IsValidOrganizationInfo" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="StaffCode" HeaderText="StaffCode" SortExpression="StaffCode" />
            <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
            <asp:BoundField DataField="CitizenID" HeaderText="CitizenID" SortExpression="CitizenID" />
            <asp:BoundField DataField="Position" HeaderText="Position" SortExpression="Position" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="DistinguishedName" HeaderText="DistinguishedName" SortExpression="DistinguishedName" />
        </Fields>
    </asp:DetailsView>
    <asp:ObjectDataSource ID="odsSearchProfileFromDB" runat="server" SelectMethod="GetProfile" TypeName="PSUPKTProvider.PSUPKTDBProfileProvider" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:QueryStringParameter Name="username" QueryStringField="id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Campus.aspx.cs" Inherits="TestProvider.Campus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CAMPUS_ID" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="CAMPUS_ID" HeaderText="CAMPUS_ID" ReadOnly="True" SortExpression="CAMPUS_ID" />
            <asp:BoundField DataField="CAMPUS_NAME_THAI" HeaderText="CAMPUS_NAME_THAI" SortExpression="CAMPUS_NAME_THAI" />
            <asp:BoundField DataField="CAMPUS_NAME_ENG" HeaderText="CAMPUS_NAME_ENG" SortExpression="CAMPUS_NAME_ENG" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PSUPKTProvider.Regist2005NewTableAdapters.CAMPUSTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_CAMPUS_ID" Type="String" />
            <asp:Parameter Name="Original_CAMPUS_NAME_THAI" Type="String" />
            <asp:Parameter Name="Original_CAMPUS_NAME_ENG" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CAMPUS_ID" Type="String" />
            <asp:Parameter Name="CAMPUS_NAME_THAI" Type="String" />
            <asp:Parameter Name="CAMPUS_NAME_ENG" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="CAMPUS_NAME_THAI" Type="String" />
            <asp:Parameter Name="CAMPUS_NAME_ENG" Type="String" />
            <asp:Parameter Name="Original_CAMPUS_ID" Type="String" />
            <asp:Parameter Name="Original_CAMPUS_NAME_THAI" Type="String" />
            <asp:Parameter Name="Original_CAMPUS_NAME_ENG" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RAAMEN.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top:60px;">
        <asp:Label ID="RoleLabel" runat="server"></asp:Label>

        <div style="margin-top:60px;">
            <asp:Label ID="ListNameLbl" runat="server"></asp:Label>
            <asp:GridView ID="UserGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ControlStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

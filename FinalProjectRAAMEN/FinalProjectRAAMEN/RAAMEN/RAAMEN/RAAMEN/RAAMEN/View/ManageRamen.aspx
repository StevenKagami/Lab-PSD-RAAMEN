<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="RAAMEN.View.ManageRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
        <h1>Manage Ramen</h1>
        <asp:GridView ID="RamenGridView" runat="server" AutoGenerateColumns="False" OnRowDeleting="RamenGridView_RowDeleting" OnRowEditing="RamenGridView_RowEditing" style="margin-top:20px;">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" SortExpression="Id" ControlStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Meat.name" HeaderText="Meat" SortExpression="Meat.name" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" HeaderText="Action" ButtonType="Button" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="InsertRamen" runat="server" Text="Insert Ramen" OnClick="InsertRamen_Click" style="margin-top:30px;" />
    </div>
</asp:Content>

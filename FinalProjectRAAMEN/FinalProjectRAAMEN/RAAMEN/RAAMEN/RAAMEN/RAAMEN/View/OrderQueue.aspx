<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="OrderQueue.aspx.cs" Inherits="RAAMEN.View.OrderQueue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Queue</h1>
        
        <asp:GridView ID="OrderQueueGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="OrderQueueGridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Transaction ID" ControlStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Staff" HeaderText="Staff" />
                <asp:BoundField DataField="Customer" HeaderText="Customer" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:ButtonField HeaderText="Handle" CommandName="Handle" Text="Handle" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

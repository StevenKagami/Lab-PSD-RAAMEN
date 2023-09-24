<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="RAAMEN.View.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>History</h1>
        <asp:Label ID="EmptyLabel" runat="server" Visible="false"></asp:Label>
        <asp:GridView ID="HistoryGridView" runat="server" AutoGenerateColumns="false" OnRowCommand="HistoryGridView_RowCommand" >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Transaction ID" ControlStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="Staff" HeaderText="Staff" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:ButtonField HeaderText="Detail" CommandName="Detail" Text="Detail"/>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

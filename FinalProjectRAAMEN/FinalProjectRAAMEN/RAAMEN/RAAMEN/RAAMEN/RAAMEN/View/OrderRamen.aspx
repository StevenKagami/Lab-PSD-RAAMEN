<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="OrderRamen.aspx.cs" Inherits="RAAMEN.View.OrderRamen" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Order Ramen</h1>

        <div>
            <asp:GridView ID="RamenGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="RamenGridView_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"/>
                    <asp:BoundField DataField="Meat.name" HeaderText="Meat" SortExpression="Meat.name" />
                    <asp:BoundField DataField="Broth" HeaderText="Broth" SortExpression="Broth"/>
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price"/>
                    <asp:ButtonField HeaderText="Order" CommandName="Order" Text="Order" />                    
                </Columns>
            </asp:GridView>            
        </div>

        <div>
            <h3>Cart</h3>
            <asp:Label ID="CartIsEmpty" runat="server" Text="Cart is empty!" Visible="false"></asp:Label>

            <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="CartGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                    <asp:BoundField DataField="Qty" HeaderText="Quantity"/>
                    <asp:ButtonField HeaderText="Remove Order" CommandName="RemoveOrder" Text="Remove" ItemStyle-HorizontalAlign="Center" />
                </Columns>
            </asp:GridView>

            <div style="margin-top:10px;">
                <asp:Button ID="BuyCartBtn" runat="server" Text="Buy Cart" OnClick="BuyCartBtn_Click" BackColor="LightGreen" style="margin-right:30px;" />
                <asp:Button ID="ClearCartBtn" runat="server" Text="Clear Cart" OnClick="ClearCartBtn_Click"/>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavigationBar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="RAAMEN.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Transaction Detail</h1>

        <div style="margin-bottom:10px;">
            <div style="display:flex; flex-direction:row; gap:1%;">
                <asp:Label ID="TrIdLabel" runat="server" Text="Transaction ID: " Font-Bold="true"></asp:Label>
                <asp:Label ID="TrId" runat="server"></asp:Label>
            </div>
            <div style="display:flex; flex-direction:row; gap:1%;">
                <asp:Label ID="StaffLabel" runat="server" Text="Staff: " Font-Bold="true"></asp:Label>
                <asp:Label ID="Staff" runat="server"></asp:Label>
            </div>
            <div style="display:flex; flex-direction:row; gap:1%;">                
                <asp:Label ID="CustomerLabel" runat="server" Text="Customer: " Font-Bold="true" Visible="false"></asp:Label>
                <asp:Label ID="Customer" runat="server" Visible="false"></asp:Label>
            </div>
            <div style="display:flex; flex-direction:row; gap:1%;">
                <asp:Label ID="DateLabel" runat="server" Text="Date: " Font-Bold="true"></asp:Label>
                <asp:Label ID="Date" runat="server"></asp:Label>
            </div>
        </div>

        <asp:GridView ID="TrDetailGridView" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Ramen Name"/>
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Qty" HeaderText="Quantity" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
            </Columns>
        </asp:GridView>

        <asp:Button ID="BackBtn" runat="server" Text="Back" OnClick="BackBtn_Click" style="margin-top:20px;" />
    </div>
</asp:Content>

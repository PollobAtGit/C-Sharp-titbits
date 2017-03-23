<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ADO_101.ASPXs.Products" %>

<asp:Content ID="ProductContent" ContentPlaceHolderID="MainContent" runat="server">
    <label>Total products count</label>
    <asp:Label ID="totalProductCount" runat="server"></asp:Label>
    <asp:GridView ID="productsGridView" runat="server"></asp:GridView>
    <asp:Button runat="server" Text="Update Quantity" ID="updateQty" EnableViewState="False" OnClick="updateQty_Click"/>
    <asp:Button runat="server" Text="Delete Product With Min Id" ID="deleteProduct" EnableViewState="False" OnClick="deleteProduct_Click"/>
    <asp:Label ID="updateRecordCount" runat="server" Visible="False"></asp:Label>
    <asp:Button runat="server" Text="Insert New Product" ID="insertProductBtn" EnableViewState="False" OnClick="insertProductBtn_Click"/>
    <asp:TextBox ID="productNameTxt" runat="server"></asp:TextBox>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ADO_101.ASPXs.Products" %>

<asp:Content ID="ProductContent" ContentPlaceHolderID="MainContent" runat="server">
    <label>Total products count</label>
    <asp:Label ID="totalProductCount" runat="server"></asp:Label>
    <asp:GridView ID="productsGridView" runat="server"></asp:GridView>
</asp:Content>


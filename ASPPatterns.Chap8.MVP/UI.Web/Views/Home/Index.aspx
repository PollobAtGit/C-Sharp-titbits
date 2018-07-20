<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="UI.Web.Views.Home.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>

<%@ Register Src="~/Views/Shared/ProductList.ascx" TagName="ProductList" TagPrefix="pl" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <h2>Tody's Top Products</h2>
    <pl:ProductList ID="plBestSellingProducts" runat="server" />
</asp:Content>

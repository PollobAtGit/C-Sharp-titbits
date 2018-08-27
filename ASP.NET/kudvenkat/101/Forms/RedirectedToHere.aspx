<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RedirectedToHere.aspx.cs" Inherits="_101.Forms.RedirectedToHere" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:TextBox runat="server" ID="secretKeyKeyValueFromViewStateWebForm"></asp:TextBox>
    </div>
    <div>
        <asp:TextBox ID="txtSessionIdFromOriginalPage" runat="server" Width="300" />
    </div>
</asp:Content>

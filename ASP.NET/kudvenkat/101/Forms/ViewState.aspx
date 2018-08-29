<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewState.aspx.cs" Inherits="_101.Forms.ViewState" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="incrementedValue" runat="server">0</asp:TextBox>
    <asp:Button ID="btnIncr" runat="server" Text="Click me" OnClick="btnIncr_Click" />
    <div>
        <asp:Label ID="lblPreviousInt" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblSecretKey" runat="server"></asp:Label>
    </div>
    <%--
        Following control can't be referenced from backend because runat="server" 
        is not present as an attribute
        In fact parsing error will occur when page is loaded again

        <asp:TextBox ID="lblTxtPureHtml">0</asp:TextBox>
    --%>

    <input type="text" name="inputNumber" value="-99" />
    <asp:TextBox ID="inputNumberDisplayer" runat="server" />
    <asp:TextBox ID="nid" runat="server" Width="350"></asp:TextBox>
    <asp:Button ID="redirectTo" Text="Redirect me to somewhere" runat="server" OnClick="redirectTo_Click" />
</asp:Content>

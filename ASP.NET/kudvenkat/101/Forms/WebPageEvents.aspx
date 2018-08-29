<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebPageEvents.aspx.cs" Inherits="_101.Forms.WebPageEvents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="postBack" runat="server" OnClick="PostBack_Click" Text="post me back to server" />
    <asp:TextBox ID="textWillChangeOnAutoPostBack" runat="server" AutoPostBack="true" OnTextChanged="TextWillChangeWithAutoPostBack_TextChanged" />
    <asp:TextBox ID="textWillChange" runat="server" OnTextChanged="TextWillChange_TextChanged" />
    <input name="dumbControl" value="99" type="text" />

    <%--validator works only with server controls <asp:TextBox /> etc.--%>
    <%--validation works in client side--%>
    <%--validation not working while we are auto post backing on text box text change--%>
    <asp:TextBox ID="requiredField" runat="server" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="user name is required" SetFocusOnError="True" ControlToValidate="requiredField"></asp:RequiredFieldValidator>
</asp:Content>

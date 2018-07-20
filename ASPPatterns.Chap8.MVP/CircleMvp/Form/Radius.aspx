<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Radius.aspx.cs" Inherits="CircleMvp.Form.Radius" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <th colspan="2">Calculate Area of Circle</th>
        </tr>
        <tr>
            <td>Enter Radius</td>
            <td>
                <asp:TextBox ID="TextRadiusTxt" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Result:</td>
            <td>
                <asp:Label ID="LabelResultLbl" runat="server" ForeColor="red"></asp:Label></td>
        </tr>
        <tr align="right">
            <td colspan="2">
                <asp:Button ID="ButtonResult" runat="server" Text="Get Area?" OnClick="ButtonResult_Click" /></td>
        </tr>
    </table>
</asp:Content>


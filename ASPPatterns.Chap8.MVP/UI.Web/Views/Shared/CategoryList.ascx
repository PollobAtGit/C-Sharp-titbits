<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="UI.Web.Views.Shared.CategoryList" %>

<asp:Repeater ID="rptCategoryList" runat="server">
    <HeaderTemplate>
        <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <a href="/Views/Product/CategoryProducts.aspx?CategoryId=<%# Eval("Id")%>">
                <%# Eval("Name")%></a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>

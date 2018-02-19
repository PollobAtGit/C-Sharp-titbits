<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="ADO_101.ASPXs.Students" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>All Students</h1>
    <div>
        <asp:GridView runat="server" ID="StudentsGrdVw"></asp:GridView>
    </div>
</asp:Content>

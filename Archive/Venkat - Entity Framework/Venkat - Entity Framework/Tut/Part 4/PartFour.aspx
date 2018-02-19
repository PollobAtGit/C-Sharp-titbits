<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartFour.aspx.cs" Inherits="Venkat___Entity_Framework.Tut.Part_4.PartFour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Departments - Part Four</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <asp:GridView ID="DepartmentGridView" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="PartFourObjectDataSource" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:TemplateField HeaderText="Employees">
                        <ItemTemplate>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSource='<%# Eval("Employees") %>'>
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
            <asp:ObjectDataSource ID="PartFourObjectDataSource" runat="server" SelectMethod="GetDepartments" TypeName="Venkat___Entity_Framework.Tut.Part_4.VenketRepository"></asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>

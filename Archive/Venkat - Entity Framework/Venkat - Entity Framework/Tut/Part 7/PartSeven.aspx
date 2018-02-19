<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartSeven.aspx.cs" Inherits="Venkat___Entity_Framework.Tut.Part_7.PartSeven" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department - Part 7</title>
    <style>
        div {
            margin: 20px;
        }
    </style>
</head>
<body>

    <!-- TODO: Check HTTP methods for each operation via Grid or Details View -->

    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <asp:GridView ID="EmployeeGridView" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="PartSevenEDS">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
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
        </div>

        <div>
            <!-- POI: InsertVisible for BoundFields indicates whether a column or field will be shown or not in Insert mode -->

            <asp:DetailsView ID="EmployeeDetailsView" runat="server" Height="50px" Width="125px" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="PartSevenEDS" DefaultMode="Insert" OnItemInserted="EmployeeInserted">
                <AlternatingRowStyle BackColor="White" />
                <CommandRowStyle BackColor="#FFFFC0" Font-Bold="True" />
                <FieldHeaderStyle BackColor="#FFFF99" Font-Bold="True" />
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="false" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Salary" HeaderText="Salary" SortExpression="Salary" />
                    <asp:CommandField ShowInsertButton="True" />
                </Fields>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            </asp:DetailsView>
        </div>
        <div>

            <!-- POI: Most probably, EnableInsert & EnableUpdate enables creation of SQL -->
            <!-- POI: From SQL Profiler it is evident that EF is issuing all SQL operations -->
            <!-- 
                POI: Mapping between operation & SP from EDMX ensures the stored procedures are 
                being invoked when that operation is performed 
            -->
            <!-- 
                POI: One function(procedure) mapping is provided for EDMX then all 
                functions mapping has to be provided otherwise other operations will not work properly\
            -->

            <asp:EntityDataSource ID="PartSevenEDS" runat="server"
                ConnectionString="name=PartSevenConnectionString"
                DefaultContainerName="PartSevenConnectionString"
                EnableDelete="True"
                EnableFlattening="False"
                EnableInsert="True"
                EnableUpdate="True"
                EntitySetName="Employees">
            </asp:EntityDataSource>
        </div>
    </form>
</body>
</html>

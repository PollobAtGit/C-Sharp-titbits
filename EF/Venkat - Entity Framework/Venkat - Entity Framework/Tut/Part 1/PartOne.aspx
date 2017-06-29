<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartOne.aspx.cs" Inherits="Venkat___Entity_Framework.Tut.Part_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Departments - Part One</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family: Arial">
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="DepartmentsGridView" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="ID">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                    <asp:TemplateField HeaderText="Employees">
                        <ItemTemplate>

                            <!-- TOOD: What does Eval do? -->
                            <!-- TODO: What is the relation between Eval & Navigation property? -->
                            <!-- TODO: If both Eval points to the same navigation property as Includes in EntityDataSource then why should they be put seperately? -->

                            <!-- POI: DataField in the BoundField indicates the property name of the mentioned model class -->

                            <asp:GridView ID="GridView2" runat="server" DataSource='<%# Eval("Employees") %>' AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                    <asp:BoundField DataField="Salary" HeaderText="Salary" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />

            </asp:GridView>

            <!-- POI: Includes works based on Navigation property. If the navigation property is not given properly & server side error will be thrown -->
            <!-- POI: EntitySetName indicates the Model class -->
            <!-- TODO: What is the usage of 'DefaultContainerName'? -->

            <asp:EntityDataSource ID="DepartmentsGridView" runat="server" ConnectionString="name=PartOneEntities" DefaultContainerName="PartOneEntities" EnableFlattening="False" EntitySetName="Departments" Include="Employees">
            </asp:EntityDataSource>
        </div>
    </form>
</body>
</html>

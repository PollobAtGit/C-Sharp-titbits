<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient._Default" %>

<!DOC

<html>
<head runat="server"></head>
<body>
    <div>
        <form id="webServiceInvokerFrm" runat="server">
            <table style="font-family: Arial">
                <tr>
                    <td>
                        <asp:TextBox ID="textBoxOne" runat="server"></asp:TextBox>
                        <asp:Button ID="btnOne" runat="server" Text="GetMessage" OnClick="btnOne_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>

        </form>
    </div>

</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_192.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGetItem" runat="server" Text="Obtener Item" OnClick="btnGetItem_Click" />
            <asp:Literal ID="ltResultado" runat="server"></asp:Literal>

        </div>
    </form>
</body>
</html>

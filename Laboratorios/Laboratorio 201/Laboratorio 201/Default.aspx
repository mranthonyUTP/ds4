<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_201.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Tabla de Multiplicar</h2>

            <asp:Label ID="lblNumero" runat="server" Text="Ingrese un número: "></asp:Label>
            <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
            <br /><br />

            <asp:Literal ID="ltResultado" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Laboratorio_203.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ID: <asp:TextBox ID="txtID" runat="server" /><br />
            Nombre: <asp:TextBox ID="txtNombre" runat="server" /><br />
            Precio: <asp:TextBox ID="txtPrecio" runat="server" /><br />
            Stock: <asp:TextBox ID="txtStock" runat="server" /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </form>
</body>
</html>

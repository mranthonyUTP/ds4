<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Parcial_3.Agregar" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Agregar Artículo</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Agregar Nuevo Artículo</h2>

        <asp:TextBox ID="txtTitulo" runat="server" Width="300" Placeholder="Título"></asp:TextBox><br /><br />
        <asp:TextBox ID="txtAutores" runat="server" Width="300" Placeholder="Autores"></asp:TextBox><br /><br />
        <asp:TextBox ID="txtResumen" runat="server" Width="300" TextMode="MultiLine" Rows="4" Placeholder="Resumen"></asp:TextBox><br /><br />
        <asp:TextBox ID="txtRevista" runat="server" Width="300" Placeholder="Revista"></asp:TextBox><br /><br />
        <asp:TextBox ID="txtAnio" runat="server" Width="300" Placeholder="Año"></asp:TextBox><br /><br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnVolver" runat="server" Text="Volver" PostBackUrl="Default.aspx" />

    </form>
</body>
</html>

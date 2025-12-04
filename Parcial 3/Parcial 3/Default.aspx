<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Parcial_3._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Gestión de Artículos</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2 style="margin-left: 120px">Gestión de Artículos Científicos</h2>

        <asp:TextBox ID="txtBuscar" runat="server" Width="250" Placeholder="Buscar por título"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" style="margin-left: 24px" />


        <asp:Button ID="btnAgregar" runat="server" Text="Agregar Artículo" PostBackUrl="Agregar.aspx" style="margin-left: 24px" />

        <br /><br />


        <asp:GridView ID="GridViewArticulos" runat="server" AutoGenerateColumns="False"
                      DataKeyNames="IdArticulo" OnRowDeleting="GridViewArticulos_RowDeleting">
            <Columns>

                <asp:BoundField DataField="IdArticulo" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                <asp:BoundField DataField="Autores" HeaderText="Autores" />
                <asp:BoundField DataField="Revista" HeaderText="Revista" />
                <asp:BoundField DataField="AnioPublicacion" HeaderText="Año" />

                <asp:CommandField ShowDeleteButton="True" DeleteText="Eliminar" ButtonType="Button" />

            </Columns>
        </asp:GridView>

    </form>
</body>
</html>

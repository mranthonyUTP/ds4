<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_203.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowEditing="gvProductos_RowEditing"
                OnRowDeleting="gvProductos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                    <asp:BoundField DataField="PRECIO" HeaderText="Precio" />
                    <asp:BoundField DataField="STOCK" HeaderText="Stock" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>

            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        </div>
    </form>
</body>
</html>

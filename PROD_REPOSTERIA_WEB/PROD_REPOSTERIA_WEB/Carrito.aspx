<%@ Page Title="Carrito"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Carrito.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>🛒 Carrito de Compras</h2>

    <asp:GridView ID="gvCarrito" runat="server"
        CssClass="table table-bordered"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Postre" />
            <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="$ {0:F2}" />
        </Columns>
    </asp:GridView>

    <h4>Total: $ <asp:Label ID="lblTotal" runat="server" /></h4>

    <asp:Button ID="btnConfirmar" runat="server"
        Text="Confirmar compra"
        CssClass="btn btn-success"
        OnClick="btnConfirmar_Click" />

</asp:Content>

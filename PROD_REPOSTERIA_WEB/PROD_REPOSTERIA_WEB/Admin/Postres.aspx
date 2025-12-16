<%@ Page Title="Gestión de Postres" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Postres.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Admin.Postres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Gestión de Postres</h2>

    <!-- ID oculto -->
    <asp:HiddenField ID="hfIdPostre" runat="server" />

    <!-- Formulario -->
    <div>
        <asp:Label Text="Nombre" runat="server" />
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
        <br />

        <asp:Label Text="Descripción" runat="server" />
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
        <br />

        <asp:Label Text="Precio" runat="server" />
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
        <br />

     <!--   <div class="mb-3">
            <label>Imagen del postre</label>
            <asp:Label Text="Buscar imagen (keyword)" runat="server" />
            <asp:TextBox ID="txtKeyword" runat="server" CssClass="form-control" />
            <br />
        </div>          -->

        <asp:Button ID="btnGuardar" runat="server"
            Text="Guardar" CssClass="btn btn-success"
            OnClick="btnGuardar_Click" />

        <asp:Button ID="btnCancelar" runat="server"
            Text="Cancelar" CssClass="btn btn-secondary"
            OnClick="btnCancelar_Click" />
    </div>

    <hr />

<asp:GridView ID="gvPostres" runat="server"
    AutoGenerateColumns="False"
    CssClass="table table-bordered"
    DataKeyNames="IdPostre"
    OnRowCommand="gvPostres_RowCommand">

    <Columns>
        <asp:BoundField DataField="IdPostre" HeaderText="ID" />
        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:BoundField DataField="Precio" HeaderText="Precio" />

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button runat="server"
                    Text="Editar"
                    CommandName="Editar"
                    CommandArgument='<%# Eval("IdPostre") %>'
                    CssClass="btn btn-warning btn-sm" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button runat="server"
                    Text="Eliminar"
                    CommandName="Eliminar"
                    CommandArgument='<%# Eval("IdPostre") %>'
                    CssClass="btn btn-danger btn-sm"
                    OnClientClick="return confirm('¿Seguro que deseas eliminar este postre?');" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>


</asp:Content>

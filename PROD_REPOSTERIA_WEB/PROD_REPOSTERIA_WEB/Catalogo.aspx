<%@ Page Title="Catálogo de Postres"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Catalogo.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>🍰 Catálogo de Postres</h2>

    <asp:Repeater ID="rptPostres" runat="server" OnItemCommand="rptPostres_ItemCommand">
        <ItemTemplate>
            <div class="card mb-3" style="width: 18rem; display:inline-block; margin:10px;">
                <img src="<%# Eval("Imagen") %>"
                    class="card-img-top"
                    style="height:200px; object-fit:cover;" />


                <div class="card-body">
                    <h5 class="card-title"><%# Eval("Nombre") %></h5>
                    <p class="card-text"><%# Eval("Descripcion") %></p>
                    <p><strong>$ <%# Eval("Precio") %></strong></p>

                    <asp:Button runat="server"
                        Text="Agregar al carrito"
                        CssClass="btn btn-primary"
                        CommandName="Comprar"
                        CommandArgument='<%# Eval("IdPostre") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

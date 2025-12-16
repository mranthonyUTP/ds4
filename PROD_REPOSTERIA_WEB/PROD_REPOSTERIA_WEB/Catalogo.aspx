<%@ Page Title="Catálogo de Postres"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Catalogo.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Catalogo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container py-4">

        <!-- Título -->
        <div class="mb-4">
            <h2 class="fw-bold">🍰 Catálogo de Postres</h2>
            <p class="text-muted">
                Descubre nuestra selección de postres artesanales.
            </p>
        </div>

        <!-- Grid de productos -->
        <div class="row g-4">

            <asp:Repeater ID="rptPostres" runat="server" OnItemCommand="rptPostres_ItemCommand">
                <ItemTemplate>

                    <div class="col-md-4 col-lg-3">
                        <div class="card h-100 shadow-sm">

                            <img src="<%# Eval("Imagen") %>"
                                 data-cache="true"
                                 class="card-img-top"
                                 style="height:200px; object-fit:cover;"
                                 alt="<%# Eval("Nombre") %>" />

                            <div class="card-body d-flex flex-column">
                                <h5 class="card-title">
                                    <%# Eval("Nombre") %>
                                </h5>

                                <p class="card-text text-muted small flex-grow-1">
                                    <%# Eval("Descripcion") %>
                                </p>

                                <div class="d-flex justify-content-between align-items-center mt-2">
                                    <span class="fw-bold">
                                        $ <%# Eval("Precio") %>
                                    </span>

                                    <!-- Botón cliente que abre la modal de compra -->
                                    <button type="button"
                                            class="btn btn-sm btn-primary"
                                            data-id='<%# Eval("IdPostre") %>'
                                            data-name='<%# Eval("Nombre") %>'
                                            onclick="return showPurchaseModal(this);">
                                        Agregar
                                    </button>
                                </div>
                            </div>

                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

        </div>

        <!-- Hidden fields y botón invisible que manejará el postback cuando se confirme -->
        <asp:HiddenField ID="hfPurchaseId" runat="server" />
        <asp:HiddenField ID="hfPurchaseQty" runat="server" />
        <asp:Button ID="btnConfirmPurchase" runat="server" OnClick="btnConfirmPurchase_Click" Style="display:none" />

        <!-- Inicializamos variables JS con los ClientID/UniqueID necesarios -->
        <script type="text/javascript">
            window.__hfPurchaseIdClientId = '<%= hfPurchaseId.ClientID %>';
            window.__hfPurchaseQtyClientId = '<%= hfPurchaseQty.ClientID %>';
            window.__confirmTarget = '<%= btnConfirmPurchase.UniqueID %>';
        </script>

             <!-- ACCIONES DEL CATÁLOGO -->
        <div class="d-flex flex-column flex-md-row gap-3 justify-content-between align-items-center mt-5">
            <a href="LandingPage.aspx" class="btn btn-outline-secondary">
                ⬅ Volver al inicio
            </a>

            <a href="Carrito.aspx" class="btn btn-success">
                Continuar compra 🛒
            </a>
        </div>

    </section>

</asp:Content>
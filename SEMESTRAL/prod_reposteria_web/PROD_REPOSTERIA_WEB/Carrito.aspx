<%@ Page Title="Carrito"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Carrito.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section class="container py-4">
        <div class="row justify-content-center">
            <div class="col-lg-9">

                <h2 class="mb-3">🛒 Carrito de Compras</h2>

                <asp:Panel ID="pnlEmpty" runat="server" Visible="false" CssClass="alert alert-info">
                    El carrito está vacío. <a href="Catalogo.aspx" class="alert-link">Ir al catálogo</a>.
                </asp:Panel>

                <div class="card mb-3" runat="server" id="cardCart" visible="false">
                    <div class="card-body p-0">
                        <div class="table-responsive">
                            <table class="table mb-0">
                                <thead class="table-light">
                                    <tr>
                                        <th style="width:120px;">Imagen</th>
                                        <th>Postre</th>
                                        <th class="text-end">Precio unit.</th>
                                        <th class="text-center">Cantidad</th>
                                        <th class="text-end">Subtotal</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCart" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <img src='<%# Eval("Imagen") %>' data-cache="true" alt='<%# Eval("Nombre") %>' class="img-fluid rounded" style="max-height:80px; object-fit:cover;" />
                                                </td>
                                                <td>
                                                    <div class="fw-bold"><%# Eval("Nombre") %></div>
                                                    <div class="small text-muted"><%# Eval("Descripcion") %></div>
                                                </td>
                                                <td class="text-end">$ <%# String.Format("{0:F2}", Eval("Precio")) %></td>
                                                <td class="text-center"><%# Eval("Cantidad") %></td>
                                                <td class="text-end">$ <%# String.Format("{0:F2}", Eval("Subtotal")) %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <td colspan="4" class="text-end fw-bold">Total</td>
                                        <td class="text-end fw-bold">$ <asp:Label ID="lblTotal" runat="server" /></td>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="d-flex justify-content-between align-items-center">
                    <a href="Catalogo.aspx" class="btn btn-outline-secondary">⬅ Seguir comprando</a>

                    <asp:Button ID="btnConfirmar" runat="server"
                        Text="Confirmar compra"
                        CssClass="btn btn-success"
                        OnClick="btnConfirmar_Click" />
                </div>

            </div>
        </div>
    </section>

</asp:Content>
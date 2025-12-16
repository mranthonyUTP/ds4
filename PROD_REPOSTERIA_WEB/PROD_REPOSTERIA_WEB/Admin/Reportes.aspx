<%@ Page Title="Reportes"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Reportes.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Admin.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- main container with min-height so footer stays at bottom -->
    <div class="container py-4" style="min-height: calc(100vh - 220px);">
        <div class="row gy-4">

            <div class="col-12 col-lg-6">
                <div class="card shadow-sm h-100">
                    <div class="card-body">
                        <h4 class="card-title">📊 Resumen</h4>

                        <ul class="list-group list-group-flush mt-3">
                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                <div>
                                    <small class="text-muted">Total de postres</small>
                                    <div class="fw-bold" id="totalPostresContainer">
                                        <asp:Label ID="lblTotalPostres" runat="server" />
                                    </div>
                                </div>
                                <i class="bi bi-box-seam fs-4 text-primary"></i>
                            </li>

                            <li class="list-group-item d-flex justify-content-between align-items-center">
                                <div>
                                    <small class="text-muted">Precio promedio</small>
                                    <div class="fw-bold">$ <asp:Label ID="lblPromedio" runat="server" /></div>
                                </div>
                                <i class="bi bi-currency-dollar fs-4 text-success"></i>
                            </li>

                            <li class="list-group-item">
                                <small class="text-muted">Postre más caro</small>
                                <div class="fw-bold"><asp:Label ID="lblMasCaro" runat="server" /></div>
                            </li>

                            <li class="list-group-item">
                                <small class="text-muted">Postre más barato</small>
                                <div class="fw-bold"><asp:Label ID="lblMasBarato" runat="server" /></div>
                            </li>
                        </ul>

                    </div>
                </div>
            </div>

            <div class="col-12 col-lg-6">
                <div class="card shadow-sm mb-3 h-100">
                    <div class="card-body">
                        <h5 class="card-title">Top 5 más caros</h5>
                        <div class="table-responsive" style="max-height:55vh; overflow:auto;">
                            <table class="table mb-0">
                                <thead class="table-light">
                                    <tr>
                                        <th>Postre</th>
                                        <th class="text-end">Precio</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptTopExpensive" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("Nombre") %></td>
                                                <td class="text-end">$ <%# String.Format("{0:F2}", Eval("Precio")) %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
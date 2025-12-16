<%@ Page Title="Gestión de Postres" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Postres.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Admin.Postres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container py-4">
        <div class="row justify-content-center">
            <div class="col-lg-10">

                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h2 class="mb-0">🍰 Gestión de Postres</h2>
                    <div>
                        <a href="Reportes.aspx" class="btn btn-outline-secondary">Ver reportes</a>
                    </div>
                </div>

                <div class="card mb-4 shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">Crear / Editar Postre</h5>

                        <asp:HiddenField ID="hfIdPostre" runat="server" />

                        <div class="row g-3">
                            <div class="col-md-6">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                            </div>

                            <div class="col-md-6">
                                <label class="form-label">Precio</label>
                                <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                            </div>

                            <div class="col-12">
                                <label class="form-label">Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                            </div>

                            <div class="col-md-4">
                                <label class="form-label">Imagen (URL)</label>
                                <asp:TextBox ID="txtImagen" runat="server" CssClass="form-control" />
                            </div>

                            <div class="col-md-2 d-flex align-items-end">
                                <button type="button" id="btnGuardarClient" class="btn btn-success w-100">
                                    Guardar
                                </button>
                                <!-- Hidden server button used to perform postback -->
                                <asp:Button ID="btnGuardar" runat="server" Text="GuardarServer" OnClick="btnGuardar_Click" Style="display:none" />
                            </div>

                            <div class="col-md-2 d-flex align-items-end">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary w-100" OnClick="btnCancelar_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title">Listado de postres</h5>

                        <div class="table-responsive">
                            <asp:GridView ID="gvPostres" runat="server"
                                AutoGenerateColumns="False"
                                CssClass="table table-hover align-middle"
                                DataKeyNames="IdPostre"
                                OnRowCommand="gvPostres_RowCommand"
                                OnRowDataBound="gvPostres_RowDataBound">

                                <Columns>
                                    <asp:TemplateField HeaderText="Imagen" ItemStyle-Width="120px">
                                        <ItemTemplate>
                                            <img src='<%# Eval("Imagen") %>' alt='<%# Eval("Nombre") %>' class="img-fluid rounded" style="max-height:60px; object-fit:cover;" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="IdPostre" HeaderText="ID" ItemStyle-Width="60px" />

                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />

                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

                                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="$ {0:F2}" ItemStyle-HorizontalAlign="Right" />

                                    <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="180px">
                                        <ItemTemplate>
                                            <div class="d-flex gap-2">
                                                <asp:Button runat="server"
                                                    ID="btnEditar"
                                                    Text="Editar"
                                                    CommandName="Editar"
                                                    CommandArgument='<%# Eval("IdPostre") %>'
                                                    CssClass="btn btn-sm btn-outline-warning" />

                                                <!-- Client delete button: calls JS that triggers modal and then postback -->
                                                <button type="button"
                                                        class="btn btn-sm btn-danger"
                                                        onclick="return confirmDelete('<%# Eval("IdPostre") %>');">
                                                    Eliminar
                                                </button>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <!-- hidden controls used by client-side confirm to trigger server actions -->
                        <asp:HiddenField ID="hfDeleteId" runat="server" />
                        <asp:Button ID="btnDeleteConfirm" runat="server" OnClick="btnDeleteConfirm_Click" Style="display:none" />
                    </div>
                </div>

            </div>
        </div>
    </div>

    <script type="text/javascript">
        // helper used by the Delete buttons in GridView
        function confirmDelete(id) {
            var msg = '¿Seguro que deseas eliminar este postre?';
            // set hidden field
            var hf = document.getElementById('<%= hfDeleteId.ClientID %>');
            if (hf) hf.value = id;

            // show modal and on confirm do postback to hidden server button
            showAppConfirm(msg, function () {
                __doPostBack('<%= btnDeleteConfirm.UniqueID %>', '');
            });
            return false;
        }

        // Save flow: confirm before posting to server btnGuardar
        document.addEventListener('DOMContentLoaded', function () {
            var saveBtn = document.getElementById('btnGuardarClient');
            if (!saveBtn) return;
            saveBtn.addEventListener('click', function () {
                var name = document.getElementById('<%= txtNombre.ClientID %>').value;
                var msg = name ? 'Guardar postre: ' + name + ' ?' : 'Guardar postre?';
                showAppConfirm(msg, function () {
                    __doPostBack('<%= btnGuardar.UniqueID %>', '');
                });
            });
        });
    </script>

</asp:Content>
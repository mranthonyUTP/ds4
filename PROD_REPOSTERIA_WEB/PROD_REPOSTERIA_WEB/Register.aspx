<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Register.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-8 col-lg-5">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h3 class="card-title text-center mb-3">Crear cuenta</h3>
                        <p class="text-muted text-center small mb-4">Regístrate para comprar postres</p>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtUsuario" Text="Usuario" />
                            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ControlToValidate="txtUsuario"
                                runat="server" ErrorMessage="Campo requerido" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Email" />
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Campo requerido" CssClass="text-danger small" Display="Dynamic" />
                            <asp:RegularExpressionValidator ControlToValidate="txtEmail"
                                runat="server" ErrorMessage="Email inválido" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Contraseña" />
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword"
                                runat="server" ErrorMessage="Campo requerido" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtConfirm" Text="Confirmar contraseña" />
                            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" CssClass="form-control" />
                            <asp:CompareValidator ControlToValidate="txtConfirm" ControlToCompare="txtPassword"
                                runat="server" ErrorMessage="Las contraseñas no coinciden" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="d-grid gap-2">
                            <asp:Button ID="btnRegister" runat="server" Text="Crear cuenta"
                                CssClass="btn btn-primary" OnClick="btnRegister_Click" />
                        </div>

                        <div class="text-center mt-3 small text-muted">
                            ¿Ya tienes cuenta? <a href="Login.aspx">Inicia sesión</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="container py-5">
        <div class="row justify-content-center">
            <div class="col-md-7 col-lg-4">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h3 class="card-title text-center mb-3">Iniciar sesión</h3>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtUser" Text="Usuario o Email" />
                            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ControlToValidate="txtUser"
                                runat="server" ErrorMessage="Campo requerido" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Contraseña" />
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator ControlToValidate="txtPassword"
                                runat="server" ErrorMessage="Campo requerido" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <div class="d-grid gap-2">
                            <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                        </div>

                        <div class="text-center mt-3 small text-muted">
                            ¿No tienes cuenta? <a href="Register.aspx">Regístrate</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
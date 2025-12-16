<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PROD_REPOSTERIA_WEB.About" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Iniciar Sesión</h2>

    <asp:Label Text="Email" runat="server" />
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
    <br />

    <asp:Label Text="Contraseña" runat="server" />
    <asp:TextBox ID="txtPassword" runat="server"
        TextMode="Password" CssClass="form-control" />
    <br />

    <asp:Button ID="btnLogin" runat="server"
        Text="Ingresar" CssClass="btn btn-primary"
        OnClick="btnLogin_Click" />
    <br /><br />

    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
</asp:Content>

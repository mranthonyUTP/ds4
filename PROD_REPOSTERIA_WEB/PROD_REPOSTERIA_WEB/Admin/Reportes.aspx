<%@ Page Title="Reportes"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Reportes.aspx.cs"
    Inherits="PROD_REPOSTERIA_WEB.Admin.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>📊 Reportes del Sistema</h2>

<ul class="list-group">

    <li class="list-group-item">
        <strong>Total de postres:</strong>
        <asp:Label ID="lblTotalPostres" runat="server" />
    </li>

    <li class="list-group-item">
        <strong>Precio promedio:</strong>
        $
        <asp:Label ID="lblPromedio" runat="server" />
    </li>

    <li class="list-group-item">
        <strong>Postre más caro:</strong>
        <asp:Label ID="lblMasCaro" runat="server" />
    </li>

    <li class="list-group-item">
        <strong>Postre más barato:</strong>
        <asp:Label ID="lblMasBarato" runat="server" />
    </li>

</ul>

</asp:Content>

<%@ Page Title="Home Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" 
    Inherits="Laboratorio_171._Default" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GridV" runat="server" AutoGenerateColumns="true"></asp:GridView>

</asp:Content>

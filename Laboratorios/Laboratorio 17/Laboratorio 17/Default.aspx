<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laboratorio_17._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>

        <asp:GridView ID="MyGridView" DataSourceID="MyDataSource1"
            AllowSorting="True" AllowPaging="True"
            DataKeyNames="ProductID"
            AutoGenerateEditButton="True"
            runat="server"/>

        <asp:SqlDataSource ID="MyDataSource1" runat="server"
            ConnectionString="Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=Northwind;Integrated Security=True;"
            ProviderName="System.Data.SqlClient"
            SelectCommand="SELECT ProductID, ProductName, UnitPrice FROM Products"
            UpdateCommand="UPDATE Products SET ProductName=@ProductName, UnitPrice=@UnitPrice WHERE ProductID=@ProductID">
        </asp:SqlDataSource>

    </div>

</asp:Content>

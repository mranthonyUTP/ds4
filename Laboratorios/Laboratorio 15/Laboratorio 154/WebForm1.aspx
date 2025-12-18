<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Laboratorio_154.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div> 
            <asp:TextBox ID="Numero1TextBox" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="Numero2TextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="calcularbtn" runat="server" Text="Sumar" OnClick="SumarButton_Click" />
            <asp:Label ID="Results" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>

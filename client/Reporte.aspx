<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Cliente.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reporte de Compras</title>
    <link href="StyleSheet3.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="Reporte" runat="server">
        <div>
            <asp:Label ID="filtro" CssClass="ete" runat="server" Text="filtro pagos"></asp:Label>
            <br />
            <asp:TextBox ID="filt_in" CssClass="box" runat="server"></asp:TextBox>
            <br /> <br />
            <asp:Button ID="Button1" CssClass="boton" runat="server" Text="Confirmar" OnClick="Button1_Click" />
            <br />
            <asp:GridView ID="GridView1" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>

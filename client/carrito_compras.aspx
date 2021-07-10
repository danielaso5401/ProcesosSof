<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrito_compras.aspx.cs" Inherits="Cliente.carrito_compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form runat="server">
        <asp:GridView ID="lista_compras" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="false" DataKeyNames="idproductos"
OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
OnRowUpdating="OnRowUpdating"  RowDataBound="GridView_RowDataBound" EmptyDataText="No records has been added.">
<Columns>
    
    <asp:TemplateField HeaderText="Id" ItemStyle-Width="150" Visible="False">
        
        <ItemTemplate>
            <asp:Label ID="lblId" runat="server" Text='<%# Eval("IDPRODUCTOS") %>' Visible="False"></asp:Label>
        </ItemTemplate>
        
        <EditItemTemplate>
            <asp:TextBox ID="txtId" runat="server" Text='<%# Eval("IDPRODUCTOS") %>' Visible="False"></asp:TextBox>
        </EditItemTemplate>

    </asp:TemplateField>
    
    
    <asp:TemplateField HeaderText="Name" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblName" runat="server" Text='<%# Eval("NOM_PROD") %>'></asp:Label>
        </ItemTemplate>
    
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Precio" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PRECIO_UNIT") %>'></asp:Label>
        </ItemTemplate>
    
    </asp:TemplateField>
    

    <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="150">

        <ItemTemplate>
            <asp:Label ID="lblCantidad" runat="server" Text='Cantidad'></asp:Label>
        </ItemTemplate>


        <EditItemTemplate>
            <asp:TextBox ID="txtCantidad" runat="server" Text='0'></asp:TextBox>
        </EditItemTemplate>

    </asp:TemplateField>


    <asp:CommandField ButtonType="button" ShowEditButton="true"  ItemStyle-Width="150"/>

</Columns>
       
</asp:GridView>
    </form>

   
</body>
</html>

<%@ Page Title="MiniMarket DHC" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Cliente.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css">
    <h2 class="titulo_client"><%: Title %>.</h2>
    
    <div >
        
    <asp:GridView ID="GridView1" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" runat="server" AutoGenerateColumns="false" DataKeyNames="idproductos"
OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit="OnRowCancelingEdit"
OnRowUpdating="OnRowUpdating" OnRowDeleting="OnRowDeleting" RowDataBound="GridView_RowDataBound" EmptyDataText="No records has been added.">
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
        <EditItemTemplate>
            <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("NOM_PROD") %>'></asp:TextBox>
        </EditItemTemplate>
    
    </asp:TemplateField>
    

    <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="150">

        <ItemTemplate>
            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:Label>
        </ItemTemplate>


        <EditItemTemplate>
            <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("CANTIDAD") %>'></asp:TextBox>
        </EditItemTemplate>

    </asp:TemplateField>


    <asp:TemplateField HeaderText="Precio" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PRECIO_UNIT") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtPrecio" runat="server" Text='<%# Eval("PRECIO_UNIT") %>'></asp:TextBox>
        </EditItemTemplate>
    
    </asp:TemplateField>


    <asp:TemplateField HeaderText="IdProv" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblIdProvl" runat="server" Text='<%# Eval("IDPROVEEDOR") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtIdProv" runat="server" Text='<%# Eval("IDPROVEEDOR") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Proveedor" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblProveedor" runat="server" Text='<%# Eval("NOM_COMP") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtProveedor" runat="server" Text='<%# Eval("NOM_COMP") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>


    <asp:TemplateField HeaderText="IdCat" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblIdCat" runat="server" Text='<%# Eval("IDCATEGORIA") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtIdCat" runat="server" Text='<%# Eval("IDCATEGORIA") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>

    <asp:TemplateField HeaderText="Categoria" ItemStyle-Width="150">
        <ItemTemplate>
            <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("NOM_CAT") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtCategoria" runat="server" Text='<%# Eval("NOM_CAT") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>


    <asp:CommandField ButtonType="button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="150"/>

</Columns>
       
</asp:GridView>
        <br/>
</div>
<div>
<table CssClass="tablas" style="margin: 0 auto;" border="0" cellpadding="0" cellspacing="0" style="border-collapse: collapse  ">

<tr>
    <td style="width: 150px">
        Name:<br />
        <asp:TextBox ID="TextName" runat="server" Width="140" />
    </td>
</tr>

<tr>
    <td style="width: 150px">
        Cantidad:<br />
        <asp:TextBox ID="TextCantidad" runat="server" Width="140" />
    </td>
</tr>

<tr>
    <td style="width: 150px">
        Precio:<br />
        <asp:TextBox ID="TextPrecio" runat="server" Width="140" />
    </td>
</tr>

<tr>
    <td style="width: 150px">
        ID Proveedor:<br />
        <asp:TextBox ID="TextProveedor" runat="server" Width="140" />
    </td>

</tr>

<tr>
    <td style="width: 150px">
        ID Categoria:<br />
        <asp:TextBox ID="TextCategoria" runat="server" Width="140" />
    </td>

</tr>

<tr>
    
    <td style="width: 100px">
        <br/>
        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Insert" />
    </td>
</tr>
</table>        
     </div>  

</asp:Content>

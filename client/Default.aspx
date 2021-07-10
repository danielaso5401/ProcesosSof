
<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="Cliente._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="StyleSheet2.css" rel="stylesheet" type="text/css">
    

    <div class="login-page">
      <div class="form">
        <div class="login-form">
          <h2 class="titulo_client"><%: Title %>.</h2>
          <asp:Label ID="usuario" runat="server" Text="Usuario:"></asp:Label>
          <asp:TextBox ID="v_usuario" runat="server"  ToolTip="usuario" ></asp:TextBox>
          <asp:Label ID="contra" runat="server" Text="Contraseña:"></asp:Label>
          <asp:TextBox ID="v_contra" runat="server" TextMode="Password" ToolTip="contraseña"></asp:TextBox>
          
          
        </div>
          <asp:Button ID="validar" runat="server" Text="Ingresar" OnClick="validar_Click"  class="button"/>
      </div>
    </div>
    

    
    

    
    
    
    
</asp:Content>

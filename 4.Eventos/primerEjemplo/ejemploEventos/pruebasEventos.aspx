﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pruebasEventos.aspx.cs" Inherits="ejemploEventos.pruebasEventos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:TextBox ID="txtNombre" runat="server" OnTextChanged="lblMensaje_TextChanged"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="Button1_Click" />
    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblSecundario" runat="server" Text="Label"></asp:Label>

    <asp:LinkButton ID="btnLink" href="Default?id=Rodrigo" runat="server">LinkButton</asp:LinkButton>

</asp:Content>

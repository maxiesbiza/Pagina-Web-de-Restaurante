<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Restaurante___Final.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center{
            margin:auto;
            border:solid;
            width: 60%;
            text-align:center;
            padding: 30px;
            margin-top: 50px;
            background-color:blanchedalmond;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <h2>Administracion</h2>
        <br />
        <asp:LinkButton ID="LinkButton1" CssClass="btn btn-primary" runat="server" OnClick="LinkButton1_Click">Administrar Promociones</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-primary" runat="server" OnClick="LinkButton2_Click">Ver Pedidos de Clientes</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="LinkButton3" CssClass="btn btn-primary" runat="server" OnClick="LinkButton3_Click">Administrar Menú</asp:LinkButton>
    </div>
</asp:Content>

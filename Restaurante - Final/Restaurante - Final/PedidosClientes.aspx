<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PedidosClientes.aspx.cs" Inherits="Restaurante___Final.PedidosClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .center{
            margin:auto;
            width: 100%;
            text-align:center;
            background-color:antiquewhite;
        }
        body{
            background-color:antiquewhite;
        }
    
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <h2>PEDIDOS</h2>
        <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
                    <Columns>  
                        <asp:BoundField DataField="PedidoID" HeaderText="Código" />  
                        <asp:BoundField DataField="NombreID" HeaderText="Nombre de Usuario"/>
                        <asp:BoundField DataField="MailUsuario" HeaderText="Mail"/>
                        
                        <asp:ButtonField CommandName="Select" Text="Seleccionar" ControlStyle-CssClass="btn btn-secondary" />
                    </Columns>  
                    <EmptyDataTemplate><b>No hay pedidos</b></EmptyDataTemplate>  

<HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
                </asp:GridView>
    </div>
    <br />
    <br />
    <div class="center">
        <h2>Detalle del Pedido</h2>
        <asp:GridView ID="GridViewDetalle" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
                    <Columns>  
                        <asp:BoundField DataField="PedidoID" HeaderText="Código Pedido" />  
                        <asp:BoundField DataField="DetalleID" HeaderText="Codigo Detalle" />
                        <asp:BoundField DataField="NombreDetalle" HeaderText="Producto"/>
                        <asp:BoundField DataField="DescripcionDetalle" HeaderText="Decripcion"/>
                        <asp:BoundField DataField="PrecioDetalle" HeaderText="Precio" />
                    </Columns>  
                    <EmptyDataTemplate><b>Seleccione un pedido</b></EmptyDataTemplate>  

<HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
                </asp:GridView>
    </div>
    <div class="center" style="margin-top: 30px">
        Enviar Correo<br />
        <br />
        Para: <asp:Label ID="lblTo" runat="server"></asp:Label><br />
        <br />
        Mensaje<br />
        <asp:TextBox ID="txtMsg" runat="server" Height="45px" TextMode="MultiLine" Width="347px"></asp:TextBox><br />
        <br />
        <asp:Button ID="btnConfirmar" CssClass="btn btn-primary" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
    </div>
    
</asp:Content>

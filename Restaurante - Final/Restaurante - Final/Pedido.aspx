<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Pedido.aspx.cs" Inherits="Restaurante___Final.Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">  
        $(document).ready(function () {  
            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();  
        });  
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center" style="margin-top: 20px">SU PEDIDO</h2>
    <br />
    <br />
    <div class="container">
        <div class="card" style="margin-bottom: 15px">
            <div class="card-body">
                <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="true" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">  
                    <Columns>  
                        <asp:BoundField DataField="PedidoID" HeaderText="Nro Pedido" />
                        <asp:BoundField DataField="DetalleID" HeaderText="Nro Detalle" />  
                        <asp:BoundField DataField="NombreDetalle" HeaderText="Nombre"/>
                        <asp:BoundField DataField="DescripcionDetalle" HeaderText="Descripción"/>
                        <asp:BoundField DataField="PrecioDetalle" HeaderText="Precio" />                          
                    </Columns>  
                    <EmptyDataTemplate>Elija que va a llevar hoy <b>Vuelva a la Pagina Principal</b></EmptyDataTemplate>  
                </asp:GridView>  
            </div>
        </div>
    </div>
    <div style="margin:auto">
        <asp:Button ID="BtnConfirmar" CssClass="btn btn-primary" runat="server" Text="Confirmar Pedido" OnClick="BtnConfirmar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCancelar" runat="server" CssClass="btn btn-danger" Text="Cancelar Pedido" OnClick="BtnCancelar_Click" />
    </div>

    <br />
    <br />
    <br />
</asp:Content>

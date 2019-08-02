<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Restaurante___Final.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="card" style="margin-bottom: 15px">
            <div class="card-body">
                <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
                    <Columns>  
                        <asp:BoundField DataField="ProdID" HeaderText="ID" />
                        <asp:BoundField DataField="ProdNombre" HeaderText="Producto" />  
                        <asp:BoundField DataField="ProdDescripcion" HeaderText="Descripcion"/>
                        <asp:BoundField DataField="ProdPrecio" HeaderText="Precio" />  
                          
                        <asp:ButtonField CommandName="Select" Text="Elegir" ControlStyle-CssClass="btn btn-secondary" />
                    </Columns>  
                    <EmptyDataTemplate>No Hay Promociones Cargadas <b>Cargue Una</b></EmptyDataTemplate>  

<HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
                </asp:GridView>  
            </div>
        </div>
    </div>
</asp:Content>

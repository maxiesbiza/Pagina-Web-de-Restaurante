<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Restaurante___Final.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .estilo{
            margin: 20px 20px 0px 20px;
        }
        .center{
            margin:auto;
            width: 100%;
            text-align:center;
            background-color:burlywood;
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Categorías Menú</h2>
        
    </div>
    <div class="row">
        <div class="col-sm-6 center" style="padding: 20px 0px 0px 20px">
            <h3>Agregar Categoría</h3>
            <br />
            Nombre Categoria<br />
            <asp:TextBox ID="txtNombreCategoria" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnAgregarCategoria" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="btnAgregarCategoria_Click" />
        </div>        
        
            <div class="col-sm-3 center" >
                <asp:DropDownList ID="listCategorias" runat="server" OnSelectedIndexChanged="listCategorias_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnCargarCat" runat="server" CssClass="btn btn-primary" Text="Cargar Productos" OnClick="btnCargarCat_Click" />
            </div>
            <div class="col-sm-3 center">
                <br />
                <h3>Cambiar nombre de categoría</h3><br />
                Nombre de Categoria<br />
                Categoría ID: 
                <asp:Label ID="lblCatID" runat="server" Text=""></asp:Label>
                <br />
                <asp:TextBox ID="txtCambiarNomCat" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnCambiarNomCat" runat="server" CssClass="btn btn-primary" Text="Modificar" OnClick="btnCambiarNomCat_Click" />
            </div>            
        </div>

    <div>
        
    </div>
    <h3 class="text-center">
        <asp:Label ID="lblNomCat" runat="server" Text=""></asp:Label>
    </h3>
    <div class="row">
        <div class="col-sm-3 center">
            Agregar Producto
            <br />
            <br />
            Nombre<br />
            <asp:TextBox ID="txtAgrNombreProd" runat="server"></asp:TextBox><br />
            <br />
            Descripción<br />
            <asp:TextBox ID="txtAgrDescProd" runat="server" Height="41px" TextMode="MultiLine"></asp:TextBox><br />
            <br />
            Precio<br />
            <asp:TextBox ID="txtAgrPrecProd" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnAgrProd" runat="server" Text="Agregar Producto" OnClick="btnAgrProd_Click" />
        </div>
        <div class="col-sm-9 center">
            <asp:GridView ID="GridViewCategoria" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnSelectedIndexChanged="GridViewCategoria_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="ProdID" HeaderText="Código" />
                <asp:BoundField DataField="ProdNombre" HeaderText="Nombre" />
                <asp:BoundField DataField="ProdDescripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="ProdPrecio" HeaderText="Precio" />
                <asp:BoundField DataField="Habilitacion" HeaderText="Habilitado" />
                <asp:ButtonField CommandName="Select" ControlStyle-CssClass="btn btn-secondary" Text="Seleccionar" />
            </Columns>
                <HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
                </asp:GridView>
            </div>
        <div style="margin:auto">
            <h3>Modificar Producto</h3>
            <br />
            Código<br />
            <asp:TextBox ID="txtModProdID" Enabled="false" runat="server"></asp:TextBox>
            <br />
            <br />
            Titulo<br />
            <asp:TextBox ID="txtModProdTitulo" runat="server"></asp:TextBox>
            <br />
            <br />
            Descripción<br />
            <asp:TextBox ID="txtModProdDescrip" runat="server"  Height="61px" TextMode="MultiLine" Width="358px"></asp:TextBox>
            <br />
            <br />
            Precio<br />
            <asp:TextBox ID="txtModProdPrecio" runat="server"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnActualizarProd" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizarProd_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBorrarProd" runat="server" CssClass="btn btn-danger" Text="Borrar" OnClick="btnBorrarProd_Click"/>        
            <br />
            <br />
            <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
            <br />
            <br />
        </div>
        

        
    </div>
    
</asp:Content>

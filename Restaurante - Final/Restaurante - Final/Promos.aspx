<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Promos.aspx.cs" Inherits="Restaurante___Final.Promos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">  
        $(document).ready(function () {  
            $("#GridView1").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();  
        });  
    </script> 

    <style type="text/css">
        .auto-style1 {
            left: 0px;
            top: 0px;
        }
        </style>
    <style>
        .center{
            margin:auto;
            border:solid;
            width: 50%;
            text-align:center;
            padding: 30px;
            margin-top: 50px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="center">
            
        <h2>CARGAR NUEVA PROMO</h2>
        <br />
        Titulo<br />
        <asp:TextBox ID="TxtBoxTitulo" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtBoxTitulo" CssClass="text-danger" ValidationGroup="CargarPromo"></asp:RequiredFieldValidator>
        <br />
        <br />
        Descripción<br />
        <asp:TextBox ID="TxtBoxDesc" runat="server" Height="61px" TextMode="MultiLine" Width="358px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtBoxDesc" CssClass="text-danger" ErrorMessage="Este campo es requerido" ValidationGroup="CargarPromo"></asp:RequiredFieldValidator>
        <br />
        <br />
        Precio<br />
        <asp:TextBox ID="TxtBoxPrecio" runat="server"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtBoxPrecio" CssClass="text-danger" ErrorMessage="Este campo es requerido" ValidationGroup="CargarPromo"></asp:RequiredFieldValidator>
        <br />
        <br />
        Imagen<br />
        <asp:FileUpload ID="SubirImg" runat="server" /><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="SubirImg" CssClass="text-danger" ErrorMessage="Este campo es requerido" ValidationGroup="CargarPromo"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnSubirPromo" class="btn btn-primary" runat="server" OnClick="btnSubirPromo_Click" Text="Subir Promo" ValidationGroup="CargarPromo" />
        <br />
        <asp:Label ID="Lblcatch" runat="server" Text=""></asp:Label>

    </div>
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div class="card" style="margin-bottom: 15px">
            <div class="card-body">
                <asp:GridView ID="GridView1" ShowHeaderWhenEmpty="True" HeaderStyle-CssClass="bg-primary text-white" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">  
                    <Columns>  
                        <asp:BoundField DataField="PromoID" HeaderText="Código" />  
                        <asp:BoundField DataField="Titulo" HeaderText="Titulo"/>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:BoundField DataField="ImageName" HeaderText="Nombre Imagen" />  
                        <asp:ImageField DataImageUrlField="ImagePath" ControlStyle-CssClass="img-thumbnail" ControlStyle-Width="100" ControlStyle-Height="60" HeaderText="Image" />  
                          
                        <asp:ButtonField CommandName="Select" Text="Modificar" ControlStyle-CssClass="btn btn-secondary" />
                    </Columns>  
                    <EmptyDataTemplate>No Hay Promociones Cargadas <b>Cargue Una</b></EmptyDataTemplate>  

<HeaderStyle CssClass="bg-primary text-white"></HeaderStyle>
                </asp:GridView>  
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="center">
        <h2>Modficar Promo</h2>
        <br />
        Código<br />
        <asp:TextBox ID="txtModPromoID" Enabled="false" runat="server"></asp:TextBox>
        <br />
        <br />
        Titulo<br />
        <asp:TextBox ID="txtModTitulo" runat="server"></asp:TextBox>
        <br />
        <br />
        Descripción<br />
        <asp:TextBox ID="txtModDescrip" runat="server"  Height="61px" TextMode="MultiLine" Width="358px"></asp:TextBox>
        <br />
        <br />
        Precio<br />
        <asp:TextBox ID="txtModPrecio" runat="server"></asp:TextBox>
        <br />
        <br />
        Imagen
        <asp:Label ID="lblNombreImg" runat="server"></asp:Label>
        <br />
        <asp:Image ID="ImageMod" runat="server" CssClass="img-thumbnail"/><br />
        <asp:FileUpload ID="FileUploadMod" runat="server" />
        <br />
        <br />
        <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBorrar" runat="server" CssClass="btn btn-danger" Text="Borrar" OnClick="btnBorrar_Click" />        
        <br />
        <br />
        <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>
        <br />
        <br />
    </div>
    <br />
    <br />
    <br />
    
    
</asp:Content>

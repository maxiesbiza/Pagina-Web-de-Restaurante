<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Restaurante___Final.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>  
        .carousel-inner img {  
            width: 100%;  
            height: 350px;  
        }  

        .button{
            background-color: #008CBA;
            border: none;
            color: white;
            padding: 12px 400px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        .center{
            margin:auto;
            border:solid;
            width: 100%;
            text-align:center;
            padding: 30px;
            margin-top: 50px;
        }
        body{
            background-color: antiquewhite;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <h2 class="text-center" style="margin-top: 20px">Bienvenido, elija que desea llevar hoy</h2>
    </p>

    <div class="container" style="margin-top: 50px">  
        <h2 class="text-capitalize text-center">Promociones</h2>  
        <div id="myCarousel" class="carousel slide" data-ride="carousel">  
            <div class="carousel-inner" role="listbox">  
                <asp:Repeater ID="Repeater1" runat="server">  
                    <ItemTemplate>  
                        <div class="carousel-item <%#GetActiveClass(Container.ItemIndex) %>">  
                            <img alt="<%#Eval("ImageName")%>" src="<%#Eval("ImagePath")%>" />  
                            <div class="carousel-caption d-none d-md-block">
                                <h4><%#Eval("Titulo") %></h4>
                                <p><%# Eval("Descripcion") %><br /><%#"$ " + Eval("Precio") %></p>
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-secondary" CommandName="btnPedido" CommandArgument='<%# Eval("PromoID") %>' >Agregar al Pedido</asp:LinkButton>
                            </div>
                        </div>  
                    </ItemTemplate>  
                </asp:Repeater>  
            </div>  
            <a class="carousel-control-prev" href="#myCarousel" data-slide="prev" role="button">  
                <span class="carousel-control-prev-icon"></span>  
            </a>  
            <a class="carousel-control-next" href="#myCarousel" data-slide="next" role="button">  
                <span class="carousel-control-next-icon"></span>  
            </a>  
        </div>  
    </div> 
    <br />
    <br />
    <div class="center">
        <h2>CARTA</h2>
        <asp:Repeater ID="RepeaterMenu" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <br />
                            <asp:LinkButton ID="LinkButton2" CssClass="button" runat="server" CommandName="btnCat" CommandArgument='<%# Eval("CategoriaID") %>' ><%#Eval("CategoriaNombre") %></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        
    </div>





</asp:Content>

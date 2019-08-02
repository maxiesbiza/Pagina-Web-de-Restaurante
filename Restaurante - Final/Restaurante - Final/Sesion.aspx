<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sesion.aspx.cs" Inherits="Restaurante___Final.Sesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .center{
            margin:auto;
            border:solid;
            width: 300px;
            text-align:center;
            padding: 30px;
            margin-top: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div role="form">
        <div class="center" >
            <h2>Iniciar Sesion</h2>
            <p>
                Nombre de Usuario
                <br />
                <asp:TextBox ID="txtbox_login_username" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbox_login_username" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Login">Este campo es requerido</asp:RequiredFieldValidator>
                <br />
                <br />
                Clave
                <br />
                <asp:TextBox ID="txtbox_login_pass" runat="server" Width="188px" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbox_login_pass" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Login">Este campo es requerido</asp:RequiredFieldValidator>
                <br />
                <br />
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" OnClick="btnLogin_Click" Text="Iniciar Sesión" ValidationGroup="Login" /><br />
                <asp:Label ID="lbl_login" runat="server"></asp:Label>
            </p>
        </div>
        
    </div>
    
    <p>
    </p>
    
    <div class="center">
        <h2>Registrar Usuario</h2>
        <br />
        Nombre de Usuario<br />
        <asp:TextBox ID="txtbox_reg_username" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtbox_reg_username" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">Este campo es requerido</asp:RequiredFieldValidator>
        <br />
        <br />
        Clave<br />
        <asp:TextBox ID="txtbox_reg_pass" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbox_reg_pass" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">Este campo es requerido</asp:RequiredFieldValidator>
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtbox_reg_pass" ControlToValidate="txtbox_pass_confirm" CssClass="text-danger" ErrorMessage="CompareValidator" ValidationGroup="Register">Las claves ingresadas deben coincidir</asp:CompareValidator>
        <br />
        Confirmar Clave<br />
        <asp:TextBox ID="txtbox_pass_confirm" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbox_pass_confirm" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">Este campo es requerido</asp:RequiredFieldValidator>
        <br />
        <br />
        E-mail<br />
        <asp:TextBox ID="txtbox_reg_mail" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtbox_reg_mail" CssClass="text-danger" ErrorMessage="RequiredFieldValidator" ValidationGroup="Register">Este campo es requerido</asp:RequiredFieldValidator>
        <br />
        <br />
        Telefono (opcional)<br />
        <asp:TextBox ID="txtbox_reg_telefono" runat="server"></asp:TextBox>

        <br />
        <br />
        <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" Text="Registrar" ValidationGroup="Register" /><br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>

</asp:Content>

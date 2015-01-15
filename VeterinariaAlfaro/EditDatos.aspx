﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDatos.aspx.cs" Inherits="VeterinariaAlfaro.EditDatos" %>

<!DOCTYPE html />
<html lang="es">
<head id="Head1" runat="server">
    <title>Veterinaria Alfaro</title>
    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Edit.css" rel="stylesheet" type="text/css" />
    
    <meta charset="utf-8" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/menu.js"></script>
    <script src="/media/js/jquery.validate.min.js"></script>
    <script src="/media/js/messages_es.js"></script>
    <script src="/media/js/jquery.validation.net.webforms.min.js"></script>
    <script type="text/javascript">
        $(function () {

            $("#formIni").validateWebForm();
        });
         
    </script>
</head>
<body>
    <form id="formIni" runat="server">
    
    <header id="cabezera">

        <div id="logo">
            <img src="/media/img/dog.png" class="sello" alt="dog Text" />                
            <img src="/media/img/logo.png" id="home" class="logo_img" onclick="" alt="Logo Text" />                
            <img src="/media/img/cat.png" class="sello" alt="cat Text" />  
        </div>

        <nav id="menu">
            <ul>
                <li runat="server" id="LNombre" class="ocultar"><asp:HyperLink ID="lkNombre" runat="server" NavigateUrl="~/EditDatos.aspx"></asp:HyperLink></li><!-- 
                --><li class="home"><a href="/Index.aspx">Inicio</a></li><!--   
                --><li class="perros"><a href="/Index.aspx?filter=perro">Perros</a></li><!--   
                --><li class="gatos"><a href="/Index.aspx?filter=gato">Gatos</a></li><!-- 
                --><li class="aves"><a href="/Index.aspx?filter=ave">Aves</a></li><!-- 
                --><li class="otros"><a href="/Index.aspx?filter=peque">Pequeños</a></li><!--   
                --><li runat="server" id="LLongin"><asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink></li><!--                
                --><li runat="server" id="LPanel" class="ocultar"><asp:HyperLink ID="panel" runat="server" NavigateUrl="~/panelControl.aspx">[panel]</asp:HyperLink></li><!-- 
                --><li runat="server" id="LbtnCerrar" class="ocultar"><asp:Button ID="btnCerrar" runat="server" Text="Salir" Visible="False" onclick="btnCerrar_Click"></asp:Button></li>
            </ul>
        </nav>
    </header>   
    
    <div id="content_aux">
    
    
    <section id="contenido" runat="server">        
                      
            <div class="notificacion">
                <p id="msg" runat="server">Notificaciones</p>
            </div>

            
            <fieldset class="form" id="section">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="required" minLength="5" maxLength="8" placeholder="Nombre"></asp:TextBox>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="required" minLength="5" placeholder="Apellidos"></asp:TextBox>                    
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="required email" placeholder="E-mail"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="required" minLength="8" placeholder="Contraseña" TextMode="Password"></asp:TextBox>                                        
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="required digits" placeholder="Telefono" minLength="9" maxLength="11"></asp:TextBox>
                    <asp:TextBox ID="txtTarjeta" runat="server" CssClass="required" minLength="16" maxLength="16" placeholder="# Tarjeta de Credito"></asp:TextBox>                    
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="required digits" minLength="3" maxLength="3" placeholder="Codigo de Seguridad"></asp:TextBox>                    

                <asp:Button ID="btnRegister" runat="server" Text="Actualizar"  class="submit" 
                    onclick="btnRegister_Click"></asp:Button>
            </fieldset>
    </section>

    </div>

    <footer id="reference">    
        <span>Veterinaria Alfaro © 2014 - 2015</span>
    </footer>

    </form>
</body>
</html>

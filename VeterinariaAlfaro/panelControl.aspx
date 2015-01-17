<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panelControl.aspx.cs" Inherits="VeterinariaAlfaro.panelControl" %>


<!DOCTYPE html />
<html lang="es">
<head id="Head1" runat="server">
    <title>Panel De Mantenimiento</title>
    <link id="favicon1" runat="server" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link id="favicon2" runat="server" rel="icon" href="/favicon.ico" type="image/ico" />

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Mantenimiento.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/menu.js"></script>
    
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
        <fieldset>
        <header>
            <h3>Panel de Mantenimiento</h3>
        </header>    
        <section>
            <ul class="mantenimiento">
                <li runat="server"><asp:HyperLink ID="musuario" runat="server" NavigateUrl="~/Mantenimiento/Usuarios.aspx">Mantenimiento Usuarios</asp:HyperLink></li><!-- 
                --><li runat="server"><asp:HyperLink ID="mmascota" runat="server" NavigateUrl="~/Mantenimiento/Mascotas.aspx">Mantenimiento Mascotas</asp:HyperLink></li><!-- 
                --><li runat="server"><asp:HyperLink ID="mreserva" runat="server" NavigateUrl="~/Mantenimiento/Reservas.aspx">Mantenimiento Reservas</asp:HyperLink></li>
            </ul>
        </section>
        </fieldset>

    </section>

    </div>

    <footer id="reference">    
        <span>Veterinaria Alfaro © 2014 - 2015</span>
    </footer>

    </form>
</body>
</html>

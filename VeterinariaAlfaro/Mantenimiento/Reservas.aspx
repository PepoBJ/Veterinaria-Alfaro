<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="VeterinariaAlfaro.Mantenimiento.Reservas" %>


<!DOCTYPE html />
<html lang="es">
<head id="Head1" runat="server">
    <title>Panel De Mantenimiento</title>
    <link id="favicon1" runat="server" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link id="favicon2" runat="server" rel="icon" href="/favicon.ico" type="image/ico" />

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Mantenimiento.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Recerva.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/MReservas.css" rel="stylesheet" type="text/css" />
    
    <link rel="stylesheet" href="/media/notify/themes/alertify.core.css" />
    <link rel="stylesheet" href="/media/notify/themes/alertify.default.css" id="toggleCSS" />

    <meta charset="utf-8" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/menu.js"></script>
    <script src="/media/notify/lib/alertify.min.js"></script>
    <script src="/media/js/Confirmation.js"></script>
    
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
                --><li class="otros"><a href="/Index.aspx?filter=otro">Otros</a></li><!--   
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

        <div id="buscador">                
            <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" onclick="btnBuscar_Click" 
                ></asp:Button>
        </div>

        <div id="content_reservas" runat="server">
                
        </div> 

        
    </section>

    </div>

    <footer id="reference">    
        <span>Veterinaria Alfaro © 2014 - 2015</span>
    </footer>

    </form>
</body>
</html>

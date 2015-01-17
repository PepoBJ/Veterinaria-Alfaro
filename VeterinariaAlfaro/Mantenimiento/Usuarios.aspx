<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="VeterinariaAlfaro.Mantenimiento.Usuarios" %>


<!DOCTYPE html />
<html lang="es">
<head id="Head1" runat="server">
    <title>Panel De Mantenimiento</title>
    <link id="favicon1" runat="server" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link id="favicon2" runat="server" rel="icon" href="/favicon.ico" type="image/ico" />

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Mantenimiento.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="/media/notify/themes/alertify.core.css" />
	<link rel="stylesheet" href="/media/notify/themes/alertify.default.css" id="toggleCSS" />

    <meta charset="utf-8" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/menu.js"></script>
    <script src="/media/js/jquery.validate.min.js"></script>
    <script src="/media/js/messages_es.js"></script>
    <script src="/media/js/jquery.validation.net.webforms.min.js"></script>
    <script src="/media/notify/lib/alertify.min.js"></script>
    <script type="text/javascript">

        function Confirmacion(str) {

            var seleccion = confirm("¿ " + str + " ?");
            
            return seleccion;
        }

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
            <header>
                <h3>Mantenimiento Usuarios</h3>
            </header>

            <aside class="lista">
                <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlUsuarios_SelectedIndexChanged" ></asp:DropDownList>
            </aside>

            <section class="campos">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="required" minLength="5" maxLength="8" placeholder="Nombre"></asp:TextBox>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="required" minLength="5" placeholder="Apellidos"></asp:TextBox>                    
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="required email" placeholder="E-mail"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="required" minLength="8" 
                placeholder="Contraseña" TextMode="Password"></asp:TextBox>                                        
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="required digits" placeholder="Telefono" minLength="9" maxLength="11"></asp:TextBox>
            <asp:TextBox ID="txtTarjeta" runat="server" CssClass="required" minLength="16" maxLength="16" placeholder="# Tarjeta de Credito"></asp:TextBox>                    
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="required digits" minLength="3" maxLength="3" placeholder="Codigo de Seguridad"></asp:TextBox>                    
            <asp:RadioButtonList ID="rblTipo" runat="server">
                <asp:ListItem Selected="True" Value="normal">Usuario Normal</asp:ListItem>
                <asp:ListItem Value="admin">Administrador</asp:ListItem>
            </asp:RadioButtonList>
            <input type="hidden" />
            </section>

            <footer class="acciones">
            <asp:Button ID="btnHabilitar" runat="server" Text="Nuevo" 
                onclick="btnHabilitar_Click" ></asp:Button>

            <asp:Button ID="btnAgregar" runat="server" Text="Insertar"  class="submit" 
                onclick="btnAgregar_Click" OnClientClick="return Confirmacion('Seguro que quiere crear este Usuario');"></asp:Button>

            <asp:Button ID="btnEditar" runat="server" Text="Actualizar"  
             OnClientClick="return Confirmacion('Esta seguro de editar la información de este Usuario');"
            class="submit" onclick="btnEditar_Click" ></asp:Button>

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  
             OnClientClick="return Confirmacion('Esta seguro de eliminar este Usuario');"
            class="submit" onclick="btnEliminar_Click" ></asp:Button>
            </footer>
        </fieldset>
    </section>

    </div>

    <footer id="reference">    
        <span>Veterinaria Alfaro © 2014 - 2015</span>
    </footer>

    </form>
</body>
</html>

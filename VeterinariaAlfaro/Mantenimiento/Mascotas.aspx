<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mascotas.aspx.cs" Inherits="VeterinariaAlfaro.Mantenimiento.Mascotas" %>


<!DOCTYPE html />
<html lang="es">
<head id="Head1" runat="server">
    <title>Panel De Mantenimiento</title>
    <link id="favicon1" runat="server" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link id="favicon2" runat="server" rel="icon" href="/favicon.ico" type="image/ico" />

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Mantenimiento.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Mascotas.css" rel="stylesheet" type="text/css" />
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

        function textAreaAdjust(o) {
            o.style.height = "1px";
            o.style.height = (25 + o.scrollHeight) + "px";
        }

        $(function () {
            $("#formIni").validateWebForm();
            $('textarea').each(function (i, x) { textAreaAdjust(x) });
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

            
        <fieldset class="form" id="section">
            <header>
                <h3>Mantenimiento Mascotas</h3>
            </header>

            <aside class="lista">
                
                <asp:DropDownList ID="ddlMascotas" runat="server" AutoPostBack="True" onselectedindexchanged="ddlMascotas_SelectedIndexChanged" 
                       ></asp:DropDownList>
            </aside>

            <section class="campos">
                <asp:DropDownList ID="ddlTipo" runat="server">
                    <asp:ListItem Selected="True" Value="perro">Perro</asp:ListItem>
                    <asp:ListItem Value="gato">Gato</asp:ListItem>
                    <asp:ListItem Value="ave">Ave</asp:ListItem>
                    <asp:ListItem Value="otro">Otro</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlTam" runat="server">
                    <asp:ListItem Selected="True" Value="1">Pequeño</asp:ListItem>
                    <asp:ListItem Value="2">Mediano</asp:ListItem>
                    <asp:ListItem Value="3">Grande</asp:ListItem>
                </asp:DropDownList>
                <div class="group">
                    <span>Foto</span>                   
                    <asp:FileUpload ID="fuFoto" runat="server" />
                </div>
                <asp:TextBox ID="txtRaza" CssClass="required" minlength="4" runat="server" placeholder="Raza"></asp:TextBox>
                <asp:TextBox ID="txtPelo" CssClass="required" minlength="4" runat="server" placeholder="Descripcin Pelo" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="txtColor" CssClass="required" minlength="4" runat="server" placeholder="Descripcin Color" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="txtCola" CssClass="required" minlength="4" runat="server" placeholder="Descripcin Cola" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="txtPrecio" CssClass="required number" runat="server" min="0" placeholder="Precio"></asp:TextBox>
                <asp:TextBox ID="txtStock" runat="server" CssClass="required digits" min="0" placeholder="Stock"></asp:TextBox>
                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="required" minlength="20" placeholder="Descripcion" TextMode="MultiLine"></asp:TextBox>
            </section>

            <footer class="acciones">
            <asp:Button ID="btnHabilitar" runat="server" Text="Nuevo" 
                onclick="btnHabilitar_Click" ></asp:Button>

            <asp:Button ID="btnAgregar" runat="server" Text="Insertar"  class="submit" 
                onclick="btnAgregar_Click" OnClientClick="return Confirmacion('Seguro que quiere agregar esta Mascota');"></asp:Button>

            <asp:Button ID="btnEditar" runat="server" Text="Actualizar"  
             OnClientClick="return Confirmacion('Esta seguro de editar la información de la Mascota');"
            class="submit" onclick="btnEditar_Click" ></asp:Button>

            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"  
             OnClientClick="return Confirmacion('Esta seguro de eliminar esta Mascota');"
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

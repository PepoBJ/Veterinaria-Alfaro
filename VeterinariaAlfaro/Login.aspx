<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VeterinariaAlfaro.Login" %>

<!DOCTYPE html />
<html lang="es">
<head runat="server">
    <title>Login Users</title>
    <link id="favicon1" runat="server" rel="shortcut icon" href="/favicon.ico" type="image/x-icon" />
    <link id="favicon2" runat="server" rel="icon" href="/favicon.ico" type="image/ico" />

    <link href="/media/css/Validate.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Login.css" rel="stylesheet" type="text/css" />
    
    <meta charset="utf-8" />
    
    <script src="/media/js/jquery.js"></script>
    <script src="/media/js/menu.js"></script>
    <script src="/media/js/tools.js"></script>
    <script src="/media/js/jquery.validate.min.js"></script>
    <script src="/media/js/messages_es.js"></script>
    <script src="/media/js/jquery.validation.net.webforms.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#formIni").validateWebForm();
            $('#home').click(function () {
                location.href = "Index.aspx";
            });
        });
         
    </script>

</head>
<body>
    <form id="formIni" runat="server">
    <div id="contenedor">

         <header id="cabezera">

            <div id="logo">
                <img src="/media/img/dog.png" class="sello" alt="dog Text" />                
                <img src="/media/img/logo.png" id="home" class="logo_img" onclick="" alt="Logo Text" />                
                <img src="/media/img/cat.png" class="sello" alt="cat Text" />  
            </div>

            <nav id="menu">
                <ul>             
                    <li runat="server" id="LNombre" class="ocultar"><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></li><!-- 
                --><li class="home"><a href="/Index.aspx">Inicio</a></li><!--   
                --><li class="perros"><a href="/Index.aspx?view=mision">Perros</a></li><!--   
                --><li class="gatos"><a href="/Index.aspx?view=vision">Gatos</a></li><!-- 
                --><li class="aves"><a href="/Index.aspx?view=nosotros">Aves</a></li><!-- 
                --><li class="otros"><a href="/Index.aspx?view=ubicanos">Pequeños</a></li><!--   
                --><li runat="server" id="LLongin"><asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink></li><!--                
                --><li runat="server" id="LbtnCerrar" class="ocultar"><asp:Button ID="btnCerrar" runat="server" Text="Salir" Visible="False"></asp:Button></li>
                </ul>
            </nav>
        </header>   
        
        <section id="contenido" runat="server">      
        
            <aside class="notificacion">
                <p id="msg" runat="server">Notificaciones</p>
            </aside>
                      
            <fieldset class="form" id="login">
                <header>
                    <p>Login Usuario</p>
                </header>
                <section>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="required email" placeholder="E-mail"></asp:TextBox>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="required" minLength="8" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" 
                    CssClass="submit login" onclick="btnLogin_Click"></asp:Button>
                </section>
            </fieldset>
            <fieldset class="form" id="registro">
                <header>
                    <p>Registro de Usuario</p>
                </header>
                
                <section>                                        
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="required" minLength="5" maxLength="8" placeholder="Nombre"></asp:TextBox>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="required" minLength="5" placeholder="Apellidos"></asp:TextBox>                    
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="required email" placeholder="E-mail"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="required" minLength="8" placeholder="Contraseña" TextMode="Password"></asp:TextBox>                    
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="required digits" placeholder="Telefono" minLength="9" maxLength="11"></asp:TextBox>
                    <asp:TextBox ID="txtTarjeta" runat="server" CssClass="required" minLength="16" maxLength="16" placeholder="# Tarjeta de Credito"></asp:TextBox>                    
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="required digits" minLength="3" maxLength="3" placeholder="Codigo de Seguridad"></asp:TextBox>                    
                    <asp:Button ID="btnRegister" runat="server" Text="Registrarse" 
                    CssClass="submit registro" onclick="btnRegister_Click"></asp:Button>
                </section>
            </fieldset>
        </section>

        <footer id="reference">    
            <span>Veterinaria Alfaro © 2014 - 2015</span>
        </footer>
    </div>
    </form>
</body>
</html>

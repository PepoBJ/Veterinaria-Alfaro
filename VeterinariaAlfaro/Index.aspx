<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="VeterinariaAlfaro.Index" %>

<!DOCTYPE html />
<html lang="es">
<head runat="server">
    <title>Veterinaria Alfaro</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/Index.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/slider.js"></script>
    <script type="text/javascript" src="/media/js/menu.js"></script>
    <script type="text/javascript">
        $(function () {
            $('img.foto').click(function () { location.href = $(this).attr('alt') });
            var x = $('.item');
            x.find('header').hide(0);
            x.find('aside').hide(0);
            x.find('section').hide(0);
            x.find('footer').hide(0);

            $.each(x, function (index, value) {
                $(value).find('header').delay(200).show(500, function () {
                    $(value).find('aside').delay(200).show(500, function () {
                        $(value).find('section').delay(200).show(500, function () {
                            $(value).find('footer').delay(200).show(500, function () {

                                $(value).find('header').css({
                                    WebkitTransition: 'all 1.5s ease',
                                    MozTransition: 'all 1.5s ease',
                                    MsTransition: 'all 1.5s ease',
                                    OTransition: 'all 1.5s ease',
                                    transition: 'all 1.5s ease'
                                });
                                $(value).find('aside').css({
                                    WebkitTransition: 'all 1.5s ease',
                                    MozTransition: 'all 1.5s ease',
                                    MsTransition: 'all 1.5s ease',
                                    OTransition: 'all 1.5s ease',
                                    transition: 'all 1.5s ease'
                                });
                                $(value).find('section').css({
                                    WebkitTransition: 'all 1.5s ease',
                                    MozTransition: 'all 1.5s ease',
                                    MsTransition: 'all 1.5s ease',
                                    OTransition: 'all 1.5s ease',
                                    transition: 'all 1.5s ease'
                                });
                                $(value).find('footer').css({
                                    WebkitTransition: 'all 1.5s ease',
                                    MozTransition: 'all 1.5s ease',
                                    MsTransition: 'all 1.5s ease',
                                    OTransition: 'all 1.5s ease',
                                    transition: 'all 1.5s ease'
                                });

                            });
                        });
                    });
                });
            });

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
                <li runat="server" id="LNombre" class="ocultar"><asp:Label ID="lblNombre" runat="server" Text=""></asp:Label></li><!-- 
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
    
    <div id="banner">
        <div class="s_element s_visible" ><img src="/media/banner/banner1.jpg" /></div>
        <div class="s_element" >
            <img src="/media/banner/banner2.png" />
            <span>No existe mejor psiquiatra en el mundo que un cachorro lamiendo tu cara.</span>
        </div>
        <div class="s_element" >
            <img src="/media/banner/banner3.jpg" />
            <span>Quién podría creer que no hay un alma tras esos ojos iluminados!.</span>
        </div>
        <div class="s_element" >
            <img src="/media/banner/banner4.jpg" />
            <span>La elegancia quiso cuerpo y vida, por eso se transformó en gato.</span>
        </div>
        <div class="s_element" >
            <img src="/media/banner/banner5.jpg" />
            <span>Cada niño debería tener dos cosas: un perro, y una madre que le deje tener uno.</span>
        </div>
        <div class="s_element" >
            <img src="/media/banner/banner6.png" />
            <span>Los animales son buenos amigos, no hacen preguntas y tampoco critican.</span>
        </div>
        <span class="ant"></span>
        <span class="sgt"></span>
    </div>

    <div id="content_aux">
    
    <aside id="merchandising">
        <li class="mision"><a href="/Index.aspx?view=mision">Misión</a></li>
        <li class="vision"><a href="/Index.aspx?view=vision">Visión</a></li>
        <li class="nosotros"><a href="/Index.aspx?view=nosotros">Nosotros</a></li>
        <li class="ubicanos"><a href="/Index.aspx?view=ubicanos">Ubicanos</a></li>
    </aside>
    
    <section id="contenido" runat="server">        
        
    </section>

    </div>

    <footer id="reference">    
        <span>Veterinaria Alfaro © 2014 - 2015</span>
    </footer>

    </form>
</body>
</html>

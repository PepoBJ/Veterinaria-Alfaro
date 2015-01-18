using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace VeterinariaAlfaro.Report
{
    public class EReports
    {
        
        public static Panel listaMascotas(string patron = "", string order = "")
        {
            DataTable dtPA;
            Panel aux = new Panel();

            order = order == "" ? ("ORDER BY precio") : order;
            order = " AND stock > 0 " + order;
            dtPA = new Controller.Mascota().listaMascota(patron,order);

            if (dtPA.Rows.Count < 1)
            {
                Panel pnull = new Panel();
                Label l = new Label();
                l.Text = "No se encontro lo que buscabas";
                pnull.CssClass = "nofound";
                pnull.Controls.Add(l);
                aux.Controls.Add(pnull);
                return aux;
            }

            for (int i = 0; i < dtPA.Rows.Count ; i++)
            {
                HtmlGenericControl mascota = new HtmlGenericControl("article");
                mascota.Attributes.Add("class", "item");

                                
                /*     TITULO - HEADER     */   
                HtmlGenericControl titulo = new HtmlGenericControl("header");
                titulo.Attributes.Add("class", "titulo");

                HtmlGenericControl title = new HtmlGenericControl("h2");
                title.InnerHtml = "<a href=\"/Index.aspx?id=" + dtPA.Rows[i].ItemArray[0].ToString() + "\">" + dtPA.Rows[i].ItemArray[1] + "</a>";

                titulo.Controls.Add(title);

                /*      ASIDE - IMG - FORMAT    */  

                HtmlGenericControl aside = new HtmlGenericControl("aside");
                aside.Attributes.Add("class", "imagen");                

                HtmlGenericControl foto = new HtmlGenericControl("img");
                string ruta = Controller.Mascota.DIR + dtPA.Rows[i].ItemArray[5].ToString() + ".jpg";
                foto.Attributes.Add("class", "foto");
                foto.Attributes.Add("src", ruta);
                foto.Attributes.Add("width", "100");
                foto.Attributes.Add("height", "100");
                foto.Attributes.Add("alt", "/Index.aspx?id=" + dtPA.Rows[i].ItemArray[0].ToString());
                                
                aside.Controls.Add(foto);

                /*     CONTENIDO - SECTION     */   
                HtmlGenericControl contenido = new HtmlGenericControl("section");
                contenido.Attributes.Add("class", "contenido");

                HtmlGenericControl descripcion = new HtmlGenericControl("div");
                descripcion.Attributes.Add("class", "descripcion");
                descripcion.InnerText = dtPA.Rows[i].ItemArray[4].ToString().Length > 130 ? (dtPA.Rows[i].ItemArray[4].ToString().Substring(0, 130) + "...") : dtPA.Rows[i].ItemArray[4].ToString();
                
                contenido.Controls.Add(descripcion);

                /*     DETALLES - FOOTER     */ 
                HtmlGenericControl detalles = new HtmlGenericControl("footer");
                detalles.Attributes.Add("class", "detalles");

                HyperLink link = new HyperLink();
                link.CssClass = "linkDetalles";
                link.ToolTip = dtPA.Rows[i].ItemArray[1].ToString();
                link.Text = "Más Info";
                link.NavigateUrl = "~/Index.aspx?id=" + dtPA.Rows[i].ItemArray[0].ToString();

                Label precio = new Label();
                precio.CssClass = "precio";
                precio.Text = "$" + dtPA.Rows[i].ItemArray[3].ToString();

                detalles.Controls.Add(precio);                               
                detalles.Controls.Add(link);


                mascota.Controls.Add(titulo);
                mascota.Controls.Add(aside);
                mascota.Controls.Add(contenido);
                mascota.Controls.Add(detalles);

                aux.Controls.Add(mascota);

            }
            Panel pnclear = new Panel();
            pnclear.Attributes.Add("style","clear:both;");
            aux.Controls.Add(pnclear);
            return aux;
        }


        public static Panel DetallesMascota(string id)
        {
            Panel aux = new Panel();
            aux.CssClass = "informacion";

            Controller.Mascota mas = new Controller.Mascota(Convert.ToInt16(id));

            if (mas.Id == 112143)
            {
                Panel pnull = new Panel();
                Label l = new Label();
                l.Text = "No se encontro lo que buscabas";
                pnull.CssClass = "nofound";
                pnull.Controls.Add(l);
                aux.Controls.Add(pnull);
                return aux;
            }


            /*** HEADER ***/

            HtmlGenericControl titulo = new HtmlGenericControl("header");
            titulo.Attributes.Add("class", "titulo");

            HtmlGenericControl title = new HtmlGenericControl("h2");
            title.InnerText = mas.Raza;

            titulo.Controls.Add(title);

            /**** SECTION ***/
            HtmlGenericControl cuerpo = new HtmlGenericControl("section");
            cuerpo.Attributes.Add("class", "cuerpo");

            HtmlGenericControl foto = new HtmlGenericControl("img");
            string ruta = Controller.Mascota.DIR + mas.Foto + ".jpg";
            foto.Attributes.Add("class", "foto");
            foto.Attributes.Add("src", ruta);
            foto.Attributes.Add("width", "100");
            foto.Attributes.Add("height", "100");
            foto.Attributes.Add("alt", "/Index.aspx?id=" + mas.Foto);

            Label precio = new Label();
            precio.CssClass = "precio";
            precio.Text = "$" + mas.Precio.ToString();
            
           
            HtmlGenericControl descripcion = new HtmlGenericControl("div");
            descripcion.Attributes.Add("class", "descripcion");
            Label text = new Label();
            HtmlGenericControl titu = new HtmlGenericControl("h3");

            titu.InnerText = "Descripcion";            
            text.Text = mas.Descripcion;
            descripcion.Controls.Add(titu);
            descripcion.Controls.Add(text);

            HtmlGenericControl pelo = new HtmlGenericControl("div");
            pelo.Attributes.Add("class", "pelo");

            text = new Label();
            titu = new HtmlGenericControl("h3");
            titu.InnerText = "Pelo";
            text.Text = mas.Pelo;
            pelo.Controls.Add(titu);
            pelo.Controls.Add(text);

            HtmlGenericControl color = new HtmlGenericControl("div");
            color.Attributes.Add("class", "color");

            text = new Label();
            titu = new HtmlGenericControl("h3");
            titu.InnerText = "Color";
            text.Text = mas.Color;
            color.Controls.Add(titu);
            color.Controls.Add(text);

            HtmlGenericControl cola = new HtmlGenericControl("div");
            cola.Attributes.Add("class", "cola");

            text = new Label();
            titu = new HtmlGenericControl("h3");
            titu.InnerText = "Cola";
            text.Text = mas.Cola;
            cola.Controls.Add(titu);
            cola.Controls.Add(text);

            Panel tama = new Panel();
            tama.CssClass = "contenTam";
            HtmlGenericControl tamT = new HtmlGenericControl("img");
            string ruta2 = Controller.Mascota.DIR + "t" + mas.Tamanyo + ".gif";
            tamT.Attributes.Add("class", "tamanio");
            tamT.Attributes.Add("src", ruta2);
            tamT.Attributes.Add("width", "100");
            tamT.Attributes.Add("height", "100");

            Label des = new Label();
            des.Text = mas.Type.ToUpper() + " " + ( mas.Tamanyo == 1 ? "PEQUEÑO" :  mas.Tamanyo == 2 ? "MEDIANO" : "GRANDE" );

            tama.Controls.Add(tamT);
            tama.Controls.Add(des);

            cuerpo.Controls.Add(foto);
            cuerpo.Controls.Add(precio);
            cuerpo.Controls.Add(new Panel());
            cuerpo.Controls.Add(descripcion);
            if (mas.Type == "perro")
                cuerpo.Controls.Add(tama);
            cuerpo.Controls.Add(pelo);
            cuerpo.Controls.Add(color);
            if (mas.Type != "ave")
                cuerpo.Controls.Add(cola);

            /*     FOOTER     */
            HtmlGenericControl reserva = new HtmlGenericControl("footer");
            reserva.Attributes.Add("class", "reserva");

            HyperLink link = new HyperLink();
            link.CssClass = "linkReserva";
            link.ID = "linked";
            if (System.Web.HttpContext.Current.Session["userID"] != null && System.Web.HttpContext.Current.Session["userName"] != null)
            {
                link.Text = "Reserva tu " + mas.Raza + " Ahora!";
                link.NavigateUrl = "~/Reservar.aspx?reserva=" + mas.Id;
            }
            else
            {
                link.Text = "¿Quieres reservar un " + mas.Raza + "?, Primero Logeate!";
                link.NavigateUrl = "~/Login.aspx?url=" + mas.Id ;
            }
            reserva.Controls.Add(link);


            
            aux.Controls.Add(titulo);
            aux.Controls.Add(cuerpo);            
            aux.Controls.Add(reserva);

            return aux;
        }

        public static Panel listaReservas(string patron = "", bool allUser = false)
        {
            Panel aux = new Panel();

            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(System.Web.HttpContext.Current.Session["userID"]));

            DataTable _data = new Controller.Reserva().listaReservaUser(user.Id, patron, allUser);

            for (int i = 0; i < _data.Rows.Count; i++)
            {
                Controller.Reserva reser = new Controller.Reserva(Convert.ToInt16(_data.Rows[i].ItemArray[0]));

                HtmlGenericControl reserva = new HtmlGenericControl("article");
                reserva.Attributes.Add("class", "reserva");

                HtmlGenericControl name = new HtmlGenericControl("div");
                name.Attributes.Add("class", "nombre");
                Label leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Cliente";
                name.Controls.Add(leyend);
                Label text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Usuario.Nombre + " " + reser.Usuario.Apellido.Split(' ')[0];
                name.Controls.Add(text);

                HtmlGenericControl freserva = new HtmlGenericControl("div");
                freserva.Attributes.Add("class", "freserva");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Fecha Reserva";
                freserva.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Fecha_reserva;
                freserva.Controls.Add(text);

                HtmlGenericControl fentrega = new HtmlGenericControl("div");
                fentrega.Attributes.Add("class", "fentrega");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Fecha Entrega";
                fentrega.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                if (reser.Estado.ToLower() == "entregado")
                    text.Text = reser.Fecha_entrega;
                else
                    text.Text = "No Entregado";
                fentrega.Controls.Add(text);

                HtmlGenericControl mascota = new HtmlGenericControl("div");
                mascota.Attributes.Add("class", "mascota");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Mascota";
                mascota.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Mascota.Type + " - " + reser.Mascota.Raza;
                mascota.Controls.Add(text);

                HtmlGenericControl cantidad = new HtmlGenericControl("div");
                cantidad.Attributes.Add("class", "cantidad");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Cantidad";
                cantidad.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Cantidad.ToString();
                cantidad.Controls.Add(text);

                HtmlGenericControl punitario = new HtmlGenericControl("div");
                punitario.Attributes.Add("class", "punitario");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Sub Total";
                punitario.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Mascota.Precio.ToString();
                punitario.Controls.Add(text);

                HtmlGenericControl ptotal = new HtmlGenericControl("div");
                ptotal.Attributes.Add("class", "ptotal");
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Total";
                ptotal.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Total.ToString();
                ptotal.Controls.Add(text);

                HtmlGenericControl estado = new HtmlGenericControl("div");
                estado.Attributes.Add("class", "estado " + reser.Estado);
                leyend = new Label();
                leyend.CssClass = "leyend";
                leyend.Text = "Estado";
                estado.Controls.Add(leyend);
                text = new Label();
                text.CssClass = "cont";
                text.Text = reser.Estado;
                estado.Controls.Add(text);


                HtmlGenericControl links = new HtmlGenericControl("div");
                links.Attributes.Add("class", "links");                

                if (!allUser)
                {
                    HyperLink lcancel = new HyperLink();
                    lcancel.CssClass = "lbtndefault";
                    lcancel.Text = "Cancelar Reserva";
                    lcancel.NavigateUrl = "#"; //"javascript:;";
                    lcancel.Attributes.Add("data-url", "/AccionReservar.aspx?uri=Reservar.aspx&accion=cancel&url=" + reser.Id);
                    lcancel.Attributes.Add("data-msg", "¿Seguro que quieres cancelar tu reserva?<br/>");
                    lcancel.Attributes.Add("data-cancel", "No se cancelo tu reserva.");


                    if (reser.Estado.ToLower() == "cancelado")
                    {
                        lcancel.Text = "¿Volver a Reservar?";
                        lcancel.NavigateUrl = "#"; //"javascript:;";
                        lcancel.Attributes.Add("data-url", "/Reservar.aspx?reserva=" + reser.Mascota.Id);
                        lcancel.Attributes.Add("data-msg", "¿Seguro que quieres volver a pedir tu reserva?<br/>");
                        lcancel.Attributes.Add("data-cancel", "No se reenvio tu reserva.");
                    }
                    links.Controls.Add(lcancel);
                }
                else
                {
                    HyperLink lcancel = new HyperLink();
                    lcancel.CssClass = "lbtndefault";
                    lcancel.Text = "Cancelar";
                    lcancel.NavigateUrl = "#"; //"javascript:;";
                    lcancel.Attributes.Add("data-url", "/AccionReservar.aspx?uri=/Mantenimiento/Reservas.aspx&accion=cancel&url=" + reser.Id);
                    lcancel.Attributes.Add("data-msg", "¿Seguro que quieres cancelar esta reserva?<br/>");
                    lcancel.Attributes.Add("data-cancel", "No se cancelo la reserva.");

                    HyperLink lpendiente = new HyperLink();
                    lpendiente.CssClass = "lbtndefault";
                    lpendiente.Text = "Pendiente";
                    lpendiente.NavigateUrl = "#"; //"javascript:;";
                    lpendiente.Attributes.Add("data-url", "/AccionReservar.aspx?uri=/Mantenimiento/Reservas.aspx&accion=pendiente&url=" + reser.Id);
                    lpendiente.Attributes.Add("data-msg", "¿Seguro que quieres poner en pendiente esta reserva?<br/>");
                    lpendiente.Attributes.Add("data-cancel", "No se puso en pendiente la reserva.");

                    HyperLink lentregado = new HyperLink();
                    lentregado.CssClass = "lbtndefault";
                    lentregado.Text = "Entregar";
                    lentregado.NavigateUrl = "#"; //"javascript:;";
                    lentregado.Attributes.Add("data-url", "/AccionReservar.aspx?uri=/Mantenimiento/Reservas.aspx&accion=entregar&url=" + reser.Id);
                    lentregado.Attributes.Add("data-msg", "¿Seguro que quieres entregar esta reserva?<br/>");
                    lentregado.Attributes.Add("data-cancel", "No se entrego la reserva.");


                    if(reser.Estado.Equals("entregado"))
                    {
                        links.Controls.Add(lcancel);
                        links.Controls.Add(lpendiente);
                    }
                    else if(reser.Estado.Equals("pendiente"))
                    {
                        links.Controls.Add(lcancel);
                        links.Controls.Add(lentregado);
                    }
                    else
                    {
                        links.Controls.Add(lpendiente);
                        links.Controls.Add(lentregado);
                    }                    
                }                               

                reserva.Controls.Add(name);
                reserva.Controls.Add(freserva);
                reserva.Controls.Add(fentrega);
                reserva.Controls.Add(mascota);
                reserva.Controls.Add(cantidad);
                reserva.Controls.Add(punitario);
                reserva.Controls.Add(ptotal);
                reserva.Controls.Add(estado);

                if(allUser)
                    reserva.Controls.Add(links);
                else if (reser.Estado.ToLower() == "pendiente" || reser.Estado.ToLower() == "cancelado")
                    reserva.Controls.Add(links);


                aux.Controls.Add(reserva);

            }

            return aux;
        }

    }
    
}
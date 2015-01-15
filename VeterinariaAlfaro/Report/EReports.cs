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

    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace VeterinariaAlfaro
{
    public partial class Index : System.Web.UI.Page
    {
        Dictionary<string, string> diccionario = new Dictionary<string, string> {  
            {"mision", "<h1>MISION</h1><p>Ofrecer bienestar a las familias de nuestros pacientes a través de la prestación de servicios médicos veterinarios y complementarios de óptima calidad, contribuyendo a la innovación, capacitación y desarrollo profesional del sector en Abancay. Nuestro grupo de trabajo comparte valores y principios éticos de respeto, responsabilidad y compromiso.</p>"},
            {"vision", "<h1>VISION</h1><p>Ser una empresa sólida, líder en la prestación de servicios médicos veterinarios de la mejor calidad y profesionalismo, con énfasis en pequeños animales y proyección a otras especies; contando con una moderna red de establecimientos dotada de la más alta tecnología, un equipo médico y paramédico altamente calificado y un departamento de educación continuada con reconocimiento local y regional. <br/> Nuestro compromiso social es mejorar la calidad de vida de las familias a través del cuidado de la salud de nuestros pacientes y ofrecer bienestar a empleados y accionistas.</p>"},
            {"nosotros", "<h1>NOSOTROS</h1><p>En nuestra clínica siempre estamos mirando hacia el futuro, la medicina animal avanza rápidamente y aparecen nuevas técnicas, nuevos productos y siempre tenemos que adaptarnos a los tiempos. <br/><br/> Nuestro equipo trabaja muy dinámicamente siempre informándonos y buscando la mejor manera para avanzar en el mundo animal,  nuestro objetivo es la salud y el bienestar de los animales, no sólo estamos aquí para curar  a los animales sino para mejorar su salud y hacerles disfrutar de una larga vida. <br/><br/>En nuestra clínica todos los animales son individuales y todos requieren un cuidado personalizado, unos de nuestros objetivos mas grandes es que los animales se sientan cómodos y relajados en nuestra clínica, y por eso utilizamos técnicas y un correcto manejo para que la visita sea lo mas confortable para el animales y su dueño.</p>"},
            {"ubicanos", "<div id=\"list\"><h1>UBICANOS</h1><div class=\"stack rotated\"><img src=\"/media/img/ubicacion.jpg\"/></div><div class=\"stack twisted\"><img src=\"/media/img/fachada.jpg\"/></div> <div style=\"clear:both;\"></div></div><div id=\"zoom\"><img class=\"zoom\" src=\"\"/></div>"}
        };


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                sesion_init();
                if (Request.QueryString["view"] != null)
                    request_view(Request.QueryString["view"].ToString());
                else if (Request.QueryString["filter"] != null)
                {
                    cargarContent(Request.QueryString["filter"].ToString());
                }
                else if (Request.QueryString["id"] != null)
                {
                    cargarContent(Request.QueryString["id"].ToString(), false);
                }
                else
                    cargarContent();
            }
            else
                cargarContent();

        }

        private void cargarContent(string filtro = "",bool ty = true)
        {
            contenido.Controls.Clear();
            if(ty)
                contenido.Controls.Add(Report.EReports.listaMascotas(filtro));
            else
                contenido.Controls.Add(Report.EReports.DetallesMascota(filtro));
        }

        private void sesion_init()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null)
            {
                lkNombre.Text = Session["userName"].ToString();
                LNombre.Attributes.Remove("class");

                lnkLogin.Visible = false;
                LLongin.Attributes.Add("class","ocultar");

                btnCerrar.Visible = true;
                LbtnCerrar.Attributes.Remove("class");

                if ("admin".Equals(Session["type"]))
                {
                    panel.Text = "Mantenimiento";
                    panel.NavigateUrl = "~/panelControl.aspx";
                }
                else
                {
                    panel.Text = "Mis Reservas";
                    panel.NavigateUrl = "~/Reservar.aspx";
                }

                panel.Visible = true;
                LPanel.Attributes.Remove("class");
            }
            else
            {
                lkNombre.Text = "";
                lnkLogin.Visible = true;
                LLongin.Attributes.Remove("class");

                btnCerrar.Visible = false;
                LbtnCerrar.Attributes.Add("class", "ocultar");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["userName"] = null;
            Session["userID"] = null;
            Session["type"] = null;

            btnCerrar.Visible = false;
            LbtnCerrar.Attributes.Add("class", "ocultar");

            lnkLogin.Visible = true;
            LLongin.Attributes.Remove("class");

            lkNombre.Text = "";

            panel.Visible = false;
            LPanel.Attributes.Add("class", "ocultar");
            return;
        }

        private void request_view(String uri)
        {
            contenido.Controls.Clear();
            HtmlGenericControl pnl = new HtmlGenericControl("div");
            pnl.Attributes.Add("id", "text_info");
            pnl.InnerHtml = diccionario[uri];
            contenido.Controls.Add(pnl);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro
{
    public partial class AccionReservar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion_init(); 
            if (Request.QueryString["accion"] != null && Request.QueryString["url"] != null)
                response_view();
            else
            {
                Response.Redirect("~/Index.aspx");
            }
        }

        private void sesion_init()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null)
            {
                /*lkNombre.Text = Session["userName"].ToString();
                LNombre.Attributes.Remove("class");

                lnkLogin.Visible = false;
                LLongin.Attributes.Add("class", "ocultar");

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
                LPanel.Attributes.Remove("class");*/
            }
            else
            {
                /*lkNombre.Text = "";
                lnkLogin.Visible = true;
                LLongin.Attributes.Remove("class");

                btnCerrar.Visible = false;
                LbtnCerrar.Attributes.Add("class", "ocultar");*/
                Response.Redirect("~/Index.aspx");
            }
        }

        private void response_view()
        {
            string type = Request.QueryString["accion"].ToString();
            Controller.Reserva reserva = new Controller.Reserva(Convert.ToInt16(Request.QueryString["url"]));
            string uri = Request.QueryString["uri"] != null ? Request.QueryString["uri"].ToString() : null;

            bool outs = false;
            if (type == "cancel")
            {
                outs = reserva.cambiar_estado("cancelado");
            }
            else if (type == "entregar")
            {
                outs = reserva.cambiar_estado("entregado");
            }
            else if (type == "pendiente")
            {
                outs = reserva.cambiar_estado("pendiente");
            }      
            Response.Redirect( uri != null ? uri : "~/Reservar.aspx");
        }
    }
}
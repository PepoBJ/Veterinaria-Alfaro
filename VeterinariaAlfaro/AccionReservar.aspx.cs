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
            if (Request.QueryString["accion"] != null && Request.QueryString["url"] != null)
                response_view();

            sesion_init();   
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

            if (type == "cancel")
            {
                reserva.cambiar_estado("cancelado");
                Response.Redirect("~/Reservar.aspx");
            }
        }
    }
}
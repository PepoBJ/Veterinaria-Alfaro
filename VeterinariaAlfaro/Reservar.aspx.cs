using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro
{
    public partial class Reservar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["reserva"] != null)
                response_view();
            else
                if(!Page.IsPostBack)
                    cargarContenido();

            sesion_init();        
        }

        private void response_view()
        {
            Controller.Reserva reserva = new Controller.Reserva();
            reserva.Mascota = new Controller.Mascota(Convert.ToInt16(Request.QueryString["reserva"]));
            reserva.Usuario = new Controller.Usuario(Convert.ToInt16(Session["userID"]));
            reserva.Fecha_reserva = DateTime.Now.ToString();
            reserva.Cantidad = 1;
            reserva.Estado = "pendiente";

            Label lbl = new Label();
            lbl.Text = "Seras redirigido, en 5 segundos";
            lbl.ID = "redireccion";
            content_reservas.Controls.Add(lbl);

            if (reserva.newReserva())
                msg.InnerText = "Tu reserva fue realizada con exito";                
            else
                msg.InnerText = "Tu reserva no pudo ser hecha, se envio el error.";
            Response.AddHeader("REFRESH", "5;URL=Index.aspx");
        }

        private void cargarContenido(string patron = "")
        { 
            content_reservas.Controls.Clear();
            Panel pnl = Report.EReports.listaReservas(patron);
            if (pnl.Controls.Count < 1)
            {
                txtBusqueda.Visible = false;
                btnBuscar.Visible = false;
                Label lbl = new Label();
                lbl.Text = "No tienes ninguna reserva";
                lbl.ID = "redireccion";
                content_reservas.Controls.Add(lbl);
            }
            else
                content_reservas.Controls.Add(pnl);
        }
        private void sesion_init()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null)
            {
                lkNombre.Text = Session["userName"].ToString();
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
                LPanel.Attributes.Remove("class");
            }
            else
            {
                lkNombre.Text = "";
                lnkLogin.Visible = true;
                LLongin.Attributes.Remove("class");

                btnCerrar.Visible = false;
                LbtnCerrar.Attributes.Add("class", "ocultar");
                Response.Redirect("~/Index.aspx");
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
            Response.Redirect("~/Index.aspx");
            return;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string quet = txtBusqueda.Text;
            string patron = " AND ( estado like '%" + quet + "%' OR fecha_reserva like '%" + quet + "%' OR fecha_entrega like '%" + quet + "%' OR estado like '%" + quet + "%' )";
            cargarContenido(patron);
        }
    }
}
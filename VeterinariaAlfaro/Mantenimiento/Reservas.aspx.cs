using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro.Mantenimiento
{
    public partial class Reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion_init();
            cargarContenido(true);            
        }
        private void sesion_init()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null && "admin".Equals(Session["type"]))
            {
                lkNombre.Text = Session["userName"].ToString();
                LNombre.Attributes.Remove("class");

                lnkLogin.Visible = false;
                LLongin.Attributes.Add("class", "ocultar");

                btnCerrar.Visible = true;
                LbtnCerrar.Attributes.Remove("class");
                panel.Text = "Mantenimiento";
                panel.NavigateUrl = "~/panelControl.aspx";
                panel.Visible = true;
                LPanel.Attributes.Remove("class");
            }
            else
            {
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
        private void cargarContenido(bool allUser = false, string patron = "", bool busqueda = false)
        {
            content_reservas.Controls.Clear();
            Panel pnl = Report.EReports.listaReservas(patron,allUser);
            if (pnl.Controls.Count < 1)
            {
                Label lbl = new Label();
                lbl.Text = "No tienes ninguna reserva";

                if (busqueda)
                    lbl.Text = "No se encontraron reservas, Intenta otra vez.";

                lbl.ID = "redireccion";
                content_reservas.Controls.Add(lbl);
            }
            else
                content_reservas.Controls.Add(pnl);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string quet = txtBusqueda.Text;
            string patron = " estado like '%" + quet + "%' OR fecha_reserva like '%" + quet +
                "%' OR fecha_entrega like '%" + quet + "%' OR estado like '%" + quet +
                "%' OR tu.apellido like '%" + quet + "%' OR tu.nombre like '%" + quet +
                "%' OR tm.raza like '%" + quet + "%' OR tm.type like '%" + quet + "%' ";
            cargarContenido(true, patron, true);
        }
    }
}
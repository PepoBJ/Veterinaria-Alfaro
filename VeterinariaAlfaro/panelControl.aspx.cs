using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro
{
    public partial class panelControl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion_init();
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

    }
}
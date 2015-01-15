using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro
{
    public partial class EditDatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                cargarDatos();
            sesion_init();
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

        private void cargarDatos()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null)
            {
                Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(Session["userID"]));

                txtNombre.Text = user.Nombre;
                txtApellido.Text = user.Apellido;
                txtCodigo.Text = user.CodigoSeguridad;
                txtTelefono.Text = user.Telefono;
                txtTarjeta.Text = user.Tarjeta;
                txtUsuario.Text = user.Email;

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

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(Session["userID"]));
            if (!user.login(txtUsuario.Text, txtPassword.Text))
            {
                msg.InnerText = "La contraseña|Email Incorrectos";
            }
            else
            {
                user.Nombre = txtNombre.Text;
                user.Apellido =  txtApellido.Text;
                user.CodigoSeguridad = txtCodigo.Text;
                user.Telefono = txtTelefono.Text;
                user.Tarjeta = txtTarjeta.Text;
                user.Email = txtUsuario.Text;

                Session["userName"] = user.Nombre;
                if (user.editUser())
                    msg.InnerText = "Datos Modificados con exito";
                else
                    msg.InnerText = "Datos no fueron modificados!";
                txtPassword.Text = "";
            }
        }
    }
}
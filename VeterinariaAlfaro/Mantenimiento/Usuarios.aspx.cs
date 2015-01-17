using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro.Mantenimiento
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
                cargarListaUsuarios();
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

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = true;
            txtPassword.TextMode = TextBoxMode.SingleLine;
            cargarDatosDDL();
        }
        private void cargarDatosDDL()
        {
            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(ddlUsuarios.SelectedValue));
            txtNombre.Text = user.Nombre;
            txtApellido.Text = user.Apellido;
            txtUsuario.Text = user.Email;
            txtPassword.Text = user.Contrasena;
            txtTelefono.Text = user.Telefono;
            txtTarjeta.Text = user.Tarjeta;
            txtCodigo.Text = user.CodigoSeguridad;
            rblTipo.SelectedValue = user.Tipo;
        }
        private void cargarListaUsuarios()
        {
            ddlUsuarios.DataSource = new Controller.Usuario().listaUsuarios("",true);
            ddlUsuarios.DataTextField = "nombres";
            ddlUsuarios.DataValueField = "id";
            ddlUsuarios.DataBind();
        }

        private void limpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCodigo.Text = "";
            txtPassword.Text = "";
            txtTarjeta.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            rblTipo.SelectedIndex = 0;
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = false;
            txtPassword.TextMode = TextBoxMode.Password;
            limpiarCampos();
        }
        private void llenarDatos(Controller.Usuario user)
        { 
            user.Nombre =txtNombre.Text ; 
            user.Apellido =txtApellido.Text; 
            user.Email =txtUsuario.Text; 
            user.Contrasena =txtPassword.Text; 
            user.Telefono =txtTelefono.Text; 
            user.Tarjeta =txtTarjeta.Text;
            user.CodigoSeguridad = txtCodigo.Text;
            user.Tipo = rblTipo.SelectedValue ;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(ddlUsuarios.SelectedValue));
            llenarDatos(user);
            if (user.newUser())
            {
                cargarListaUsuarios();
                limpiarCampos();
                msg.InnerText = "Se Creo Correctamente el Usuario.";
            }
            else
            {
                msg.InnerText = "Este usuario probablemente ya exista!.";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(ddlUsuarios.SelectedValue));
            llenarDatos(user);
            if (user.editUser())
            {
                cargarListaUsuarios();
                limpiarCampos();
                msg.InnerText = "Se Edito Correctamente el Usuario.";                
            }
            else
            {
                ddlUsuarios.SelectedValue = user.Id.ToString();
                msg.InnerText = "El email ya esta registrado!.";
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Controller.Usuario user = new Controller.Usuario(Convert.ToInt16(ddlUsuarios.SelectedValue));
            if (user.delUser())
            {
                cargarListaUsuarios();
                limpiarCampos();
                msg.InnerText = "Se Elimino Correctamente el Usuario.";
            }
            else
            {
                ddlUsuarios.SelectedValue = user.Id.ToString();
                msg.InnerText = "Este usuario tiene registros, no se puede eliminar.";
            }
        }
    }
}
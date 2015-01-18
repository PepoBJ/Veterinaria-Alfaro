using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeterinariaAlfaro
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion_init();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Controller.Usuario usr = new Controller.Usuario();
            if (usr.login(txtUser.Text, txtPass.Text))
            {
                Session["userName"] = usr.Nombre;
                Session["userID"] = usr.Id;
                Session["type"] = usr.Tipo;

                if (usr.Tipo.Equals("admin"))
                    Response.Redirect("~/panelControl.aspx");

                if (Request.QueryString["url"] != null)
                    redirect_old_page();

                Response.Redirect("~/Index.aspx");
            }
            else
                msg.InnerText = "Usuario o contraseña incorrecta";
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Controller.Usuario user = new Controller.Usuario();
            user.Nombre = txtNombre.Text;
            user.Apellido = txtApellido.Text;
            user.Email = txtUsuario.Text;
            user.Contrasena = txtPassword.Text;
            user.Telefono = txtTelefono.Text;
            user.Tarjeta = txtTarjeta.Text;
            user.CodigoSeguridad = txtCodigo.Text;

            if (user.newUser())
            {
                Session["userName"] = user.Nombre;
                Session["userID"] = user.Id;
                Session["type"] = user.Tipo;
                if (Request.QueryString["url"] != null)
                    redirect_old_page();

                Response.Redirect("~/Index.aspx");
            }
            else
                msg.InnerText = "El E-mail del usuario ya esta registrado!";
        }

        private void redirect_old_page()
        {
            Response.Redirect("~/Index.aspx?id=" + Request.QueryString["url"] + "#linked");
        }

        private void sesion_init()
        {
            if (Session["userID"] != null && Session["userName"] != null && Session["type"] != null)
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                lnkLogin.Visible = true;
            }
        }

        
    }
}
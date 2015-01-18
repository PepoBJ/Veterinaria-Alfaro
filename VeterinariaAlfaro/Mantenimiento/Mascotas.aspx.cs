using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace VeterinariaAlfaro.Mantenimiento
{
    public partial class Mascotas : System.Web.UI.Page
    {
        string carpetaImg;

        protected void Page_Load(object sender, EventArgs e)
        {
            sesion_init();
            if (!Page.IsPostBack)
                cargarListaMascotas();

            carpetaImg = Path.Combine(Request.PhysicalApplicationPath, "media\\img-mascota");

        }

        private void cargarListaMascotas()
        {
            ddlMascotas.DataSource = new Controller.Mascota().listaMascota("","",true);
            ddlMascotas.DataTextField = "mascota";
            ddlMascotas.DataValueField = "id";
            ddlMascotas.DataBind();
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

        private void llenarDatos(Controller.Mascota mas)
        {
            mas.Type = ddlTipo.SelectedValue ;
            mas.Tamanyo = Convert.ToInt16(ddlTam.SelectedValue);
            mas.Raza = txtRaza.Text ;
            mas.Pelo = txtPelo.Text ; 
            mas.Color = txtColor.Text ;
            mas.Cola = txtCola.Text ;
            mas.Precio = Convert.ToDouble(Helpers.HelpTool.convertDoubleToDB(txtPrecio.Text));
            mas.Stock = Convert.ToInt16(txtStock.Text);
            mas.Descripcion = txtDescripcion.Text;
        }
        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (fuFoto.PostedFile.FileName == "" )
            {
                msg.InnerText = "No se selecionaron la imagen!";
            }
            else
            {
                string extensionImg = Path.GetExtension(fuFoto.PostedFile.FileName);

                if (extensionImg.ToLower() != ".jpg")
                {
                    msg.InnerText = "Extension de archivo imagen es invalida!";
                }
                else
                {
                        Controller.Mascota mas = new Controller.Mascota();
                        llenarDatos(mas);

                        if (mas.newMascota())
                        {

                            string carpeta_final_img = Path.Combine(carpetaImg, mas.Id.ToString() + ".jpg");

                            fuFoto.PostedFile.SaveAs(carpeta_final_img);                            
                            msg.InnerText = "Mascota agregada satisfactoriamente!";
                            limpiarCampos();
                            cargarListaMascotas();
                        }
                        else
                        {
                            msg.InnerText = "Mascota imposible de añadir";
                        }
                    
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Controller.Mascota masc = new Controller.Mascota(Convert.ToInt16(ddlMascotas.SelectedValue));
            llenarDatos(masc);

            if (fuFoto.PostedFile.FileName == "")
            {

                if (masc.editMascota())
                {
                    msg.InnerText = "Datos Modificados correctamente";
                    cargarListaMascotas();
                    ddlMascotas.SelectedValue = masc.Id.ToString();
                }
                else
                {
                    msg.InnerText = "Datos imposibles de modificar";
                }

            }
            else
            {

                string extensionImg = "";

                if (fuFoto.PostedFile.FileName != "")
                    extensionImg = Path.GetExtension(fuFoto.PostedFile.FileName);

                try
                {

                    if (fuFoto.PostedFile.FileName != "")
                    {
                        if (extensionImg.ToLower() != ".jpg")
                        {
                            msg.InnerText = "Extension de archivo imagen es invalida!";
                            return;
                        }
                        string carpeta_final_img = Path.Combine(carpetaImg, masc.Foto + ".jpg");
                        fuFoto.PostedFile.SaveAs(carpeta_final_img);
                    }

                    if (!masc.editMascota())
                    {
                        msg.InnerText = "Datos imposibles de modificar D:";
                        return;
                    }
                    msg.InnerText = "Datos Modificados correctamente";
                    limpiarCampos();
                    cargarListaMascotas();
                }
                catch (Exception ex)
                {
                    msg.InnerText = "Error: " + ex.Message;
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Controller.Mascota peli = new Controller.Mascota(Convert.ToInt16(ddlMascotas.SelectedValue));

            if (peli.delMascota())
            {
                msg.InnerText = "Mascota eliminada correctamente";
                limpiarCampos();
                cargarListaMascotas();
            }
            else
            {
                msg.InnerText = "La Mascota no se pudo eliminar D:";
            }

        }


        protected void ddlMascotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDatosDDL();
        }
        private void cargarDatosDDL()
        {
            Controller.Mascota mas = new Controller.Mascota(Convert.ToInt16(ddlMascotas.SelectedValue));
            ddlTipo.SelectedValue = mas.Type;
            ddlTam.SelectedValue = mas.Tamanyo.ToString();
            txtRaza.Text = mas.Raza;
            txtPelo.Text = mas.Pelo;
            txtColor.Text = mas.Color;
            txtCola.Text = mas.Cola.ToLower() == "null" ? "Esta Información es irrelevante para esta mascota" : mas.Cola;
            txtPrecio.Text = Helpers.HelpTool.convertDouble(Convert.ToDouble(mas.Precio.ToString()));
            txtStock.Text = mas.Stock.ToString();
            txtDescripcion.Text = mas.Descripcion;
        }
        private void limpiarCampos()
        {
            ddlTipo.SelectedIndex = 0;
            ddlTam.SelectedIndex = 0;
            txtRaza.Text = "";
            txtPelo.Text = "";
            txtColor.Text = "";
            txtCola.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtDescripcion.Text = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace Gestor_Comercio
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if(!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgMiPerfil.ImageUrl = "~/images/Perfil/" + user.UrlImagenPerfil + "?v=" + DateTime.Now.Ticks.ToString();
                        else                       
                            imgMiPerfil.ImageUrl = "https://img.freepik.com/vector-premium/icono-perfil-usuario-estilo-plano-ilustracion-vector-avatar-miembro-sobre-fondo-aislado-concepto-negocio-signo-permiso-humano_157943-15752.jpg?w=360";
                        
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                UsuarioBusiness negocio = new UsuarioBusiness();
                Usuario user = (Usuario)Session["usuario"];
                if(txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./images/Perfil/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";

                }
                
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                negocio.Actualizar(user);

                Image img = (Image)Master.FindControl("imagenPerfil");
                img.ImageUrl = ("~/images/Perfil/") + user.UrlImagenPerfil;
                imgMiPerfil.ImageUrl = ("~/images/Perfil/") + user.UrlImagenPerfil;

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
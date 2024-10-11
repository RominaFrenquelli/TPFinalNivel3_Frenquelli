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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imagenPerfil.ImageUrl = "https://img.freepik.com/vector-premium/icono-perfil-usuario-estilo-plano-ilustracion-vector-avatar-miembro-sobre-fondo-aislado-concepto-negocio-signo-permiso-humano_157943-15752.jpg?w=360";
            if (!(Page is Login || Page is Default || Page is Registro || Page is DetalleArticulo || Page is Error))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                //else
                //{
                //    Usuario user = (Usuario)Session["usuario"];
                //    if (user.Nombre != null)
                //        lblUsuario.Text = user.Nombre;
                    
                //    if(!string.IsNullOrEmpty(user.UrlImagenPerfil))
                //        imagenPerfil.ImageUrl = "~/images/Perfil/" + user.UrlImagenPerfil;
                //}
            }

            if (Seguridad.SesionActiva(Session["usuario"]))
            {
                Usuario user = (Usuario)Session["usuario"];
                if (!string.IsNullOrEmpty(user.Nombre))
                    lblUsuario.Text = user.Nombre;
                else
                    lblUsuario.Text = "Usuario";

                if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                    imagenPerfil.ImageUrl = "~/images/Perfil/" + user.UrlImagenPerfil;

            }
            

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}
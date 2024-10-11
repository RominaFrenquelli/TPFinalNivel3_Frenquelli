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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
                Usuario usuario = new Usuario();
                UsuarioBusiness negocio = new UsuarioBusiness();
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (Validaciones.ValidarTextoVacio(txtMail) || Validaciones.ValidarTextoVacio(txtPass))
                {
                    Session.Add("error", "Debes completar todos los campos");
                    Response.Redirect("Error.aspx");
                }

                usuario.Email = txtMail.Text;
                usuario.Pass = txtPass.Text;
                if (negocio.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("~/MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "Usuario o pass incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
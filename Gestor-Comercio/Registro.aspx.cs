using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;

namespace Gestor_Comercio
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
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

                UsuarioBusiness negocio = new UsuarioBusiness();

                if (negocio.ExisteEmail(txtMail.Text))
                {
                    Session.Add("error", "El email ya está registrado. Por favor, utiliza otro email.");
                    Response.Redirect("Error.aspx");
                    return;
                }

                Usuario user = new Usuario();
                EmailService emailService = new EmailService();
                user.Email = txtMail.Text;
                user.Pass = txtPass.Text;
                user.Id = negocio.CrearUsuario(user);
                Session.Add("usuario", user);

                emailService.ArmarCorreo(user.Email, "Bienvenido", "Bienvenido a Mi Empresa...");
                emailService.EnviarMail();
                Response.Redirect("Default.aspx", false);
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